/* ============================
   EventPlannerDB.sql
   ============================ */

IF DB_ID('EventPlannerDB') IS NULL
BEGIN
    CREATE DATABASE EventPlannerDB;
END
GO

USE EventPlannerDB;
GO

-- Drop tables (safe re-run)
IF OBJECT_ID('dbo.Registrations', 'U') IS NOT NULL DROP TABLE dbo.Registrations;
IF OBJECT_ID('dbo.Events', 'U') IS NOT NULL DROP TABLE dbo.Events;
IF OBJECT_ID('dbo.Venues', 'U') IS NOT NULL DROP TABLE dbo.Venues;
IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL DROP TABLE dbo.Users;
GO

-- 1) Users
CREATE TABLE dbo.Users
(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(120) NOT NULL UNIQUE,
    CreatedAt DATETIME2 NOT NULL CONSTRAINT DF_Users_CreatedAt DEFAULT (SYSUTCDATETIME())
);
GO

-- 2) Venues
CREATE TABLE dbo.Venues
(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(120) NOT NULL,
    City NVARCHAR(80) NOT NULL,
    Address NVARCHAR(160) NOT NULL,
    Capacity INT NOT NULL CHECK (Capacity > 0)
);
GO

-- 3) Events (FK -> Venues, FK -> Users as Organizer)
CREATE TABLE dbo.Events
(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Title NVARCHAR(140) NOT NULL,
    StartUtc DATETIME2 NOT NULL,
    EndUtc DATETIME2 NOT NULL,
    VenueId INT NOT NULL,
    OrganizerUserId INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL CONSTRAINT DF_Events_Price DEFAULT (0),
    CONSTRAINT CK_Events_Time CHECK (EndUtc > StartUtc),
    CONSTRAINT FK_Events_Venues FOREIGN KEY (VenueId) REFERENCES dbo.Venues(Id) ON DELETE NO ACTION,
    CONSTRAINT FK_Events_Users FOREIGN KEY (OrganizerUserId) REFERENCES dbo.Users(Id) ON DELETE NO ACTION
);
GO

-- 4) Registrations (many-to-many-ish between Users and Events)
CREATE TABLE dbo.Registrations
(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    UserId INT NOT NULL,
    EventId INT NOT NULL,
    RegisteredAtUtc DATETIME2 NOT NULL CONSTRAINT DF_Registrations_RegisteredAtUtc DEFAULT (SYSUTCDATETIME()),
    Status NVARCHAR(20) NOT NULL CONSTRAINT DF_Registrations_Status DEFAULT ('Confirmed'),
    CONSTRAINT FK_Registrations_Users FOREIGN KEY (UserId) REFERENCES dbo.Users(Id) ON DELETE CASCADE,
    CONSTRAINT FK_Registrations_Events FOREIGN KEY (EventId) REFERENCES dbo.Events(Id) ON DELETE CASCADE,
    CONSTRAINT UQ_Registrations_User_Event UNIQUE (UserId, EventId),
    CONSTRAINT CK_Registrations_Status CHECK (Status IN ('Confirmed','Cancelled','Waitlist'))
);
GO

/* ===== Inserts ===== */

-- Users (10)
INSERT INTO dbo.Users (Username, FullName, Email) VALUES
('alexw',   'Alex Walker',   'alex.walker@example.com'),
('mariah',  'Maria Hughes',  'maria.hughes@example.com'),
('johnc',   'John Carter',   'john.carter@example.com'),
('sarahk',  'Sarah King',    'sarah.king@example.com'),
('davidp',  'David Parker',  'david.parker@example.com'),
('emilyr',  'Emily Reed',    'emily.reed@example.com'),
('liamt',   'Liam Turner',   'liam.turner@example.com'),
('noahb',   'Noah Brooks',   'noah.brooks@example.com'),
('oliviam', 'Olivia Moore',  'olivia.moore@example.com'),
('ethans',  'Ethan Scott',   'ethan.scott@example.com');
GO

-- Venues (10)
INSERT INTO dbo.Venues (Name, City, Address, Capacity) VALUES
('Riverside Hall',   'London',   '12 River St',     300),
('Skyline Center',   'Berlin',   '8 Tower Ave',     450),
('Green Park Hub',   'Dublin',   '45 Park Lane',    200),
('Sunset Auditorium','Madrid',   '3 Sunset Blvd',   600),
('Harbor Conference','Oslo',     '77 Harbor Rd',    350),
('Maple Theater',    'Toronto',  '19 Maple St',     250),
('Tech Loft',        'Amsterdam','5 Canal Way',     180),
('Grand Forum',      'Paris',    '101 Forum Sq',    800),
('City Expo',        'Vienna',   '66 Expo Ring',    500),
('Nova Studio',      'Prague',   '27 Nova Street',  120);
GO

-- Events (10)  (VenueId 1..10, OrganizerUserId 1..10)
INSERT INTO dbo.Events (Title, StartUtc, EndUtc, VenueId, OrganizerUserId, Price) VALUES
('AI Basics Workshop',     '2026-03-05T10:00:00Z', '2026-03-05T13:00:00Z', 7, 1, 25.00),
('Startup Pitch Night',    '2026-03-07T18:00:00Z', '2026-03-07T21:00:00Z', 1, 2, 10.00),
('Cloud Essentials',       '2026-03-10T09:00:00Z', '2026-03-10T12:30:00Z', 2, 3, 30.00),
('Design Thinking',        '2026-03-12T11:00:00Z', '2026-03-12T15:00:00Z', 3, 4, 20.00),
('Data Analytics 101',     '2026-03-15T10:00:00Z', '2026-03-15T14:00:00Z', 6, 5, 35.00),
('Cybersecurity Meetup',   '2026-03-18T17:30:00Z', '2026-03-18T20:00:00Z', 5, 6, 0.00),
('Mobile Dev Sprint',      '2026-03-20T09:30:00Z', '2026-03-20T16:30:00Z', 10,7, 15.00),
('Open Source Hackday',    '2026-03-22T10:00:00Z', '2026-03-22T18:00:00Z', 8, 8, 0.00),
('Product Management',     '2026-03-25T12:00:00Z', '2026-03-25T16:00:00Z', 9, 9, 40.00),
('DevOps Bootcamp Intro',  '2026-03-28T09:00:00Z', '2026-03-28T12:00:00Z', 4,10, 50.00);
GO

-- Registrations (10)
INSERT INTO dbo.Registrations (UserId, EventId, Status) VALUES
(2, 1, 'Confirmed'),
(3, 1, 'Confirmed'),
(4, 2, 'Confirmed'),
(5, 2, 'Waitlist'),
(6, 3, 'Confirmed'),
(7, 4, 'Confirmed'),
(8, 5, 'Confirmed'),
(9, 6, 'Confirmed'),
(10,7, 'Confirmed'),
(1, 8, 'Cancelled');
GO