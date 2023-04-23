CREATE PROCEDURE GetPatientWithAddress
	@SSN varchar(9)
AS
BEGIN
	SELECT
		*
	FROM Patient, Home
	WHERE Patient.SSN = @SSN AND Patient.SSN = Home.Patient_Key
	ORDER BY
		Patient.LastName;
END


Create Procedure FindVisitHistoryByPatientSSN
	@SSN nvarchar(9)
As
Begin
	Select *
	From Patient
	Inner Join VisitHistory On Patient.SSN = VisitHistory.Patient_SSN
	Inner Join Presents On Patient.SSN = Presents.Patient_SSN
	Where SSN = @SSN
End


Create Procedure FindSymptomByPatientSSN
	@SSN nvarchar(9)
As
Begin
	Select *
	From Patient 
	Inner Join Presents On Patient.SSN = Presents.Patient_SSN
	Where SSN = @SSN
End

CREATE PROCEDURE GetPasswordByUserName
	@UserName varchar(25)
AS
BEGIN
	SELECT
		Password
	FROM Staff
	WHERE Staff.UserName = @UserName
	ORDER BY
		Staff.LastName;
END

CREATE PROCEDURE GetSymptomFrequency
AS
BEGIN
    SELECT [NAME], COUNT(*) AS frequency
    FROM Symptom
    GROUP BY [NAME]
    ORDER BY frequency DESC;
END

EXEC GetSymptomFrequency;