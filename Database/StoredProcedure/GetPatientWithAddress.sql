CREATE PROCEDURE GetPatientWithAddress
AS
BEGIN
	SELECT
		*
	FROM Patient, Home
	WHERE Patient.SSN = Home.Patient_Key
	ORDER BY
		Patient.LastName;
END
		

EXEC GetPatientWithAddress