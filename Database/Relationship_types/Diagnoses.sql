CREATE TABLE Diagnoses (
	Patient_SSN VARCHAR(9),
	Diagnosis_Name VARCHAR(50),
	Staff_UserName VARCHAR(50),
	CONSTRAINT PK_Diagnoses PRIMARY KEY (Patient_SSN, Staff_UserName),
	CONSTRAINT FK_Diagnoses_Patient FOREIGN KEY (Patient_SSN) REFERENCES Patient(SSN),
	CONSTRAINT FK_Diagnoses_Staff FOREIGN KEY (Staff_UserName) REFERENCES Staff(UserName)
);