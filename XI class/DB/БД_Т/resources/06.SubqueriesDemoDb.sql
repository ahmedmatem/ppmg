/*
    Учебен ресурс: Подзаявки и временни таблици
    Предмет: База данни – теория, 11. клас
    СУБД: Microsoft SQL Server

    Скриптът:
    1. Създава база данни SubqueriesDemoDb, ако тя не съществува.
    2. Създава таблиците Categories, Products, Customers и Orders.
    3. Добавя примерни записи за задачите от презентацията.

    Забележка: При повторно изпълнение учебните таблици се изтриват
    и се създават отново, за да се възстановят началните данни.
*/

USE master;
GO

IF DB_ID(N'SubqueriesDemoDb') IS NULL
BEGIN
    CREATE DATABASE SubqueriesDemoDb;
END;
GO

USE SubqueriesDemoDb;
GO

/* Изтриване в ред, съобразен с външните ключове */
DROP TABLE IF EXISTS Orders;
DROP TABLE IF EXISTS Products;
DROP TABLE IF EXISTS Customers;
DROP TABLE IF EXISTS Categories;
GO

/* 1. Категории */
CREATE TABLE Categories
(
    Id INT IDENTITY(1, 1) PRIMARY KEY,
    CategoryName NVARCHAR(50) NOT NULL UNIQUE
);
GO

/* 2. Продукти */
CREATE TABLE Products
(
    Id INT IDENTITY(1, 1) PRIMARY KEY,
    ProductName NVARCHAR(50) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    CategoryId INT NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,

    CONSTRAINT CK_Products_Price CHECK (Price >= 0),
    CONSTRAINT FK_Products_Categories
        FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);
GO

/* 3. Клиенти */
CREATE TABLE Customers
(
    Id INT IDENTITY(1, 1) PRIMARY KEY,
    CustomerName NVARCHAR(60) NOT NULL,
    City NVARCHAR(40) NOT NULL
);
GO

/* 4. Поръчки */
CREATE TABLE Orders
(
    Id INT IDENTITY(1, 1) PRIMARY KEY,
    CustomerId INT NOT NULL,
    OrderDate DATE NOT NULL,
    Status NVARCHAR(20) NOT NULL,

    CONSTRAINT CK_Orders_Status
        CHECK (Status IN (N'Нова', N'Обработва се', N'Изпратена', N'Завършена')),
    CONSTRAINT FK_Orders_Customers
        FOREIGN KEY (CustomerId) REFERENCES Customers(Id)
);
GO

/* Добавяне на категории */
INSERT INTO Categories (CategoryName)
VALUES
    (N'Техника'),
    (N'Книги'),
    (N'Игри'),
    (N'Храни'),
    (N'Спорт');
GO

/* Добавяне на продукти */
INSERT INTO Products (ProductName, Price, CategoryId, IsActive)
VALUES
    (N'Клавиатура',      80.00,  1, 1),
    (N'Мишка',           45.00,  1, 1),
    (N'Монитор',        420.00,  1, 1),
    (N'Слушалки',       120.00,  1, 1),
    (N'Уеб камера',     180.00,  1, 0),
    (N'SQL за начинаещи', 38.00, 2, 1),
    (N'Алгоритми',       52.00,  2, 1),
    (N'Шах',             35.00,  3, 1),
    (N'Пъзел',           28.00,  3, 1),
    (N'Шоколад',          6.50,  4, 1),
    (N'Кафе',            14.00,  4, 0),
    (N'Футболна топка',  48.00,  5, 1);
GO

/* Добавяне на клиенти */
INSERT INTO Customers (CustomerName, City)
VALUES
    (N'Анна Петрова',    N'Разград'),
    (N'Борис Иванов',    N'Русе'),
    (N'Виктория Георгиева', N'Варна'),
    (N'Георги Димитров', N'Разград'),
    (N'Десислава Николова', N'София'),
    (N'Елена Стоянова',  N'Шумен');
GO

/* Клиентите с Id 5 и 6 нямат поръчки – използват се при NOT EXISTS */
INSERT INTO Orders (CustomerId, OrderDate, Status)
VALUES
    (1, '2026-10-02', N'Нова'),
    (1, '2026-10-10', N'Завършена'),
    (2, '2026-10-12', N'Изпратена'),
    (3, '2026-10-18', N'Нова'),
    (3, '2026-10-25', N'Обработва се'),
    (4, '2026-11-03', N'Завършена');
GO

/* Проверка на създадените данни */
SELECT * FROM Categories;
SELECT * FROM Products;
SELECT * FROM Customers;
SELECT * FROM Orders;
GO

/*
    Начална задача:
    Изпълнете отделните SELECT заявки и разгледайте записите.
    След това използвайте базата за примерите с подзаявки и
    временни таблици от презентацията.
*/
