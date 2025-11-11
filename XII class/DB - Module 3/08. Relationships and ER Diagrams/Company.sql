--База данни Company 
--Създайте база данни Company със следните обекти: 
--• Employees (Id, FirstName, LastName, Email, DepartmentId, ManagerId, AddressId) 
--• Departments  (Id, Name) 
--• Cities (Id, Name) 
--• Addresses (Id, Name, CityId) 
--Подсказка: ManagerId сочи към първичния ключ на работник. Мениджърите не могат да имат свой 
--мениджър. Помислете дали ще направите полето ManagerId задължително или не. 
--Вмъкнете по 4 записа във всяка таблица. Качете тези заявки в Judge, както и заявки за селектиране на броя 
--на записите във всяка таблица.

CREATE DATABASE Company
GO
USE Company

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL
)

CREATE TABLE Cities
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(200) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id)
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Email VARCHAR(50) UNIQUE,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
	ManagerId INT FOREIGN KEY REFERENCES Employees(Id),
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

ALTER TABLE Employees
ADD UNIQUE (AddressId)

-- INSERT STATEMENTS

-- Insert 10 records (SQL Server)
INSERT INTO Cities ([Name])
VALUES
  ('New York'),
  ('London'),
  ('Tokyo'),
  ('Paris'),
  ('Sydney'),
  ('Toronto'),
  ('Berlin'),
  ('São Paulo'),
  ('Mumbai'),
  ('Cairo');

-- Insert 10 records (SQL Server)
-- Assumes Cities were inserted in this order:
-- 1: New York, 2: London, 3: Tokyo, 4: Paris, 5: Sydney,
-- 6: Toronto, 7: Berlin, 8: São Paulo, 9: Mumbai, 10: Cairo
INSERT INTO Addresses ([Name], CityId)
VALUES
  ('123 Main St', 1),
  ('45 Baker St', 2),
  ('1-2-3 Shibuya', 3),
  ('10 Rue de Rivoli', 4),
  ('200 George St', 5),
  ('100 Queen St W', 6),
  ('5 Unter den Linden', 7),
  ('150 Avenida Paulista', 8),
  ('221 Marine Drive', 9),
  ('12 Tahrir Square', 10);

-- 40 more addresses
-- Insert 40 more addresses (SQL Server)
-- Assumes the next IDENTITY value is 11 (first 10 already inserted).
-- CityId mapping (from your earlier step):
-- 1: New York, 2: London, 3: Tokyo, 4: Paris, 5: Sydney,
-- 6: Toronto, 7: Berlin, 8: São Paulo, 9: Mumbai, 10: Cairo
INSERT INTO Addresses ([Name], CityId)
VALUES
  ('500 Fifth Ave', 1),
  ('221B Baker St', 2),
  ('3-5-7 Akihabara', 3),
  ('25 Champs-Élysées', 4),
  ('10 Martin Place', 5),
  ('1 Front St E', 6),
  ('20 Friedrichstrasse', 7),
  ('900 Rua Augusta', 8),
  ('77 Linking Road', 9),
  ('5 Nile Corniche', 10),
  ('85 Broadway', 1),
  ('12 Downing St', 2),
  ('2 Chome-11 Dogenzaka', 3),
  ('30 Boulevard Saint-Germain', 4),
  ('1 Pitt St', 5),
  ('250 Spadina Ave', 6),
  ('15 Alexanderplatz', 7),
  ('100 Rua Oscar Freire', 8),
  ('14 Colaba Causeway', 9),
  ('3 Zamalek Island', 10),
  ('1 Liberty Plaza', 1),
  ('30 Kensington High St', 2),
  ('4-2-1 Roppongi', 3),
  ('5 Place Vendôme', 4),
  ('88 Darling Harbour Rd', 5),
  ('400 Bloor St W', 6),
  ('7 Potsdamer Platz', 7),
  ('350 Avenida Faria Lima', 8),
  ('55 Bandra Kurla Complex', 9),
  ('200 Heliopolis Rd', 10),
  ('60 Wall St', 1),
  ('100 Oxford St', 2),
  ('1-9-1 Marunouchi', 3),
  ('12 Rue de la Paix', 4),
  ('33 Circular Quay W', 5),
  ('1200 Yonge St', 6),
  ('1 Kurfürstendamm', 7),
  ('800 Rua da Consolação', 8),
  ('9 Lokhandwala Complex', 9),
  ('8 Giza St', 10);

