IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'RailwaysDb')
	CREATE DATABASE RailwaysDb
GO

USE RailwaysDb
GO

CREATE TABLE Passengers(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(80) NOT NULL
)
GO

CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)
GO

CREATE TABLE RailwayStations(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	TownId INT NOT NULL,
	CONSTRAINT FK_RailwayStation_Town FOREIGN KEY (TownId) REFERENCES Towns(Id)
)
GO

CREATE TABLE Trains(
	Id INT PRIMARY KEY IDENTITY,
	HourOfDeparture VARCHAR(5) NOT NULL,
	HourOfArrival VARCHAR(5) NOT NULL,
	DepartureTownId INT FOREIGN KEY REFERENCES Towns(Id),
	ArrivalTownId INT FOREIGN KEY REFERENCES Towns(Id)
)
GO

CREATE TABLE TrainsRailwayStations(
	TrainId INT FOREIGN KEY REFERENCES Trains(Id),
	RailwayStationId INT FOREIGN KEY REFERENCES RailwayStations(Id),
	CONSTRAINT PK_Train_RailwayStation PRIMARY KEY (TrainId, RailwayStationId)
)
GO

CREATE TABLE MaintenanceRecords(
	Id INT PRIMARY KEY IDENTITY,
	DateOfMaintenance DATETIME2 NOT NULL,
	Details NVARCHAR(2000) NOT NULL,
	TrainId INT NOT NULL,
	CONSTRAINT FK_MaintenaceRecord_Train FOREIGN KEY (TrainId) REFERENCES Trains(Id)
)
GO

CREATE TABLE Tickets(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(10,2) NOT NULL,
	DateOfDeparture DATETIME2 NOT NULL,
	DateOfArrival DATETIME2 NOT NULL,
	TrainId INT NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id),
	CONSTRAINT FK_Ticket_Train FOREIGN KEY (TrainId) REFERENCES Trains(id)
)
GO

USE RailwaysDb

