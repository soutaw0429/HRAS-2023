namespace HRAS.Logic;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
        // return _context.Staff
        //     .SingleOrDefault(staff => staff.userName!.Equals(username));

        /**
        * If you have any issues comment out these lines below and uncomment return null
        * To minimise issues I HIGHLY recommend you setup the DB on your local dev machines. This will be setup if you are using the Lab Machines
        * If you need to make changes to this file you MUST run the following command FIRST: git update-index --assume-unchanged Logic/StaffLogic.cs
        * this makes github think the file has not been changed and so the file will not show any changes.
        * We need this code to be readily available so Rosenberg can connect to the db.
        */
        var userIdParam = new SqlParameter("@UserName", username);
        return _context.Staff.FromSqlRaw("EXEC GetPasswordByUserName @UserName", username).AsEnumerable().FirstOrDefault();

        // return null;
    }
}