namespace HRAS_2023.Interfaces;
using HRAS_2023.Models;

public interface IDiagnosisWizardService
{
    Symptom? GetDiagnoses(string diagnosesId);
}