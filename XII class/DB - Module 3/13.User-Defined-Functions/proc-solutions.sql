-- Procedures

--1. Employees full name
DROP PROC IF EXISTS EmployeeFullNameById
CREATE PROC usp_EmployeeFullNameById(@employeeId INT, @fullName VARCHAR(100) OUTPUT)
AS
	SELECT @fullName = CONCAT(FirstName, ' ', LastName)
	  FROM Employees
	 WHERE EmployeeId = @employeeId

-- usage example
DECLARE @outFulName VARCHAR(100)
EXEC usp_EmployeeFullNameById 20, @outFulName OUTPUT
SELECT @outFulName AS EmployeeFullName

CREATE PROC usp_EmployeeNameById(@employeeId INT)
AS
	SELECT CONCAT(FirstName, ' ', LastName) AS FullName
	  FROM Employees
	 WHERE EmployeeId = @employeeId

EXEC usp_EmployeeNameById 2

--2. Employee manager name by Id
ALTER PROC usp_EmployeeManagerNameBy(@employeeId INT, @mFullName VARCHAR(100) OUTPUT)
AS
BEGIN
	DECLARE @mId INT
	DECLARE @employeeExists BIT

	 SELECT @employeeExists = COUNT(*)
	   FROM Employees
	  WHERE EmployeeID = @employeeId

	IF(@employeeExists = 1)
	BEGIN
		SELECT @mFullName = m.FirstName + ' ' + m.LastName, @mId = e.ManagerId
		  FROM Employees e
		  JOIN Employees m ON e.ManagerID = m.EmployeeID
		 WHERE e.EmployeeID = @employeeId

		 IF(@mId IS NULL)
			SET @mFullName = 'no manager'
	END
	ELSE
		SET @mFullName = NULL
END

DECLARE @mFullNameRobber VARCHAR(100)
EXEC usp_EmployeeManagerNameBy @employeeId = 109000, @mFullName = @mFullNameRobber OUTPUT
SELECT @mFullNameRobber AS ManagerName

SELECT *
  FROM Employees
 WHERE ManagerID IS NULL

 SELECT COUNT(*)
   FROM Employees
  WHERE EmployeeID = 103333

--Задача 3: Град на служител по Id

DROP PROC IF EXISTS usp_EmployeeTownName
ALTER PROC usp_EmployeeTownName(@empId INT)
AS
BEGIN
	DECLARE @isEmpExists BIT
	
	SELECT @isEmpExists = COUNT(*)
	  FROM Employees
	 WHERE EmployeeID = @empId

	IF(@isEmpExists = 0)
		SELECT NULL
	ELSE
		SELECT e.FirstName, e.LastName, t.[Name] AS TownName
		  FROM Employees e
		  JOIN Addresses a ON e.AddressID = a.AddressID
		  JOIN Towns t ON a.TownID = t.TownID
		 WHERE e.EmployeeID = @empId
END

EXEC dbo.usp_EmployeeTownName @empId = 12