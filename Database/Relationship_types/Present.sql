CREATE TABLE Presents (
	Symptom_Name VARCHAR(25),
	Patient_SSN VARCHAR(9),
	VisitHistory_CheckInDateTime DATETIME, 
	CONSTRAINT PK_Presents PRIMARY KEY (Patient_SSN, Symptom_Name, VisitHistory_CheckInDateTime),
	CONSTRAINT FK_Presents_VisitHistory FOREIGN KEY (Patient_SSN, VisitHistory_CheckInDateTime) REFERENCES VisitHistory(patient_SSN, CheckInDateTime),
	CONSTRAINT FK_Presents_Symptom FOREIGN KEY (Symptom_Name) REFERENCES Symptom([Name])
)