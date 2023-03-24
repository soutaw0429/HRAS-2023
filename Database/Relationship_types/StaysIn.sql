Create table StaysIn
(
isAdmitted BIT,
leftTheRoom DateTime,
room_building_key varchar(30),
room_key varchar(9),
history_patient_SSN varchar(9), 
history_CheckInDateTime DATETIME,

Constraint PK_StaysIn primary key(room_building_key, room_key, history_patient_SSN, history_CheckInDateTime),

Constraint FK_StaysIn_Room
    foreign key(room_building_key, room_key)
    references Room(building_key, room_number),

Constraint FK_StaysIn_VisitHistory
    foreign key(history_patient_SSN, history_CheckInDateTime)
    references VisitHistory(patient_SSN, CheckInDateTime)
)
