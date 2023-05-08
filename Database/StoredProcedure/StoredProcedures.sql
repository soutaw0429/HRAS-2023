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