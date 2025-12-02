------------------------------------------------------------
-- Създаване на базата данни TravelAgency
------------------------------------------------------------
IF DB_ID('TravelAgency') IS NOT NULL
BEGIN
    ALTER DATABASE TravelAgency SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE TravelAgency;
END
GO

CREATE DATABASE TravelAgency;
GO

USE TravelAgency;
GO

------------------------------------------------------------
-- Таблица: Tourists (туристи / клиенти)
------------------------------------------------------------
CREATE TABLE Tourists
(
    Id         INT IDENTITY(1,1)  NOT NULL PRIMARY KEY,
    FirstName  NVARCHAR(50)       NOT NULL,
    LastName   NVARCHAR(50)       NOT NULL,
    Country    NVARCHAR(50)       NOT NULL,
    City       NVARCHAR(50)       NOT NULL,
    Phone      NVARCHAR(20)       NULL,
    Email      NVARCHAR(80)       NULL,
    BirthDate  DATE               NULL,
    CONSTRAINT UQ_Tourists_Email UNIQUE (Email)
);
GO

------------------------------------------------------------
-- Таблица: Destinations (дестинации)
------------------------------------------------------------
CREATE TABLE Destinations
(
    Id          INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Country     NVARCHAR(50)      NOT NULL,
    City        NVARCHAR(50)      NOT NULL,
    [Description] NVARCHAR(255)   NULL,
    CONSTRAINT UQ_Destinations_CityCountry UNIQUE (Country, City)
);
GO

------------------------------------------------------------
-- Таблица: Guides (екскурзоводи)
------------------------------------------------------------
CREATE TABLE Guides
(
    Id        INT IDENTITY(1,1)   NOT NULL PRIMARY KEY,
    FirstName NVARCHAR(50)        NOT NULL,
    LastName  NVARCHAR(50)        NOT NULL,
    [Language] NVARCHAR(50)       NOT NULL,
    Phone     NVARCHAR(20)        NULL,
    Email     NVARCHAR(80)        NULL
);
GO

------------------------------------------------------------
-- Таблица: Tours (екскурзии / туристически пакети)
------------------------------------------------------------
CREATE TABLE Tours
(
    Id             INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name]         NVARCHAR(100)     NOT NULL,
    DestinationId  INT               NOT NULL,
    StartDate      DATE              NOT NULL,
    EndDate        DATE              NOT NULL,
    PricePerPerson DECIMAL(10,2)     NOT NULL,
    MaxSeats       INT               NOT NULL,
    CONSTRAINT FK_Tours_Destinations
        FOREIGN KEY (DestinationId) REFERENCES Destinations(Id),
    CONSTRAINT CHK_Tours_Dates
        CHECK (EndDate >= StartDate),
    CONSTRAINT CHK_Tours_MaxSeats
        CHECK (MaxSeats > 0)
);
GO

------------------------------------------------------------
-- Свързваща таблица 1: TourBookings (M:N – туристи <-> екскурзии)
------------------------------------------------------------
CREATE TABLE TourBookings
(
    TourId       INT           NOT NULL,
    TouristId    INT           NOT NULL,
    BookingDate  DATE          NOT NULL,
    PeopleCount  INT           NOT NULL,
    PaymentStatus NVARCHAR(20) NOT NULL, -- 'Pending', 'Paid', 'Cancelled'
    CONSTRAINT PK_TourBookings PRIMARY KEY (TourId, TouristId),
    CONSTRAINT FK_TourBookings_Tours
        FOREIGN KEY (TourId) REFERENCES Tours(Id),
    CONSTRAINT FK_TourBookings_Tourists
        FOREIGN KEY (TouristId) REFERENCES Tourists(Id),
    CONSTRAINT CHK_TourBookings_People
        CHECK (PeopleCount > 0)
);
GO

------------------------------------------------------------
-- Свързваща таблица 2: TourGuides (M:N – екскурзии <-> екскурзоводи)
------------------------------------------------------------
CREATE TABLE TourGuides
(
    TourId  INT           NOT NULL,
    GuideId INT           NOT NULL,
    [Role]  NVARCHAR(20)  NOT NULL, -- 'Lead', 'Assistant'
    CONSTRAINT PK_TourGuides PRIMARY KEY (TourId, GuideId),
    CONSTRAINT FK_TourGuides_Tours
        FOREIGN KEY (TourId) REFERENCES Tours(Id),
    CONSTRAINT FK_TourGuides_Guides
        FOREIGN KEY (GuideId) REFERENCES Guides(Id)
);
GO

------------------------------------------------------------
-- Примерни данни
------------------------------------------------------------

-------------------------
-- Destinations
-------------------------
INSERT INTO Destinations (Country, City, [Description]) VALUES
(N'Франция',   N'Париж',      N'Уикенд в града на любовта'),
(N'Италия',    N'Рим',        N'Антични забележителности и кухня'),
(N'Испания',   N'Барселона',  N'Море, архитектура и нощен живот'),
(N'Гърция',    N'Атина',      N'История и средиземноморски климат'),
(N'България',  N'Варна',      N'Морска почивка на Черно море'),
(N'Австрия',   N'Виена',      N'Култура, музика и коледен базар');
GO

