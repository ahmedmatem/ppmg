--Part I – Queries for SoftUni Database

--1.Employees with Salary Above 35000

DROP PROC IF EXISTS usp_EmployeesWithSalaryAbove

CREATE PROC usp_EmployeesWithSalaryAbove(@salary MONEY)
AS
	SELECT FirstName, LastName
	  FROM Employees
	 WHERE Salary > @salary

EXEC usp_EmployeesWithSalaryAbove 35000

CREATE FUNCTION udf_EmployeesCountWithSalaryAbove(@salary MONEY)
RETURNS INT AS
BEGIN
	DECLARE @result INT

	SELECT @result = COUNT(*)
	  FROM Employees
	 WHERE Salary > @salary

	RETURN @result
END

SELECT dbo.udf_EmployeesCountWithSalaryAbove(35000) AS 'Count'

--3.Town Names Starting With
DROP PROC IF EXISTS usp_TownStartWith
CREATE PROC usp_TownStartWith(@start VARCHAR(50))
AS
	SELECT [Name] AS Town
	  FROM Towns
	 WHERE [Name] LIKE @start + '%'

EXEC usp_TownStartWith 'b'

--4.Employees from Town
CREATE PROC usp_EmployeesFromTown(@town VARCHAR(20))
AS
	SELECT e.FirstName, e.LastName
	  FROM Employees e
	  JOIN Addresses a ON e.AddressID = a.AddressID
	  JOIN Towns t ON a.TownId = t.TownID
	 WHERE t.[Name] = @town

EXEC usp_EmployeesFromTown 'Berlin'

--5.Salary Level Function
CREATE FUNCTION udf_SalaryLevel(@salary MONEY)
RETURNS VARCHAR(10) AS
BEGIN
	DECLARE @result VARCHAR(10)
	IF(@salary < 30000)
		SET @result = 'low'
	ELSE IF(@salary < 50000)
		SET @result = 'average'
	ELSE 
		SET @result = 'high'
	RETURN @result
END

SELECT Salary, dbo.udf_SalaryLevel(Salary) AS SalaryLevel
  FROM Employees

--6.Employees by Salary Level
CREATE PROC usp_EmployeesBySalaryLevel(@level VARCHAR(10))
AS
SELECT FirstName, LastName
  FROM Employees
 WHERE dbo.udf_SalaryLevel(Salary) = @level

 EXEC usp_EmployeesBySalaryLevel 'low'

 --7.Define Function
-- Define a function ufn_IsWordComprised(@setOfLetters, @word) that returns true or false, 
-- depending on that if the word is comprised of the given set of letters. 
CREATE FUNCTION udf_IsWordComprised(@setOfLetters VARCHAR(20), @word VARCHAR(20))
RETURNS BIT AS
BEGIN
	DECLARE @wordLen INT = LEN(@word)
	DECLARE @pos INT = 1
	DECLARE @letter CHAR

	WHILE @pos <= @wordLen
	BEGIN
		SET @letter = SUBSTRING(@word, @pos, 1)
		IF(CHARINDEX(@letter, @setOfLetters) = 0)
			RETURN 0
		SET @pos = @pos + 1
	END

	RETURN 1
END

SELECT dbo.udf_IsWordComprised('istmiahf', 'Sofia') AS IsComprised

--8. Delete Employees and Departments
SELECT * FROM Employees
SELECT * FROM Departments

DROP PROC IF EXISTS usp_DeleteEmployeesFromDepartment
ALTER PROC usp_DeleteEmployeesFromDepartment(@depId INT)
AS
BEGIN
	-- -1. Set managerID to null in table Departments
	ALTER TABLE Departments
		ALTER COLUMN ManagerID INT NULL
	-- 0. delete employees from Projects
	DELETE
	  FROM EmployeesProjects
	 WHERE EmployeeID IN (
		 SELECT EmployeeID
				  FROM Employees
				 WHERE DepartmentID = @depId
	 )
	-- 1. delete employees from given department by @depId
	DELETE 
	  FROM Employees
	 WHERE DepartmentID = @depId
	-- 2. delete department with given @depId
	DELETE
	  FROM Departments
	 WHERE DepartmentID = @depId
	-- 3. Select the count of employees in deleted deprtment - expected count 0
	SELECT COUNT(*)
	  FROM Employees
	 WHERE DepartmentID = @depId
END

EXEC usp_DeleteEmployeesFromDepartment 13

-- Procedure OUTPUT parameter exercise
ALTER PROC usp_GetEmployeesNumberForDepartment(@depId INT, @eNumber INT OUTPUT)
AS
	SELECT @eNumber = COUNT(*)
	  FROM Employees
	 WHERE DepartmentID = @depId

-- OUTPUT parameter usage example
DECLARE @count INT
EXEC usp_GetEmployeesNumberForDepartment @depId = 16, @eNumber = @count OUTPUT

SELECT @count