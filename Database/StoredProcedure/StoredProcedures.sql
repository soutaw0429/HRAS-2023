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
GO

CREATE PROCEDURE GetSymptomFrequency
AS
BEGIN
    SELECT Symptom_Name, COUNT(*) AS frequency
    FROM Present
	Inner Join VisitHistory On Present.SSN = VisitHistory.Patient_SSN
	Inner Join Symptom On Present.Symptom_Name = Symptom.[Name]
    GROUP BY Symptom_Name
    ORDER BY frequency DESC;
END
GO

-- Create Procedure FindPatientSSNBySymptom
-- 	@Symptom_Name varchar(25)
-- As
-- Begin
-- 	Select Presents.Patient_SSN, Symptom_Name
-- 	From Presents
-- 	Inner Join VisitHistory On Presents.Patient_SSN = VisitHistory.Patient_SSN
-- 	Inner Join Symptom On Presents.Symptom_Name = Symptom.[Name]
-- 	Where Symptom_Name = @Symptom_Name
-- End

CREATE PROCEDURE GetTableNearFiftyPercent
AS
BEGIN
    SELECT *
          FROM   (
		  SELECT TOP 5 * 
		  FROM Symptom
          WHERE  (select AVG(Symptom.Frequency) from Symptom) > Symptom.Frequency
		  ORDER  BY Symptom.Frequency DESC) Symptom
    UNION ALL
    SELECT *
          FROM   (
		  SELECT TOP 5 * 
		  FROM Symptom
          WHERE  (select AVG(Symptom.Frequency) from Symptom) <= Symptom.Frequency
		  ORDER  BY Symptom.Frequency ASC) Symptom
END
GO

Create Procedure GetPatientWithAddressByRoomNumber
	@room_number varchar(9)
As
Begin
	Select *
	FROM (
	SELECT
		*
	FROM Patient, Home
	WHERE Patient.SSN = Home.Patient_Key
	) Patient
	Inner Join StaysIn On StaysIn.visitHistory_patientSSN = Patient.SSN
	WHERE StaysIn.room_number = @room_number
End
GO

CREATE PROCEDURE GetPatientWithAddressByFirstName
	@FirstName VARCHAR(25)
AS
BEGIN
	SELECT
		*
	FROM Patient, Home
	WHERE Patient.FirstName = @FirstName AND Patient.SSN = Home.Patient_Key
	ORDER BY
		Patient.FirstName;
END
GO

CREATE PROCEDURE GetPatientWithAddressByLastName
	@LastName VARCHAR(25)
AS
BEGIN
	SELECT
		*
	FROM Patient, Home
	WHERE Patient.LastName = @LastName AND Patient.SSN = Home.Patient_Key
	ORDER BY
		Patient.LastName;
END