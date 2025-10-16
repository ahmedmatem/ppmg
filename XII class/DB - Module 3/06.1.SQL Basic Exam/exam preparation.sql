--Ahmed Matem - Hotel

--1.
CREATE DATABASE Hotel
USE Hotel

-- TABLES
--2.
CREATE TABLE Employees
(
	Id INT NOT NULL IDENTITY PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Title VARCHAR(30) NOT NULL,
	Notes VARCHAR(200)
)

--3.
CREATE TABLE RoomStatus
(
	Id INT PRIMARY KEY NOT NULL IDENTITY,
	RoomStatus VARCHAR(50) DEFAULT 'FREE',
	Notes VARCHAR(500)
)

--4.
CREATE TABLE BedTypes
(
	Id INT NOT NULL IDENTITY PRIMARY KEY,
	BedType VARCHAR(20) NOT NULL DEFAULT 'SINGLE',
	Notes VARCHAR(500)
)

--5.
CREATE TABLE Rooms
(
	RoomNumber VARCHAR(10) NOT NULL,
	RoomTypeId INT NOT NULL,
	BedTypeId INT NOT NULL,
	Rate INT,
	RoomStatusId INT NOT NULL,
	Notes VARCHAR(200)
)

--6
INSERT INTO BedTypes(BedType, Notes)
	 VALUES ('Single', NULL),
		    ('Double', 'Super komfortno leglo za sam chovek'),
		    ('Person and a half', 'Bez belejki')

INSERT INTO Customers(FirstName, LastName, PhoneNumber, Notes)
	 VALUES ('Ahmed', 'Matem', '123456789', NULL),
			('Tsanko', 'Bogdanow', '2233445566', 'Bez belejka'),
			('Anastasiq', 'Stojkova', '0011223344', NULL)

--7.
SELECT * FROM Customers

--8.
   SELECT TOP(3) CONCAT(FirstName, ' ', LastName) AS 'Full Name' FROM Customers
    WHERE FirstName LIKE 'A%'
 ORDER BY 'Full Name' DESC

 --9. UPDATE
 SELECT * FROM Customers

 UPDATE Customers
    SET FirstName = 'Tzanko', Notes = NULL
  WHERE Id = 2

  -- 10. DELETE
  DELETE FROM Customers
   WHERE Id = 2

  -- 11.Delete all rows
  TRUNCATE TABLE Customers

  -- 12. Delete table
  DROP TABLE Customers
