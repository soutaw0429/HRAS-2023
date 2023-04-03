namespace HRAS.Repository;

using System.Linq;
using HRAS.Context;
using HRAS.Interfaces;
using HRAS.Models;

public class StaffRepository : IStaffRepository
{
    private readonly AuthDbContext _context;

    public StaffRepository(AuthDbContext context)
    {
        _context = context;
    } 

    public Staff? findUserByCredentials(string username)
    {
        return _context.Staff
            .SingleOrDefault(staff => staff.userName!.Equals(username));
    }
}