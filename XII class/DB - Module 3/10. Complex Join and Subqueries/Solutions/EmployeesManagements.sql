SELECT * FROM Employees
SELECT * FROM Departments

SELECT Id FROM Departments
 WHERE [Name] = 'Finance'

-- 1.	Служители от финансов отдел
-- Subquery solution
 SELECT FirstName, LastName
   FROM Employees
  WHERE DepartmentId IN (
	SELECT Id FROM Departments
	WHERE [Name] = 'Finance'
  )

-- JOIN solution
SELECT e.FirstName, e.LastName
  FROM Employees e
  JOIN Departments d ON e.DepartmentId = d.Id
 WHERE d.[Name] = 'Finance'


-- 2.	40-годишни или по-млади служители
 SELECT FirstName, LastName, 
	CASE
		WHEN DepartmentId = 2 THEN 'Sales'
		WHEN DepartmentId = 3 THEN 'Research and Development'
		ELSE ''
	END AS DepartmentName
   FROM Employees
  WHERE DepartmentId IN (
	SELECT Id FROM Departments
	WHERE [Name] = 'Sales' OR [Name] = 'Research and Development'
  ) AND Age <= 40

-- JOIN better/right solution
SELECT e.FirstName, e.LastName, d.[Name] AS DepartmentName
  FROM Employees e
  JOIN Departments d ON e.DepartmentId = d.Id
 WHERE (d.[Name] = 'Sales' OR d.[Name] = 'Research and Development') AND e.Age <= 40

--3.	Служители с буквата 'е' в името си
SELECT e.FirstName, e.Age, d.[Name] AS Department
  FROM Employees e
  JOIN Departments d ON e.DepartmentId = d.Id
 WHERE d.[Name] != 'Research and Development' AND e.FirstName LIKE '%e%'