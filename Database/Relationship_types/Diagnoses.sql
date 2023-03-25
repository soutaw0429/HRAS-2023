CREATE TABLE Diagnoses (
	Patient_SSN VARCHAR(9),
	CheckInDateTime DATETIME,
	Diagnosis_Name VARCHAR(50),
	Staff_UserName VARCHAR(25),
	CONSTRAINT PK_Diagnoses PRIMARY KEY (Patient_SSN, CheckInDateTime, Staff_UserName),
	CONSTRAINT FK_Diagnoses_VisitHistory FOREIGN KEY (Patient_SSN, CheckInDateTime) REFERENCES VisitHistory(Patient_SSN, CheckInDateTime),
	CONSTRAINT FK_Diagnoses_Staff FOREIGN KEY (Staff_UserName) REFERENCES Staff(UserName)
);