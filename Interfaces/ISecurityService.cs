namespace HRAS.Interfaces;

using HRAS.Models;

public interface ISecurityService
{
    Staff? authenticateUser(string username, string password);
}