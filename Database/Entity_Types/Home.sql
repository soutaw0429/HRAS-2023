CREATE TABLE Home
(
	Patient_Key VARCHAR(9),
	StreetAddress_Line_1 VARCHAR(35),
    StreetAddress_Line_2 VARCHAR(35),
    City VARCHAR(25),
	[State] CHAR(2),
    ZIP VARCHAR(5),
	
	CONSTRAINT PK_Home PRIMARY KEY (Patient_Key),

	CONSTRAINT FK_Home_Patient FOREIGN KEY (Patient_Key)
		REFERENCES Patient (SSN)
)

--added at 5.11

CREATE PROCEDURE GetPatientBySSN
	@SSN varchar(9)
AS
BEGIN
	SELECT
		Patient.SSN AS PatientSSN, Patient.FirstName AS PatientFirstName, Patient.LastName AS PatientLastName, Patient.MiddleInitial AS PatientMiddleInitial
	FROM Patient
	WHERE Patient.SSN = @SSN
END

CREATE PROCEDURE GetPatientByFirstName
	@FirstName varchar(25)
AS
BEGIN
	SELECT
		Patient.SSN AS PatientSSN, Patient.FirstName AS PatientFirstName, Patient.LastName AS PatientLastName, Patient.MiddleInitial AS PatientMiddleInitial
	FROM Patient
	WHERE Patient.FirstName = @FirstName
END

CREATE PROCEDURE GetPatientByLastName
	@LastName varchar(50)
AS
BEGIN
	SELECT
		Patient.SSN AS PatientSSN, Patient.FirstName AS PatientFirstName, Patient.LastName AS PatientLastName, Patient.MiddleInitial AS PatientMiddleInitial
	FROM Patient
	WHERE Patient.LastName = @LastName
END

Create Procedure getPatientSSNByRoom
	@room_number varchar(9)
As
Begin
	Select *
	FROM StaysIn
	WHERE StaysIn.room_number = @room_number
End

Create Procedure getPatientsSSNFromRoom
As
Begin
	Select StaysIn.visitHistory_patientSSN
	FROM StaysIn
End

Create Procedure getHomeAddressBySSN
	@SSN varchar(9)
As
Begin
	Select *
	FROM Home
	WHERE Home.Patient_Key = @SSN
End