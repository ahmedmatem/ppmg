------------------------------------------------------------
-- Създаване на базата данни MoviesDB
------------------------------------------------------------
IF DB_ID('MoviesDB') IS NOT NULL
BEGIN
    ALTER DATABASE MoviesDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE MoviesDB;
END
GO

CREATE DATABASE MoviesDB;
GO

USE MoviesDB;
GO

------------------------------------------------------------
-- Таблица: Directors (режисьори)
------------------------------------------------------------
CREATE TABLE Directors
(
    Id        INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    FirstName NVARCHAR(50)      NOT NULL,
    LastName  NVARCHAR(50)      NOT NULL,
    Country   NVARCHAR(50)      NULL,
    BirthDate DATE              NULL
);
GO

------------------------------------------------------------
-- Таблица: Genres (жанрове)
------------------------------------------------------------
CREATE TABLE Genres
(
    Id   INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(50)      NOT NULL UNIQUE
);
GO

------------------------------------------------------------
-- Таблица: Actors (актьори)
------------------------------------------------------------
CREATE TABLE Actors
(
    Id        INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    FirstName NVARCHAR(50)      NOT NULL,
    LastName  NVARCHAR(50)      NOT NULL,
    Country   NVARCHAR(50)      NULL,
    BirthDate DATE              NULL
);
GO

------------------------------------------------------------
-- Таблица: Movies (филми)
------------------------------------------------------------
CREATE TABLE Movies
(
    Id              INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Title           NVARCHAR(150)     NOT NULL,
    ReleaseYear     INT               NOT NULL,
    DurationMinutes INT               NOT NULL,
    Rating          DECIMAL(3,1)      NULL,        -- 0.0 - 10.0
    AgeRating       NVARCHAR(10)      NULL,        -- 'PG-13', 'R', '12+', ...
    DirectorId      INT               NOT NULL,
    CONSTRAINT FK_Movies_Directors
        FOREIGN KEY (DirectorId) REFERENCES Directors(Id),
    CONSTRAINT CHK_Movies_Year CHECK (ReleaseYear >= 1900 AND ReleaseYear <= YEAR(GETDATE())),
    CONSTRAINT CHK_Movies_Duration CHECK (DurationMinutes > 0),
    CONSTRAINT CHK_Movies_Rating CHECK (Rating IS NULL OR (Rating >= 0 AND Rating <= 10))
);
GO

------------------------------------------------------------
-- Свързваща таблица 1: MovieGenres (M:N – Movies <-> Genres)
------------------------------------------------------------
CREATE TABLE MovieGenres
(
    MovieId INT NOT NULL,
    GenreId INT NOT NULL,
    CONSTRAINT PK_MovieGenres PRIMARY KEY (MovieId, GenreId),
    CONSTRAINT FK_MovieGenres_Movies
        FOREIGN KEY (MovieId) REFERENCES Movies(Id),
    CONSTRAINT FK_MovieGenres_Genres
        FOREIGN KEY (GenreId) REFERENCES Genres(Id)
);
GO

------------------------------------------------------------
-- Свързваща таблица 2: MovieActors (M:N – Movies <-> Actors)
------------------------------------------------------------
CREATE TABLE MovieActors
(
    MovieId  INT           NOT NULL,
    ActorId  INT           NOT NULL,
    RoleName NVARCHAR(100) NULL,
    CONSTRAINT PK_MovieActors PRIMARY KEY (MovieId, ActorId),
    CONSTRAINT FK_MovieActors_Movies
        FOREIGN KEY (MovieId) REFERENCES Movies(Id),
    CONSTRAINT FK_MovieActors_Actors
        FOREIGN KEY (ActorId) REFERENCES Actors(Id)
);
GO

------------------------------------------------------------
-- Примерни данни
------------------------------------------------------------

