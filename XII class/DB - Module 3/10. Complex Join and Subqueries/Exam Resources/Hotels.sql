-- 1. Създаване на базата данни
USE master
GO

IF DB_ID('Hotel_DB') IS NOT NULL
DROP DATABASE Hotel_DB
GO

CREATE DATABASE Hotel_DB
GO

USE Hotel_DB
GO

-- 2. Създаване на основните таблици (7 таблици)

-- Table 1: Cities (Градове)
CREATE TABLE Cities(
    CityID INT IDENTITY(1,1) NOT NULL,
    city_name VARCHAR(100) NOT NULL,
    CONSTRAINT PK_Cities PRIMARY KEY CLUSTERED (CityID)
)
GO

-- Table 2: RoomTypes (ТиповеСтаи)
CREATE TABLE RoomTypes(
    RoomTypeID INT IDENTITY(1,1) NOT NULL,
    type_name VARCHAR(50) NOT NULL, -- Напр. Единична, Двойна, Апартамент
    description_bg VARCHAR(200),
    CONSTRAINT PK_RoomTypes PRIMARY KEY CLUSTERED (RoomTypeID)
)
GO

-- Table 3: Services (Услуги)
CREATE TABLE Services(
    ServiceID INT IDENTITY(1,1) NOT NULL,
    service_name VARCHAR(100) NOT NULL, -- Напр. Басейн, Паркинг, СПА
    price DECIMAL(10, 2),
    CONSTRAINT PK_Services PRIMARY KEY CLUSTERED (ServiceID)
)
GO

-- Table 4: Hotels (Хотели)
CREATE TABLE Hotels(
    HotelID INT IDENTITY(1,1) NOT NULL,
    hotel_name VARCHAR(150) NOT NULL,
    category INT, -- Звезди (1 до 5)
    address_bg VARCHAR(250) NOT NULL,
    CityID INT NOT NULL,
    CONSTRAINT PK_Hotels PRIMARY KEY CLUSTERED (HotelID)
)
GO

-- Table 5: Rooms (Стаи)
CREATE TABLE Rooms(
    RoomID INT IDENTITY(1,1) NOT NULL,
    room_number VARCHAR(10) NOT NULL,
    capacity INT NOT NULL,
    price_per_night DECIMAL(10, 2) NOT NULL,
    HotelID INT NOT NULL,
    RoomTypeID INT NOT NULL,
    CONSTRAINT PK_Rooms PRIMARY KEY CLUSTERED (RoomID)
)
GO

-- Table 6: Guests (Гости)
CREATE TABLE Guests(
    GuestID INT IDENTITY(1,1) NOT NULL,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    phone_number VARCHAR(20),
    CONSTRAINT PK_Guests PRIMARY KEY CLUSTERED (GuestID)
)
GO

-- Table 7: Reservations (Резервации)
CREATE TABLE Reservations(
    ReservationID INT IDENTITY(1,1) NOT NULL,
    GuestID INT NOT NULL,
    RoomID INT NOT NULL,
    check_in_date DATE NOT NULL,
    check_out_date DATE NOT NULL,
    total_price DECIMAL(10, 2),
    CONSTRAINT PK_Reservations PRIMARY KEY CLUSTERED (ReservationID)
)
GO

-- 3. Създаване на свързващите таблици (2 таблици за M:N релации)

-- Linking Table 8: HotelServices (M:N between Hotels and Services)
CREATE TABLE HotelServices(
    HotelID INT NOT NULL,
    ServiceID INT NOT NULL,
    CONSTRAINT PK_HotelServices PRIMARY KEY CLUSTERED (HotelID, ServiceID)
)
GO

-- Linking Table 9: ReservationServices (M:N between Reservations and Services)
CREATE TABLE ReservationServices(
    ReservationID INT NOT NULL,
    ServiceID INT NOT NULL,
    quantity INT DEFAULT 1,
    CONSTRAINT PK_ReservationServices PRIMARY KEY CLUSTERED (ReservationID, ServiceID)
)
GO

-- 4. Вмъкване на примерни данни (Остава на български)
SET IDENTITY_INSERT Cities ON
INSERT INTO Cities (CityID, city_name) VALUES (1, 'София'), (2, 'Варна'), (3, 'Пловдив')
SET IDENTITY_INSERT Cities OFF
GO

SET IDENTITY_INSERT RoomTypes ON
INSERT INTO RoomTypes (RoomTypeID, type_name, description_bg) VALUES
(1, 'Единична', 'Стая за един човек'),
(2, 'Двойна', 'Стая за двама с едно голямо легло'),
(3, 'Апартамент', 'Две отделни стаи с хол')
SET IDENTITY_INSERT RoomTypes OFF
GO

SET IDENTITY_INSERT Services ON
INSERT INTO Services (ServiceID, service_name, price) VALUES
(1, 'Басейн', 0.00),
(2, 'СПА Център', 50.00),
(3, 'Паркинг', 10.00),
(4, 'Закуска', 15.00)
SET IDENTITY_INSERT Services OFF
GO

