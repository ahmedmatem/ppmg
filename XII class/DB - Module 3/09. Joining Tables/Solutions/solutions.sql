
SELECT * FROM Employees
SELECT * FROM Departments
SELECT * FROM Addresses
--01.
	SELECT TOP 5 e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText
	  FROM Employees e
	  JOIN Addresses a
	    ON e.AddressID = a.AddressID
  ORDER BY e.AddressID ASC

--02.
	SELECT TOP 5 e.EmployeeID, e.FirstName, e.Salary, d.[Name]
	  FROM Employees e
	  JOIN Departments d
	    ON e.DepartmentID = d.DepartmentID
	 WHERE e.Salary > 15000
  ORDER BY e.DepartmentID ASC

--03.
SELECT * FROM Employees
SELECT * FROM EmployeesProjects

	SELECT TOP 3 e.EmployeeID, e.FirstName
	  FROM Employees e
 LEFT JOIN EmployeesProjects ep
		ON e.EmployeeID = ep.EmployeeID
	 WHERE ep.ProjectID IS NULL
  ORDER BY e.EmployeeID ASC

--04.
SELECT * FROM Employees
SELECT * FROM EmployeesProjects
SELECT * FROM Projects

	SELECT TOP 5 e.EmployeeID, e.FirstName, p.[Name] AS [ProjectName]
	  FROM Employees e
	  JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
	  JOIN Projects p ON ep.ProjectID = p.ProjectID
	 WHERE p.StartDate > '08/13/2002' AND p.EndDate IS NULL
  ORDER BY e.EmployeeID ASC

--05.
SELECT * FROM Employees

	SELECT e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName AS ManagerName
	  FROM Employees e
	  JOIN Employees m
	    ON e.ManagerID = m.EmployeeID
	 WHERE e.ManagerID = 3 OR e.ManagerID = 7
  ORDER BY e.EmployeeID ASC