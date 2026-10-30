CREATE DATABASE SchoolSystemDb

USE SchoolSystemDb

-- Students (Id, FirstName, LastName, ClassName, Notes)
CREATE TABLE Students
(
  Id INT PRIMARY KEY IDENTITY,
  FirstName NVARCHAR(20) NOT NULL,
  LastName NVARCHAR(20) NOT NULL,
  ClassName NVARCHAR(3) NOT NULL, -- 10а, 11г, 2б
  Notes NVARCHAR(100)
)

-- Teachers (Id, TeacherName, Email, Notes)
CREATE TABLE Teachers
(
  Id INT PRIMARY KEY,
  TeacherName NVARCHAR(50) NOT NULL,
  Email VARCHAR(50) NOT NULL,
  Notes NVARCHAR(100)
)

-- Courses (Id, CourseName, TeacherId, WeeklyHours, Notes)
CREATE TABLE Courses
(
  Id INT PRIMARY KEY IDENTITY,
  CourseName NVARCHAR(50) NOT NULL,
  TeacherId INT FOREIGN KEY REFERENCES Teachers(Id),
  WeeklyHours TINYINT DEFAULT 22,
  Notes NVARCHAR(100)
)

-- StudentsCourses - table that connect Students and Courses in ralation many-to-many
CREATE TABLE StudentsCourses
(
  StudentId INT FOREIGN KEY REFERENCES Students(Id),
  CourseId INT FOREIGN KEY REFERENCES Courses(Id),
  PRIMARY KEY (StudentId, CourseId)
)

SELECT * FROM Students
INSERT INTO Students (FirstName, LastName, ClassName, Notes)
	 VALUES (N'Иван', N'Иванов', N'11г', NULL),
			(N'Леа', N'Димитрова', N'11г', NULL),
			(N'Петър', N'Ангелов', N'12г', NULL)

SELECT * FROM Teachers
INSERT INTO Teachers (Id, TeacherName, Email, Notes)
	 VALUES (1, N'Ахмед Матем Ахмед', 'ahmedmatem@gmail.com', NULL),
			(2, N'Мария Колева', 'mariyakoleva@gmail.com', NULL),
			(3, N'Иван Петков', 'ivanpetkov@gmail.com', NULL)

SELECT * FROM Courses
INSERT INTO Courses (CourseName, TeacherId, WeeklyHours, Notes)
	 VALUES (N'Информатика', 1, 12, NULL),
			(N'Математика', 1, 15, NULL),
			(N'Физика и астрономия', 3, 27, NULL)

SELECT * FROM StudentsCourses
INSERT INTO StudentsCourses (StudentId, CourseId)
	 VALUES (1, 1),
			(1, 2),
			(1, 3),
			(3, 1)

SELECT * FROM Students
SELECT * FROM Teachers
SELECT * FROM Courses
SELECT * FROM StudentsCourses