SET IDENTITY_INSERT Hotels ON
INSERT INTO Hotels (HotelID, hotel_name, category, address_bg, CityID) VALUES
(101, 'Гранд Хотел София', 5, 'Ул. Витоша 1', 1),
(102, 'Морски Бриз', 4, 'Крайбрежна Алея', 2),
(103, 'Старият Пловдив', 3, 'Ул. Капана 5', 3)
SET IDENTITY_INSERT Hotels OFF
GO

SET IDENTITY_INSERT Rooms ON
INSERT INTO Rooms (RoomID, room_number, capacity, price_per_night, HotelID, RoomTypeID) VALUES
(1001, '101', 2, 80.00, 101, 2), -- Двойна в Гранд Хотел София
(1002, '205', 4, 150.00, 101, 3), -- Апартамент в Гранд Хотел София
(2001, 'А1', 2, 70.00, 102, 2), -- Двойна в Морски Бриз
(3001, '5', 1, 50.00, 103, 1)  -- Единична в Старият Пловдив
SET IDENTITY_INSERT Rooms OFF
GO

SET IDENTITY_INSERT Guests ON
INSERT INTO Guests (GuestID, first_name, last_name, email, phone_number) VALUES
(1, 'Иван', 'Петров', 'ivan.p@example.com', '0881234567'),
(2, 'Мария', 'Георгиева', 'maria.g@example.com', '0899876543')
SET IDENTITY_INSERT Guests OFF
GO

SET IDENTITY_INSERT Reservations ON
INSERT INTO Reservations (ReservationID, GuestID, RoomID, check_in_date, check_out_date, total_price) VALUES
(1, 1, 1001, '2025-12-10', '2025-12-15', 400.00), -- 5 нощувки * 80 лв.
(2, 2, 2001, '2026-01-20', '2026-01-22', 140.00)  -- 2 нощувки * 70 лв.
SET IDENTITY_INSERT Reservations OFF
GO

-- Вмъкване на данни в M:N таблиците
INSERT INTO HotelServices (HotelID, ServiceID) VALUES
(101, 1), (101, 2), (101, 3), (101, 4), -- Гранд Хотел предлага всички
(102, 1), (102, 4), -- Морски Бриз предлага Басейн и Закуска
(103, 3) -- Старият Пловдив предлага Паркинг
GO

INSERT INTO ReservationServices (ReservationID, ServiceID, quantity) VALUES
(1, 4, 5), -- Резервация 1: 5 закуски
(2, 3, 2)  -- Резервация 2: 2 дни паркинг
GO


-- 5. Дефиниране на Външни Ключове (Foreign Key Constraints)

-- Hotels -> Cities (1:N)
ALTER TABLE Hotels
ADD CONSTRAINT FK_Hotels_Cities FOREIGN KEY (CityID)
REFERENCES Cities(CityID)
GO

-- Rooms -> Hotels (1:N)
ALTER TABLE Rooms
ADD CONSTRAINT FK_Rooms_Hotels FOREIGN KEY (HotelID)
REFERENCES Hotels(HotelID)
GO

-- Rooms -> RoomTypes (1:N)
ALTER TABLE Rooms
ADD CONSTRAINT FK_Rooms_RoomTypes FOREIGN KEY (RoomTypeID)
REFERENCES RoomTypes(RoomTypeID)
GO

-- Reservations -> Guests (N:1)
ALTER TABLE Reservations
ADD CONSTRAINT FK_Reservations_Guests FOREIGN KEY (GuestID)
REFERENCES Guests(GuestID)
GO

-- Reservations -> Rooms (N:1)
ALTER TABLE Reservations
ADD CONSTRAINT FK_Reservations_Rooms FOREIGN KEY (RoomID)
REFERENCES Rooms(RoomID)
GO

-- HotelServices (Linking Table 1)
ALTER TABLE HotelServices
ADD CONSTRAINT FK_HotelServices_Hotels FOREIGN KEY (HotelID)
REFERENCES Hotels(HotelID)
GO

ALTER TABLE HotelServices
ADD CONSTRAINT FK_HotelServices_Services FOREIGN KEY (ServiceID)
REFERENCES Services(ServiceID)
GO

-- ReservationServices (Linking Table 2)
ALTER TABLE ReservationServices
ADD CONSTRAINT FK_ReservationServices_Reservations FOREIGN KEY (ReservationID)
REFERENCES Reservations(ReservationID)
GO

ALTER TABLE ReservationServices
ADD CONSTRAINT FK_ReservationServices_Services FOREIGN KEY (ServiceID)
REFERENCES Services(ServiceID)
GO

-- Проверка на данните
--SELECT * FROM Cities;
--SELECT * FROM Hotels;
--SELECT * FROM Rooms;
--SELECT * FROM RoomTypes;
--SELECT * FROM Guests;
--SELECT * FROM Services;
--SELECT * FROM Reservations;
--SELECT * FROM HotelServices;
--SELECT * FROM ReservationServices;