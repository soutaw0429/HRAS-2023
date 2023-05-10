CREATE PROCEDURE GetPatientWithAddress
	@SSN varchar(9)
AS
BEGIN
	SELECT
		*
	FROM Patient, Home
	WHERE Patient.SSN = @SSN AND Patient.SSN = Home.Patient_Key
	ORDER BY
		Patient.LastName;
END
GO

--Create Procedure FindVisitHistoryByPatientSSN
--	@SSN nvarchar(9)
--As
--Begin
--	Select *
--	From Patient
--	Inner Join VisitHistory On Patient.SSN = VisitHistory.Patient_SSN
--	Inner Join Presents On Patient.SSN = Presents.Patient_SSN
--	Where SSN = @SSN
--End


--Create Procedure FindSymptomByPatientSSN
--	@SSN nvarchar(9)
--As
--Begin
--	Select *
--	From Patient 
--	Inner Join Presents On Patient.SSN = Presents.Patient_SSN
--	Where SSN = @SSN
--End

CREATE PROCEDURE GetPasswordByUserName
	@UserName varchar(25)
AS
BEGIN
	SELECT
		UserName, FirstName, LastName, [Password], UserType, Position
	FROM Staff
	WHERE Staff.UserName = @UserName
	ORDER BY
		Staff.LastName;
END
GO

Create Procedure GetInventoryItemByStockId
	@StockId varchar(5)
AS
BEGIN
	SELECT *
	FROM dbo.Inventory
	WHERE stock_id = @StockId
END
GO

CREATE PROCEDURE find_symptoms_near_median
AS
BEGIN
    -- Calculate the median frequency
    DECLARE @total_count int, @median float
	DECLARE @s1_answer bit, @s2_answer bit, @s3_answer bit, @s4_answer bit, @s5_answer bit, @s6_answer bit
	DECLARE @s1_name varchar(25), @s2_name varchar(25), @s3_name varchar(25), @s4_name varchar(25), @s5_name varchar(25), @s6_name varchar(25)
    SELECT @total_count = COUNT(Symptom_Name) FROM Presents
    SELECT @median = AVG(CAST(frequency as float))
    FROM
    (
        SELECT COUNT(*) as frequency
        FROM Presents
        INNER JOIN VisitHistory ON Presents.Patient_SSN = VisitHistory.Patient_SSN
        INNER JOIN Symptom ON Symptom.NAME = Presents.Symptom_Name
        GROUP BY Symptom.NAME
    ) AS frequency_table
    WHERE frequency_table.frequency <= (@total_count + 1) / 2
    
    -- Find 10 symptoms whose frequency is near the median
    SELECT TOP 10 Symptom.NAME, COUNT(*) as frequency
    FROM Presents
    INNER JOIN VisitHistory ON Presents.Patient_SSN = VisitHistory.Patient_SSN
    INNER JOIN Symptom ON Symptom.NAME = Presents.Symptom_Name
    GROUP BY Symptom.NAME
    HAVING ABS(CAST(COUNT(*) as float) - @median) <= 15
    ORDER BY ABS(CAST(COUNT(*) as float) - @median);
END
GO

CREATE PROCEDURE find_symptoms_near_medians_hasParameter @s1_name varchar(25)
AS
BEGIN
    -- Create temporary table to store the first set of results
    CREATE TABLE #temp_results (
        symptom varchar(25),
        frequency int
    )

    -- Calculate the median frequency
    DECLARE @total_count int, @median float
    SELECT @total_count = COUNT(*) FROM Presents
    SELECT @median = AVG(CAST(frequency as float))
    FROM
    (
        SELECT COUNT(*) as frequency
        FROM Presents
        GROUP BY Symptom_Name
    ) AS frequency_table
    WHERE frequency_table.frequency <= (@total_count + 1) / 2
    
    -- Find 10 symptoms whose frequency is near the median
    INSERT INTO #temp_results (symptom, frequency)
    SELECT TOP 10 Symptom_Name, COUNT(*) as frequency
    FROM Presents
    INNER JOIN VisitHistory ON Presents.Patient_SSN = VisitHistory.Patient_SSN
    INNER JOIN Symptom ON Symptom.NAME = Presents.Symptom_Name
    GROUP BY Symptom_Name
    HAVING ABS(CAST(COUNT(*) as float) - @median) <= 5
    ORDER BY ABS(CAST(COUNT(*) as float) - @median)

    -- Find 10 symptoms whose frequency is near the median and include s1_name
    SELECT TOP 10 Symptom_Name, COUNT(*) as frequency
    FROM Presents
    INNER JOIN VisitHistory ON Presents.Patient_SSN = VisitHistory.Patient_SSN
    INNER JOIN Symptom ON Symptom.NAME = Presents.Symptom_Name
    WHERE (Symptom_Name = @s1_name OR Symptom_Name IN (SELECT symptom FROM #temp_results))
    GROUP BY Symptom_Name
    HAVING ABS(CAST(COUNT(*) as float) - @median) <= 5
    ORDER BY ABS(CAST(COUNT(*) as float) - @median)

    -- Drop the temporary table
    DROP TABLE #temp_results
END
GO

Create Procedure GetInventoryItemByName
	@Description varchar(35)

AS
BEGIN
	SELECT *
	FROM dbo.Inventory
	WHERE description = @Description
END
GO

Create Procedure GetPatientWithAddressByRoomNumber
	@room_number varchar(9)
As
Begin
	Select *
	FROM (
	SELECT
		*
	FROM Patient, Home
	WHERE Patient.SSN = Home.Patient_Key
	) Patient
	Inner Join StaysIn On StaysIn.visitHistory_patientSSN = Patient.SSN
	WHERE StaysIn.room_number = @room_number
End
GO


CREATE PROCEDURE UpdateInventory 
	@StockId nchar(5),
	@Quantity nvarchar(5), 
	@Description varchar(35),
	@Size int,
	@Price money
AS
BEGIN
	
	If exists (Select 1 From[Inventory]
	Where @StockId = stock_id)
	Begin
		Update Inventory Set
		quantity = @Quantity
		where @StockId = stock_id
	End

	Else
	Begin
		Insert Into Inventory(stock_id, quantity, description, size, price)
		Values (@StockId, @Quantity, @Description, @Size, @Price)
	End

	SELECT *
	FROM dbo.Inventory
	WHERE stock_id = @StockId
END
GO