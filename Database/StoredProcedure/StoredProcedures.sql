--CREATE PROCEDURE GetPatientWithAddress
--	@SSN varchar(9)
--AS
--BEGIN
--	SELECT
--		*
--	FROM Patient, Home
--	WHERE Patient.SSN = @SSN AND Patient.SSN = Home.Patient_Key
--	ORDER BY
--		Patient.LastName;
--END


--Create Procedure FindVisitHistoryByPatientSSN
--	@SSN nvarchar(9)
--As
--Begin
--	Select *
--	From Patient
--	Inner Join VisitHistory On Patient.SSN = VisitHistory.Patient_SSN
--	Inner Join Presents On Patient.SSN = Presents.Patient_SSN
--	Where SSN = @SSN
--End


--Create Procedure FindSymptomByPatientSSN
--	@SSN nvarchar(9)
--As
--Begin
--	Select *
--	From Patient 
--	Inner Join Presents On Patient.SSN = Presents.Patient_SSN
--	Where SSN = @SSN
--End

CREATE PROCEDURE GetPasswordByUserName
	@UserName varchar(25)
AS
BEGIN
	SELECT
		UserName, FirstName, LastName, [Password], UserType
	FROM Staff
	WHERE Staff.UserName = @UserName
	ORDER BY
		Staff.LastName;
END

CREATE PROCEDURE find_symptoms_near_median
AS
BEGIN
    -- Calculate the median frequency
    DECLARE @total_count int, @median float
	DECLARE @s1_answer bit, @s2_answer bit, @s3_answer bit, @s4_answer bit, @s5_answer bit, @s6_answer bit
	DECLARE @s1_name varchar(25), @s2_name varchar(25), @s3_name varchar(25), @s4_name varchar(25), @s5_name varchar(25), @s6_name varchar(25)
    SELECT @total_count = COUNT(Symptom_Name) FROM Presents
    SELECT @median = AVG(CAST(frequency as float))
    FROM
    (
        SELECT COUNT(*) as frequency
        FROM Presents
        INNER JOIN VisitHistory ON Presents.Patient_SSN = VisitHistory.Patient_SSN
        INNER JOIN Symptom ON Symptom.NAME = Presents.Symptom_Name
        GROUP BY Symptom.NAME
    ) AS frequency_table
    WHERE frequency_table.frequency <= (@total_count + 1) / 2
    
    -- Find 10 symptoms whose frequency is near the median
    SELECT TOP 10 Symptom.NAME, COUNT(*) as frequency
    FROM Presents
    INNER JOIN VisitHistory ON Presents.Patient_SSN = VisitHistory.Patient_SSN
    INNER JOIN Symptom ON Symptom.NAME = Presents.Symptom_Name
    GROUP BY Symptom.NAME
    HAVING ABS(CAST(COUNT(*) as float) - @median) <= 15
    ORDER BY ABS(CAST(COUNT(*) as float) - @median);
END