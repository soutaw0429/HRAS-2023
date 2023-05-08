namespace HRAS_2023.Controllers;

using Microsoft.AspNetCore.Mvc;
using HRAS_2023.Interfaces;
using HRAS_2023.ViewModels;
using Microsoft.IdentityModel.Tokens;

public class SearchController : Controller
{
    private readonly ISearchService _search;

    public SearchController(ISearchService searchService)
    {
        _search = searchService;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Details(IFormCollection collection) 
    {
        if (!collection["ssn"].IsNullOrEmpty()) {
            SearchViewModel? patientResult = _search.getPatientFromSearch(collection?["ssn"]!);
            return (patientResult == null) ? View("Index") : View("Index", patientResult);
        }

        List<SearchViewModel>? patientResults = _search.getPatientListFromSearch(collection);
        return (patientResults == null) ? View("Index") : View("Index", patientResults);
    }
}
