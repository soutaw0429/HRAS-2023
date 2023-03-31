Create table StaysIn
(
isAdmitted BIT,
leftTheRoomDateTime DateTime,
room_building_name varchar(30),
room_number varchar(9),
visitHistory_patientSSN varchar(9), 
visitHistory_checkInDateTime DATETIME,

Constraint PK_StaysIn primary key(room_building_name, room_number, visitHistory_patientSSN, visitHistory_checkInDateTime),

Constraint FK_StaysIn_Room
    foreign key(room_building_name, room_number)
    references Room(building_key, [number]),

Constraint FK_StaysIn_VisitHistory
    foreign key(visitHistory_patientSSN, visitHistory_checkInDateTime)
    references VisitHistory(patient_SSN, CheckInDateTime)
)