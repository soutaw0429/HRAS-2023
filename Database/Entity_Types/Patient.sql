CREATE TABLE Patient (
    SSN VARCHAR(9) PRIMARY KEY,
    Insurer VARCHAR(50),
    [State] CHAR(2),
    ZIP VARCHAR(10),
    City VARCHAR(50),
    StreetAddress VARCHAR(100),
	VisitHistory_ChecksInDateTime DATETIME
);