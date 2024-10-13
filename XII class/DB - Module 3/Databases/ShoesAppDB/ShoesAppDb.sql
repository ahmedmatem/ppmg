IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'ShoesAppDB')
  CREATE DATABASE ShoesAppDB
GO

USE ShoesAppDB
GO

-- CReate tables

CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(50) NOT NULL UNIQUE,
	FullName NVARCHAR(100) NOT NULL,
	PhoneNumber NVARCHAR(15),
	Email NVARCHAR(100) NOT NULL UNIQUE
)
GO

CREATE TABLE Brands(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL UNIQUE
)
GO

CREATE TABLE Sizes(
	Id INT PRIMARY KEY IDENTITY,
	EU DECIMAL(5,2) NOT NULL,
	US DECIMAL(5,2) NOT NULL,
	UK DECIMAL(5,2) NOT NULL,
	CM DECIMAL(5,2) NOT NULL,
	[IN] DECIMAL(5,2) NOT NULL
)
GO

CREATE TABLE Shoes(
	Id INT PRIMARY KEY IDENTITY,
	Model NVARCHAR(30) NOT NULL,
	Price DECIMAL(10,2) NOT NULL,
	BrandId INT FOREIGN KEY REFERENCES Brands(Id)
)
GO

CREATE TABLE Orders(
	Id INT PRIMARY KEY IDENTITY,
	ShoeId INT FOREIGN KEY REFERENCES Shoes(Id),
	SizeId INT FOREIGN KEY REFERENCES Sizes(Id),
	UserId INT FOREIGN KEY REFERENCES Users(Id)
)
GO

CREATE TABLE ShoesSizes(
	ShoeId INT FOREIGN KEY REFERENCES Shoes(Id),
	SizeId INT FOREIGN KEY REFERENCES Sizes(Id),
	CONSTRAINT PK_Shoes_Sizes PRIMARY KEY (ShoeId, SizeId)
)
GO

SET IDENTITY_INSERT Users ON;

INSERT INTO Users (Id, Username, FullName, PhoneNumber, Email) VALUES
(1, 'jdoe', 'John Doe', '555-123-4567', 'jdoe@example.com'),
(2, 'asmith', 'Alice Smith', '555-234-5678', 'asmith@example.com'),
(3, 'bwhite', 'Bob White', '555-345-6789', 'bwhite@example.com'),
(4, 'cjones', 'Carol Jones', '555-456-7890', 'cjones@example.com'),
(5, 'djames', 'David James', '555-567-8901', 'djames@example.com'),
(6, 'emiller', 'Eva Miller', '555-678-9012', 'emiller@example.com'),
(7, 'fjackson', 'Frank Jackson', '555-789-0123', 'fjackson@example.com'),
(8, 'gthomas', 'Grace Thomas', '555-890-1234', 'gthomas@example.com'),
(9, 'hwilliams', 'Henry Williams', '555-901-2345', 'hwilliams@example.com'),
(10, 'ianderson', 'Ivy Anderson', '555-012-3456', 'ianderson@example.com'),
(11, 'jwilson', 'Jack Wilson', '555-123-4560', 'jwilson@example.com'),
(12, 'kmoore', 'Karen Moore', '555-234-5671', 'kmoore@example.com'),
(13, 'llee', 'Larry Lee', '555-345-6782', 'llee@example.com'),
(14, 'mking', 'Mary King', '555-456-7893', 'mking@example.com'),
(15, 'nmartin', 'Nina Martin', '555-567-8904', 'nmartin@example.com'),
(16, 'ohernandez', 'Oscar Hernandez', '555-678-9015', 'ohernandez@example.com'),
(17, 'pperez', 'Paula Perez', '555-789-0126', 'pperez@example.com'),
(18, 'qcooper', 'Quinn Cooper', '555-890-1237', 'qcooper@example.com'),
(19, 'rwood', 'Rachel Wood', '555-901-2348', 'rwood@example.com'),
(20, 'sstewart', 'Sam Stewart', '555-012-3459', 'sstewart@example.com');

SET IDENTITY_INSERT Users OFF;

SET IDENTITY_INSERT Brands ON;

INSERT INTO Brands (Id, [Name]) VALUES
(1, 'Nike'),
(2, 'Adidas'),
(3, 'Puma'),
(4, 'Reebok'),
(5, 'New Balance'),
(6, 'Under Armour'),
(7, 'ASICS'),
(8, 'Skechers'),
(9, 'Converse'),
(10, 'Vans'),
(11, 'Fila');

