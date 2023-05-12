CREATE TABLE Home
(
	Patient_Key VARCHAR(9),
	StreetAddress_Line_1 VARCHAR(35),
    StreetAddress_Line_2 VARCHAR(35),
    City VARCHAR(25),
	[State] CHAR(2),
    ZIP VARCHAR(5),
	
	CONSTRAINT PK_Home PRIMARY KEY (Patient_Key),

	CONSTRAINT FK_Home_Patient FOREIGN KEY (Patient_Key)
		REFERENCES Patient (SSN)
)
