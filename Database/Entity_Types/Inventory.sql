Create table Inventory
(
stock_id char(5),
quantity varchar(5),
description varchar(35),
size int,
price money,
Constraint PK_Inventory primary key(stock_id)
)