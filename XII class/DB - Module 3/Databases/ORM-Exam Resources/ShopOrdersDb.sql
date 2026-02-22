/* ============================
   ShopOrdersDB.sql
   ============================ */

IF DB_ID('ShopOrdersDB') IS NULL
BEGIN
    CREATE DATABASE ShopOrdersDB;
END
GO

USE ShopOrdersDB;
GO

-- Drop tables (safe re-run)
IF OBJECT_ID('dbo.OrderItems', 'U') IS NOT NULL DROP TABLE dbo.OrderItems;
IF OBJECT_ID('dbo.Orders', 'U') IS NOT NULL DROP TABLE dbo.Orders;
IF OBJECT_ID('dbo.Products', 'U') IS NOT NULL DROP TABLE dbo.Products;
IF OBJECT_ID('dbo.Categories', 'U') IS NOT NULL DROP TABLE dbo.Categories;
IF OBJECT_ID('dbo.Customers', 'U') IS NOT NULL DROP TABLE dbo.Customers;
GO

-- 1) Customers
CREATE TABLE dbo.Customers
(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    FullName NVARCHAR(120) NOT NULL,
    Email NVARCHAR(140) NOT NULL UNIQUE,
    Phone NVARCHAR(30) NULL,
    City NVARCHAR(80) NOT NULL
);
GO

-- 2) Categories
CREATE TABLE dbo.Categories
(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(80) NOT NULL UNIQUE
);
GO

-- 3) Products (FK -> Categories)
CREATE TABLE dbo.Products
(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(140) NOT NULL,
    CategoryId INT NOT NULL,
    UnitPrice DECIMAL(10,2) NOT NULL CHECK (UnitPrice >= 0),
    InStock INT NOT NULL CHECK (InStock >= 0),
    CONSTRAINT FK_Products_Categories FOREIGN KEY (CategoryId) REFERENCES dbo.Categories(Id) ON DELETE NO ACTION
);
GO

-- 4) Orders (FK -> Customers)
CREATE TABLE dbo.Orders
(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    CustomerId INT NOT NULL,
    OrderDateUtc DATETIME2 NOT NULL CONSTRAINT DF_Orders_OrderDateUtc DEFAULT (SYSUTCDATETIME()),
    Status NVARCHAR(20) NOT NULL CONSTRAINT DF_Orders_Status DEFAULT ('Pending'),
    CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerId) REFERENCES dbo.Customers(Id) ON DELETE NO ACTION,
    CONSTRAINT CK_Orders_Status CHECK (Status IN ('Pending','Paid','Shipped','Cancelled'))
);
GO

-- 5) OrderItems (FK -> Orders, FK -> Products)
CREATE TABLE dbo.OrderItems
(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    UnitPriceAtOrder DECIMAL(10,2) NOT NULL CHECK (UnitPriceAtOrder >= 0),
    CONSTRAINT FK_OrderItems_Orders FOREIGN KEY (OrderId) REFERENCES dbo.Orders(Id) ON DELETE CASCADE,
    CONSTRAINT FK_OrderItems_Products FOREIGN KEY (ProductId) REFERENCES dbo.Products(Id) ON DELETE NO ACTION,
    CONSTRAINT UQ_OrderItems_Order_Product UNIQUE (OrderId, ProductId)
);
GO

/* ===== Inserts ===== */

-- Customers (10)
INSERT INTO dbo.Customers (FullName, Email, Phone, City) VALUES
('Emma Johnson',   'emma.johnson@example.com',   '+1-202-555-0101', 'New York'),
('Noah Williams',  'noah.williams@example.com',  '+1-202-555-0102', 'Chicago'),
('Olivia Brown',   'olivia.brown@example.com',   '+1-202-555-0103', 'Boston'),
('Liam Jones',     'liam.jones@example.com',     '+1-202-555-0104', 'Seattle'),
('Ava Garcia',     'ava.garcia@example.com',     '+1-202-555-0105', 'Austin'),
('Ethan Miller',   'ethan.miller@example.com',   '+1-202-555-0106', 'Denver'),
('Sophia Davis',   'sophia.davis@example.com',   '+1-202-555-0107', 'Miami'),
('Mason Wilson',   'mason.wilson@example.com',   '+1-202-555-0108', 'San Diego'),
('Isabella Moore', 'isabella.moore@example.com', '+1-202-555-0109', 'Atlanta'),
('Lucas Taylor',   'lucas.taylor@example.com',   '+1-202-555-0110', 'Portland');
GO

-- Categories (10)
INSERT INTO dbo.Categories (Name) VALUES
('Laptops'),
('Monitors'),
('Keyboards'),
('Mice'),
('Headphones'),
('Storage'),
('Networking'),
('Office Chairs'),
('Webcams'),
('Speakers');
GO

-- Products (10) (CategoryId 1..10)
INSERT INTO dbo.Products (Name, CategoryId, UnitPrice, InStock) VALUES
('ApexBook 14',             1,  899.00, 25),
('UltraView 27 Monitor',    2,  249.99, 40),
('Mechanical Keyboard Pro', 3,  109.50, 60),
('Precision Mouse X2',      4,   39.90, 120),
('NoiseCancel Headset',     5,  179.00, 35),
('NVMe SSD 1TB',            6,   89.99, 80),
('WiFi 6 Router',           7,  129.00, 30),
('Ergo Office Chair',       8,  219.00, 15),
('HD Webcam 1080p',         9,   49.99, 55),
('Compact Speakers Set',   10,   59.00, 45);
GO

-- Orders (10) (CustomerId 1..10)
INSERT INTO dbo.Orders (CustomerId, OrderDateUtc, Status) VALUES
(1,  '2026-02-01T10:15:00Z', 'Paid'),
(2,  '2026-02-03T14:20:00Z', 'Shipped'),
(3,  '2026-02-05T09:05:00Z', 'Paid'),
(4,  '2026-02-07T18:45:00Z', 'Cancelled'),
(5,  '2026-02-09T11:30:00Z', 'Pending'),
(6,  '2026-02-10T16:10:00Z', 'Paid'),
(7,  '2026-02-12T12:00:00Z', 'Shipped'),
(8,  '2026-02-14T08:50:00Z', 'Paid'),
(9,  '2026-02-16T19:25:00Z', 'Pending'),
(10, '2026-02-18T13:40:00Z', 'Paid');
GO

-- OrderItems (>=10; тук са 20 за по-богати LINQ заявки)
INSERT INTO dbo.OrderItems (OrderId, ProductId, Quantity, UnitPriceAtOrder) VALUES
(1,  1, 1, 899.00),
(1,  6, 1,  89.99),

(2,  2, 2, 249.99),
(2,  4, 1,  39.90),

(3,  3, 1, 109.50),
(3,  5, 1, 179.00),

(4,  9, 1,  49.99),
(4, 10, 1,  59.00),

(5,  7, 1, 129.00),
(5,  6, 2,  89.99),

(6,  8, 1, 219.00),
(6,  4, 2,  39.90),

(7,  1, 1, 899.00),
(7,  2, 1, 249.99),

(8,  5, 1, 179.00),
(8,  3, 1, 109.50),

(9,  6, 1,  89.99),
(9,  9, 2,  49.99),

(10, 2, 1, 249.99),
(10, 4, 1,  39.90);
GO