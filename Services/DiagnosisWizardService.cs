using System;

public class DiagnosisWizardService
{

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


}
