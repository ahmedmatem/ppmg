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

--1.5 Създаване на таблица Users
CREATE TABLE Users
(
	Id BIGINT PRIMARY KEY NOT NULL IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(max),
	LastLoginTime DATETIME2 NOT NULL,
	IsDeleted BIT DEFAULT 1
)

-- INSERT 5 users
INSERT INTO Users(Username, [Password], LastLoginTime, IsDeleted)
	 VALUES ('ahmedmatem1', '123456', '2025-10-24 12:00', 0),
			('mariya1', '123456', '2025-10-24 12:01', 0),
			('yoana1', '123456', '2025-10-25 12:00', 0),
			('hristo1', '123456', '2025-10-24 12:30', 0),
			('marindrinov1', '123456', '2025-10-25 12:10', 0)

SELECT * FROM Users

-- Премахвяме първичния ключ
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07E5A6F046

-- Добавяме комбиниран първичен ключ
ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id, Username) 

-- Добавяме ограничител за проверка на дължината на паролата
-- не по-малко от 5
ALTER TABLE Users
ADD CONSTRAINT Pass_Len_Cheker CHECK(LEN(Password) >= 5)

-- Проверка, дали ограничителя работи коректно
INSERT INTO Users(Username, Password, LastLoginTime)
	 VALUES ('mikimaouse', '1234', '2025-10-24 13:31')

-- Задаване на стойност по подразбиране на колона
ALTER TABLE Users
ADD CONSTRAINT DEF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime

-- Проверка за стойност по подразбиране
INSERT INTO Users(Username, Password)
	 VALUES ('tom_jerry', '123456')

SELECT * FROM Users
 WHERE Username = 'tom_jerry'

 -- Премахване на колона Username от комбинирания ключ
 ALTER TABLE  Users
 DROP CONSTRAINT PK_Users

 -- Добавяне на първичен ключ - Id
 ALTER TABLE Users
 ADD CONSTRAINT PK_Users PRIMARY KEY (Id)

 -- Добавяне на ограничение за Username да е поне 3 символа
 ALTER TABLE Users
 ADD CONSTRAINT CHK_UsernameLength CHECK(LEN(Username) >= 3)

 -- Проверка, дали ограничителя за Username работи
 INSERT INTO Users(Username, [Password])
	  VALUES ('shr', '12345678')

	  SELECT * FROM Users



