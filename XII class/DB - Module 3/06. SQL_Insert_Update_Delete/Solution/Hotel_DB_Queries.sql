CREATE DATABASE Hotel

USE Hotel

--Employees (Id, FirstName, LastName, Title, Notes)
CREATE TABLE Employees(
	Id INT PRIMARY KEY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Title NVARCHAR(10),
	Notes NVARCHAR(100)
)

--Customers (Id, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
CREATE TABLE Customers(
	Id INT PRIMARY KEY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	PhoneNumber CHAR(10) NOT NULL,
	EmergencyName NVARCHAR(50) NOT NULL,
	EmergencyNumber CHAR(10) NOT NULL,
	Notes NVARCHAR(100)
)

--RoomStatus (Id, RoomStatus, Notes)
CREATE TABLE RoomStatus(
	Id INT PRIMARY KEY,
	RoomStatus BIT DEFAULT 0, -- 0 means the room is available
	Notes NVARCHAR(100)
)

--RoomTypes (Id, RoomType, Notes)
CREATE TABLE RoomTypes(
	Id INT PRIMARY KEY,
	RoomType NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(100)
)

--DROP TABLE RoomTypes

--BedTypes (Id, BedType, Notes)
CREATE TABLE BedTypes(
	Id INT PRIMARY KEY,
	BedType NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(100)
)

--Rooms (RoomNumber, RoomTypeId, BedTypeId, Rate, RoomStatusId, Notes)
CREATE TABLE Rooms(
	RoomNumber INT PRIMARY KEY,
	RoomTypeId INT FOREIGN KEY REFERENCES RoomTypes(Id),
	BedTypeId INT,
	Rate INT DEFAULT 1,
	RoomStatusId INT NOT NULL,
	Notes NVARCHAR(100),
	CONSTRAINT FK_Rooms_BedTypes FOREIGN KEY (BedTypeId) REFERENCES BedTypes(Id)
)

--Add new foreign key in table Rooms
ALTER TABLE Rooms
ADD CONSTRAINT FK_Rooms_RoomStatus FOREIGN KEY (RoomStatusId) REFERENCES RoomStatus(Id)

--Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
CREATE TABLE Payments(
	Id INT PRIMARY KEY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	PaymentDate DATETIME2 NOT NULL,
	AccountNumber CHAR(22) NOT NULL,
	FirstDateOccupied DATETIME2 NOT NULL,
	LastDateOccupied DATETIME2 NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL(18,2) NOT NULL,
	TaxRate FLOAT,
	TaxAmount DECIMAL NOT NULL,
	PaymentTotal DECIMAL NOT NULL,
	Notes NVARCHAR(100) 
)

--Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
CREATE TABLE Occupancies(
	Id INT PRIMARY KEY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	DateOccupied DATETIME2 NOT NULL,
	AccountNumber CHAR(22) NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied FLOAT NOT NULL,
	PhoneCharge DECIMAL,
	Notes NVARCHAR(100) 
)

--insert data

INSERT INTO Employees (Id, FirstName, LastName, Title, Notes) 
	 VALUES (1, 'Anna', 'Lee', 'Manager', 'Experienced in project management'),
		   (2, 'Brian', 'Carter', 'Dev', 'Skilled in C# and SQL'),
		   (3, 'Christina', 'Martinez', 'QA', 'Detail-oriented QA tester'),
		   (4, 'David', 'Robinson', 'HR', 'Specialized in recruitment'),
		   (5, 'Eva', 'Kim', 'Intern', 'Learning software development')

-- insert into Customers
INSERT INTO Customers (Id, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) 
     VALUES (1, 'Emily', 'Jones', '5551234567', 'John Jones', '5557654321', 'NKA (No known allergies)'),
	(2, 'Michael', 'Brown', '5552345678', 'Anna Brown', '5558765432', 'Diabetic'),
	(3, 'Sarah', 'Wilson', '5553456789', 'David Wilson', '5559876543', 'Asthmatic'),
	(4, 'James', 'Taylor', '5554567890', 'Laura Taylor', '5550987654', 'Vegetarian'),
	(5, 'Sophia', 'Anderson', '5555678901', 'Mark Anderson', '5551230987', 'Gluten intolerant')

-- insert into RoomStatus
INSERT INTO RoomStatus (Id, RoomStatus, Notes) 
     VALUES (6, 0, 'Available - ready for new guests'),
			(7, 1, 'Occupied - currently in use'),
			(8, 0, 'Available - needs cleaning'),
			(9, 1, 'Occupied - under maintenance'),
			(12, 0, 'Available - reserved for future use')



-- insert into RoomTypes
INSERT INTO RoomTypes (Id, RoomType, Notes) 
     VALUES (1, 'Standard', 'Basic room with essential amenities'),
			(2, 'Deluxe', 'Spacious room with premium amenities'),
			(3, 'Suite', 'Luxurious room with additional space'),
			(4, 'Family', 'Room designed for family stays'),
			(5, 'Economy', 'Affordable room with necessary amenities')




INSERT INTO BedTypes (Id, BedType, Notes) 
     VALUES (6, 'Full', 'Suitable for two people'),
			(7, 'California King', 'Extra-long, extra-wide'),
			(8, 'Bunk', 'Two beds stacked for space saving'),
			(9, 'Murphy', 'Fold-down bed to save space'),
			(10, 'Daybed', 'Can be used as a sofa or bed');


-- insert into Rooms
INSERT INTO Rooms (RoomNumber, RoomTypeId, BedTypeId, Rate, RoomStatusId, Notes) 
	 VALUES (101, 1, 2, 150, 1, 'Sea view, king bed'),
			(102, 2, 1, 200, 1, 'City view, double bed'),
			(103, 1, 3, 175, 2, 'Garden view, twin beds'),
			(104, 3, 1, 220, 1, 'Suite with balcony, double bed'),
			(105, 2, 2, 185, 3, 'Pool view, king bed')


-- insert into Payment
INSERT INTO Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes) 
     VALUES (6, 1, '2024-10-26 10:00:00', '1234567890123456789012', '2024-10-20 08:00:00', '2024-10-24 08:00:00', 4, 600.00, 0.10, 60.00, 660.00, 'Paid in full'),
			(7, 2, '2024-10-25 11:00:00', '2345678901234567890123', '2024-10-19 09:00:00', '2024-10-23 09:00:00', 4, 800.00, 0.12, 96.00, 896.00, 'Partial payment'),
			(8, 1, '2024-10-24 12:00:00', '3456789012345678901234', '2024-10-18 10:00:00', '2024-10-22 10:00:00', 4, 700.00, 0.15, 105.00, 805.00, 'Paid in full'),
			(9, 4, '2024-10-23 13:00:00', '4567890123456789012345', '2024-10-17 11:00:00', '2024-10-21 11:00:00', 4, 880.00, 0.18, 158.40, 1038.40, 'Late fee included'),
			(10, 5, '2024-10-22 14:00:00', '5678901234567890123456', '2024-10-16 12:00:00', '2024-10-20 12:00:00', 4, 740.00, 0.20, 148.00, 888.00, 'Discount applied')


-- insert into Occupancies
INSERT INTO Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes) 
     VALUES (1, 1, '2024-10-24 08:00:00', '1234567890123456789012', 101, 150.50, 12.75, 'Corporate event'),
			(2, 2, '2024-10-23 09:00:00', '2345678901234567890123', 102, 200.00, 15.50, 'Client meeting'),
			(3, 3, '2024-10-22 10:00:00', '3456789012345678901234', 103, 175.75, 10.00, 'Project discussion'),
			(4, 4, '2024-10-21 11:00:00', '4567890123456789012345', 104, 220.25, 20.00, 'Interview session'),
			(5, 5, '2024-10-20 12:00:00', '5678901234567890123456', 105, 185.00, 18.75, 'Training workshop')


-- 11.
SELECT TaxRate
  FROM Payments

UPDATE Payments
   SET TaxRate = TaxRate - 0.03

SELECT TaxRate
  FROM Payments

-- 12.
SELECT COUNT(*) AS [Count] FROM Occupancies

DELETE FROM Occupancies

SELECT COUNT(*) AS [Count] FROM Occupancies