-------------------------
-- Tourists
-------------------------
INSERT INTO Tourists (FirstName, LastName, Country, City, Phone, Email, BirthDate) VALUES
(N'Иван',     N'Иванов',     N'България', N'София',    N'+359881111111', N'ivan.ivanov@example.com',    '2006-03-12'),
(N'Мария',    N'Петкова',    N'България', N'Пловдив',  N'+359888222222', N'maria.petkova@example.com',  '2007-07-25'),
(N'Георги',   N'Георгиев',   N'България', N'Варна',    N'+359887333333', N'georgi.g@example.com',       '2005-11-05'),
(N'Симона',   N'Димитрова',  N'България', N'Бургас',   N'+359886444444', N'simona.d@example.com',       '2006-01-30'),
(N'Алекс',    N'Стоянов',    N'България', N'Русе',     N'+359885555555', N'alex.stoyanov@example.com',  '2005-05-18'),
(N'Даниела',  N'Николова',   N'България', N'Стара Загора', N'+359884666666', N'daniela.n@example.com',  '2007-09-02'),
(N'Калоян',   N'Илиев',      N'България', N'София',    N'+359883777777', N'kaloyan.i@example.com',      '2006-12-11'),
(N'Никол',    N'Тонева',     N'България', N'Плевен',   N'+359882888888', N'nikol.t@example.com',        '2005-02-09');
GO

-------------------------
-- Guides
-------------------------
INSERT INTO Guides (FirstName, LastName, [Language], Phone, Email) VALUES
(N'Петър',    N'Атанасов',   N'Български / Английски', N'+359878111111', N'petar.guide@example.com'),
(N'Елена',    N'Караиванова',N'Български / Италиански', N'+359878222222', N'elena.guide@example.com'),
(N'Христо',   N'Колев',      N'Български / Испански', N'+359878333333', N'hristo.guide@example.com'),
(N'Виктория', N'Иванова',    N'Български / Гръцки',   N'+359878444444', N'viktoria.guide@example.com'),
(N'Мартин',   N'Стефанов',   N'Български / Немски',   N'+359878555555', N'martin.guide@example.com');
GO

-------------------------
-- Tours
-------------------------
INSERT INTO Tours ([Name], DestinationId, StartDate, EndDate, PricePerPerson, MaxSeats) VALUES
(N'Пролетен уикенд в Париж',    1, '2025-04-10', '2025-04-14',  950.00,  20),
(N'Рим – градът на вечността',  2, '2025-05-01', '2025-05-05',  880.00,  25),
(N'Барселона и Коста Брава',    3, '2025-06-15', '2025-06-21', 1050.00,  30),
(N'Атина – в сърцето на историята', 4, '2025-04-28', '2025-05-02', 720.00,  18),
(N'Лято във Варна',             5, '2025-07-10', '2025-07-17',  540.00,  40),
(N'Коледен базар във Виена',    6, '2025-12-15', '2025-12-19',  690.00,  22),
(N'Класически тур Париж–Рим',   1, '2025-08-05', '2025-08-12', 1300.00,  28),
(N'Средиземноморски микс – Атина и Барселона', 4, '2025-09-01', '2025-09-09', 1450.00, 26);
GO

-------------------------
-- TourGuides (M:N – екскурзии <-> екскурзоводи)
-------------------------
INSERT INTO TourGuides (TourId, GuideId, [Role]) VALUES
(1, 1, N'Lead'),      -- Париж – Петър
(1, 5, N'Assistant'), -- Париж – Мартин
(2, 2, N'Lead'),      -- Рим – Елена
(3, 3, N'Lead'),      -- Барселона – Христо
(3, 1, N'Assistant'), -- Барселона – Петър
(4, 4, N'Lead'),      -- Атина – Виктория
(5, 1, N'Lead'),      -- Варна – Петър
(6, 5, N'Lead'),      -- Виена – Мартин
(7, 2, N'Lead'),      -- Париж–Рим – Елена
(7, 3, N'Assistant'), -- Париж–Рим – Христо
(8, 4, N'Lead'),      -- Атина+Барселона – Виктория
(8, 3, N'Assistant'); -- Атина+Барселона – Христо
GO

-------------------------
-- TourBookings (M:N – туристи <-> екскурзии)
-------------------------
INSERT INTO TourBookings (TourId, TouristId, BookingDate, PeopleCount, PaymentStatus) VALUES
-- Пролетен уикенд в Париж
(1, 1, '2025-02-01', 1, N'Paid'),
(1, 2, '2025-02-05', 2, N'Paid'),
(1, 6, '2025-02-10', 1, N'Pending'),
-- Рим – градът на вечността
(2, 3, '2025-03-01', 1, N'Paid'),
(2, 4, '2025-03-03', 1, N'Paid'),
-- Барселона и Коста Брава
(3, 2, '2025-03-15', 1, N'Paid'),
(3, 5, '2025-03-16', 3, N'Pending'),
(3, 7, '2025-03-20', 1, N'Paid'),
-- Лято във Варна
(5, 1, '2025-04-01', 2, N'Paid'),
(5, 8, '2025-04-02', 4, N'Pending'),
-- Коледен базар във Виена
(6, 4, '2025-09-15', 1, N'Pending'),
(6, 3, '2025-09-16', 2, N'Paid'),
-- Класически тур Париж–Рим
(7, 6, '2025-05-10', 1, N'Paid'),
(7, 7, '2025-05-11', 1, N'Pending'),
-- Средиземноморски микс – Атина и Барселона
(8, 2, '2025-06-01', 2, N'Paid'),
(8, 5, '2025-06-02', 1, N'Pending');
GO

------------------------------------------------------------
-- Примерни проверки
------------------------------------------------------------
-- SELECT * FROM Tourists;
-- SELECT * FROM Destinations;
-- SELECT * FROM Guides;
-- SELECT * FROM Tours;
-- SELECT * FROM TourGuides;
-- SELECT * FROM TourBookings;
