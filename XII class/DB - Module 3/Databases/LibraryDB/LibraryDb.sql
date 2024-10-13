IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'LibraryDB')
  CREATE DATABASE LibraryDB
GO

USE LibraryDB
GO

-- Create tables
CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)
GO

CREATE TABLE Contacts(
	Id INT PRIMARY KEY IDENTITY,
	Email NVARCHAR(100),
	PhoneNumber NVARCHAR(20),
	PostAddress NVARCHAR(200),
	Website NVARCHAR(50)
)
GO

CREATE TABLE Authors(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	ContactId INT FOREIGN KEY REFERENCES Contacts(Id)
)
GO

CREATE TABLE Libraries(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	ContactId INT FOREIGN KEY REFERENCES Contacts(Id)
)
GO

CREATE TABLE Books(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(100) NOT NULL,
	YearPublished INT NOT NULL,
	ISBN NVARCHAR(13) UNIQUE,
	AuthorId INT FOREIGN KEY REFERENCES Authors(Id) NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL
)
GO

CREATE TABLE LibrariesBooks(
	LibraryId INT FOREIGN KEY REFERENCES Libraries(Id) NOT NULL,
	BookId INT FOREIGN KEY REFERENCES Books(Id) NOT NULL,
	CONSTRAINT PK_Books_Libraries PRIMARY KEY (LibraryId, BookId)
)
GO

USE LibraryDb

SET IDENTITY_INSERT Genres ON;
GO

INSERT INTO Genres (Id, [Name]) VALUES
(1, 'Mystery'),
(2, 'Fiction'),
(3, 'Biography'),
(4, 'Memoir'),
(5, 'Historical Fiction'),
(6, 'Science Fiction'),
(7, 'Fantasy'),
(8, 'Romance'),
(9, 'Thriller'),
(10, 'Non-Fiction');
GO

SET IDENTITY_INSERT Genres OFF;
GO

SET IDENTITY_INSERT Contacts ON;
GO

INSERT INTO Contacts (Id, [Email], [PhoneNumber], [PostAddress], [Website]) VALUES
(1, 'alex@example.com', '+1234567890', '123 Main St, SF, CA', 'www.alex.com'),
(2, 'delia@example.com', '+9876543210', '456 Elm St, NY, NY', 'www.delia.com'),
(3, 'michelle@example.com', '+1112131415', '789 Maple Ave, CHI, IL', 'www.michelle.com'),
(4, 'tara@example.com', '+1617181920', '101 Oak St, BOS, MA', 'www.tara.com'),
(5, 'kristin@example.com', '+2122232425', '202 Pine St, SEA, WA', 'www.kristin.com'),
(6, 'jk@example.com', '+3334445555', '100 Kings Rd, London, UK', 'www.jkrowling.com'),
(7, 'george@example.com', '+5556667777', '7 Thrones St, LA, CA', 'www.grrmartin.com'),
(8, 'jrr@example.com', '+8889990000', '221B Baker St, London, UK', 'www.tolkien.com'),
(9, NULL, NULL, NULL, NULL),
(10, NULL, NULL, NULL, NULL),
(11, NULL, NULL, NULL, NULL),
(12, NULL, NULL, NULL, NULL),
(13, NULL, NULL, NULL, NULL),
(14, NULL, NULL, NULL, NULL),
(15, NULL, NULL, NULL, NULL),
(16, 'citylights@example.com', '+14154370444', '261 Columbus Ave, SF, CA', 'www.citylights.com'),
(17, 'strand@example.com', '+12124734477', '828 Broadway, NY, NY', 'www.strand.com'),
(18, 'powells@example.com', '+15032282265', '1005 W Burnside St, Portland, OR', 'www.powells.com'),
(19, 'tattered@example.com', '+13038361211', '2526 E Colfax Ave, Denver, CO', 'www.tatteredcover.com'),
(20, 'politics@example.com', '+12023648754', '5015 Connecticut Ave NW, Washington, DC', 'www.politicsprose.com');
GO

SET IDENTITY_INSERT Contacts OFF;
GO

SET IDENTITY_INSERT Authors ON;
GO

INSERT INTO Authors (Id, [Name], [ContactId]) VALUES
(1, 'Alex Michaelides', 1),
(2, 'Delia Owens', 2),
(3, 'Michelle Obama', 3),
(4, 'Tara Westover', 4),
(5, 'Kristin Hannah', 5),
(6, 'J.K. Rowling', 6),
(7, 'George R.R. Martin', 7),
(8, 'J.R.R. Tolkien', 8),
(9, 'Jane Austen', 9),
(10, 'Mark Twain', 10),
(11, 'Charles Dickens', 11),
(12, 'Leo Tolstoy', 12),
(13, 'Herman Melville', 13),
(14, 'Victor Hugo', 14),
(15, 'Fyodor Dostoevsky', 15);
GO

