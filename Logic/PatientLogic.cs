namespace HRAS_2023.Logic;

using HRAS_2023.Context;
using HRAS_2023.Interfaces;
using HRAS_2023.Models;
using HRAS_2023.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

public class PatientLogic : IPatientLogic
{
    private readonly HrasDbContext _context;
    
    public PatientLogic(HrasDbContext context)
    {
        _context = context;
    }
    public SearchViewModel? getPatientFromDbWithSSN(string ssn)
    {
        var searchParam = new SqlParameter("@SSN", ssn);
        return _context.SearchViewModel.FromSqlRaw("EXEC GetPatientWithAddress @SSN", searchParam).AsEnumerable().FirstOrDefault();
        
        // return null;
    }
    public List<SearchViewModel>? getPatientFromDbWithLastname(string lastname)
    {
        var searchParam = new SqlParameter("@LastName", lastname);
        return _context.SearchViewModel.FromSqlRaw("EXEC GetPatientWithAddress @LastName", searchParam).AsEnumerable().ToList();

        // return null;
    }
    public List<SearchViewModel>? getPatientFromDbWithFirstname(string firstname)
    {
        var searchParam = new SqlParameter("@FirstName", firstname);
        return _context.SearchViewModel.FromSqlRaw("EXEC GetPatientWithAddress @FirstName", searchParam).AsEnumerable().ToList();

        // return null;
    }
    public List<SearchViewModel>? getPatientFromDbWithRoom(string room)
    {
        var searchParam = new SqlParameter("@number", room);
        return _context.SearchViewModel.FromSqlRaw("EXEC GetPatientWithAddress @number", searchParam).AsEnumerable().ToList();

        // return null;
    }
}
