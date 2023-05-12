namespace HRAS_2023.Interfaces;

using HRAS_2023.Models;
using HRAS_2023.ViewModels;

public interface ISearchService
{
    SearchViewModel? getPatientFromSearch(string search);

    SearchViewModel? getPatientListFromSearch(IFormCollection search);
}
