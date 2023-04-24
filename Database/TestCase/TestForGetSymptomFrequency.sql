INSERT INTO Symptom VALUES ('Fever');
INSERT INTO Symptom VALUES ('Cold');
INSERT INTO Symptom VALUES ('Flu');

INSERT INTO Patient VALUES ('234756847', 'KIKI', 'X', 'H', 'M', 3/21/1989, 'Null', 'N', 'N');
INSERT INTO Patient VALUES ('234753247', 'HFF', 'C', 'D', 'M', 2/5/1999, 'Null', 'N', 'N');
INSERT INTO Patient VALUES ('234762647', 'TYU', 'A', 'B', 'M', 6/3/1996, 'Null', 'N', 'N');

INSERT INTO VisitHistory VALUES ('234756847', 1/1/2020, 1/3/2020, 'High fever', 'not serious');
INSERT INTO VisitHistory VALUES ('234753247', 1/1/2020, 1/3/2020, 'Red Eyes', 'serious');
INSERT INTO VisitHistory VALUES ('234762647', 1/1/2020, 1/3/2020, 'flu', 'not serious');

INSERT INTO Presents VALUES ('Fever', '234756847', 1/1/2020);
INSERT INTO Presents VALUES ('Cold', '234753247', 1/1/2020);
INSERT INTO Presents VALUES ('Fever', '234762647', 1/1/2020);

EXEC GetSymptomFrequency;