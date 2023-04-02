CREATE TABLE Patient 
(
    SSN VARCHAR(9),
    LastName VARCHAR(50),
    FirstName VARCHAR(25),
    Sex CHAR(1),
    BirthDate DATETIME, 
    Insurer VARCHAR(5),
    OrganDonor VARCHAR(1),
    DNR_Status VARCHAR(1),
    CONSTRAINT PK_Patient PRIMARY KEY (SSN)
);