-------------------------
-- Directors
-------------------------
INSERT INTO Directors (FirstName, LastName, Country, BirthDate) VALUES
(N'Christopher', N'Nolan',          N'Великобритания', '1970-07-30'),
(N'Lana',        N'Wachowski',      N'САЩ',            '1965-06-21'),
(N'Peter',       N'Jackson',        N'Нова Зеландия',  '1961-10-31'),
(N'Francis Ford',N'Coppola',        N'САЩ',            '1939-04-07'),
(N'Bong',        N'Joon Ho',        N'Южна Корея',     '1969-09-14'),
(N'Hayao',       N'Miyazaki',       N'Япония',         '1941-01-05'),
(N'Frank',       N'Darabont',       N'Франция',        '1959-01-28'),
(N'Quentin',     N'Tarantino',      N'САЩ',            '1963-03-27'),
(N'Anthony',     N'Russo',          N'САЩ',            '1970-02-03'),
(N'Виктор',      N'Божинов',        N'България',       '1970-09-27'),
(N'Димитър',     N'Митовски',       N'България',       '1964-10-14');
GO

-------------------------
-- Genres
-------------------------
INSERT INTO Genres (Name) VALUES
(N'Action'),
(N'Drama'),
(N'Sci-Fi'),
(N'Fantasy'),
(N'Animation'),
(N'Crime'),
(N'Thriller'),
(N'Comedy');
GO

-------------------------
-- Actors
-------------------------
INSERT INTO Actors (FirstName, LastName, Country, BirthDate) VALUES
(N'Leonardo',     N'DiCaprio',        N'САЩ',            '1974-11-11'), -- 1
(N'Joseph',       N'Gordon-Levitt',   N'САЩ',            '1981-02-17'), -- 2
(N'Elliot',       N'Page',            N'Канада',         '1987-02-21'), -- 3
(N'Keanu',        N'Reeves',          N'Канада',         '1964-09-02'), -- 4
(N'Carrie-Anne',  N'Moss',            N'Канада',         '1967-08-21'), -- 5
(N'Ian',          N'McKellen',        N'Великобритания', '1939-05-25'), -- 6
(N'Elijah',       N'Wood',            N'САЩ',            '1981-01-28'), -- 7
(N'Al',           N'Pacino',          N'САЩ',            '1940-04-25'), -- 8
(N'Marlon',       N'Brando',          N'САЩ',            '1924-04-03'), -- 9
(N'Song',         N'Kang-ho',         N'Южна Корея',     '1967-01-17'), -- 10
(N'Tim',          N'Robbins',         N'САЩ',            '1958-10-16'), -- 11
(N'Morgan',       N'Freeman',         N'САЩ',            '1937-06-01'), -- 12
(N'John',         N'Travolta',        N'САЩ',            '1954-02-18'), -- 13
(N'Samuel L.',    N'Jackson',         N'САЩ',            '1948-12-21'), -- 14
(N'Robert',       N'Downey Jr.',      N'САЩ',            '1965-04-04'), -- 15
(N'Chris',        N'Evans',           N'САЩ',            '1981-06-13'), -- 16
(N'Matthew',      N'McConaughey',     N'САЩ',            '1969-11-04'), -- 17
(N'Rumi',         N'Hiiragi',         N'Япония',         '1987-08-01'), -- 18
(N'Александър',   N'Алексиев',        N'България',       '1989-09-19'), -- 19
(N'Орлин',        N'Павлов',          N'България',       '1979-04-23'); -- 20
GO

-------------------------
-- Movies
-------------------------
INSERT INTO Movies (Title, ReleaseYear, DurationMinutes, Rating, AgeRating, DirectorId) VALUES
(N'Inception',                                   2010, 148, 8.8, N'PG-13', 1),  -- Nolan
(N'The Matrix',                                  1999, 136, 8.7, N'R',     2),  -- Wachowski
(N'The Lord of the Rings: The Fellowship of the Ring', 2001, 178, 8.8, N'PG-13', 3),
(N'The Godfather',                               1972, 175, 9.2, N'R',     4),
(N'Parasite',                                    2019, 132, 8.6, N'R',     5),
(N'Spirited Away',                               2001, 125, 8.6, N'PG',    6),
(N'The Shawshank Redemption',                    1994, 142, 9.3, N'R',     7),
(N'Interstellar',                                2014, 169, 8.6, N'PG-13', 1),  -- Nolan
(N'Pulp Fiction',                                1994, 154, 8.9, N'R',     8),
(N'Avengers: Endgame',                           2019, 181, 8.4, N'PG-13', 9),
(N'Възвишение',                                  2017, 138, 8.0, N'12+',   10),
(N'Мисия Лондон',                                2010, 115, 7.2, N'12+',   11);
GO

