CREATE TABLE ChecksOut (
	Patient_SSN VARCHAR(9),
	CheckInDateTime DATETIME,
	Staff_UserName VARCHAR(25),
	CONSTRAINT PK_ChecksOut PRIMARY KEY (Patient_SSN, CheckInDateTime, Staff_UserName),
	CONSTRAINT FK_ChecksOut_VisitHistory FOREIGN KEY (Patient_SSN, CheckInDateTime) REFERENCES VisitHistory(Patient_SSN, CheckInDateTime),
	CONSTRAINT FK_ChecksOut_Staff FOREIGN KEY (Staff_UserName) REFERENCES Staff(UserName)
);