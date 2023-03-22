CREATE TABLE Present (
	Symptom_Name VARCHAR(50),
	Patient_SSN VARCHAR(9),
	CONSTRAINT PK_Present PRIMARY KEY (Patient_SSN, Symptom_Name),
	CONSTRAINT FK_Present_Patient FOREIGN KEY (Patient_SSN) REFERENCES Patient(SSN),
	CONSTRAINT FK_Present_Symptom FOREIGN KEY (Symptom_Name) REFERENCES Symptom([Name])
)