SET IDENTITY_INSERT Brands OFF;

SET IDENTITY_INSERT Sizes ON;

INSERT INTO Sizes (Id, EU, US, UK, CM, [IN]) VALUES
(1, 35.0, 5.0, 2.5, 22.0, 8.66),
(2, 36.0, 5.5, 3.0, 22.5, 8.86),
(3, 37.0, 6.0, 3.5, 23.0, 9.06),
(4, 38.0, 6.5, 4.0, 23.5, 9.25),
(5, 39.0, 7.0, 4.5, 24.0, 9.45),
(6, 40.0, 7.5, 5.0, 24.5, 9.65),
(7, 41.0, 8.0, 5.5, 25.0, 9.84),
(8, 42.0, 8.5, 6.0, 25.5, 10.04),
(9, 43.0, 9.0, 6.5, 26.0, 10.24),
(10, 44.0, 9.5, 7.0, 26.5, 10.43),
(11, 45.0, 10.0, 7.5, 27.0, 10.63),
(12, 46.0, 10.5, 8.0, 27.5, 10.83);

SET IDENTITY_INSERT Sizes OFF;

SET IDENTITY_INSERT Shoes ON;

INSERT INTO Shoes (Id, Model, Price, BrandId) VALUES
(1, 'Air Max 90', 130.00, 1),
(2, 'Air Force 1', 100.00, 1),
(3, 'React Infinity Run', 160.00, 1),
(4, 'ZoomX Vaporfly', 250.00, 1),
(5, 'Pegasus 37', 120.00, 1),
(6, 'Blazer Mid', 110.00, 1),
(7, 'Dunk Low', 100.00, 1),
(8, 'Joyride Run Flyknit', 180.00, 1),
(9, 'Metcon 6', 130.00, 1),
(10, 'Free RN 5.0', 100.00, 1),
(11, 'Ultraboost 21', 180.00, 2),
(12, 'NMD_R1', 140.00, 2),
(13, 'Superstar', 85.00, 2),
(14, 'Stan Smith', 75.00, 2),
(15, 'Gazelle', 90.00, 2),
(16, 'ZX 2K Boost', 150.00, 2),
(17, 'Continental 80', 80.00, 2),
(18, 'Alphaedge 4D', 300.00, 2),
(19, 'Adizero Adios', 120.00, 2),
(20, 'Terrex Free Hiker', 200.00, 2),
(21, 'Puma Suede Classic', 70.00, 3),
(22, 'RS-X', 110.00, 3),
(23, 'Cali', 80.00, 3),
(24, 'Future Rider', 90.00, 3),
(25, 'Cell Endura', 120.00, 3),
(26, 'Ignite Limitless', 100.00, 3),
(27, 'Thunder Spectra', 120.00, 3),
(28, 'Tazon 6', 65.00, 3),
(29, 'Roma', 60.00, 3),
(30, 'Speed Cat', 95.00, 3),
(31, 'Club C 85', 75.00, 4),
(32, 'Classic Leather', 80.00, 4),
(33, 'Nano X1', 130.00, 4),
(34, 'Zig Kinetica', 120.00, 4),
(35, 'Floatride Run', 150.00, 4),
(36, 'Flexagon Force 3', 60.00, 4),
(37, 'Reebok Legacy Lifter II', 200.00, 4),
(38, 'Workout Plus', 85.00, 4),
(39, 'DMX Series 2200', 100.00, 4),
(40, 'Harmony Road 3', 130.00, 4),
(41, '574', 80.00, 5),
(42, '990v5', 175.00, 5),
(43, 'Fresh Foam 1080v11', 150.00, 5),
(44, '860v11', 130.00, 5),
(45, 'FuelCell Rebel v2', 130.00, 5),
(46, '880v11', 130.00, 5),
(47, 'HOVR Phantom', 140.00, 6),
(48, 'HOVR Sonic', 100.00, 6),
(49, 'Charged Assert 8', 70.00, 6),
(50, 'Micro G Pursuit', 75.00, 6),
(51, 'Spawn 3', 110.00, 6),
(52, 'Charged Bandit 6', 90.00, 6),
(53, 'Micro G Valsetz', 125.00, 6),
(54, 'Gel-Kayano 27', 160.00, 7),
(55, 'Gel-Nimbus 23', 150.00, 7),
(56, 'GT-2000 9', 120.00, 7),
(57, 'Gel-Quantum 360', 150.00, 7),
(58, 'D:Lites', 65.00, 8),
(59, 'GOrun Razor 3', 135.00, 8),
(60, 'Max Cushioning Elite', 90.00, 8),
(61, 'Chuck Taylor All Star', 55.00, 9),
(62, 'Chuck 70', 85.00, 9),
(63, 'One Star', 75.00, 9),
(64, 'Jack Purcell', 90.00, 9),
(65, 'Old Skool', 60.00, 10),
(66, 'Sk8-Hi', 65.00, 10),
(67, 'Authentic', 50.00, 10),
(68, 'Disruptor II', 65.00, 11),
(69, 'Ray Tracer', 75.00, 11);

