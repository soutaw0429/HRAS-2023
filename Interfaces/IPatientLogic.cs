namespace HRAS_2023.Interfaces;

using HRAS_2023.Models;
using HRAS_2023.ViewModels;

public interface IPatientLogic
{
    SearchViewModel? getPatientFromDbWithSSN(string ssn);
    SearchViewModel? getPatientFromDbWithLastname(string lastname);
    SearchViewModel? getPatientFromDbWithFirstname(string firstname);
    SearchViewModel? getPatientFromDbWithRoom(string room);
}
