SELECT * FROM Employees

SELECT * FROM Departments

SELECT * FROM Addresses

SELECT * FROM Towns

SELECT e.FirstName, e.LastName, d.Name
  FROM Employees AS e
  RIGHT OUTER JOIN Departments AS d
    ON e.DepartmentID = d.DepartmentID

             SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [Employee Name],
		            e.ManagerId,
	                CONCAT(m.FirstName, ' ', m.LastName) AS [Manager Name]
			   FROM Employees e
    FULL OUTER JOIN Employees m
                 ON e.ManagerID = m.EmployeeID
           ORDER BY [ManagerId]

	UPDATE Employees
	   SET DepartmentID = 17
	 WHERE FirstName = 'Guy'

SELECT e.FirstName, a.AddressText AS Street, t.[Name] AS City
  FROM Employees AS e
  JOIN Addresses AS a ON e.AddressID = a.AddressID
  JOIN Towns AS t ON a.TownID = t.TownID

  SELECT *
    FROM Addresses a
	LEFT JOIN Towns t
	  ON t.TownID = a.TownID