SET IDENTITY_INSERT Passengers ON
INSERT INTO Passengers(Id, [Name]) VALUES
(1, 'James Smith'),
(2, 'Maria Garcia'),
(3, 'Muhammad Ali'),
(4, 'Ying Lee'),
(5, 'John Johnson'),
(6, 'Patricia Brown'),
(7, 'Robert Davis'),
(8, 'Linda Martinez'),
(9, 'Michael Wilson'),
(10, 'Elizabeth Taylor'),
(11, 'William Moore'),
(12, 'Barbara Jones'),
(13, 'Richard Miller'),
(14, 'Susan Anderson'),
(15, 'Joseph Thomas'),
(16, 'Jessica Hernandez'),
(17, 'Charles Jackson'),
(18, 'Sarah Martin'),
(19, 'Thomas White'),
(20, 'Karen Clark'),
(21, 'Christopher Lewis'),
(22, 'Lisa Robinson'),
(23, 'Daniel Walker'),
(24, 'Emily Young'),
(25, 'Matthew Allen'),
(26, 'Natalia Zotova'),
(27, 'Anthony Gonzalez'),
(28, 'Sofía Pérez'),
(29, 'Mark Harris'),
(30, 'Ashley Nelson'),
(31, 'Paul King'),
(32, 'Laura Wright'),
(33, 'Steven Scott'),
(34, 'Stephanie Green'),
(35, 'Andrew Adams'),
(36, 'Melissa Baker'),
(37, 'Joshua Hill'),
(38, 'Michelle Campbell'),
(39, 'Brian Carter'),
(40, 'Amanda Mitchell'),
(41, 'Kevin Roberts'),
(42, 'Rebecca Turner'),
(43, 'George Phillips'),
(44, 'Mary Campbell'),
(45, 'Kenneth Parker'),
(46, 'Maria Rodriguez'),
(47, 'Edward Evans'),
(48, 'Margaret Torres'),
(49, 'Ronald Collins'),
(50, 'Dorothy Edwards'),
(51, 'Jerry Stewart'),
(52, 'Shirley Sanchez'),
(53, 'Walter Morris'),
(54, 'Cynthia Nguyen'),
(55, 'Henry White'),
(56, 'Janet Murphy'),
(57, 'Douglas Diaz'),
(58, 'Carolyn Cook'),
(59, 'Gary Howard'),
(60, 'Ruth Ward'),
(61, 'Timothy Cox'),
(62, 'Anna Rivera'),
(63, 'Jason Wood'),
(64, 'Kathleen Brooks'),
(65, 'Frank Barnes'),
(66, 'Diana Flores'),
(67, 'Raymond Patterson'),
(68, 'Helen Bell'),
(69, 'Walter Lee'),
(70, 'Brenda Price'),
(71, 'Shawn Bennett'),
(72, 'Gloria Bailey'),
(73, 'Terry Foster'),
(74, 'Julia Powell'),
(75, 'Jack Russell'),
(76, 'Joyce Perry'),
(77, 'Harold Long'),
(78, 'Amanda Gray'),
(79, 'Wayne Richardson'),
(80, 'Beverly Ross'),
(81, 'Carl Jenkins'),
(82, 'Anne Torres'),
(83, 'Ryan Sanchez'),
(84, 'Alice James'),
(85, 'Lawrence Ramirez'),
(86, 'Marilyn Hughes'),
(87, 'Eugene Watson'),
(88, 'Emma Reyes'),
(89, 'Ralph Torres'),
(90, 'Cheryl Ortiz'),
(91, 'Roy Butler'),
(92, 'Louise Simmons'),
(93, 'Jack Kelly'),
(94, 'Marie Gonzales'),
(95, 'Bruce Howard'),
(96, 'Jacqueline Rivera'),
(97, 'Ernest Ward'),
(98, N'Дмитрий Иванов'),
(99, 'Joan Coleman'),
(100, N'Анна Петрова')
SET IDENTITY_INSERT Passengers OFF

SET IDENTITY_INSERT Towns ON;
INSERT INTO Towns (Id, [Name]) 
VALUES 
    (1, 'London'),
    (2, 'Paris'),
    (3, 'Berlin'),
    (4, 'Madrid'),
    (5, 'Rome'),
    (6, 'Amsterdam'),
    (7, 'Prague'),
    (8, 'Vienna'),
    (9, 'Moscow'),
    (10, 'Lisbon'),
    (11, 'Brussels'),
    (12, 'Warsaw'),
    (13, 'Budapest'),
    (14, 'Stockholm'),
    (15, 'Copenhagen'),
    (16, 'Helsinki'),
    (17, 'Oslo'),
    (18, 'Wroclaw'),
    (19, 'Athens'),
    (20, 'Barcelona'),
    (21, 'Munich'),
    (22, 'Milan'),
    (23, 'Frankfurt'),
    (24, 'Zurich'),
    (25, 'Geneva'),
    (26, 'Luxembourg City'),
    (27, 'Edinburgh'),
    (28, 'Manchester'),
    (29, 'Lyon'),
    (30, 'Marseille'),
    (31, 'Krakow'),
    (32, 'Gdansk'),
    (33, 'Tallinn'),
    (34, 'Riga'),
    (35, 'Vilnius'),
    (36, 'Bucharest'),
    (37, 'Sofia'),
    (38, 'Belgrade'),
    (39, 'Zagreb'),
    (40, 'Sarajevo'),
    (41, 'Ljubljana'),
    (42, 'Skopje'),
    (43, 'Tirana'),
    (44, 'Podgorica'),
    (45, 'Bratislava'),
    (46, 'Kiev'),
    (47, 'Istanbul');
SET IDENTITY_INSERT Towns OFF;