-------------------------
-- MovieGenres (M:N между филми и жанрове)
-- Genres: 1 Action, 2 Drama, 3 Sci-Fi, 4 Fantasy, 5 Animation, 6 Crime, 7 Thriller, 8 Comedy
-------------------------
INSERT INTO MovieGenres (MovieId, GenreId) VALUES
-- Inception
(1, 1),  -- Action
(1, 3),  -- Sci-Fi
(1, 7),  -- Thriller

-- The Matrix
(2, 1),
(2, 3),

-- LOTR: Fellowship
(3, 1),
(3, 4),

-- The Godfather
(4, 2),  -- Drama
(4, 6),  -- Crime

-- Parasite
(5, 2),
(5, 7),

-- Spirited Away
(6, 4),  -- Fantasy
(6, 5),  -- Animation

-- Shawshank
(7, 2),

-- Interstellar
(8, 2),
(8, 3),

-- Pulp Fiction
(9, 2),
(9, 6),

-- Avengers: Endgame
(10, 1),
(10, 3),

-- Възвишение
(11, 2),

-- Мисия Лондон
(12, 8); -- Comedy
GO

-------------------------
-- MovieActors (M:N между филми и актьори)
-------------------------
INSERT INTO MovieActors (MovieId, ActorId, RoleName) VALUES
-- Inception: DiCaprio, Gordon-Levitt, Page
(1, 1,  N'Cobb'),
(1, 2,  N'Arthur'),
(1, 3,  N'Ariadne'),

-- The Matrix: Reeves, Moss
(2, 4,  N'Neo'),
(2, 5,  N'Trinity'),

-- LOTR: McKellen, Wood
(3, 6,  N'Gandalf'),
(3, 7,  N'Frodo'),

-- The Godfather: Pacino, Brando
(4, 8,  N'Michael Corleone'),
(4, 9,  N'Vito Corleone'),

-- Parasite: Song Kang-ho
(5,10,  N'Kim Ki-taek'),

-- Spirited Away: Rumi Hiiragi (voice)
(6,18,  N'Chihiro Ogino'),

-- Shawshank: Tim Robbins, Morgan Freeman
(7,11,  N'Andy Dufresne'),
(7,12,  N'Ellis Boyd "Red" Redding'),

-- Interstellar: Matthew McConaughey
(8,17,  N'Cooper'),

-- Pulp Fiction: Travolta, Jackson
(9,13,  N'Vincent Vega'),
(9,14,  N'Jules Winnfield'),

-- Avengers: Endgame: Downey Jr., Evans
(10,15, N'Tony Stark / Iron Man'),
(10,16, N'Steve Rogers / Captain America'),

-- Възвишение: Александър Алексиев
(11,19, N'Гичо'),

-- Мисия Лондон: Орлин Павлов
(12,20, N'Младият политик');
GO

------------------------------------------------------------
-- Примерни проверки (по желание разкоментирай)
------------------------------------------------------------
-- SELECT * FROM Directors;
-- SELECT * FROM Genres;
-- SELECT * FROM Actors;
-- SELECT * FROM Movies;
-- SELECT * FROM MovieGenres;
-- SELECT * FROM MovieActors;

-- Примерен JOIN: филми с режисьор и жанрове
-- SELECT m.Title, d.FirstName + ' ' + d.LastName AS Director, g.Name AS Genre
-- FROM Movies m
-- JOIN Directors d ON m.DirectorId = d.Id
-- JOIN MovieGenres mg ON m.Id = mg.MovieId
-- JOIN Genres g ON mg.GenreId = g.Id
-- ORDER BY m.Title, g.Name;
