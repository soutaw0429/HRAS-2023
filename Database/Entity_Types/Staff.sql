CREATE TABLE Staff (
    BirthDate DATE,
    FirstName VARCHAR(50),
    MiddleInitial CHAR(1),
    LastName VARCHAR(50),
    UserName VARCHAR(25),
    [Password] VARCHAR(50),
    UserType VARCHAR(1),
    Position VARCHAR(50),
	CONSTRAINT PK_Staff PRIMARY KEY (UserName)
);