SET IDENTITY_INSERT RailwayStations ON
INSERT INTO RailwayStations (Id, [Name], TownId) VALUES
	(1, 'Paddington', 1),
    (2, 'Marylebone', 1),
    (3, 'St Pancras International', 1),
    (4, 'Gare du Nord', 2),
    (5, 'Gare Montparnasse', 2),
    (6, 'Gare Saint-Lazare', 2),
    (7, 'Berlin Hauptbahnhof', 3),
    (8, 'Berilin Ostbahnhof', 3),
    (9, 'Gesundbrunnen', 3),
    (10, 'Puerta de Atocha', 4),
    (11, 'Chamartin', 4),
    (12, 'Principe Pio', 4),
	(13, 'Termini', 5),
    (14, 'Tiburtina', 5),
    (15, 'Ostiense', 5),
    (16, 'Centraal', 6),
    (17, 'Sloterdijk', 6),
    (18, 'Amstel', 6),
    (19, 'Praha Hlavni Nadrazi', 7),
    (20, 'Praha Masarykovo Nadrazi', 7),
    (21, 'Praha Holesovice', 7),
    (22, 'Hauptbahnhof', 8),
    (23, 'Westbahnhof', 8),
    (24, 'Meidling', 8),
	(25, 'Kazansky', 9),
    (26, 'Kiyevsky', 9),
    (27, 'Leningradsky', 9),
	(28, 'Santa Apolonia', 10),
    (29, 'Oriente', 10),
    (30, 'Rossio', 10),
	(31, 'Bruxelles-Central', 11),
    (32, 'Bruxelles-Nord', 11),
    (33, 'Bruxelles-Midi', 11),
	(34, 'Centralna', 12),
    (35, 'Wschodnia', 12),
    (36, 'Zachodnia', 12),
	(37, 'Keleti', 13),
    (38, 'Nyugati', 13),
	(39, 'Sodra', 14),
    (40, 'Odenplan', 14),
    (41, 'Norreport', 15),
    (42, 'Osterport', 15),
    (43, 'Pasila', 16),
    (44, 'Huopalahti', 16),
	(45, 'Oslo Central', 17),
    (46, 'Nationaltheatret', 17),
    (47, 'Reykjavik Central', 18),
    (48, 'Athens Central', 19),
    (49, 'Larissa Station', 19),
    (50, 'Barcelona Sants', 20),
    (51, 'Passeig de Gracia', 20),
	(52, 'Munchen Hauptbahnhof', 21),
    (53, 'Munchen Ostbahnhof', 21),
	(54, 'Milano Centrale', 22),
    (55, 'Milano Porta Garibaldi', 22),
    (56, 'Milano Rogoredo', 22),
	(57, 'Frankfurt Hauptbahnhof', 23),
    (58, 'Frankfurt Sudbahnhof', 23),
    (59, 'Frankfurt Flughafen Fernbahnhof', 23),
	(60, 'Zurich Hauptbahnhof', 24),
    (61, 'Zurich Stadelhofen', 24),
    (62, 'Zurich Oerlikon', 24),
	(63, 'Geneve Cornavin', 25),
    (64, 'Geneve Eaux-Vives', 25),
    (65, 'Geneve Aeroport', 25),
	(66, 'Luxembourg Gare', 26),
    (67, 'Luxembourg Pfaffenthal-Kirchberg', 26),
	(68, 'Edinburgh Waverley', 27),
    (69, 'Edinburgh Haymarket', 27),
	(70, 'Manchester Piccadilly', 28),
    (71, 'Manchester Victoria', 28),
	(72, 'Lyon Part-Dieu', 29),
    (73, 'Lyon Perrache', 29),
	(74, 'Marseille Saint-Charles', 30),
    (75, 'Marseille Blancarde', 30),
	(76, 'Krakow Glowny', 31),
    (77, 'Krakow Plaszow', 31),
	(78, 'Gdansk Glowny', 32),
    (79, 'Gdansk Wrzeszcz', 32),
	(80, 'Tallinn Baltic Station', 33),
    (81, 'Tallinn Ulemiste', 33),
	(82, 'Riga Central', 34),
    (83, 'Riga Pasazieru', 34),
    (84, 'Vilnius Pilaite', 35),
	(85, 'București Nord', 36),
    (86, 'Sofia Central', 37),
    (87, 'Belgrade Centre', 38),
    (88, 'Zagreb Glavni kolodvor', 39),
    (89, 'Sarajevo Main', 40),
    (90, 'Ljubljana', 41),
    (91, 'Skopje', 42),
    (92, 'Tirana Central', 43),
    (93, 'Podgorica', 44),
    (94, 'Bratislava Hlavna Stanica', 45),
    (95, 'Kyiv Pasazhyrskyi', 46),
    (96, 'Istanbul Sirkeci', 47);
