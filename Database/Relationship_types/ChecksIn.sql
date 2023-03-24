CREATE TABLE ChecksIn (
	Patient_SSN VARCHAR(9),
	CheckInDateTime DATETIME,
	Staff_UserName VARCHAR(50),
	CONSTRAINT PK_ChecksIn PRIMARY KEY (Patient_SSN, CheckInDateTime, Staff_UserName),
	CONSTRAINT FK_ChecksIn_VisitHistory FOREIGN KEY (Patient_SSN, CheckInDateTime) REFERENCES VisitHistory(Patient_SSN, CheckInDateTime),
	CONSTRAINT FK_ChecksIn_Staff FOREIGN KEY (Staff_UserName) REFERENCES Staff(UserName)
);