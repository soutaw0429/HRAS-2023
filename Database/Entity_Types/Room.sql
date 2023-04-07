Create table Room
(
building_key varchar(30),
[number] varchar(9),
hourly_rate money,
wing varchar(24),
[floor] varchar(4),
designation varchar(2),
max_occupancy int,
Constraint PK_Room primary key(building_key, [number]),

Constraint FK_ConsistsOf_Building
foreign key(building_key)
references Building(building_name)

)