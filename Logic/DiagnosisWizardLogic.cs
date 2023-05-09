namespace HRAS_2023.Logic;

using HRAS_2023.Context;
using HRAS_2023.Interfaces;
using HRAS_2023.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

public class DiagnosisWizardLogic : IDiagnosisWizardLogic
{
    private readonly HrasDbContext _context;

    public DiagnosisWizardLogic(HrasDbContext context)
    {
        _context = context;
    }

    public Symptom? getDiagnoses(string diagnoses)
    {
        var firstDiagnosesParam = new SqlParameter("@diagnoses", diagnoses);
        var firstBoolParam = new SqlParameter("@bool1", true);
        var secondDiagnosesParam = new SqlParameter("@diagnoses", null);
        var secondBoolParam = new SqlParameter("@bool2", false);
        Symptom? diagnosesObject = null;/*_context.Symptom.FromSqlRaw("EXEC fsnlgjksdfngjkdn @smfsndf,sn",
            firstDiagnosesParam,
            firstBoolParam,
            secondDiagnosesParam,
            secondBoolParam);*/
       
        Dictionary<string, string>? prevRespDict = createDictionaryOfPrevResponses(diagnosesObject);
        return null;
    }

    private Dictionary<string, string>? createDictionaryOfPrevResponses(Symptom? diagnosesObj)
    {
        return null;
    }
    /*
    public static int GetSymptomFrequency()
    {
        int frequency = 0;
        string connectionString = "Data Source=A;Initial Catalog=HRASDatabase;Integrated Security=True";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("GetSymptomFrequency", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        throw new Exception("There is no symptom exists.");
                    }
                    if (reader.Read())
                    {
                        frequency = reader.GetInt32(0);
                    }
                    reader.Close();
                }
            }
        }
        return frequency;
    }

    public static string FindPatientSSNBySymptom()
    {
        string SSN = "";
        string connectionString = "Data Source=A;Initial Catalog=HRASDatabase;Integrated Security=True";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("FindPatientSSNBySymptom", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        throw new Exception("There is no SSN exists.");
                    }
                    if (reader.Read())
                    {
                        SSN = reader.GetString(0);
                    }
                    reader.Close();
                }
            }
        }
        return SSN;
    }
    */

}