namespace HRAS.Logic;

using System.Data.SqlClient;
using System.Linq;
using HRAS.Context;
using HRAS.Interfaces;
using HRAS.Models;

public class StaffLogic : IStaffLogic
{
    private readonly AuthDbContext _context;

    public StaffLogic(AuthDbContext context)
    {
        _context = context;
    } 

    public Staff? findUserByCredentials(string username)
    {
        // These methods need to be kept for my local use. Do not remove these lines
        return _context.Staff
            .SingleOrDefault(staff => staff.userName!.Equals(username));

        // var userIdParam = new SqlParameter("@UserName", username);
        // return Staff.FromSqlRaw("EXEC GetPasswordByUserName @UserName", username).FirstOrDefault();
    }
}