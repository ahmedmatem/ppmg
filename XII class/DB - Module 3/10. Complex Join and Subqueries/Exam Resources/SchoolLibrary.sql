------------------------------------------------------------
-- Създаване на базата данни
------------------------------------------------------------
IF DB_ID('SchoolLibrary') IS NOT NULL
BEGIN
    ALTER DATABASE SchoolLibrary SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE SchoolLibrary;
END
GO

CREATE DATABASE SchoolLibrary;
GO

USE SchoolLibrary;
GO

------------------------------------------------------------
-- Таблица: Students
------------------------------------------------------------
CREATE TABLE Students
(
    Id          INT IDENTITY(1,1)    NOT NULL PRIMARY KEY,
    FirstName   NVARCHAR(50)         NOT NULL,
    LastName    NVARCHAR(50)         NOT NULL,
    ClassName   NVARCHAR(10)         NOT NULL,   -- напр. '12А'
    ClassNumber TINYINT              NOT NULL,   -- номер в класа
    CONSTRAINT UQ_Students_Class UNIQUE (ClassName, ClassNumber)
);
GO

------------------------------------------------------------
-- Таблица: Categories
------------------------------------------------------------
CREATE TABLE Categories
(
    Id          INT IDENTITY(1,1)    NOT NULL PRIMARY KEY,
    [Name]      NVARCHAR(50)         NOT NULL UNIQUE,
    [Description] NVARCHAR(255)      NULL
);
GO

------------------------------------------------------------
-- Таблица: Authors
------------------------------------------------------------
CREATE TABLE Authors
(
    Id        INT IDENTITY(1,1)      NOT NULL PRIMARY KEY,
    FirstName NVARCHAR(50)           NOT NULL,
    LastName  NVARCHAR(50)           NOT NULL,
    Country   NVARCHAR(50)           NULL
);
GO

------------------------------------------------------------
-- Таблица: Books
------------------------------------------------------------
CREATE TABLE Books
(
    Id            INT IDENTITY(1,1)  NOT NULL PRIMARY KEY,
    Title         NVARCHAR(100)      NOT NULL,
    YearPublished INT                NULL,
    ISBN          NVARCHAR(20)       NULL,
    CategoryId    INT                NOT NULL,
    CONSTRAINT FK_Books_Categories
        FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);
GO

------------------------------------------------------------
-- Свързваща таблица: BookAuthors (M:N между Books и Authors)
------------------------------------------------------------
CREATE TABLE BookAuthors
(
    BookId   INT NOT NULL,
    AuthorId INT NOT NULL,
    CONSTRAINT PK_BookAuthors PRIMARY KEY (BookId, AuthorId),
    CONSTRAINT FK_BookAuthors_Books
        FOREIGN KEY (BookId) REFERENCES Books(Id),
    CONSTRAINT FK_BookAuthors_Authors
        FOREIGN KEY (AuthorId) REFERENCES Authors(Id)
);
GO

------------------------------------------------------------
-- Таблица: Loans (заеми – M:N между Students и Books)
------------------------------------------------------------
CREATE TABLE Loans
(
    Id         INT IDENTITY(1,1)     NOT NULL PRIMARY KEY,
    StudentId  INT                   NOT NULL,
    BookId     INT                   NOT NULL,
    LoanDate   DATE                  NOT NULL,
    DueDate    DATE                  NOT NULL,
    ReturnDate DATE                  NULL,
    CONSTRAINT FK_Loans_Students
        FOREIGN KEY (StudentId) REFERENCES Students(Id),
    CONSTRAINT FK_Loans_Books
        FOREIGN KEY (BookId) REFERENCES Books(Id),
    CONSTRAINT CHK_Loans_Dates
        CHECK (DueDate >= LoanDate AND (ReturnDate IS NULL OR ReturnDate >= LoanDate))
);
GO

------------------------------------------------------------
-- Вмъкване на примерни данни
------------------------------------------------------------

