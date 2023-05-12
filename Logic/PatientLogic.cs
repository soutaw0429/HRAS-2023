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
        SearchViewModel? searchViewModel = new SearchViewModel();
        var searchParam = new SqlParameter("@SSN", ssn);
        // SearchViewModel? data = _context.SearchViewModel.FromSqlRaw("EXEC GetPatientWithAddress @SSN", searchParam).AsEnumerable().First();
		Patient patient = _context.Patient.FromSqlRaw("EXEC GetPatientBySSN @SSN", searchParam).AsEnumerable().First();
		Home home = _context.Home.FromSqlRaw("EXEC GetHomeAddressBySSN @SSN", searchParam).AsEnumerable().First();
        searchViewModel.Patient = patient;
        searchViewModel.Home = home;
		Console.WriteLine(home);
        return searchViewModel;
    }

    public SearchViewModel? getPatientFromDbWithLastname(string lastname)
    {
		SearchViewModel searchViewModel = new SearchViewModel();
		var searchParam = new SqlParameter("@LastName", lastname);
		List<Patient> patient = _context.Patient.FromSqlRaw("EXEC GetPatientsByLastName @LastName", searchParam).AsEnumerable().ToList();
		List<Home> home = _context.Home.FromSqlRaw("EXEC GetHomesByLastName @LastName", searchParam).AsEnumerable().ToList();
		searchViewModel.Patients = patient;
		searchViewModel.Homes = home;
        return searchViewModel;
		//return _context.SearchViewModel.FromSqlRaw("EXEC GetPatientWithAddress @LastName", searchParam).AsEnumerable().ToList();
    }

    public SearchViewModel? getPatientFromDbWithFirstname(string firstname)
    {
		SearchViewModel searchViewModel = new SearchViewModel();
		var searchParam = new SqlParameter("@FirstName", firstname);
		List<Patient> patient = _context.Patient.FromSqlRaw("EXEC GetPatientsByFirstName @FirstName", searchParam).AsEnumerable().ToList();
		List<Home> home = _context.Home.FromSqlRaw("EXEC GetHomesByFirstName @FirstName", searchParam).AsEnumerable().ToList();
		searchViewModel.Patients = patient;
		searchViewModel.Homes = home;
		return searchViewModel;
        //return _context.SearchViewModel.FromSqlRaw("EXEC GetPatientWithAddress @FirstName", searchParam).AsEnumerable().ToList();
    }
    public SearchViewModel? getPatientFromDbWithRoom(string room)
    {
		SearchViewModel searchViewModel = new SearchViewModel();
		var searchParam = new SqlParameter("@number", room);
		List<Patient> patient = _context.Patient.FromSqlRaw("EXEC GetPatientsByRoom @room_number", searchParam).AsEnumerable().ToList();
		List<Home> home = _context.Home.FromSqlRaw("EXEC GetHomesByRoomNumber @RoomNumber", searchParam).AsEnumerable().ToList();
		searchViewModel.Patients = patient;
		searchViewModel.Homes = home;
		return searchViewModel;
        //return _context.SearchViewModel.FromSqlRaw("EXEC GetPatientWithAddress @number", searchParam).AsEnumerable().ToList();
    }
}
