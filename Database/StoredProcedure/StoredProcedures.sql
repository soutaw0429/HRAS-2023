--CREATE PROCEDURE GetPatientWithAddress
--	@SSN varchar(9)
--AS
--BEGIN
--	SELECT
--		*
--	FROM Patient, Home
--	WHERE Patient.SSN = @SSN AND Patient.SSN = Home.Patient_Key
--	ORDER BY
--		Patient.LastName;
--END


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
		UserName, FirstName, LastName, [Password], UserType
	FROM Staff
	WHERE Staff.UserName = @UserName
	ORDER BY
		Staff.LastName;
END

Create Procedure GetInventoryItemByStockId
	@StockId varchar(5)
AS
BEGIN
	SELECT *
	FROM dbo.Inventory
	WHERE stock_id = @StockId
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