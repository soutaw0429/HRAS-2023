namespace HRAS_2023.Controllers;

using Microsoft.AspNetCore.Mvc;
using HRAS_2023.Interfaces;
using HRAS_2023.ViewModels;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualBasic;

//[Authorize(Policy = "Admin,Junior,Senior")]
//[Authorize(Policy = "Admin")]
public class SearchController : Controller
{
    private readonly ISearchService _search;
    private readonly ILogger<AuthController> _logger;

    public SearchController(ISearchService searchService, ILogger<AuthController> logger)
    {
        _search = searchService;
        _logger = logger;
    }
    public IActionResult Index()
    {
        SearchViewModel searchViewModel = new SearchViewModel();
        return View("Index", searchViewModel);
    }

    //[HttpPost]
    //[ValidateAntiForgeryToken]
    public IActionResult Details(IFormCollection collection)
    {
        string ssn = collection?["Patient.SSN"]!;
        if (!string.IsNullOrWhiteSpace(ssn)) {
            SearchViewModel? patientResult = _search.getPatientFromSearch(collection?["Patient.SSN"]!);
            return (patientResult == null) ? View("Index") : View("Index", patientResult);
        }
        
        SearchViewModel? patientResults = _search.getPatientListFromSearch(collection!);
        return (patientResults == null) ? View("Index") : View("Index", patientResults);
    }
}
