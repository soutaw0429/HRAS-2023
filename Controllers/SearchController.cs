namespace HRAS_2023.Controllers;

using Microsoft.AspNetCore.Mvc;
using HRAS_2023.Interfaces;
using HRAS_2023.ViewModels;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

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
        return View();
    }

    //[HttpPost]
    //[ValidateAntiForgeryToken]
    public IActionResult Details(IFormCollection collection)
    {
        SearchViewModel? patientResult = new SearchViewModel();
        string ssn = "000005578";
        if (!collection["ssn"].IsNullOrEmpty()) {
            patientResult = _search.getPatientFromSearch(ssn);//collection?["ssn"]!);
            _logger.LogInformation(patientResult?.Patient?.FirstName);
            _logger.LogInformation(patientResult?.Patient?.LastName);
            _logger.LogInformation(Convert.ToString(patientResult?.Patient?.SSN));
            _logger.LogInformation(patientResult?.Home?.StreetAddress_Line_1);
            _logger.LogInformation(patientResult?.Home?.ZIP);
            return (patientResult == null) ? View("Index") : View("Index", patientResult);
        }
        List<SearchViewModel>? patientResults = _search.getPatientListFromSearch(collection);
        return (patientResults == null) ? View("Index") : View("Index", patientResults);
    }
}
