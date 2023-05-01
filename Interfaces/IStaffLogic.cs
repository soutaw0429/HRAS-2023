namespace HRAS.Interfaces;

using HRAS.Models;

public interface IStaffLogic
{
    Staff? findUserByCredentials(string username);
}
