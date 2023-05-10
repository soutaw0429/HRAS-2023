namespace HRAS_2023.Interfaces;

using HRAS_2023.Models;
using HRAS_2023.ViewModels;

public interface IPatientLogic
{
    SearchViewModel? getPatientFromDbWithSSN(string ssn);
    List<SearchViewModel>? getPatientFromDbWithLastname(string lastname);
    List<SearchViewModel>? getPatientFromDbWithFirstname(string firstname);
    List<SearchViewModel>? getPatientFromDbWithRoom(string room);
}
