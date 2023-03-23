Create table Modifies
(
	inventory_key char(5),
	patient_key varchar(9),
	staff_key varchar(50),

Constraint PK_Modifies
	primary key (staff_key, inventory_key),

Constraint FK_Modifies_Staff
	foreign key(staff_key)
	references Staff(UserName),

Constraint FK_Modifies_Inventory
	foreign key(inventory_key)
	references Inventory(stock_id),

Constraint FK_Modifies_Patient
	foreign key(patient_key)
	references Patient(SSN),

)