SET IDENTITY_INSERT RailwayStations OFF

SET IDENTITY_INSERT Trains ON
INSERT INTO Trains(Id, HourOfDeparture, HourOfArrival, DepartureTownId, ArrivalTownId) VALUES
	(1, '08:00', '10:17', 1, 2),  -- Train from London to Paris
	(2, '11:00', '13:33', 1, 2),  -- Train from London to Paris
	(3, '16:30', '19:20', 1, 2),  -- Train from London to Paris
	(4, '17:30', '20:20', 2, 1),  -- Train from Paris to London
	(5, '00:30', '03:00', 2, 1),  -- Train from Paris to London
	(6, '07:30', '10:20', 2, 1),  -- Train from Paris to London
    (7, '09:00', '05:30', 3, 4),  -- Train from Berlin to Madrid
    (8, '07:45', '03:55', 5, 6),  -- Train from Rome to Amsterdam
    (9, '14:00', '18:00', 7, 8),  -- Train from Prague to Vienna
    (10, '15:30', '06:45', 9, 10), -- Train from Moscow to Lisbon
	(11, '20:00', '10:45', 11, 12), -- Brussels to Warsaw
    (12, '18:00', '02:10', 13, 14), -- Budapest to Stockholm
    (13, '22:00', '23:30', 15, 16), -- Copenhagen to Helsinki
    (14, '21:00', '16:05', 17, 18), -- Oslo to Wroclaw
    (15, '10:00', '06:20', 19, 20), -- Athens to Barcelona
	(16, '09:30', '19:30', 21, 22), -- Munich to Milan
    (17, '08:00', '12:15', 23, 24), -- Frankfurt to Zurich
    (18, '07:00', '19:00', 25, 26), -- Geneva to Luxembourg City
    (19, '10:00', '15:10', 27, 28), -- Edinburgh to Manchester
    (20, '15:00', '16:30', 29, 30), -- Lyon to Marseille
    (21, '10:00', '18:45', 31, 32), -- Krakow to Gdansk
    (22, '09:30', '20:50', 33, 34), -- Tallinn to Riga
    (23, '14:00', '06:15', 35, 36), -- Vilnius to Bucharest
    (24, '19:00', '21:00', 37, 38), -- Sofia to Belgrade
    (25, '11:00', '13:00', 39, 40), -- Zagreb to Sarajevo
	(26, '08:30', '10:40', 41, 42), -- Ljubljana to Skopje
    (27, '12:00', '14:30', 43, 44), -- Tirana to Podgorica
    (28, '00:15', '23:45', 45, 46), -- Bratislava to Kiev
    (29, '09:50', '12:20', 47, 1),  -- Istanbul to London
    (30, '12:00', '16:00', 2, 3),   -- Paris to Berlin
    (31, '00:30', '20:00', 4, 5),   -- Madrid to Rome
    (32, '01:15', '13:30', 6, 7),   -- Amsterdam to Prague
    (33, '16:45', '19:00', 8, 9),   -- Vienna to Moscow
    (34, '00:30', '19:15', 10, 11), -- Lisbon to Brussels
    (35, '10:00', '22:10', 12, 13) -- Warsaw to Budapest
