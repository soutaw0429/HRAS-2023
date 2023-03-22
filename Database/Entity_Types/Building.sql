Create table Building
(
building_name varchar(30),
street_address1 varchar(35),
street_address2 varchar(35),
city varchar(25),
state char(2),

zip char(5),
Constraint PK_Building primary key(building_name)
)