CREATE DATABASE Funcky
GO
USE Funcky

CREATE TABLE People ( 
Id INT IDENTITY PRIMARY KEY, 
FirstName VARCHAR(30) NOT NULL, 
LastName  VARCHAR(30) NOT NULL, 
Email     VARCHAR(60) NOT NULL, 
Salary    DECIMAL(10,2) NOT NULL, 
HireDate  DATE NOT NULL 
);

INSERT INTO People (FirstName, LastName, Email, Salary, HireDate) VALUES 
('Ana','Petrova','ana.petrova@example.com', 2450.00, '2022-09-12'), 
('ivan','IVANOV','ivan.ivanov@example.com', 3200.55, '2020-01-27'), 
('Mariya','Georgieva','mariya.georgieva@example.com', 2999.99, '2019-12-31'), 
('Nikolay','Stoyanov','nikolay.s@example.com', 1800.00, '2024-02-29'), 
('George','Dimitrov','g.dimitrov@example.com', 4000.00, '2018-06-01'); 

CREATE TABLE Albums ( 
Id INT IDENTITY PRIMARY KEY, 
Title VARCHAR(200) NOT NULL, 
ReleaseOn DATE NULL, 
Price DECIMAL(10,2) NOT NULL 
); 

INSERT INTO Albums (Title, ReleaseOn, Price) VALUES 
('Blood Moon', '2017-01-27', 15.90), 
('No Blood No Glory', '2020-10-05', 21.50), 
('Cold Sun', '2022-04-01', 18.00), 
('BLOODLINES', NULL, 12.99), 
('Blue & White', '2019-08-31', 9.99); 

CREATE TABLE Articles ( 
Id INT IDENTITY PRIMARY KEY, 
Author VARCHAR(30) NOT NULL, 
Content VARCHAR(2000) NOT NULL, 
PublishedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME() 
);

INSERT INTO Articles (Author, Content) VALUES 
('Ana', REPLICATE('Data is beautiful. ', 20)), 
('Ivan', 'Today we discuss trimming, padding, and replacing strings in SQL Server.'), 
('Mariya', 'This post covers date parts like year, month, and weekday with 
examples.'), 
('George', 'Handling NULLs properly prevents unexpected results and bugs.'); 

CREATE TABLE Orders ( 
Id INT IDENTITY PRIMARY KEY, 
CustomerName VARCHAR(50) NOT NULL, 
OrderDate DATETIME2 NOT NULL, 
Amount DECIMAL(10,2) NOT NULL, 
DiscountPercent INT NULL 
); 

INSERT INTO Orders (CustomerName, OrderDate, Amount, DiscountPercent) 
VALUES 
('Alpha Ltd', '2024-12-31 22:15', 199.95, 10), 
('Bravo OOD', '2025-01-01 09:05', 150.00, NULL), 
('Charlie Inc', '2025-03-15 13:40', 1200.49, 5), 
('Delta LLC', '2023-02-28 23:59', 89.99, 0), 
('Echo Corp', '2024-02-29 08:30', 500.00, 20); 