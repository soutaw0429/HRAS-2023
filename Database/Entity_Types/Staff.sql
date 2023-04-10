CREATE TABLE Staff (
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    UserName VARCHAR(25),
    [Password] VARCHAR(128),
    UserType VARCHAR(1),
    Position VARCHAR(50),
	CONSTRAINT PK_Staff PRIMARY KEY (UserName)
);