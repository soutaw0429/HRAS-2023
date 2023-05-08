namespace HRAS_2023.Interfaces;

using HRAS_2023.Models;

public interface IStaffLogic
{
    Staff? findUserByCredentials(string username);
}
