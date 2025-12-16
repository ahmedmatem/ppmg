-- ============================================================
-- Database: ShopAnalyticsDB (за упражнения по GROUP BY / агрегати)
-- ============================================================

IF DB_ID('ShopAnalyticsDB') IS NOT NULL
BEGIN
    ALTER DATABASE ShopAnalyticsDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE ShopAnalyticsDB;
END
GO

CREATE DATABASE ShopAnalyticsDB;
GO

USE ShopAnalyticsDB;
GO

-- ----------------------------
-- 1) Cities
-- ----------------------------
CREATE TABLE Cities(
    CityId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    CityName NVARCHAR(50) NOT NULL UNIQUE
);

-- ----------------------------
-- 2) Customers
-- ----------------------------
CREATE TABLE Customers(
    CustomerId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    FullName NVARCHAR(80) NOT NULL,
    Email NVARCHAR(120) NOT NULL UNIQUE,
    CityId INT NOT NULL,
    RegisteredOn DATE NOT NULL,
    CONSTRAINT FK_Customers_Cities FOREIGN KEY (CityId) REFERENCES Cities(CityId)
);

-- ----------------------------
-- 3) Categories
-- ----------------------------
CREATE TABLE Categories(
    CategoryId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    CategoryName NVARCHAR(60) NOT NULL UNIQUE
);

-- ----------------------------
-- 4) Products
-- ----------------------------
CREATE TABLE Products(
    ProductId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    ProductName NVARCHAR(80) NOT NULL,
    CategoryId INT NOT NULL,
    ListPrice DECIMAL(10,2) NOT NULL CHECK (ListPrice >= 0),
    IsActive BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_Products_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);

-- ----------------------------
-- 5) Orders
-- ----------------------------
CREATE TABLE Orders(
    OrderId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    CustomerId INT NOT NULL,
    OrderDate DATETIME2 NOT NULL,
    Status NVARCHAR(20) NOT NULL CHECK (Status IN ('New','Paid','Shipped','Cancelled')),
    CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
);

-- ----------------------------
-- 6) OrderItems
-- ----------------------------
CREATE TABLE OrderItems(
    OrderItemId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    UnitPrice DECIMAL(10,2) NOT NULL CHECK (UnitPrice >= 0),
    CONSTRAINT FK_OrderItems_Orders FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
    CONSTRAINT FK_OrderItems_Products FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);

-- ============================================================
-- Seed data
-- ============================================================

INSERT INTO Cities (CityName) VALUES
(N'Sofia'), (N'Plovdiv'), (N'Varna'), (N'Burgas');

INSERT INTO Customers (FullName, Email, CityId, RegisteredOn) VALUES
(N'Ivan Petrov',   N'ivan.petrov@mail.com',   1, '2024-11-15'),
(N'Maria Ivanova', N'maria.ivanova@mail.com', 1, '2025-01-05'),
(N'Georgi Georgiev',N'georgi.g@mail.com',     2, '2025-02-12'),
(N'Elena Stoyanova',N'elena.s@mail.com',      2, '2025-03-01'),
(N'Petar Dimitrov',N'petar.d@mail.com',       3, '2025-03-18'),
(N'Nikolay Kolev', N'nikolay.k@mail.com',     4, '2025-04-20'),
(N'Veselina Markova',N'vesi.m@mail.com',      3, '2025-05-02'),
(N'Desislava Petrova',N'desi.p@mail.com',     1, '2025-06-10');

INSERT INTO Categories (CategoryName) VALUES
(N'Electronics'), (N'Books'), (N'Home'), (N'Sports');

INSERT INTO Products (ProductName, CategoryId, ListPrice, IsActive) VALUES
(N'Wireless Mouse',     1,  39.90, 1),
(N'USB-C Charger',      1,  29.50, 1),
(N'Noise Cancelling Headphones', 1, 199.00, 1),
(N'Cookbook "Fast Meals"', 2, 24.99, 1),
(N'Novel "The Last Peak"', 2, 19.80, 1),
(N'Coffee Maker',       3, 129.00, 1),
(N'Vacuum Cleaner',     3, 249.00, 1),
(N'Yoga Mat',           4,  34.00, 1),
(N'Dumbbells 2x5kg',    4,  58.00, 1),
(N'Running Bottle',     4,  16.50, 0); -- inactive product

-- Orders (2025)
INSERT INTO Orders (CustomerId, OrderDate, Status) VALUES
(1, '2025-01-10T10:15:00', 'Paid'),
(2, '2025-01-12T12:05:00', 'Shipped'),
(2, '2025-02-03T09:20:00', 'Paid'),
(3, '2025-02-14T18:40:00', 'Cancelled'),
(4, '2025-03-02T11:00:00', 'Paid'),
(5, '2025-03-19T14:10:00', 'Shipped'),
(6, '2025-04-25T16:30:00', 'New'),
(7, '2025-05-08T10:00:00', 'Paid'),
(8, '2025-06-12T13:50:00', 'Paid'),
(1, '2025-06-20T09:05:00', 'Shipped'),
(3, '2025-07-01T17:25:00', 'Paid'),
(2, '2025-07-15T08:45:00', 'Paid');

-- OrderItems (UnitPrice може да е различна от ListPrice за отстъпки)
INSERT INTO OrderItems (OrderId, ProductId, Quantity, UnitPrice) VALUES
-- Order 1
(1, 1, 1, 39.90),
(1, 2, 2, 27.50),

-- Order 2
(2, 4, 1, 24.99),
(2, 1, 2, 38.90),

-- Order 3
(3, 3, 1, 189.00),
(3, 2, 1, 29.50),

-- Order 4 (Cancelled)
(4, 6, 1, 129.00),

-- Order 5
(5, 7, 1, 239.00),
(5, 5, 2, 19.80),

-- Order 6
(6, 8, 3, 33.00),
(6, 9, 1, 58.00),

-- Order 7 (New)
(7, 2, 2, 29.50),

-- Order 8
(8, 1, 1, 39.90),
(8, 4, 2, 22.99),
(8, 8, 1, 34.00),

-- Order 9
(9, 3, 1, 199.00),

-- Order 10
(10, 6, 1, 119.00),
(10, 1, 1, 39.90),
(10, 5, 1, 19.80),

-- Order 11
(11, 2, 1, 29.50),
(11, 8, 2, 34.00),

-- Order 12
(12, 7, 1, 249.00),
(12, 9, 2, 55.00);
GO