SET IDENTITY_INSERT Shoes OFF;

INSERT INTO ShoesSizes (ShoeId, SizeId) VALUES
(1, 1), (1, 3), (1, 5), (1, 7), (1, 9),
(2, 2), (2, 4), (2, 6), (2, 8), (2, 9), (2, 10),
(3, 1), (3, 3), (3, 5), (3, 7), (3, 9), (3, 11),
(4, 2), (4, 4), (4, 6), (4, 8), (4, 10),
(5, 1), (5, 3), (5, 5), (5, 9), (5, 10), (5, 11),
(6, 2), (6, 4), (6, 6), (6, 10), (6, 12),
(7, 1), (7, 3), (7, 5), (7, 7), (7, 9), (7, 11),
(8, 2), (8, 4), (8, 7), (8, 8), (8, 10), (8, 12),
(9, 1), (9, 3), (9, 7), (9, 9), (9, 11),
(10, 2), (10, 4), (10, 5), (10, 6), (10, 8), (10, 10), (10, 12),
(11, 1), (11, 3), (11, 4), (11, 5), (11, 7), (11, 9),
(12, 2), (12, 4), (12, 6), (12, 8), (12, 10),
(13, 1), (13, 3), (13, 5), (13, 7), (13, 11),
(14, 2), (14, 3), (14, 4), (14, 6), (14, 8), (14, 10),
(15, 1), (15, 3), (15, 5), (15, 9), (15, 11),
(16, 2), (16, 4), (16, 6), (16, 10), (16, 11), (16, 12),
(17, 1), (17, 5), (17, 7), (17, 9), (17, 11),
(18, 2), (18, 4), (18, 8), (18, 10), (18, 12),
(19, 1), (19, 3), (19, 7), (19, 8), (19, 9), (19, 11),
(20, 2), (20, 6), (20, 8), (20, 10), (20, 12),
(21, 1), (21, 2), (21, 3), (21, 5), (21, 7), (21, 9),
(22, 2), (22, 4), (22, 5), (22, 6), (22, 8), (22, 10), (22, 11),
(23, 1), (23, 3), (23, 5), (23, 7), (23, 11),
(24, 2), (24, 4), (24, 6), (24, 8), (24, 10),
(25, 1), (25, 3), (25, 5), (25, 9), (25, 11),
(26, 2), (26, 4), (26, 6), (26, 10), (26, 12),
(27, 1), (27, 5), (27, 7), (27, 9), (27, 11),
(28, 2), (28, 4), (28, 8), (28, 10), (28, 11), (28, 12),
(29, 1), (29, 3), (29, 7), (29, 9), (29, 11),
(30, 2), (30, 4), (30, 6), (30, 8), (30, 10), (30, 12),
(31, 1), (31, 3), (31, 5), (31, 7), (31, 8), (31, 9),
(32, 2), (32, 4), (32, 6), (32, 8), (32, 10), (32, 12),
(33, 1), (33, 2), (33, 3), (33, 5), (33, 7), (33, 11),
(34, 2), (34, 4), (34, 5), (34, 6), (34, 8), (34, 10),
(35, 1), (35, 3), (35, 5), (35, 7), (35, 9), (35, 11),
(36, 2), (36, 4), (36, 6), (36, 10), (36, 12),
(37, 1), (37, 3), (37, 5), (37, 7), (37, 9), (37, 11),
(38, 2), (38, 4), (38, 6), (38, 8), (38, 9), (38, 10), (38, 12),
(39, 1), (39, 3), (39, 7), (39, 9), (39, 11),
(40, 2), (40, 6), (40, 8), (40, 10), (40, 11), (40, 12),
(41, 1), (41, 3), (41, 5), (41, 7), (41, 9),
(42, 2), (42, 4), (42, 6), (42, 8), (42, 10),
(43, 1), (43, 3), (43, 5), (43, 7), (43, 8), (43, 11),
(44, 2), (44, 4), (44, 6), (44, 8), (44, 10), (44, 12),
(45, 1), (45, 2), (45, 3), (45, 5), (45, 9), (45, 11),
(46, 2), (46, 4), (46, 5), (46, 6), (46, 10), (46, 12),
(47, 1), (47, 5), (47, 7), (47, 9), (47, 11),
(48, 2), (48, 4), (48, 8), (48, 10), (48, 12),
(49, 1), (49, 3), (49, 7), (49, 9), (49, 11),
(50, 2), (50, 6), (50, 8), (50, 10), (50, 12),
(51, 1), (51, 5), (51, 7), (51, 9), (51, 11),
(52, 2), (52, 4), (52, 8), (52, 10), (52, 12),
(53, 1), (53, 3), (53, 7), (53, 9), (53, 11),
(54, 2), (54, 6), (54, 8), (54, 10), (54, 12),
(55, 1), (55, 5), (55, 7), (55, 9), (55, 11),
(56, 2), (56, 4), (56, 6), (56, 10), (56, 12),
(57, 1), (57, 3), (57, 5), (57, 7), (57, 9),
(58, 2), (58, 4), (58, 6), (58, 8), (58, 10), (58, 12),
(59, 1), (59, 5), (59, 7), (59, 9), (59, 11),
(60, 2), (60, 6), (60, 8), (60, 10), (60, 12),
(61, 1), (61, 3), (61, 5), (61, 7), (61, 9),
(62, 2), (62, 4), (62, 6), (62, 8), (62, 10),
(63, 1), (63, 3), (63, 5), (63, 7), (63, 11),
(64, 2), (64, 4), (64, 6), (64, 8), (64, 10),
(65, 1), (65, 3), (65, 5), (65, 7), (65, 9),
(66, 2), (66, 4), (66, 6), (66, 8), (66, 10),
(67, 1), (67, 3), (67, 5), (67, 7), (67, 11),
(68, 2), (68, 4), (68, 6), (68, 8), (68, 10),
(69, 1), (69, 3), (69, 5), (69, 7), (69, 9);

