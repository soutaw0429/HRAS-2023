namespace HRAS_2023.Services;

using HRAS_2023.Interfaces;
using HRAS_2023.Models;
using HRAS_2023.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;

public class SearchService : ISearchService
{
    private readonly IPatientLogic _patient;
    public SearchService(IPatientLogic patient) 
    {
        _patient = patient;
    }

    public SearchViewModel? getPatientFromSearch(string ssn)
    {
        if (sanatiseInput(ssn) == null) return null;
        return _patient.getPatientFromDbWithSSN(ssn);
        
    }

    public SearchViewModel? getPatientListFromSearch(IFormCollection search)
    {
        string room = search?["StaysIn.room_number"]!;
        if (!string.IsNullOrWhiteSpace(room)) {
            if (sanatiseInput(room) == null) return null;
            return _patient.getPatientFromDbWithRoom(room);
        }
        
        string lastname = search?["Patient.LastName"]!;
		if (!string.IsNullOrWhiteSpace(lastname)) {
			if (sanatiseInput(lastname) == null) return null;
            return _patient.getPatientFromDbWithLastname(lastname);
        }

		string firstname = search?["Patient.FirstName"]!;
		if (!string.IsNullOrWhiteSpace(firstname)) {
            if (sanatiseInput(firstname) == null) return null;
            return _patient.getPatientFromDbWithFirstname(firstname);
        }
        return null;
    }

    private static string? sanatiseInput(string uncleanStr)
    {
        return Regex.Replace(uncleanStr, @"[\r\n\x00\x1a\\'""]", @"");
    }
}
