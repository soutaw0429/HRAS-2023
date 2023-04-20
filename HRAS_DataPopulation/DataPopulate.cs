using System.Data;
using Microsoft.Data.SqlClient;


class DataPopulate
{
    public const string connectionString = "Data Source=desktop-rmqlafu\\sqlexpress;Initial Catalog=TestDB;Integrated Security=True; Trusted_Connection=True;TrustServerCertificate=True;";
    
    private static void Main(string[] args)
    {
        Console.WriteLine("Populating the Staff Table with limited rows for testing purposes");
        //ReadFromMedicalRecordsTxt();
        //ReadFromInventoryTxt();
        //ReadFromRoomsTxt();
        //ReadFromUsersTxt();
        WriteIntoStaffTable();
        //WriteIntoInventoryTable();
        //WriteIntoVisitHistory();
        //WriteIntoPatient();
        //WriteIntoBuilding();
        //WriteIntoRoom();
        //WriteIntoSymptom();
    }

    public static string[] ReadFromTextFile(string fileName)
    {
        string currentDirectory = Directory.GetCurrentDirectory(); //gets the current default working directory of VS
        currentDirectory = Directory.GetParent(currentDirectory).FullName;
        currentDirectory = Directory.GetParent(currentDirectory).FullName;
        currentDirectory = Directory.GetParent(currentDirectory).FullName;
        string filePath = currentDirectory + "\\DataImportFiles\\"+fileName; //specifies where the target file is located
        string[] lines = File.ReadAllLines(filePath);
        return lines;
    }

    public static void ReadFromMedicalRecordsTxt()
    {
        /*using (StreamReader reader = new StreamReader("C:\\Users\\Hayk Arzumanyan\\Desktop\\DataFiles2\\MedicalRecords.txt"))
        {
            reader.ReadLine();
        }*/

        string[] lines = File.ReadAllLines("C:\\Users\\Hayk Arzumanyan\\Desktop\\DataFiles\\MedicalRecords.txt");
        int x = 0;
        foreach (string line in lines)
        {
            x++;
            Console.WriteLine("\n");
            Console.WriteLine("Last name: " + line.Substring(0, 50) + ".");
            Console.WriteLine("First name: " + line.Substring(50, 14) + ".");
            Console.WriteLine("Middle Initial: " + line.Substring(75, 1));
            Console.WriteLine("Sex: " + line.Substring(76, 1));
            Console.WriteLine("SSN: " + line.Substring(77, 9));
            Console.WriteLine("Birth Date: " + line.Substring(86, 2) + "/" + line.Substring(88, 2) + "/" + line.Substring(90, 4));
            Console.WriteLine("Entry Date Time: " + line.Substring(94, 2) + "/" + line.Substring(96, 2) + "/" + line.Substring(98, 4) + "-" + line.Substring(102, 2) + ":" + line.Substring(104, 2));
            Console.WriteLine("Exit Date Time: " + line.Substring(106, 2) + "/" + line.Substring(108, 2) + "/" + line.Substring(110, 4) + "-" + line.Substring(114, 2) + ":" + line.Substring(116, 2));
            Console.WriteLine("Attending Physician: " + line.Substring(118, 5));
            Console.WriteLine("Room No. : " + line.Substring(123, 9));
            Console.WriteLine("Room Building: " + line.Substring(132, 30));
            Console.WriteLine("Symptom 1: " + line.Substring(162, 25).Trim());
            Console.WriteLine("Symptom 2: " + line.Substring(187, 25).Trim());
            Console.WriteLine("Symptom 3: " + line.Substring(212, 25).Trim());
            Console.WriteLine("Symptom 4: " + line.Substring(237, 25).Trim());
            Console.WriteLine("Symptom 5: " + line.Substring(262, 25).Trim());
            Console.WriteLine("Symptom 6: " + line.Substring(287, 25).Trim());
            Console.WriteLine("Diagnosis: " + line.Substring(312, 75).Trim());
            Console.WriteLine("Notes: " + line.Substring(387, 100).Trim());
            Console.WriteLine("Insurer: " + line.Substring(487, 5));
            Console.WriteLine("Address Line 1: " + line.Substring(492, 35));
            Console.WriteLine("Address Line 2: " + line.Substring(527, 35));
            Console.WriteLine("Address City: " + line.Substring(562, 25));
            Console.WriteLine("Address State: " + line.Substring(587, 2));
            Console.WriteLine("Address Zip: " + line.Substring(589, 5));
            Console.WriteLine("DNR Status: " + line.Substring(594, 1));
            Console.WriteLine("Organ Donor: " + line.Substring(595, 1));


            if (x == 5)
            {
                break;
            }
        }
    }

