
CREATE TABLE Staff (
    BirthDate DATE,
    FirstName VARCHAR(50),
    MiddleInitial CHAR(1),
    LastName VARCHAR(50),
    UserName VARCHAR(50),
    Password VARCHAR(50),
    UserType VARCHAR(50),
    Position VARCHAR(50),
	CONSTRAINT PK_Staff PRIMARY KEY (UserName)
);


CREATE TABLE Patient (
    SSN VARCHAR(9) PRIMARY KEY,
    Insurer VARCHAR(50),
    [State] CHAR(2),
    ZIP VARCHAR(10),
    City VARCHAR(50),
    StreetAddress VARCHAR(100),
	VisitHistroy_ChecksInDateTime DATETIME
);

CREATE TABLE ChecksIn (
	ChecksInDateTime DATETIME,
	Patient_SSN VARCHAR(9),
	Staff_UserName VARCHAR(50),
	CONSTRAINT PK_ChecksIn PRIMARY KEY (Patient_SSN, Staff_UserName),
	CONSTRAINT FK_ChecksIn_Patient FOREIGN KEY (Patient_SSN) REFERENCES Patient(SSN),
	CONSTRAINT FK_ChecksIn_Staff FOREIGN KEY (Staff_UserName) REFERENCES Staff(UserName)
);

CREATE TABLE ChecksOut (
	ChecksOutDateTime DATETIME,
	Patient_SSN VARCHAR(9),
	Staff_UserName VARCHAR(50),
	CONSTRAINT PK_ChecksOut PRIMARY KEY (Patient_SSN, Staff_UserName),
	CONSTRAINT FK_ChecksOut_Patient FOREIGN KEY (Patient_SSN) REFERENCES Patient(SSN),
	CONSTRAINT FK_ChecksOut_Staff FOREIGN KEY (Staff_UserName) REFERENCES Staff(UserName)
);

CREATE TABLE Diagnoses (
	Patient_SSN VARCHAR(9),
	Diagnosis_Name VARCHAR(50),
	Staff_UserName VARCHAR(50),
	CONSTRAINT PK_Diagnoses PRIMARY KEY (Patient_SSN, Staff_UserName),
	CONSTRAINT FK_Diagnoses_Patient FOREIGN KEY (Patient_SSN) REFERENCES Patient(SSN),
	CONSTRAINT FK_Diagnoses_Staff FOREIGN KEY (Staff_UserName) REFERENCES Staff(UserName)
);

CREATE TABLE Symptom (
	[Name] VARCHAR(50) PRIMARY KEY
);

CREATE TABLE Present (
	Symptom_Name VARCHAR(50),
	Patient_SSN VARCHAR(9),
	CONSTRAINT PK_Present PRIMARY KEY (Patient_SSN, Symptom_Name),
	CONSTRAINT FK_Present_Patient FOREIGN KEY (Patient_SSN) REFERENCES Patient(SSN),
	CONSTRAINT FK_Present_Symptom FOREIGN KEY (Symptom_Name) REFERENCES Symptom([Name])
)