IF DB_ID('ShopDemoDb') IS NOT NULL
BEGIN
    ALTER DATABASE ShopDemoDb SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE ShopDemoDb;
END
GO

CREATE DATABASE ShopDemoDb;
GO

USE ShopDemoDb;
GO

CREATE TABLE Categories
(
    CategoryId INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE Products
(
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(100) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    CategoryId INT NOT NULL,
    CONSTRAINT FK_Products_Categories
        FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);
GO

INSERT INTO Categories (CategoryName)
VALUES
(N'Напитки'),
(N'Плодове'),
(N'Зеленчуци'),
(N'Техника'),
(N'Книги'),
(N'Ученически пособия');
GO

INSERT INTO Products (ProductName, Price, CategoryId)
VALUES
-- Напитки
(N'Минерална вода', 1.20, 1),
(N'Портокалов сок', 2.80, 1),
(N'Студен чай', 2.50, 1),
(N'Кафе', 3.20, 1),

-- Плодове
(N'Ябълки', 2.40, 2),
(N'Банани', 2.90, 2),
(N'Портокали', 3.10, 2),
(N'Грозде', 4.50, 2),

-- Зеленчуци
(N'Домати', 3.60, 3),
(N'Краставици', 2.70, 3),
(N'Картофи', 1.80, 3),
(N'Моркови', 1.90, 3),

-- Техника
(N'Клавиатура', 35.00, 4),
(N'Мишка', 22.50, 4),
(N'Слушалки', 49.99, 4),
(N'USB памет 32GB', 18.00, 4),

-- Книги
(N'Под игото', 14.90, 5),
(N'Немили-недраги', 12.50, 5),
(N'Програмиране с C#', 27.90, 5),
(N'Бази данни', 24.00, 5),

-- Ученически пособия
(N'Тетрадка А4', 3.50, 6),
(N'Химикал', 1.20, 6),
(N'Молив', 0.90, 6),
(N'Линийка', 1.50, 6);
GO