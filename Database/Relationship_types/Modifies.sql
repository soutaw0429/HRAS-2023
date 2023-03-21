Create table Modifies
(
	staff_key varchar(150),
	inventory_key char(5),
	patient_key varchar(9),
	staff_BirthDate_key Date, 
	staff_FirstName_key varchar(50), 
	staff_MiddleInitial_key char(1), 
	staff_LastName_key varchar(50),

Constraint PK_Modifies
	primary key (staff_key, inventory_key),

Constraint FK_Modifies_Staff
	foreign key(staff_BirthDate_key, staff_FirstName_key, staff_MiddleInitial_key, staff_LastName_key)
	references Staff(BirthDate, FirstName, MiddleInitial,
	LastName),

Constraint FK_Modifies_Inventory
	foreign key(inventory_key)
	references Inventory(stock_id),

Constraint FK_Modifies_Patient
	foreign key(patient_key)
	references Patient(SSN),

)