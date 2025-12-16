-- database: Mountains

SELECT * FROM Mountains
SELECT * FROM Peaks
SELECT * FROM Continents

--01.
	SELECT p.[Name] AS HighestPeak, m.[Name] AS MountainName, MAX(p.Height) AS PeakHeight
	  FROM Mountains m
	  JOIN Peaks p ON m.Id = p.MountainId
	  JOIN Continents c ON c.Id = m.ContinentId
	 WHERE c.[Name] = 'Asia'
  GROUP BY m.[Name], p.[Name]

--02.
WITH result (cName, pName, pHeight, rowNumber) AS (
	SELECT c.[Name], p.[Name], p.Height, ROW_NUMBER() OVER 
		 (
			PARTITION BY c.Id
			ORDER BY p.Height DESC
		 ) AS rn
	  FROM Continents c
	  JOIN Mountains m ON c.Id = m.ContinentId
	  JOIN Peaks p ON m.Id = p.MountainId
	)

SELECT cName AS Continent, 
	   pName AS 'Hightest Peak Name', 
	   pHeight AS 'Hightest Peak Elevation'
  FROM result
  WHERE result.rowNumber = 1

SELECT * FROM WizzardDeposits

-- database: Gringotts

--03.
SELECT COUNT(*) AS [Count] FROM WizzardDeposits

--04.
SELECT MAX(MagicWandSize) AS LongestMagicWand FROM WizzardDeposits

--05.
	SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand 
	  FROM WizzardDeposits
  GROUP BY DepositGroup

--06.
	SELECT TOP 2 DepositGroup
	  FROM WizzardDeposits
  GROUP BY DepositGroup
  ORDER BY AVG(MagicWandSize)

--07.
	SELECT DepositGroup, SUM(DepositAmount) [TotalSum]
	  FROM WizzardDeposits
  GROUP BY DepositGroup

--08.
	SELECT DepositGroup, SUM(DepositAmount) [TotalSum]
	  FROM WizzardDeposits
  GROUP BY DepositGroup, MagicWandCreator
  HAVING MagicWandCreator = 'Ollivander family'

--09.
	SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum]
	  FROM WizzardDeposits
  GROUP BY DepositGroup, MagicWandCreator
	HAVING MagicWandCreator = 'Ollivander family' AND SUM(DepositAmount) > 150000
  ORDER BY SUM(DepositAmount) DESC

--10.
	SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS [MinDepositCharge]
	  FROM WizzardDeposits
  GROUP BY DepositGroup, MagicWandCreator

--11.
	SELECT
		CASE
			WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]'
		END AS [AgeGroup], COUNT(*) AS [WizardCount]
	  FROM WizzardDeposits
  GROUP BY 
		CASE
			WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]'
		END

--12.
	SELECT LEFT(FirstName, 1) AS [FirstLetter]
	  FROM WizzardDeposits
	 WHERE DepositGroup = 'Troll Chest'
  GROUP BY LEFT(FirstName, 1)






	




















