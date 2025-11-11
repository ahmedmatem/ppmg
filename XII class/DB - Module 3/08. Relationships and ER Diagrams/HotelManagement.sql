--База данни HotelManagement 
--Създайте база данни HotelManagement със следните обекти: 
--• Rooms (RoomNumber, FloorNumber, Capacity) 
--• Guests  (Id, FirstName, LastName, Age) 
--• RoomBookings (RoomNumber, FloorNumber, GuestId, CheckInDate, CheckOutDate) 
--• Services (Id, Name, Price) 
--• ServiceBookings (RoomNumber, FloorNumber, GuestId, ServiceId, CheckInDate) 
--Подсказка: Използвайте комбинирани първични ключове, където се налага. 
--Вмъкнете по 4 записа във всяка таблица. Качете тези заявки в Judge, както и заявки за селектиране на броя 
--на записите във всяка таблица.

CREATE DATABASE HotelManagement
GO
USE HotelManagement

CREATE TABLE Rooms
(
	RoomNumber INT,
	FloorNumber INT,
	Capacity INT DEFAULT 1
	PRIMARY KEY (RoomNumber, FloorNumber)
)

CREATE TABLE Guests
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Age INT CHECK(Age > 18) NOT NULL
)

-- Междинна таблица/ свързваща Guest и Rooms в релация много към много
CREATE TABLE RoomBookings
(
	RoomNumber INT,
	FloorNumber INT,
	GuestId INT FOREIGN KEY REFERENCES Guests(Id),
	CheckInDate DATETIME2,
	CheckOutDate DATETIME2	
	PRIMARY KEY (RoomNumber, FloorNumber, GuestId),
	FOREIGN KEY (RoomNumber, FloorNumber) REFERENCES Rooms(RoomNumber, FloorNumber),
)

CREATE TABLE [Services]
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	Price DECIMAL(10,2) CHECK(Price >= 0)
)

CREATE TABLE ServiceBookings
(
	RoomNumber INT,
	FloorNumber INT,
	GuestId INT FOREIGN KEY REFERENCES Guests(Id),
	ServiceId INT FOREIGN KEY REFERENCES [Services](Id),
	CheckInDate DATETIME2 NOT NULL,
	PRIMARY KEY (GuestId, ServiceId)
)