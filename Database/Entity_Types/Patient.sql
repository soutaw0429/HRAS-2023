CREATE TABLE Patient (
    SSN VARCHAR(9),
    Insurer VARCHAR(50),
    [State] CHAR(2),
    ZIP VARCHAR(10),
    City VARCHAR(50),
    StreetAddress VARCHAR(100),
	VisitHistroy_ChecksInDateTime DATETIME,
    CONSTRAINT PK_Patient PRIMARY KEY (SSN)

);