-- Insert 50 records (SQL Server)
-- Assumptions:
-- - Employees table is empty (IDENTITY starts at 1).
-- - Departments exist with Ids 1..4 (per your earlier insert).
-- - Addresses exist with Ids 1..50 (AddressId is UNIQUE, so each employee uses a distinct one).
INSERT INTO Employees (FirstName, LastName, Email, DepartmentId, ManagerId, AddressId)
VALUES
  -- Managers (no ManagerId)
  ('Alice',  'Johnson', 'alice.johnson@corp.example', 1, NULL,  1),
  ('Bob',    'Smith',   'bob.smith@corp.example',     2, NULL,  2),
  ('Carol',  'Davis',   'carol.davis@corp.example',   3, NULL,  3),
  ('David',  'Miller',  'david.miller@corp.example',  4, NULL,  4),
  ('Eve',    'Wilson',  'eve.wilson@corp.example',    1, NULL,  5),

  -- Staff (managed by Ids 1..5)
  ('Frank',  'Taylor',   'frank.taylor@corp.example',    2, 1,  6),
  ('Grace',  'Anderson', 'grace.anderson@corp.example',  3, 2,  7),
  ('Henry',  'Thomas',   'henry.thomas@corp.example',    4, 3,  8),
  ('Irene',  'Moore',    'irene.moore@corp.example',     1, 4,  9),
  ('Jack',   'Jackson',  'jack.jackson@corp.example',    2, 5, 10),

  ('Kelly',  'Martin',   'kelly.martin@corp.example',    3, 1, 11),
  ('Liam',   'Lee',      'liam.lee@corp.example',        4, 2, 12),
  ('Mia',    'Perez',    'mia.perez@corp.example',       1, 3, 13),
  ('Noah',   'Thompson', 'noah.thompson@corp.example',   2, 4, 14),
  ('Olivia', 'White',    'olivia.white@corp.example',    3, 5, 15),

  ('Peter',  'Harris',   'peter.harris@corp.example',    4, 1, 16),
  ('Quinn',  'Clark',    'quinn.clark@corp.example',     1, 2, 17),
  ('Ruby',   'Lewis',    'ruby.lewis@corp.example',      2, 3, 18),
  ('Sam',    'Walker',   'sam.walker@corp.example',      3, 4, 19),
  ('Tina',   'Hall',     'tina.hall@corp.example',       4, 5, 20),

  ('Uma',    'Allen',    'uma.allen@corp.example',       1, 1, 21),
  ('Victor', 'Young',    'victor.young@corp.example',    2, 2, 22),
  ('Wendy',  'King',     'wendy.king@corp.example',      3, 3, 23),
  ('Xavier', 'Wright',   'xavier.wright@corp.example',   4, 4, 24),
  ('Yara',   'Scott',    'yara.scott@corp.example',      1, 5, 25),

  ('Zach',   'Green',    'zach.green@corp.example',      2, 1, 26),
  ('Amber',  'Adams',    'amber.adams@corp.example',     3, 2, 27),
  ('Brian',  'Baker',    'brian.baker@corp.example',     4, 3, 28),
  ('Chloe',  'Brooks',   'chloe.brooks@corp.example',    1, 4, 29),
  ('Dylan',  'Campbell', 'dylan.campbell@corp.example',  2, 5, 30),

  ('Ella',   'Cooper',   'ella.cooper@corp.example',     3, 1, 31),
  ('Finn',   'Cox',      'finn.cox@corp.example',        4, 2, 32),
  ('Gianna', 'Diaz',     'gianna.diaz@corp.example',     1, 3, 33),
  ('Hugo',   'Edwards',  'hugo.edwards@corp.example',    2, 4, 34),
  ('Isla',   'Foster',   'isla.foster@corp.example',     3, 5, 35),

  ('Jonah',  'Gray',     'jonah.gray@corp.example',      4, 1, 36),
  ('Kara',   'Hayes',    'kara.hayes@corp.example',      1, 2, 37),
  ('Leo',    'Howard',   'leo.howard@corp.example',      2, 3, 38),
  ('Maya',   'Jenkins',  'maya.jenkins@corp.example',    3, 4, 39),
  ('Nolan',  'Kelly',    'nolan.kelly@corp.example',     4, 5, 40),

  ('Owen',   'Long',     'owen.long@corp.example',       1, 1, 41),
  ('Piper',  'Murphy',   'piper.murphy@corp.example',    2, 2, 42),
  ('Quinn',  'Nolan',    'quinn.nolan@corp.example',     3, 3, 43),
  ('Riley',  'Ortiz',    'riley.ortiz@corp.example',     4, 4, 44),
  ('Stella', 'Parker',   'stella.parker@corp.example',   1, 5, 45),

  ('Theo',   'Reed',     'theo.reed@corp.example',       2, 1, 46),
  ('Una',    'Rivera',   'una.rivera@corp.example',      3, 2, 47),
  ('Vera',   'Simmons',  'vera.simmons@corp.example',    4, 3, 48),
  ('Wyatt',  'Turner',   'wyatt.turner@corp.example',    1, 4, 49),
  ('Zoey',   'Ward',     'zoey.ward@corp.example',       2, 5, 50);

-- SELECT STATEMENTS

SELECT * FROM Employees
 WHERE ManagerId = 3
