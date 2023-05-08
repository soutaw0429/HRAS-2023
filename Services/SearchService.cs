namespace HRAS_2023.Services;

using HRAS_2023.Interfaces;
using HRAS_2023.Models;
using HRAS_2023.ViewModels;
using Microsoft.IdentityModel.Tokens;
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

    public List<SearchViewModel>? getPatientListFromSearch(IFormCollection search)
    {
        if (!search["room"].IsNullOrEmpty())
        {
            if (sanatiseInput(search?["room"]!) == null) return null;
            return _patient.getPatientFromDbWithRoom(search?["room"]!);
        }
        else if (!search["lastname"].IsNullOrEmpty())
        {
            if (sanatiseInput(search?["lastname"]!) == null) return null;
            return _patient.getPatientFromDbWithLastname(search?["lastname"]!);
        }
        else if (!search["firstname"].IsNullOrEmpty())
        {
            if (sanatiseInput(search?["firstname"]!) == null) return null;
            return _patient.getPatientFromDbWithFirstname(search?["firstname"]!);
        }
        return null;
    }

    private static string? sanatiseInput(string uncleanStr)
    {
        return Regex.Replace(uncleanStr, @"[\r\n\x00\x1a\\'""]", @"");
    }
}