    public static void ReadFromInventoryTxt()
    {
        string[] lines = File.ReadAllLines("C:\\Users\\Hayk Arzumanyan\\Desktop\\DataFiles\\Inventory.txt");

        foreach (string line in lines)
        {
            Console.WriteLine("\nStock ID: " + line.Substring(0, 5));
            Console.WriteLine("Quantity: " + line.Substring(5, 5));
            Console.WriteLine("Description: " + line.Substring(10, 35));
            Console.WriteLine("Size: " + line.Substring(45, 3));
            string price = line.Substring(48, 6) + "." + line.Substring(54, 2).Trim();
            Console.WriteLine("Price: $" + line.Substring(48, 6) + "." + line.Substring(54, 2));
        }
    }

    public static void ReadFromRoomsTxt()
    {
        string[] lines = File.ReadAllLines("C:\\Users\\Hayk Arzumanyan\\Desktop\\DataFiles2\\Rooms.txt");
        int x = 0;
        foreach (string line in lines)
        {
            Console.WriteLine("\nLine length: " + line.Length);
            Console.WriteLine("\nRoom No.: " + line.Substring(0, 9));
            Console.WriteLine("Hourly Rate: " + line.Substring(9, 3).Trim() + "." + line.Substring(13, 2));
            Console.WriteLine("Effective Date Time: " + line.Substring(14, 2) + "/" + line.Substring(16, 2) + "/" + line.Substring(18, 4) + "-" + line.Substring(22, 2) + ":" + line.Substring(24, 2));
            Console.WriteLine("Wing: " + line.Substring(26, 24));
            Console.WriteLine("Floor: " + line.Substring(50, 4));
            Console.WriteLine("Building: " + line.Substring(54, 30));
            Console.WriteLine("Designation: " + line.Substring(84, 2));
            Console.WriteLine("Max Occupancy: " + line.Substring(86, 2)); //based on the given data files, should be .Substring(86,2)
            x++;
            if (x == 5)
            {
                break;
            }
        }
    }

