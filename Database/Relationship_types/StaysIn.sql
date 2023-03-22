Create table StaysIn
(
isAdmitted BIT,
leftTheRoom DateTime,
room_building_key varchar(30),
room_key varchar(9),
patient_key varchar(9),


Constraint PK_StaysIn primary key(room_building_key, room_key, patient_key),

Constraint FK_StaysIn_Room
	foreign key(room_building_key, room_key)
	references Room(building_key, room_number),

Constraint FK_Modifies_Patient
	foreign key(patient_key)
	references Patient(SSN)
)