SET IDENTITY_INSERT Trains OFF

SET IDENTITY_INSERT MaintenanceRecords ON
INSERT INTO MaintenanceRecords (Id, DateOfMaintenance, Details, TrainId) VALUES
	(1, '2023-01-10', 'Routine check-up and engine maintenance', 1),
    (2, '2023-01-15', 'Brake system inspection and overhaul', 2),
    (3, '2023-01-20', 'Electrical systems diagnostic and repair', 3),
    (4, '2023-01-25', 'Wheel and axle inspection', 4),
    (5, '2023-02-01', 'Carriage interior refurbishment', 5),
	(6, '2023-02-05', 'Air conditioning system check and repair', 6),
    (7, '2023-02-10', 'Safety equipment inspection and update', 7),
    (8, '2023-02-15', 'General engine maintenance', 8),
    (9, '2023-02-20', 'Suspension system check', 9),
    (10, '2023-02-25', 'Exterior cleaning and painting', 10),
    (11, '2023-03-02', 'Control system software update', 11),
    (12, '2023-03-07', 'Brake system inspection and overhaul', 1),  -- Maintenance again for train 1
    (13, '2023-03-12', 'Interior lighting system maintenance', 2),  -- Maintenance again for train 2
    (14, '2023-03-17', 'Seat upholstery cleaning and repair', 12),
    (15, '2023-03-22', 'Toilet system inspection and maintenance', 13),
    (16, '2023-03-27', 'Communication system check', 14),
    (17, '2023-04-01', 'Door mechanism check and lubrication', 15),
    (18, '2023-04-06', 'Emergency exit signage and lighting check', 16),
    (19, '2023-04-11', 'Window sealing and insulation check', 3),   -- Maintenance again for train 3
    (20, '2023-04-16', 'Undercarriage inspection and cleaning', 17),
	(21, '2023-04-21', 'Wheel alignment and balancing', 18),
    (22, '2023-04-26', 'HVAC system check and filter replacement', 19),
    (23, '2023-05-01', 'Passenger announcement system upgrade', 20),
    (24, '2023-05-06', 'Wi-Fi system enhancement', 21),
    (25, '2023-05-11', 'Carriage coupling mechanism inspection', 22),
    (26, '2023-05-16', 'Battery and electrical system check', 23),
    (27, '2023-05-21', 'Fire detection and suppression system check', 24),
    (28, '2023-05-26', 'Fuel system and efficiency check', 25),
    (29, '2023-06-01', 'Track compatibility inspection', 26),
    (30, '2023-06-06', 'Bogie and suspension system maintenance', 27),
    (31, '2023-06-11', 'General carriage cleaning and maintenance', 28),
    (32, '2023-06-16', 'Safety compliance check', 29),
    (33, '2023-06-21', 'Engine performance tuning', 30),
    (34, '2023-06-26', 'Signal receiver and transmitter check', 31),
    (35, '2023-07-01', 'Automated control system update', 32),
    (36, '2023-07-06', 'Hydraulic system maintenance', 33),
    (37, '2023-07-11', 'Onboard kitchen equipment servicing', 34),
    (38, '2023-07-16', 'Exterior lighting and visibility check', 35)
SET IDENTITY_INSERT MaintenanceRecords OFF

