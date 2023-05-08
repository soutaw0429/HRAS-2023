namespace HRAS_2023.Interfaces;

using HRAS_2023.Models;

public interface ISecurityService
{
    Staff? authenticateUser(string username, string password);
}