USE master;
GO

IF DB_ID('ProductsDb') IS NOT NULL
BEGIN
    ALTER DATABASE ProductsDb SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE ProductsDb;
END
GO

CREATE DATABASE ProductsDb;
GO

USE ProductsDb;
GO

CREATE TABLE Products
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(100) NOT NULL,
    Price DECIMAL(10,2) NOT NULL
);
GO

INSERT INTO Products ([Name], Price)
VALUES
('Laptop', 1500.00),
('Mouse', 25.50),
('Keyboard', 45.99),
('Monitor', 320.00),
('Printer', 210.75),
('Desk Lamp', 35.40),
('USB Flash Drive', 18.20),
('External Hard Drive', 99.99),
('Webcam', 65.30),
('Headphones', 89.90),
('Microphone', 120.00),
('Tablet', 550.00),
('Smartphone', 980.00),
('Charger', 22.00),
('Router', 75.60),
('Speaker', 60.00),
('Power Bank', 40.50),
('SSD Drive', 130.00),
('Graphics Card', 799.99),
('Cooling Pad', 28.80);
GO