SET IDENTITY_INSERT Tickets ON
INSERT INTO Tickets (Id, Price, DateOfDeparture, DateOfArrival, TrainId, PassengerId) VALUES
	(1, 50.00, '2023-08-01', '2023-08-01', 1, 1),
    (2, 75.00, '2023-08-02', '2023-08-02', 2, 2),
    (3, 60.00, '2023-08-03', '2023-08-03', 3, 3),
	(4, 55.00, '2023-09-01', '2023-09-01', 6, 21),
    (5, 45.00, '2023-09-02', '2023-09-03', 7, 22),
    (6, 65.00, '2023-09-03', '2023-09-04', 8, 23),
    (7, 50.00, '2023-09-04', '2023-09-04', 9, 24),
    (8, 180.00, '2023-09-05', '2023-09-07', 10, 25),
    (9, 60.00, '2023-09-06', '2023-09-07', 11, 26),
    (10, 55.00, '2023-09-07', '2023-09-09', 12, 27),
    (11, 75.00, '2023-09-08', '2023-09-09', 13, 28),
    (12, 80.00, '2023-09-09', '2023-09-10', 14, 29),
    (13, 50.00, '2023-09-10', '2023-09-12', 15, 30),
    (14, 45.00, '2023-09-11', '2023-09-11', 16, 31),
    (15, 85.00, '2023-09-12', '2023-09-12', 17, 32),
    (16, 90.00, '2023-09-13', '2023-09-13', 18, 33),
    (17, 95.00, '2023-09-14', '2023-09-14', 19, 34),
    (18, 55.00, '2023-09-15', '2023-09-15', 20, 35),
    (19, 60.00, '2023-09-16', '2023-09-16', 21, 36),
    (20, 70.00, '2023-09-17', '2023-09-17', 22, 37),
    (21, 65.00, '2023-09-18', '2023-09-20', 23, 38),
    (22, 75.00, '2023-09-19', '2023-09-19', 24, 39),
    (23, 80.00, '2023-09-20', '2023-09-20', 25, 40),
	(24, 50.00, '2023-09-21', '2023-09-21', 26, 41),
    (25, 85.00, '2023-09-22', '2023-09-22', 27, 42),
    (26, 55.00, '2023-09-23', '2023-09-23', 28, 43),
    (27, 275.00, '2023-09-24', '2023-09-28', 29, 44),
    (28, 60.00, '2023-09-25', '2023-09-25', 30, 45),
    (29, 65.00, '2023-09-26', '2023-09-26', 31, 46),
    (30, 90.00, '2023-09-27', '2023-09-27', 32, 47),
    (31, 70.00, '2023-09-28', '2023-09-29', 33, 48),
    (32, 80.00, '2023-09-29', '2023-09-29', 34, 49),
    (33, 95.00, '2023-09-30', '2023-09-30', 35, 50),
    (34, 55.00, '2023-10-01', '2023-10-01', 1, 51),
    (35, 65.00, '2023-10-02', '2023-10-02', 2, 52),
    (36, 75.00, '2023-10-03', '2023-10-03', 3, 53),
    (37, 85.00, '2023-10-04', '2023-10-04', 4, 54),
    (38, 50.00, '2023-10-05', '2023-10-05', 5, 55),
    (39, 60.00, '2023-10-06', '2023-10-06', 6, 56),
    (40, 70.00, '2023-10-07', '2023-10-08', 7, 57),
	(41, 45.00, '2023-10-08', '2023-10-09', 8, 58),
    (42, 80.00, '2023-10-09', '2023-10-09', 9, 59),
    (43, 180.00, '2023-10-10', '2023-10-12', 10, 60),
    (44, 75.00, '2023-10-11', '2023-10-12', 11, 61),
    (45, 65.00, '2023-10-12', '2023-10-14', 12, 62),
    (46, 50.00, '2023-10-13', '2023-10-14', 13, 63),
    (47, 70.00, '2023-10-14', '2023-10-15', 14, 64),
    (48, 85.00, '2023-10-15', '2023-10-17', 15, 65),
    (49, 90.00, '2023-10-16', '2023-10-16', 16, 66),
    (50, 60.00, '2023-10-17', '2023-10-17', 17, 67),
    (51, 55.00, '2023-10-18', '2023-10-18', 18, 68),
    (52, 95.00, '2023-10-19', '2023-10-19', 19, 69),
    (53, 45.00, '2023-10-20', '2023-10-20', 20, 70),
    (54, 80.00, '2023-10-21', '2023-10-21', 21, 71),
    (55, 75.00, '2023-10-22', '2023-10-22', 22, 72),
    (56, 50.00, '2023-10-23', '2023-10-20', 23, 73),
    (57, 65.00, '2023-10-24', '2023-10-24', 24, 74),
    (58, 70.00, '2023-10-25', '2023-10-25', 25, 75),
	(59, 85.00, '2023-10-26', '2023-10-26', 26, 76),
    (60, 55.00, '2023-10-27', '2023-10-27', 27, 77),
    (61, 65.00, '2023-10-28', '2023-10-28', 28, 78),
    (62, 275.00, '2023-10-29', '2023-11-02', 29, 79),
    (63, 50.00, '2023-10-30', '2023-10-30', 30, 80),
    (64, 70.00, '2023-10-31', '2023-10-31', 31, 81),
    (65, 90.00, '2023-11-01', '2023-11-01', 32, 82),
    (66, 60.00, '2023-11-02', '2023-11-03', 33, 83),
    (67, 55.00, '2023-11-03', '2023-11-03', 34, 84),
    (68, 80.00, '2023-11-04', '2023-11-04', 35, 85),
    (69, 95.00, '2023-11-05', '2023-11-05', 1, 86),
    (70, 45.00, '2023-11-06', '2023-11-06', 2, 87),
    (71, 50.00, '2023-11-07', '2023-11-07', 3, 88),
    (72, 65.00, '2023-11-08', '2023-11-08', 4, 89),
    (73, 75.00, '2023-11-09', '2023-11-09', 5, 90),
    (74, 85.00, '2023-11-10', '2023-11-10', 6, 91),
    (75, 55.00, '2023-11-11', '2023-11-12', 7, 92),
    (76, 60.00, '2023-11-12', '2023-11-13', 8, 93),
    (77, 70.00, '2023-11-13', '2023-11-13', 9, 94),
    (78, 180.00, '2023-11-14', '2023-11-16', 10, 95)
