CREATE PROCEDURE patientAndAddress
AS
BEGIN
	SELECT
		*
	FROM Patient, Home
	WHERE Patient.SSN = Home.Patient_Key
	ORDER BY
		Patient.LastName;
END
		

EXEC patientAndAddress