SET IDENTITY_INSERT Authors OFF;
GO

SET IDENTITY_INSERT Libraries ON;
GO

INSERT INTO Libraries (Id, [Name], [ContactId]) VALUES
(1, 'City Lights', 16),
(2, 'Strand Bookstore', 17),
(3, 'Powell''s City of Books', 18),
(4, 'Tattered Cover', 19),
(5, 'Politics and Prose', 20);
GO

SET IDENTITY_INSERT Libraries OFF;
GO

SET IDENTITY_INSERT Books ON;
GO

INSERT INTO Books (Id, [Title], [YearPublished], [ISBN], [AuthorId], [GenreId]) VALUES
(1, 'The Silent Patient', 2019, '9781250301697', 1, 1),
(2, 'Where the Crawdads Sing', 2018, '9780735219090', 2, 2),
(3, 'Becoming', 2018, '9781524763138', 3, 3),
(4, 'Educated', 2018, '9780399590504', 4, 4),
(5, 'The Great Alone', 2018, '9780312577230', 5, 5),
(6, 'Harry Potter and the Sorcerer''s Stone', 1997, '9780747532699', 6, 7),
(7, 'Harry Potter and the Chamber of Secrets', 1998, '9780747538493', 6, 7),
(8, 'Harry Potter and the Prisoner of Azkaban', 1999, '9780747542155', 6, 7),
(9, 'A Game of Thrones', 1996, '9780553103540', 7, 8),
(10, 'A Clash of Kings', 1998, '9780553108033', 7, 8),
(11, 'A Storm of Swords', 2000, '9780553106633', 7, 8),
(12, 'The Hobbit', 1937, '9780547928227', 8, 7),
(13, 'The Fellowship of the Ring', 1954, '9780547928210', 8, 7),
(14, 'The Two Towers', 1954, '9780547928203', 8, 7),
(15, 'Pride and Prejudice', 1813, '9780141439518', 9, 8),
(16, 'Sense and Sensibility', 1811, '9780141439662', 9, 8),
(17, 'Emma', 1815, '9780141439587', 9, 8),
(18, 'The Adventures of Tom Sawyer', 1876, '9781591940554', 10, 10),
(19, 'Adventures of Huckleberry Finn', 1884, '9781591940561', 10, 10),
(20, 'The Prince and the Pauper', 1881, '9781591940578', 10, 10),
(21, 'Great Expectations', 1861, '9780141439563', 11, 2),
(22, 'A Tale of Two Cities', 1859, '9780141439600', 11, 2),
(23, 'David Copperfield', 1850, '9780141439624', 11, 2),
(24, 'War and Peace', 1869, '9780143039990', 12, 5),
(25, 'Anna Karenina', 1877, '9780143035008', 12, 5),
(26, 'The Death of Ivan Ilyich', 1886, '9780140445084', 12, 5),
(27, 'Moby-Dick', 1851, '9780142437247', 13, 2),
(28, 'Billy Budd, Sailor', 1924, '9780142437179', 13, 2),
(29, 'Bartleby, the Scrivener', 1853, '9780142437254', 13, 2),
(30, 'Les Misérables', 1862, '9780140444308', 14, 2),
(31, 'The Hunchback of Notre-Dame', 1831, '9780140443530', 14, 2),
(32, 'The Toilers of the Sea', 1866, '9780140444759', 14, 2),
(33, 'Crime and Punishment', 1866, '9780140449136', 15, 5),
(34, 'The Brothers Karamazov', 1880, '9780140449242', 15, 5),
(35, 'Notes from Underground', 1864, '9780140449266', 15, 5);
GO

SET IDENTITY_INSERT Books OFF;
GO

INSERT INTO LibrariesBooks (LibraryId, BookId) VALUES
(1, 1),
(1, 2),
(2, 3),
(2, 4),
(3, 5),
(3, 6),
(3, 7),
(4, 8),
(4, 9),
(4, 10),
(5, 11),
(5, 12),
(5, 13),
(1, 14),
(1, 15),
(2, 16),
(2, 17),
(3, 18),
(3, 19),
(3, 20),
(4, 21),
(4, 22),
(5, 23),
(5, 24),
(5, 25),
(1, 26),
(1, 27),
(2, 28),
(2, 29),
(3, 30),
(3, 31),
(3, 32),
(4, 33),
(4, 34),
(5, 35);
GO
