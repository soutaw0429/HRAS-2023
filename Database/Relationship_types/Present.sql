CREATE TABLE Presents (
	Symptom_Name VARCHAR(50),
	Patient_SSN VARCHAR(9),
	CONSTRAINT PK_Presents PRIMARY KEY (Patient_SSN, Symptom_Name),
	CONSTRAINT FK_Presents_Patient FOREIGN KEY (Patient_SSN) REFERENCES Patient(SSN),
	CONSTRAINT FK_Presents_Symptom FOREIGN KEY (Symptom_Name) REFERENCES Symptom([Name])
)