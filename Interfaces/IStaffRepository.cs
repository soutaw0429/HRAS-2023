namespace HRAS.Interfaces;

using HRAS.Models;

public interface IStaffRepository
{
    Staff? findUserByCredentials(string username);
}