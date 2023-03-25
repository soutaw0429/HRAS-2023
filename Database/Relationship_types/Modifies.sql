Create table Modifies
(
	staff_key varchar(150),
	inventory_key char(5),
	VisitHistory_patient_SSN varchar(9), 
	VisitHistory_CheckInDateTime DATETIME,
	

Constraint PK_Modifies
	primary key (staff_key, inventory_key, VisitHistory_patient_SSN, VisitHistory_CheckInDateTime),

CONSTRAINT FK_Modifies_Staff
	FOREIGN KEY (staff_key)
	REFERENCES Staff(UserName),


Constraint FK_Modifies_Inventory
	foreign key(inventory_key)
	references Inventory(stock_id),

Constraint FK_Modifies_VisitHistory
	foreign key(VisitHistory_patient_SSN, VisitHistory_CheckInDateTime)
	references Patient(patient_SSN, CheckInDateTime),

)