    public static void ReadFromUsersTxt()
    {
        string[] lines = File.ReadAllLines("C:\\Users\\Hayk Arzumanyan\\Desktop\\DataFiles\\Users.txt");
        int x = 0;
        int rowsAffected = 0;
        string connectionString = "desktop-rmqlafu\\sqlexpress.TestDB.dbo";
        connectionString = "Data Source=desktop-rmqlafu\\sqlexpress;Initial Catalog=TestDB;Integrated Security=True; Trusted_Connection=True;TrustServerCertificate=True;";

        //SqlConnection sqlConnection = new SqlConnection(connectionString);

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string key = "";
            int rowCount = 0;
            connection.Open();
            string insertSql = "INSERT INTO Staff (FirstName, LastName, UserName, Password, UserType, Position) VALUES (@p1, @p2, @p3, @p4, @p5, @p6)";
            string selectSql = "SELECT COUNT(*) FROM Staff WHERE UserName = @key";

            foreach (string line in lines)
            {
                using (SqlCommand selectCommand = new SqlCommand(selectSql, connection))
                {
                    using (SqlCommand insertCommand = new SqlCommand(insertSql, connection))
                    {

                        /*Console.WriteLine("\nUserName: " + line.Substring(0, 25));
                        Console.WriteLine("Password: " + line.Substring(25, 50));
                        Console.WriteLine("User Type: " + line.Substring(75, 1));
                        Console.WriteLine("Last Name: " + line.Substring(76, 30));
                        Console.WriteLine("First Name: " + line.Substring(106, 20));*/

                        selectCommand.Parameters.AddWithValue("@key", line.Substring(0, 25).Trim());
                        rowCount = (int)selectCommand.ExecuteScalar();
                        if (rowCount > 0)
                        {
                            Console.WriteLine(line.Substring(0, 25).Trim() + " username exists in db");
                            rowCount = 0;
                        }
                        else
                        {
                            insertCommand.Parameters.AddWithValue("@p1", line.Substring(106, 20).Trim());
                            insertCommand.Parameters.AddWithValue("@p2", line.Substring(76, 30).Trim());
                            insertCommand.Parameters.AddWithValue("@p3", line.Substring(0, 25).Trim());
                            insertCommand.Parameters.AddWithValue("@p4", line.Substring(25, 50).Trim());
                            insertCommand.Parameters.AddWithValue("@p5", line.Substring(75, 1).Trim());
                            insertCommand.Parameters.AddWithValue("@p6", 'J');
                            rowsAffected += insertCommand.ExecuteNonQuery();

                        }

                        /*  x++;
                          if (x == 20)
                          {
                              break;
                          }*/
                    }

                }
            }
            // output the number of rows affected
            Console.WriteLine($"\n{rowsAffected} rows inserted.");
            connection.Close();
        }
    }

    public static void WriteIntoStaffTable()
    {
        string[] lines = ReadFromTextFile("User.txt");
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            int rowCount = 0;
            int rowsAffected = 0;
            connection.Open();
            string insertSql = "INSERT INTO Staff (FirstName, LastName, UserName, Password, UserType, Position) VALUES (@p1, @p2, @p3, @p4, @p5, @p6)";
            string selectSql = "SELECT COUNT(*) FROM Staff WHERE UserName = @key";

            string userName, password, userType, lastName, firstName;
            foreach (string line in lines)
            {
                using (SqlCommand selectCommand = new SqlCommand(selectSql, connection))
                {
                    using (SqlCommand insertCommand = new SqlCommand(insertSql, connection))
                    {
                        userName = line.Substring(0, 25).Trim();
                        selectCommand.Parameters.AddWithValue("@key", userName);
                        rowCount = (int)selectCommand.ExecuteScalar();
                        if (rowCount > 0)
                        {
                            rowCount = 0;
                        }
                        else
                        {
                            password = line.Substring(25, 50).Trim();
                            userType = line.Substring(75, 1).Trim();
                            lastName = line.Substring(76, 30).Trim();
                            firstName = line.Substring(106, 20).Trim();

                            insertCommand.Parameters.AddWithValue("@p1", firstName);
                            insertCommand.Parameters.AddWithValue("@p2", lastName);
                            insertCommand.Parameters.AddWithValue("@p3", userName);
                            insertCommand.Parameters.AddWithValue("@p4", password);
                            insertCommand.Parameters.AddWithValue("@p5", userType);
                            insertCommand.Parameters.AddWithValue("@p6", 'J');//the position is not received from the data files
                            rowsAffected += insertCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
            // output the number of rows affected
            Console.WriteLine($"\n{rowsAffected} rows inserted.");
            connection.Close();
        }
    }

    public static void WriteIntoInventoryTable()
    {
        string[] lines = ReadFromTextFile("Inventory.txt");
        string stockID, quantity, description, size, price;
        int rowsAffected = 0;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            int rowCount = 0;
            connection.Open();
            string insertSql = "INSERT INTO Inventory (stock_id, quantity, description, size, price) VALUES (@p1, @p2, @p3, @p4, @p5)";
            string selectSql = "SELECT COUNT(*) FROM Inventory WHERE stock_id = @key";

            foreach (string line in lines)
            {
                using (SqlCommand selectCommand = new SqlCommand(selectSql, connection))
                {
                    using (SqlCommand insertCommand = new SqlCommand(insertSql, connection))
                    {
                        stockID = line.Substring(0, 5).Trim();
                        selectCommand.Parameters.AddWithValue("@key", stockID);
                        rowCount = (int)selectCommand.ExecuteScalar();
                        if (rowCount > 0)
                        {
                            rowCount = 0;
                        }
                        else
                        {
                            quantity = line.Substring(5, 5).Trim();
                            description = line.Substring(10, 35).Trim();
                            size = line.Substring(45, 3).Trim();
                            price = line.Substring(48, 6) + "." + line.Substring(54, 2);

                            insertCommand.Parameters.AddWithValue("@p1", stockID);
                            insertCommand.Parameters.AddWithValue("@p2", quantity);
                            insertCommand.Parameters.AddWithValue("@p3", description);
                            insertCommand.Parameters.AddWithValue("@p4", size);
                            insertCommand.Parameters.AddWithValue("@p5", price);
                            rowsAffected += insertCommand.ExecuteNonQuery();
                        }
                    }

                }
            }
            Console.WriteLine($"\n{rowsAffected} rows inserted.");
            connection.Close();
        }
    }

    public static void WriteIntoVisitHistory()
    {
        string[] lines = ReadFromTextFile("MedicalRecords.txt");
        string patientSSN, diagnosis, notes, checkInDateTime, checkOutDateTime;
        int rowsAffected = 0;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            int rowCount = 0;
            connection.Open();
            string insertSql = "INSERT INTO VisitHistory (patient_SSN, CheckInDateTime, CheckOutDateTime, Diagnosis, Notes) VALUES (@p1, @p2, @p3, @p4, @p5)";
            string selectSql = "SELECT COUNT(*) FROM VisitHistory WHERE patient_SSN = @key";

            foreach (string line in lines)
            {
                using (SqlCommand selectCommand = new SqlCommand(selectSql, connection))
                {
                    using (SqlCommand insertCommand = new SqlCommand(insertSql, connection))
                    {
                        patientSSN = line.Substring(77, 9).Trim();
                        selectCommand.Parameters.AddWithValue("@key", patientSSN);
                        rowCount = (int)selectCommand.ExecuteScalar();
                        if (rowCount > 0)
                        {
                            rowCount = 0;
                        }
                        else
                        {
                            checkInDateTime = line.Substring(98, 4) + "-" + line.Substring(94, 2) + "-" + line.Substring(96, 2) + " "
                                                                        + line.Substring(102, 2) + ":" + line.Substring(104, 2) + ":00";
                            checkOutDateTime = line.Substring(110, 4) + "-" + line.Substring(106, 2) + "-" + line.Substring(108, 2) + " "
                                                                        + line.Substring(114, 2) + ":" + line.Substring(116, 2) + ":00";
                            diagnosis = line.Substring(312, 75).Trim();
                            notes = line.Substring(387, 100).Trim();

                            insertCommand.Parameters.AddWithValue("@p1", patientSSN);
                            insertCommand.Parameters.AddWithValue("@p2", DateTime.Parse(checkInDateTime));
                            insertCommand.Parameters.AddWithValue("@p3", DateTime.Parse(checkOutDateTime));
                            insertCommand.Parameters.AddWithValue("@p4", diagnosis);
                            insertCommand.Parameters.AddWithValue("@p5", notes);
                            rowsAffected += insertCommand.ExecuteNonQuery();
                        }
                    }

                }
            }
            Console.WriteLine($"\n{rowsAffected} rows inserted.");
            connection.Close();

        }
    }

    public static void WriteIntoPatient()
    {
        string[] lines = ReadFromTextFile("MedicalRecords.txt");

        string patientSSN, lastName, firstName, middleInitial, sex, birthDate, insurer, organDonor, dnrStatus;
        //DateTime checkInDateTime, checkOutDateTime;
        int rowsAffected = 0;

        string connectionString = "desktop-rmqlafu\\sqlexpress.TestDB.dbo";
        connectionString = "Data Source=desktop-rmqlafu\\sqlexpress;Initial Catalog=TestDB;Integrated Security=True; Trusted_Connection=True;TrustServerCertificate=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            int rowCount = 0;
            connection.Open();
            //string insertSql = "INSERT INTO VisitHistory (patient_SSN, CheckInDateTime, CheckOutDateTime, Diagnosis, Notes) VALUES (@p1, (CONVERT(datetime, @p2, 120), (CONVERT(datetime, @p3, 120), @p4, @p5)";
            string insertSql = "INSERT INTO Patient (SSN, LastName, FirstName, MiddleInitial, Sex, BirthDate, Insurer, OrganDonor, DNR_Status) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9)";

            string selectSql = "SELECT COUNT(*) FROM Patient WHERE SSN = @key";

            foreach (string line in lines)
            {
                using (SqlCommand selectCommand = new SqlCommand(selectSql, connection))
                {
                    using (SqlCommand insertCommand = new SqlCommand(insertSql, connection))
                    {
                        patientSSN = line.Substring(77, 9).Trim();
                        if (patientSSN == null)
                        {
                            continue;
                        }
                        selectCommand.Parameters.AddWithValue("@key", patientSSN);
                        rowCount = (int)selectCommand.ExecuteScalar();
                        if (rowCount > 0)
                        {
                            //comment out this when running
                            //Console.WriteLine("A patient with SSN: " + patientSSN + " already exists in db\n");
                            rowCount = 0;
                        }
                        else
                        {
                            lastName = line.Substring(0, 50).Trim();
                            firstName = line.Substring(50, 14).Trim();
                            middleInitial = line.Substring(75, 1);
                            sex = line.Substring(76, 1);
                            birthDate = line.Substring(90, 4) + "-" + line.Substring(86, 2) + "-" + line.Substring(88, 2);

                            insurer = line.Substring(487, 5).Trim();
                            organDonor = line.Substring(595, 1);
                            dnrStatus = line.Substring(594, 1);

                            insertCommand.Parameters.AddWithValue("@p1", patientSSN);
                            insertCommand.Parameters.AddWithValue("@p2", lastName);
                            insertCommand.Parameters.AddWithValue("@p3", firstName);
                            insertCommand.Parameters.AddWithValue("@p4", middleInitial);
                            insertCommand.Parameters.AddWithValue("@p5", sex);
                            insertCommand.Parameters.AddWithValue("@p6", DateTime.Parse(birthDate));
                            insertCommand.Parameters.AddWithValue("@p7", insurer);
                            insertCommand.Parameters.AddWithValue("@p8", organDonor);
                            insertCommand.Parameters.AddWithValue("@p9", dnrStatus);
                            rowsAffected += insertCommand.ExecuteNonQuery();
                        }
                    }

                }
            }
            Console.WriteLine($"\n{rowsAffected} rows inserted.");
            connection.Close();
        }
    }

    public static void WriteIntoBuilding()
    {
        string[] lines = File.ReadAllLines("C:\\Users\\Hayk Arzumanyan\\Desktop\\DataFiles\\Rooms.txt");
        string buildingName;
        int rowsAffected = 0;

        string connectionString = "desktop-rmqlafu\\sqlexpress.TestDB.dbo";
        connectionString = "Data Source=desktop-rmqlafu\\sqlexpress;Initial Catalog=TestDB;Integrated Security=True; Trusted_Connection=True;TrustServerCertificate=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            int rowCount = 0;
            connection.Open();
            string insertSql = "INSERT INTO Building (building_name) VALUES (@p1)";
            //string selectSql = "SELECT * FROM Building WHERE building_name = @key";
            string selectSql = "SELECT COUNT (*) FROM Building WHERE building_name = @key";

            foreach (string line in lines)
            {
                using (SqlCommand selectCommand = new SqlCommand(selectSql, connection))
                {
                    using (SqlCommand insertCommand = new SqlCommand(insertSql, connection))
                    {
                        buildingName = line.Substring(54, 30).Trim();
                        selectCommand.Parameters.AddWithValue("@key", buildingName);
                        rowCount = (int)selectCommand.ExecuteScalar();
                        if (rowCount > 0)
                        {
                            rowCount = 0;
                        }
                        else
                        {
                            insertCommand.Parameters.AddWithValue("@p1", buildingName);
                            rowsAffected += insertCommand.ExecuteNonQuery();
                            rowCount++;
                        }
                    }

                }
            }
            Console.WriteLine($"\n{rowsAffected} rows inserted.");
            connection.Close();
        }
    }

    public static void WriteIntoRoom()
    {
        string[] lines = ReadFromTextFile("Rooms.txt");
        string buildingName, roomNumber, hourlyRate, effectiveDateTime, wing, floor, designation, maxOccupancy;
        int rowsAffected = 0;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            int rowCount = 0;
            connection.Open();
            string insertSql = "INSERT INTO Room (building_key, number, hourly_rate, effective_date_time, wing, floor, designation, max_occupancy) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8)";
            //string selectSql = "SELECT * FROM Building WHERE building_name = @key";
            string selectSql = "SELECT COUNT (*) FROM Room WHERE building_key = @building_key AND number = @number";
            string selectEffectiveDateTime = "SELECT effective_date_time FROM Room WHERE building_key = @building_key AND number = @number";

            foreach (string line in lines)
            {
                using (SqlCommand selectCommand = new SqlCommand(selectSql, connection))
                {
                    using (SqlCommand insertCommand = new SqlCommand(insertSql, connection))
                    {
                        buildingName = line.Substring(54, 30).Trim();
                        roomNumber = line.Substring(0, 9).Trim();
                        effectiveDateTime = line.Substring(18, 4) + "/" + line.Substring(14, 2) + "/" + line.Substring(16, 2) + " " + line.Substring(22, 2) + ":" + line.Substring(24, 2);
                        hourlyRate = line.Substring(9, 3).Trim() + "." + line.Substring(12, 2);

                        selectCommand.Parameters.AddWithValue("@building_key", buildingName);
                        selectCommand.Parameters.AddWithValue("@number", roomNumber);

                        rowCount = (int)selectCommand.ExecuteScalar();
                        if (rowCount > 0)
                        {
                            using (SqlCommand selectCommandEffectiveDateTime = new SqlCommand(selectEffectiveDateTime, connection))
                            {
                                selectCommandEffectiveDateTime.Parameters.AddWithValue("@building_key", buildingName);
                                selectCommandEffectiveDateTime.Parameters.AddWithValue("@number", roomNumber);
                                string existingDateTimeValue = selectCommandEffectiveDateTime.ExecuteScalar().ToString();

                                DateTime existingDateTime = DateTime.Parse(existingDateTimeValue);
                                DateTime newDateTime = DateTime.Parse(effectiveDateTime);

                                if (newDateTime > existingDateTime)
                                {
                                    string updateHourlyRateAndDateTime = "UPDATE Room SET hourly_rate = @newRate, effective_date_time = @dateTime WHERE building_key = @building_key AND number = @number";
                                    using (SqlCommand updateHourlyRateCommand = new SqlCommand(updateHourlyRateAndDateTime, connection))
                                    {
                                        updateHourlyRateCommand.Parameters.AddWithValue("@newRate", SqlDbType.Money).Value = hourlyRate;
                                        updateHourlyRateCommand.Parameters.AddWithValue("@dateTime", SqlDbType.DateTime).Value = newDateTime;
                                        updateHourlyRateCommand.Parameters.AddWithValue("@building_key", buildingName);
                                        updateHourlyRateCommand.Parameters.AddWithValue("@number", roomNumber);
                                        updateHourlyRateCommand.ExecuteNonQuery();
                                    }
                                }

                            }
                            rowCount = 0;
                        }
                        else
                        {
                            wing = line.Substring(26, 24).Trim();
                            floor = line.Substring(50, 4).Trim();
                            designation = line.Substring(84, 2).Trim();
                            maxOccupancy = line.Substring(86, 2).Trim();

                            insertCommand.Parameters.AddWithValue("@p1", buildingName);
                            insertCommand.Parameters.AddWithValue("@p2", roomNumber);
                            insertCommand.Parameters.AddWithValue("@p3", SqlDbType.Money).Value = hourlyRate;
                            insertCommand.Parameters.AddWithValue("@p4", SqlDbType.DateTime).Value = effectiveDateTime;
                            insertCommand.Parameters.AddWithValue("@p5", wing);
                            insertCommand.Parameters.AddWithValue("@p6", floor);
                            insertCommand.Parameters.AddWithValue("@p7", designation);
                            insertCommand.Parameters.AddWithValue("@p8", maxOccupancy);

                            rowsAffected += insertCommand.ExecuteNonQuery();
                        }
                    }

                }
            }
            Console.WriteLine($"\n{rowsAffected} rows inserted.");
            connection.Close();
        }
    }

    public static void WriteIntoSymptom()
    {

        string[] lines = File.ReadAllLines("C:\\Users\\Hayk Arzumanyan\\Desktop\\DataFiles2\\MedicalRecords.txt");
        int rowsAffected = 0;

        string connectionString = "desktop-rmqlafu\\sqlexpress.TestDB.dbo";
        connectionString = "Data Source=desktop-rmqlafu\\sqlexpress;Initial Catalog=TestDB;Integrated Security=True; Trusted_Connection=True;TrustServerCertificate=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            int rowCount = 0;
            connection.Open();
            string insertSql = "INSERT INTO Symptom (Name) VALUES (@name)";

            string selectSql = "SELECT COUNT(*) FROM Symptom WHERE Name = @key";
            //List<string> symptoms = new List<string>(6);
            string[] symptoms = new string[6];

            foreach (string line in lines)
            {

                symptoms[0] = line.Substring(162, 25).Trim();
                symptoms[1] = line.Substring(187, 25).Trim();
                symptoms[2] = line.Substring(212, 25).Trim();
                symptoms[3] = line.Substring(237, 25).Trim();
                symptoms[4] = line.Substring(262, 25).Trim();
                symptoms[5] = line.Substring(287, 25).Trim();

                foreach (string symptom in symptoms)
                {
                    using (SqlCommand selectCommand = new SqlCommand(selectSql, connection))
                    {
                        using (SqlCommand insertCommand = new SqlCommand(insertSql, connection))
                        {
                            selectCommand.Parameters.AddWithValue("@key", symptom);
                            rowCount = (int)selectCommand.ExecuteScalar();
                            if (rowCount > 0)
                            {
                                rowCount = 0;
                                continue;
                            }
                            else
                            {
                                insertCommand.Parameters.AddWithValue("@name", symptom);
                                rowsAffected += insertCommand.ExecuteNonQuery();
                            }
                        }
                    }

                }
            }
            Console.WriteLine($"\n{rowsAffected} rows inserted.");
            connection.Close();

        }
    }
}