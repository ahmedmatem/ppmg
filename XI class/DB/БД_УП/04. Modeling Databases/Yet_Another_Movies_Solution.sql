--	2.	База данни Movies
--	С помощта на SQL заявки създайте база данни Movies със следните обекти:
--		•	Directors (Id, DirectorName, Notes)
--		•	Genres (Id, GenreName, Notes)
--		•	Categories (Id, CategoryName, Notes)
--		•	Movies (Id, Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
--	Задайте най-подходящите типове данни за всяка колона. Задайте първичен ключ за всяка таблица. Попълнете всяка таблица с точно 5 записа. Уверете се, че колоните, които присъстват в 2 таблици, са от един и същи тип данни. Помислете кои полета винаги са задължителни и кои са незадължителни. Свържете таблицата Movies с таблиците Directors, Genres и Categories чрез foreign key constraint.



CREATE DATABASE Movies2
GO

USE Movies2

CREATE TABLE Directors
(
	Id INT PRIMARY KEY NOT NULL IDENTITY,
	DirectorName VARCHAR(60) NOT NULL,
	Notes VARCHAR(200)
)

CREATE TABLE Genres
(
	Id INT PRIMARY KEY NOT NULL IDENTITY,
	GenreName VARCHAR(60) NOT NULL,
	Notes VARCHAR(200)
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY NOT NULL IDENTITY,
	CategoryName VARCHAR(60) NOT NULL,
	Notes VARCHAR(200)
)

CREATE TABLE Movies
(
	Id INT PRIMARY KEY NOT NULL IDENTITY,
	Title VARCHAR(100) NOT NULL,
	DirectorId INT NOT NULL FOREIGN KEY REFERENCES Directors(Id),
	CopyrightYear INT NOT NULL,
	[Length] INT NOT NULL,
	GenreId INT NOT NULL, --FK after all column definitions
	CategoryId INT NOT NULL, -- left for table alter
	Rating INT NOT NULL,
	Notes VARCHAR(200),
	FOREIGN KEY (GenreId) REFERENCES Genres(Id)
)

-- Create relation between Movies and Catrgories
ALTER TABLE Movies
ADD CONSTRAINT FK_Movies_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(Id)

-- Delete relation between Movies and Genres
ALTER TABLE Movies
DROP CONSTRAINT FK__Movies__GenreId__3E52440B

-- Create table that connect Movies and Genres - many to many
CREATE TABLE MoviesGenres
(
	MovieId INT NOT NULL,
	GenreId INT NOT NULL,
	PRIMARY KEY (MovieId, GenreId),
	FOREIGN KEY (MovieId) REFERENCES Movies(Id),
	FOREIGN KEY (GenreId) REFERENCES Genres(Id)
)

-- Insert data into Movies
INSERT INTO Movies(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating)
	 VALUES ('Titanic', 2, 2000, 150, 3, 1, 100)

SELECT * FROM Movies

INSERT INTO Directors(DirectorName)
	 VALUES ('Petar Arnaudov'),
			('Mister Bean'),
			('Sasha Masha')

INSERT INTO Genres(GenreName, Notes)
	 VALUES ('Fantasy', 'Umiram ot kef'),
			('Drama', NULL),
			('Comedy', 'Umiram ot smyah - ha-Ha-hA')

INSERT INTO Categories (CategoryName, Notes)
VALUES 
('Beverages', 'Soft drinks, coffees, teas, beers, and ales'),
('Condiments', 'Sweet and savory sauces, relishes, spreads, and seasonings'),
('Confections', 'Desserts, candies, and sweet breads'),
('Dairy Products', 'Cheeses and other dairy items'),
('Grains/Cereals', 'Breads, crackers, pasta, and cereal'),
('Meat/Poultry', 'Prepared meats'),
('Produce', 'Dried fruit and bean curd'),
('Seafood', 'Seaweed and fish');

SELECT * FROM Categories

DELETE FROM Categories
 WHERE Id = 1
