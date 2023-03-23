CREATE TABLE ChecksOut (
	ChecksOutDateTime DATETIME,
	Patient_SSN VARCHAR(9),
	Staff_UserName VARCHAR(50),
	CONSTRAINT PK_ChecksOut PRIMARY KEY (Patient_SSN, Staff_UserName),
	CONSTRAINT FK_ChecksOut_Patient FOREIGN KEY (Patient_SSN) REFERENCES Patient(SSN),
	CONSTRAINT FK_ChecksOut_Staff FOREIGN KEY (Staff_UserName) REFERENCES Staff(UserName)
);