Create table Room
(
building_key varchar(30),
room_number varchar(9),
hourly_rate money,
wing varchar(24),
[floor] int,
designation varchar(2),
max_occupancy int,
Constraint PK_Room primary key(building_key, room_number),

Constraint FK_ConsistsOf_Building
foreign key(building_key)
references Building(building_name)

)