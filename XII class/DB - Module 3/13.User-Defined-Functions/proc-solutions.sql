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

--Задача 4: Брой служители в отдел по име
DROP PROC IF EXISTS usp_EmployeesNumberInDepartment
ALTER PROC usp_EmployeesNumberInDepartment(@depName VARCHAR(50), @empCount INT OUTPUT)
AS
BEGIN
	SELECT @empCount = COUNT(*)
	  FROM Employees e
	  JOIN Departments d ON e.DepartmentID = d.DepartmentID
	 WHERE d.[Name] = @depName
END

DECLARE @empCountInDep INT
EXEC usp_EmployeesNumberInDepartment 'Tool design', @empCountInDep OUTPUT
SELECT @empCountInDep

CREATE FUNCTION udf_EmployeesNumberInDepartment(@depName VARCHAR(50))
RETURNS INT
AS
BEGIN
	DECLARE @result INT

	SELECT @result = COUNT(*)
	  FROM Employees e
	  JOIN Departments d ON e.DepartmentID = d.DepartmentID
	 WHERE d.[Name] = @depName

	 RETURN @result
END

SELECT [Name], dbo.udf_EmployeesNumberInDepartment([Name]) AS EmployeeName
  FROM Departments

--Задача 5: Обща сума заплати по DepartmentId
DROP PROC IF EXISTS usp_TotalSalaryInDepartment
CREATE PROC usp_TotalSalaryInDepartment(@depID INT, @total MONEY OUTPUT)
AS
BEGIN
	DECLARE @haveEmployees INT

	SELECT @haveEmployees = COUNT(*)
	  FROM Employees
	 WHERE DepartmentID = @depID

	IF(@haveEmployees = 0) -- no emplyees
		SET @total = 0
	ELSE
		SELECT @total = SUM(Salary)
		  FROM Employees
		 WHERE DepartmentID = @depID	
END
-- procedure usage
DECLARE @totalSalary MONEY
EXEC usp_TotalSalaryInDepartment 1200, @totalSalary OUTPUT
SELECT @totalSalary AS 'Total Salary'

--Задача 6: Брой участници в проект
DROP PROC IF EXISTS usp_GetParticipantInProject
CREATE PROC usp_GetParticipantInProject(@prID INT, @participants INT OUTPUT)
AS
	SELECT @participants = COUNT(*) 
	  FROM EmployeesProjects
	 WHERE ProjectID = @prID

DECLARE @participants INT
EXEC usp_GetParticipantInProject 1, @participants OUTPUT
SELECT @participants AS [Participants Number]