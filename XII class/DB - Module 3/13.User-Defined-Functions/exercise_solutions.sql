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
