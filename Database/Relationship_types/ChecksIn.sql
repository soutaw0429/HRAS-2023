CREATE TABLE ChecksIn (
	ChecksInDateTime DATETIME,
	Patient_SSN VARCHAR(9),
	Staff_UserName VARCHAR(50),
	CONSTRAINT PK_ChecksIn PRIMARY KEY (Patient_SSN, Staff_UserName),
	CONSTRAINT FK_ChecksIn_Patient FOREIGN KEY (Patient_SSN) REFERENCES Patient(SSN),
	CONSTRAINT FK_ChecksIn_Staff FOREIGN KEY (Staff_UserName) REFERENCES Staff(UserName)
);