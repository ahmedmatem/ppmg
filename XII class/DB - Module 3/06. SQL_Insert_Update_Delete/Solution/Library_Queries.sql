--1.
CREATE DATABASE Library

USE Library

-- Authors (Id, FirstName, LastName, BirthDate)
CREATE TABLE Authors(
	Id INT PRIMARY KEY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	BirthDate DATETIME2 NOT NULL
)

-- Books (Id, Title, PublicationYear, AuthorId)
CREATE TABLE Books(
	Id INT PRIMARY KEY,
	Title NVARCHAR(100) NOT NULL,
	PublicationYear INT NOT NULL,
	AuthorId INT NOT NULL,
	--AuthorId INT FOREIGN KEY REFERENCES Authors(Id)
	CONSTRAINT FK_Books_Authors FOREIGN KEY (AuthorId) REFERENCES Authors(Id)
)

-- after creating Books table without any foreign key use this ALTER query
ALTER TABLE Books
ADD CONSTRAINT FK_Books_Authors FOREIGN KEY (AuthorId) REFERENCES Authors(Id)

-- inserts
INSERT INTO Authors (Id, FirstName, LastName, BirthDate) 
     VALUES (1, 'Ivan', 'Vazov', '1850-07-09'),
			(2, 'Aleko', 'Konstantinov', '1863-01-01'),
			(3, 'Elin', 'Pelin', '1877-07-08'),
			(4, 'Peyo', 'Yavorov', '1878-01-13')

INSERT INTO Books (Id, Title, PublicationYear, AuthorId) 
     VALUES (1, 'Pod Igoto', 1889, 1),
			(2, 'Bay Ganyo', 1895, 2),
			(3, 'Yan Bibiyan', 1923, 3),
			(4, 'Shadows', 1911, 4);


--2.
SELECT * FROM Books

UPDATE Books
   SET PublicationYear = 1888
 WHERE Id = 1

--3.
SELECT * FROM Authors

DELETE FROM Books
      WHERE AuthorId = 4

DELETE FROM Authors
      WHERE Id = 4