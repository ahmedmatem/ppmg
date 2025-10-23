CREATE DATABASE People2

USE People2

CREATE TABLE People
(
	Id INT NOT NULL PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	Age INT	
)

-- Добавяме колона към вече създадена таблица
ALTER TABLE People
ADD TownId INT NOT NULL

-- Създаваме колона външен ключ(foreign key) във вече създадена таблица
ALTER TABLE People
ADD CONSTRAINT FK_People_Towns FOREIGN KEY (TownId) REFERENCES Towns(ID)

CREATE TABLE Towns
(
	ID INT NOT NULL PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL
)

-- Вмъкване на данни
INSERT INTO People(Id, [Name], Age, TownId)
	 VALUES (1, 'Kevin', 22, 1),
			(2, 'Bob', 15, 3),
			(3, 'Steward', NULL, 2)

INSERT INTO Towns(Id, [Name])
	 VALUES (1, 'Sofia'),
			(2, 'Plovdiv'),
			(3, 'Varna')

-- Опит за въвеждане на невалидни данни
INSERT INTO People(Id, [Name], Age, TownId)
	 VALUES (2, 'Mitko', 20, 1), -- invalid Id - already exists
	        (5, 'Petra', 20, 10) -- TownId does not exist

-- Грешка при опит да изтрием град, в който имаме записани хора(в таблицата People)
DELETE FROM Towns
	  WHERE ID = 1

SELECT * FROM Towns
SELECT * FROM People