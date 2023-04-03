namespace HRAS.Services;

using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using HRAS.Interfaces;
using HRAS.Models;

public class SecurityService : ISecurityService
{
    private readonly int _iterations = 300000;
    private readonly IStaffRepository _staffRepository;

    public SecurityService(IStaffRepository staffRepository)
    {
        _staffRepository = staffRepository;
    }

    public Staff? authenticateUser(string username, string password)
    {
        System.Diagnostics.Debug.WriteLine("Plain password is: " + password);

        string passwordHash = Convert.ToBase64String(hashPassword(password));

        System.Diagnostics.Debug.WriteLine("Hashed password is: " + passwordHash);

        Staff? user = validateUser(username);
        if (user == null) {
            System.Diagnostics.Debug.WriteLine("Validation be very broken");
            return null;
        }

        bool passResult = verifyPassword(password, user.password!);

        if (!passResult) {
            System.Diagnostics.Debug.WriteLine("Password not verified");
            return null;
        }
        return user;
    }

    private Staff? validateUser(string username)
    {
        Staff? staff = _staffRepository.findUserByCredentials(username);
        if (staff == null) return null;
        return staff;
    }

    private byte[] hashPassword(string password)
    {
        return hashPassword(
            password: password!,
            saltSize: 128/8,
            prf: KeyDerivationPrf.HMACSHA512,
            iterationCount: _iterations,
            numBytesRequested: 256/8);
    }

    private byte[] hashPassword(string password, int saltSize, KeyDerivationPrf prf, int iterationCount, int numBytesRequested)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(saltSize);
        byte[] subkey = KeyDerivation.Pbkdf2(password, salt, prf, iterationCount, numBytesRequested);

        var outputBytes = new byte[13 + salt.Length + subkey.Length];
        outputBytes[0] = 0x01;
        WriteNetworkByteOrder(outputBytes, 1, (uint)prf);
        WriteNetworkByteOrder(outputBytes, 5, (uint)iterationCount);
        WriteNetworkByteOrder(outputBytes, 9, (uint)saltSize);
        Buffer.BlockCopy(salt, 0, outputBytes, 13, salt.Length);
        Buffer.BlockCopy(subkey, 0, outputBytes, 13 + saltSize, subkey.Length);
        return outputBytes;
    }

    private bool verifyPassword(string password, string hashPass)
    {
        byte[] decodedHashPass = Convert.FromBase64String(hashPass);

        if (decodedHashPass.Length == 0) return false;
        
        return verifyHashedPass(decodedHashPass, password, out int iterCount, out KeyDerivationPrf prf) ? true : false ;
    }

    private static bool verifyHashedPass(byte[] decodedHashPass, string password, out int iterCount, out KeyDerivationPrf prf)
    {
        iterCount = default(int);
        prf = default(KeyDerivationPrf);

        try {
            prf = (KeyDerivationPrf)ReadNetworkByteOrder(decodedHashPass, 1);
            iterCount = (int)ReadNetworkByteOrder(decodedHashPass, 5);
            int saltLength = (int)ReadNetworkByteOrder(decodedHashPass, 9);

            if (saltLength < 128 / 8) return false;

            byte[] salt = new byte[saltLength];
            Buffer.BlockCopy(decodedHashPass, 13, salt, 0, salt.Length);

            int subKeyLength = decodedHashPass.Length - 13 - salt.Length;
            if (subKeyLength < 128 / 8) return false;

            byte[] expectedSubKey = new byte[subKeyLength];
            Buffer.BlockCopy(decodedHashPass, 13 + salt.Length, expectedSubKey, 0, expectedSubKey.Length);

            byte[] actualSubkey = KeyDerivation.Pbkdf2(password, salt, prf, iterCount, subKeyLength);
            bool result = CryptographicOperations.FixedTimeEquals(actualSubkey, expectedSubKey);
            return result;
        } catch {
            return false;
        }
    }

    private static uint ReadNetworkByteOrder(byte[] buffer, int offset)
    {
        return ((uint)(buffer[offset + 0]) << 24)
            | ((uint)(buffer[offset + 1]) << 16)
            | ((uint)(buffer[offset + 2]) << 8)
            | ((uint)(buffer[offset + 3]));
    }

    private static void WriteNetworkByteOrder(byte[] buffer, int offset, uint value)
    {
        buffer[offset + 0] = (byte)(value >> 24);
        buffer[offset + 1] = (byte)(value >> 16);
        buffer[offset + 2] = (byte)(value >> 8);
        buffer[offset + 3] = (byte)(value >> 0);
    }

    public void logout(HttpContext context) {context.Response.Redirect($"/");}
}