SET IDENTITY_INSERT Tickets OFF

INSERT INTO TrainsRailwayStations (TrainId, RailwayStationId) VALUES
(1,1),(1,4),
(2,2),(2,5),
(3,3),(3,6),
(4,1),(4,5),
(5,2),(5,6),
(6,3),(6,4),
(7,7),(7,57),(7,4),(7,10),
(8,13),(8,54),(8,60),(8,57),(8,16),
(9,19),(9,22),
(10, 25), (10, 52), (10, 57), (10, 4), (10, 50), (10, 28),
(11, 31), (11, 57), (11, 34),
(12, 37), (12, 52), (12, 60), (12, 39),
(13, 41), (13, 45), (13, 43),
(14, 45), (14, 52), (14, 57), (14, 22),
(15, 48), (15, 86), (15, 87), (15, 57), (15, 4), (15, 50),
(16, 52), (16, 54),
(17, 58), (17, 61),
(18, 64), (18, 66),
(19, 69), (19, 70),
(20, 73), (20, 74),
(21, 76), (21, 77), (21, 78),
(22, 80),(22,81), (22, 83),
(23, 35), (23, 36), (23, 12), (23, 13), (23, 37), (23, 38),
(24,86),(24,87),
(25,88),(25,89),
(26,90),(26,91),
(27,92),(27,93),
(28, 92),(28, 43),(28, 91),(28, 44),(28, 93),(28, 45),(28, 94),(28, 95),
(29, 96),(29, 86),(29, 87),(29, 22),(29, 52),(29, 4),(29, 1),
(30,4),(30,57),(30,7),
(31,10),(31,50),(31,54),(31,13),
(32,16),(32,31),(31,19),
(33, 22),(33, 52),(33, 37),(33, 34),(33, 46),(33, 25),
(34, 28),(34, 10),(34, 4),(34, 60),(34, 31),
(35,36),(35,38)