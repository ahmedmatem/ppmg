CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(200)
)

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(200)
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(200)
)

CREATE TABLE Movies(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(100) NOT NULL,
	DirectorId INT,
	GenreId INT,
	Rating INT,
	Notes NVARCHAR(200)
)

CREATE TABLE MovieDirectors(
	MovieId INT,
	DirectorId INT,
	PRIMARY KEY (MovieId, DirectorId),
	FOREIGN KEY (MovieId) REFERENCES Movies(Id),
	FOREIGN KEY (DirectorId) REFERENCES Directors(Id)
)

INSERT INTO Directors ([Name], Notes)
	 VALUES ('Tarantino', NULL),
			('Dimitar Andonov', 'Koziqt rod')

SELECT * FROM Directors

INSERT INTO Movies (Title, Notes)
	 VALUES ('Koziqt rog', NULL),
			('Svatba', NULL)

SELECT * FROM Movies

INSERT INTO MovieDirectors (MovieId, DirectorId)
	 VALUES (1, 2),
			(2, 1),
			(2, 2)

SELECT * FROM MovieDirectors

UPDATE Movies
   SET Rating = 10
 WHERE Id = 1

 DROP TABLE Movies

 DELETE FROM MovieDirectors

 ALTER TABLE MovieDirectors
 DROP CONSTRAINT FK__MovieDire__Movie__5DCAEF64

 ALTER TABLE MovieDirectors
 ADD CONSTRAINT FK_MovieDirectors_Movies FOREIGN KEY (MovieId) REFERENCES Movies(Id)

 -- one to many relationship

 CREATE TABLE Customers(
	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	Phone CHAR(10) NOT NULL,
	CratedAt DATETIME2 NOT NULL
 ) 

 CREATE TABLE Orders(
	Id INT PRIMARY KEY IDENTITY,
	OrderDate DATETIME2 NOT NULL,
	Amount DECIMAL(18,2),
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id)
 )
