CREATE TABLE Patient (
    SSN VARCHAR(9),
    Insurer VARCHAR(5),
    OrganDonor VARCHAR(1),
    DNR_Status VARCHAR(1),
    [State] CHAR(2),
    ZIP VARCHAR(5),
    City VARCHAR(25),
    StreetAddress_Line_1 VARCHAR(35),
    StreetAddress_Line_2 VARCHAR(35),
    CONSTRAINT PK_Patient PRIMARY KEY (SSN)
);