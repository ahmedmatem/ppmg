-- 2.
DROP FUNCTION IF EXISTS dbo.udf_ManagerFullNameByEmployeeId

CREATE FUNCTION udf_ManagerFullNameByEmployeeId(@empId INT)
RETURNS VARCHAR(100) AS
BEGIN
	DECLARE @result VARCHAR(100)

	SELECT @result = m.FirstName + ' ' + m.LastName
	  FROM Employees e
	  JOIN Employees m ON e.ManagerID = m.EmployeeID
	 WHERE e.EmployeeID = @empId

	RETURN @result
END

SELECT FirstName + ' ' + LastName AS Employees, 
	   dbo.udf_ManagerFullNameByEmployeeId(EmployeeId) AS Managers
  FROM Employees

-- 3.
DROP FUNCTION IF EXISTS udf_EmployeeTownById

CREATE FUNCTION udf_EmployeeTownById(@empId INT)
RETURNS VARCHAR(20) AS
BEGIN
	DECLARE @result VARCHAR(20)

	-- Searching for employee Town by EmpId
	SELECT @result = t.[Name]
	  FROM Employees e
	  JOIN Addresses a ON e.AddressID = a.AddressID
	  JOIN Towns t ON a.TownID = t.TownID
	 WHERE e.EmployeeID = @empId

	RETURN @result
END

SELECT FirstName + ' ' + LastName AS Employees, 
	   dbo.udf_EmployeeTownById(EmployeeId) AS Towns
  FROM Employees

-- 4.
SELECT * FROM Employees
SELECT * FROM Departments

DROP FUNCTION IF EXISTS dbo.udf_EmployeesCountByDepName

CREATE FUNCTION udf_EmployeesCountByDepName(@depName VARCHAR(50))
RETURNS INT AS
BEGIN
	DECLARE @result INT

	   SELECT @result = COUNT(*)
		 FROM Employees e
		 JOIN Departments d ON e.DepartmentID = d.DepartmentID
		WHERE d.[Name] = @depName
	 --GROUP BY d.[Name]

	RETURN @result
END

SELECT [Name] AS DepName, 
	   dbo.udf_EmployeesCountByDepName([Name]) AS EmpCount
  FROM Departments

-- 5. With procedure

CREATE PROC usp_DepartmentTotalSalary(@depName VARCHAR(50) = 'Sales')
AS
  SELECT d.[Name], SUM(e.Salary)
    FROM Employees e
    JOIN Departments d ON e.DepartmentID = d.DepartmentID
   WHERE d.[Name] = @depName
GROUP BY d.[Name]

EXEC usp_DepartmentTotalSalary 'Sales'

CREATE PROC usp_DepartmentTotalSalaryOut(@depName VARCHAR(50) = 'Sales', @total MONEY OUTPUT)
AS
  SELECT @total = SUM(e.Salary)
    FROM Employees e
    JOIN Departments d ON e.DepartmentID = d.DepartmentID
   WHERE d.[Name] = @depName

DECLARE @totalSalary MONEY
EXEC usp_DepartmentTotalSalaryOut 'Engineering',  @totalSalary OUT
SELECT @totalSalary

--6. Employees Count in Project (Scalar) 

CREATE FUNCTION dbo.ufn_ProjectEmployeesCount (@ProjectId INT) 
RETURNS INT 
AS 
BEGIN 
	DECLARE @cnt INT; 
	SELECT @cnt = COUNT(*) 
	FROM EmployeesProjects AS ep 
	WHERE ep.ProjectID = @ProjectId; 
	RETURN ISNULL(@cnt, 0); 
END 
GO -- Example: 
SELECT dbo.ufn_ProjectEmployeesCount(3) AS PeopleOnProject; 

 --7. Project Duration in Days by Project ID (Scalar)
 SELECT [Name] AS ProjectName, DATEDIFF(day, StartDate, EndDate) AS ProjectDuration 
   FROM Projects
  WHERE ProjectID = 3

DROP FUNCTION IF EXISTS udf_ProjectDurationInDaysBy
CREATE FUNCTION udf_ProjectDurationInDaysBy(@projectId INT)
RETURNS INT AS
BEGIN
	DECLARE @result INT

	SELECT @result = DATEDIFF(day, StartDate, ISNULL(EndDate, GETDATE()))
	  FROM Projects
	 WHERE ProjectID = @projectId

	RETURN @result
END

-- usage example
SELECT ProjectId, [Name] AS ProjectName, dbo.udf_ProjectDurationInDaysBy(ProjectId) AS Duration
  FROM Projects

SELECT ProjectId, [Name] AS ProjectName, dbo.udf_ProjectDurationInDaysBy(ProjectId) AS Duration
  FROM Projects
 WHERE ProjectID = 3

 CREATE FUNCTION udf_ProjectDurationInDays_2(@projectId INT)
RETURNS INT AS
BEGIN
	DECLARE @start DATETIME2
	DECLARE @end DATETIME2

	SELECT @start = StartDate, @end = EndDate
	  FROM Projects
	 WHERE ProjectID = @projectId

	IF(@end IS NULL)
		SET @end = GETDATE()

	RETURN DATEDIFF(day, @start, @end)
END

--8) Employees in a Town (Inline Table-Valued Function)
DROP FUNCTION IF EXISTS udf_EmployeesInTown
CREATE FUNCTION udf_EmployeesInTown(@townName VARCHAR(50))
RETURNS TABLE AS
RETURN
(
	SELECT 
			CONCAT(e.FirstName, ' ', e.LastName) AS FullName,
			d.[Name] AS DepName,
			e.Salary,
			t.[Name] AS TownName
	  FROM Employees e
	  JOIN Departments d ON e.DepartmentID = d.DepartmentID
	  JOIN Addresses a ON e.AddressID = a.AddressID
	  JOIN Towns t ON a.TownID = t.TownID
	 WHERE t.[Name] = @townName
)

-- usage example
SELECT *
  FROM dbo.udf_EmployeesInTown('Redmond')










