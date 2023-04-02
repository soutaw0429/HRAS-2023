Create Table VisitHistory
(
patient_SSN varchar(9),
CheckInDateTime DATETIME,
CheckOutDateTime DATETIME,
Diagnosis varchar(75),
Notes VARCHAR(100),

Constraint PK_VisitHistory Primary Key (patient_SSN, CheckInDateTime),
Constraint FK_VisitHistory_Patient Foreign Key (patient_SSN)
	References Patient (SSN)
)