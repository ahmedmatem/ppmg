-- 4.	Всички поръчки
SELECT * FROM Users
SELECT * FROM Orders
SELECT * FROM Products
SELECT * FROM ProductTypes

SELECT u.FirstName, u.LastName, p.[Name] AS ProductName, p.Price
  FROM Users u
  JOIN Orders o ON u.Id = o.UserId
  JOIN Products p ON o.ProductId = p.Id

 SELECT u.FirstName, u.LastName, p.[Name] AS ProductName, p.Price
   FROM Users u
   JOIN Orders o ON u.Id = o.UserId
   JOIN Products p ON o.ProductId = p.Id

--5.	Продукти от тип електроника
SELECT u.FirstName, u.LastName, p.[Name] AS ProductName, p.Price
  FROM Users u
  JOIN Orders o ON u.Id = o.UserId
  JOIN Products p ON o.ProductId = p.Id
 WHERE p.TypeId IN 
 (
	SELECT Id
	  FROM ProductTypes
	 WHERE [Name] = 'Electronics'
 )

 SELECT u.FirstName, u.LastName, p.[Name] AS ProductName, p.Price
   FROM Users u
   JOIN Orders o ON u.Id = o.UserId
   JOIN Products p ON o.ProductId = p.Id
   JOIN ProductTypes pt ON p.TypeId = pt.Id
  WHERE pt.[Name] = 'Electronics'

--6.	Поръчки на потребител с името John
 SELECT u.FirstName, p.[Name] AS 'Product', p.Price
   FROM Users u
   JOIN Orders o ON u.Id = o.UserId
   JOIN Products p ON o.ProductId = p.Id
  WHERE u.FirstName = 'John'

--7.	Поръчки на стойност над 1000
  SELECT o.Id, p.[Name] AS 'Product', u.FirstName, u.LastName, p.Price
    FROM Users u
    JOIN Orders o ON u.Id = o.UserId
    JOIN Products p ON o.ProductId = p.Id
   WHERE p.Price > 1000
ORDER BY p.Price DESC

--8.	Най-скъпия продукт
  SELECT o.Id, u.FirstName, u.LastName, p.[Name] AS 'Product', p.Price
    FROM Users u
    JOIN Orders o ON u.Id = o.UserId
    JOIN Products p ON o.ProductId = p.Id
	WHERE p.Id IN
	(
		    SELECT TOP(1) Id
		      FROM Products 
		  ORDER BY Price DESC
	)

--9.	*Потребители с повече от една поръчка
SELECT u.FirstName, u.LastName
  FROM Users u
 WHERE 
 (
	SELECT COUNT(*)
	  FROM Orders o
	 WHERE u.Id = o.UserId
 ) > 1