SET IDENTITY_INSERT Orders ON;

INSERT INTO Orders (Id, ShoeId, SizeId, UserId) VALUES
(1, 45, 5, 14),
(2, 30, 10, 17),
(3, 5, 1, 8),
(4, 7, 3, 1),
(5, 13, 7, 9),
(6, 38, 9, 2),
(7, 58, 6, 6),
(8, 22, 11, 19),
(9, 14, 3, 7),
(10, 25, 11, 12),
(11, 17, 11, 3),
(12, 6, 6, 15),
(13, 67, 1, 11),
(14, 4, 6, 20),
(15, 55, 5, 5),
(16, 29, 9, 4),
(17, 51, 7, 10),
(18, 21, 2, 16),
(19, 47, 9, 18),
(20, 10, 2, 13),
(21, 60, 6, 14),
(22, 11, 7, 17),
(23, 32, 10, 8),
(24, 2, 6, 19),
(25, 44, 8, 7),
(26, 3, 3, 12),
(27, 19, 3, 6),
(28, 34, 10, 15),
(29, 53, 9, 2),
(30, 12, 10, 20),
(31, 48, 8, 1),
(32, 37, 7, 3),
(33, 9, 3, 11),
(34, 41, 9, 16),
(35, 62, 4, 18),
(36, 27, 5, 13),
(37, 15, 11, 14),
(38, 66, 4, 17),
(39, 28, 10, 8),
(40, 52, 12, 19),
(41, 16, 10, 4),
(42, 31, 1, 5),
(43, 36, 10, 10),
(44, 18, 4, 7),
(45, 43, 5, 12),
(46, 8, 7, 9),
(47, 63, 7, 2),
(48, 23, 11, 20),
(49, 40, 10, 1),
(50, 24, 10, 6);
SET IDENTITY_INSERT Orders OFF;