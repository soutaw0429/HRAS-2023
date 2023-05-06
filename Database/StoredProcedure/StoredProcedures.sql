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

Create Procedure FindPatientSSNBySymptom
	@Symptom_Name varchar(25)
As
Begin
	Select Presents.Patient_SSN, Symptom_Name
	From Presents
	Inner Join VisitHistory On Presents.Patient_SSN = VisitHistory.Patient_SSN
	Inner Join Symptom On Presents.Symptom_Name = Symptom.[Name]
	Where Symptom_Name = @Symptom_Name
End

