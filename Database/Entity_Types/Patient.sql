CREATE TABLE Patient (
    SSN VARCHAR(9),
    Insurer VARCHAR(5),
    OrganDonor VARCHAR(1),
    DNR_Status VARCHAR(1),
    CONSTRAINT PK_Patient PRIMARY KEY (SSN)
);