-------------------------
-- Categories
-------------------------
SET IDENTITY_INSERT Categories ON;
INSERT INTO Categories (Id, [Name], [Description]) VALUES
(1, N'Роман',              N'Художествена проза'),
(2, N'Фентъзи',            N'Фантастични светове и магия'),
(3, N'Научна литература',  N'Популярна и специализирана научна литература'),
(4, N'Информатика',        N'Програмиране и компютърни науки'),
(5, N'История',            N'Исторически събития и личности'),
(6, N'Биография',          N'Книги за живота на известни личности');
SET IDENTITY_INSERT Categories OFF;
GO

-------------------------
-- Students
-------------------------
SET IDENTITY_INSERT Students ON;
INSERT INTO Students (Id, FirstName, LastName, ClassName, ClassNumber) VALUES
(1,  N'Иван',     N'Иванов',    N'12А', 1),
(2,  N'Мария',    N'Георгиева', N'12А', 2),
(3,  N'Петър',    N'Петров',    N'12А', 3),
(4,  N'Габриела', N'Николова',  N'12Б', 5),
(5,  N'Алекс',    N'Стоянов',   N'12Б', 7),
(6,  N'Десислава',N'Костова',   N'12Б', 10),
(7,  N'Калоян',   N'Илиев',     N'11А', 4),
(8,  N'Никол',    N'Димитрова', N'11А', 8),
(9,  N'Борис',    N'Тодоров',   N'11Б', 6),
(10, N'Виктория', N'Симеонова', N'11Б', 9),
(11, N'Симеон',   N'Атанасов',  N'10А', 3),
(12, N'Йоана',    N'Пенева',    N'10А', 12);
SET IDENTITY_INSERT Students OFF;
GO

-------------------------
-- Authors
-------------------------
SET IDENTITY_INSERT Authors ON;
INSERT INTO Authors (Id, FirstName, LastName, Country) VALUES
(1,  N'Джордж',   N'Оруел',       N'Великобритания'),
(2,  N'Дж. К.',   N'Роулинг',     N'Великобритания'),
(3,  N'Айзък',    N'Азимов',      N'САЩ'),
(4,  N'Стиг',     N'Ларшон',      N'Швеция'),
(5,  N'Харуки',   N'Мураками',    N'Япония'),
(6,  N'Иван',     N'Вазов',       N'България'),
(7,  N'Елин',     N'Пелин',       N'България'),
(8,  N'Брайън',   N'Керниган',    N'САЩ'),
(9,  N'Денис',    N'Ричи',        N'САЩ'),
(10, N'Ювал',     N'Харари',      N'Израел');
SET IDENTITY_INSERT Authors OFF;
GO

-------------------------
-- Books
-------------------------
SET IDENTITY_INSERT Books ON;
INSERT INTO Books (Id, Title, YearPublished, ISBN, CategoryId) VALUES
(1,  N'1984',                              1949, N'9780451524935', 1),
(2,  N'Хари Потър и Философският камък',   1997, N'9780747532743', 2),
(3,  N'Фундацията',                        1951, N'9780553293357', 2),
(4,  N'Момичето с драконовата татуировка', 2005, N'9780307454546', 1),
(5,  N'Норвежка гора',                     1987, N'9780375704024', 1),
(6,  N'Под игото',                         1894, N'9789540901260', 5),
(7,  N'Гераците',                          1911, N'9789540904841', 1),
(8,  N'C Programming Language',            1978, N'9780131103627', 4),
(9,  N'Въведение в алгоритмите',           1990, N'9780262033848', 4),
(10, N'Sapiens: Кратка история на човечеството', 2011, N'9780099590088', 3),
(11, N'Homo Deus: Кратка история на бъдещето',  2015, N'9780062464316', 3),
(12, N'История на България',               2000, N'9789540900003', 5),
(13, N'Животът на един програмист',        2018, N'9789549999999', 6),
(14, N'Алгоритми и структури от данни',    2012, N'9789549876543', 4),
(15, N'Фентъзи хроники: Пламъкът на дракона', 2019, N'9789541234567', 2);
SET IDENTITY_INSERT Books OFF;
GO

