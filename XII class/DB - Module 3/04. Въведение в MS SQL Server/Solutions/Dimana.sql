SELECT *
  FROM Employees

--1.
SELECT *
  FROM Employees
 WHERE JobTitle = 'Sales Representative'
 --14

--2. Съединение на имена на колони
SELECT TOP (3) CONCAT(FirstName, ' ', LastName) AS FullName
  FROM Employees

--3.
SELECT DISTINCT TOP 10 LastName
  FROM Employees

--4.
SELECT FirstName, LastName, Salary
  FROM Employees
 WHERE DepartmentID = 1

--5.
SELECT TOP 5 FirstName, LastName, JobTitle
  FROM Employees
 WHERE Salary BETWEEN 20000 AND 30000

--6.
SELECT FirstName, LastName
  FROM Employees
 WHERE ManagerID IS NULL

--7.
  SELECT TOP 5 FirstName, LastName
    FROM Employees
ORDER BY Salary DESC

--8.
  SELECT TOP 5 FirstName, LastName
    FROM Employees
   WHERE DepartmentID <> 4
ORDER BY Salary DESC

--9.
  SELECT *
    FROM Employees
ORDER BY Salary DESC, FirstName, LastName DESC, MiddleName ASC


