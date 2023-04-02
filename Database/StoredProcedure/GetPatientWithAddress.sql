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