-------------------------
-- BookAuthors (M:N)
-------------------------
INSERT INTO BookAuthors (BookId, AuthorId) VALUES
-- 1984 – Оруел
(1, 1),
-- Хари Потър – Роулинг
(2, 2),
-- Фундацията – Азимов
(3, 3),
-- Момичето с драконовата татуировка – Ларшон
(4, 4),
-- Норвежка гора – Мураками
(5, 5),
-- Под игото – Вазов
(6, 6),
-- Гераците – Елин Пелин
(7, 7),
-- C Programming Language – Керниган и Ричи (двама автори)
(8, 8),
(8, 9),
-- Въведение в алгоритмите – да кажем Азимов (фиктивно за пример)
(9, 3),
-- Sapiens и Homo Deus – Харари
(10, 10),
(11, 10),
-- История на България – Вазов (фиктивно за пример)
(12, 6),
-- Животът на един програмист – Керниган (фиктивно)
(13, 8),
-- Алгоритми и структури от данни – Керниган и Ричи
(14, 8),
(14, 9),
-- Фентъзи хроники – Роулинг (фиктивно)
(15, 2);
GO

-------------------------
-- Loans
-------------------------
SET IDENTITY_INSERT Loans ON;
INSERT INTO Loans (Id, StudentId, BookId, LoanDate, DueDate, ReturnDate) VALUES
-- Иван (12А, №1)
(1,  1, 1,  '2024-09-15', '2024-10-15', '2024-10-10'),
(2,  1, 8,  '2024-10-20', '2024-11-20', NULL),
-- Мария (12А, №2)
(3,  2, 2,  '2024-09-20', '2024-10-20', '2024-10-19'),
(4,  2, 10, '2024-11-01', '2024-12-01', NULL),
-- Петър (12А, №3)
(5,  3, 9,  '2024-09-25', '2024-10-25', '2024-10-24'),
(6,  3, 14, '2024-11-10', '2024-12-10', NULL),
-- Габриела (12Б, №5)
(7,  4, 5,  '2024-09-10', '2024-10-10', '2024-10-09'),
(8,  4, 15, '2024-10-05', '2024-11-05', NULL),
-- Алекс (12Б, №7)
(9,  5, 3,  '2024-09-18', '2024-10-18', '2024-10-15'),
(10, 5, 8,  '2024-10-25', '2024-11-25', '2024-11-24'),
-- Десислава (12Б, №10)
(11, 6, 11, '2024-11-02', '2024-12-02', NULL),
-- Калоян (11А, №4)
(12, 7, 6,  '2024-09-12', '2024-10-12', '2024-10-11'),
(13, 7, 12, '2024-10-15', '2024-11-15', NULL),
-- Никол (11А, №8)
(14, 8, 7,  '2024-09-22', '2024-10-22', '2024-10-21'),
(15, 8, 1,  '2024-11-05', '2024-12-05', NULL),
-- Борис (11Б, №6)
(16, 9, 9,  '2024-09-30', '2024-10-30', '2024-10-28'),
-- Виктория (11Б, №9)
(17,10, 2,  '2024-09-07', '2024-10-07', '2024-10-01'),
(18,10,10,  '2024-10-10', '2024-11-10', '2024-11-09'),
-- Симеон (10А, №3)
(19,11, 4,  '2024-09-05', '2024-10-05', '2024-09-30'),
-- Йоана (10А, №12)
(20,12,13,  '2024-10-01', '2024-11-01', NULL);
SET IDENTITY_INSERT Loans OFF;
GO

------------------------------------------------------------
-- Кратка проверка (примерни справки)
------------------------------------------------------------
-- SELECT * FROM Students;
-- SELECT * FROM Categories;
-- SELECT * FROM Authors;
-- SELECT * FROM Books;
-- SELECT * FROM BookAuthors;
-- SELECT * FROM Loans;
