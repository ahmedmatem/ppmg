CREATE DATABASE Movies
GO

USE Movies

CREATE TABLE Directors
(
	Id INT PRIMARY KEY NOT NULL IDENTITY,
	DirectorName VARCHAR(50) NOT NULL,
	Notes VARCHAR(200)
)

CREATE TABLE Genres
(
	Id INT PRIMARY KEY NOT NULL IDENTITY,
	GenreName VARCHAR(50) NOT NULL,
	Notes VARCHAR(200)
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY NOT NULL IDENTITY,
	CategoryName VARCHAR(50) NOT NULL,
	Notes VARCHAR(200)
)

CREATE TABLE Movies
(
	Id INT PRIMARY KEY NOT NULL IDENTITY,
	Title VARCHAR(100) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
	CopyrightYear INT NOT NULL,
	[Length] INT NOT NULL,
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating INT NOT NULL,
	Notes VARCHAR(200),
	FOREIGN KEY (GenreId) REFERENCES Genres(Id),
	FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
)

-- Delete relation (one to many) between Movies and Directors
ALTER TABLE Movies
DROP CONSTRAINT FK__Movies__Director__3D5E1FD2


-- Create many to many relation between Movies and Directors tables
CREATE TABLE MoviesDirectors
(
	MovieId INT NOT NULL,
	DirectorId INT NOT NULL,
	PRIMARY KEY (MovieId, DirectorId),
	FOREIGN KEY (MovieId) REFERENCES Movies(Id),
	FOREIGN KEY (DirectorId) REFERENCES Directors(Id)
)