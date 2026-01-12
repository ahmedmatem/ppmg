-- 1.
SELECT COUNT(*) AS OrdersCount FROM Orders

-- 2.
  SELECT [Status], COUNT(*) AS OrdersCount
    FROM Orders
GROUP BY [Status]
ORDER BY OrdersCount DESC, [Status] ASC 

-- 3.
  SELECT * FROM Orders
  SELECT * FROM OrderItems

  SELECT [Status], SUM(oi.Quantity * oi.UnitPrice) AS TotalRevenue
    FROM Orders o
	JOIN OrderItems oi ON o.OrderId = oi.OrderId
GROUP BY [Status]

-- 4.

  SELECT c.FullName, COUNT(*) AS OrdersCount
    FROM Customers c
    JOIN Orders o ON c.CustomerId = o.CustomerId
GROUP BY o.CustomerId, c.FullName
ORDER BY OrdersCount DESC, c.FullName

-- 5.
  SELECT c.FullName, COUNT(*) AS PaidOrdersCount
    FROM Customers c
    JOIN Orders o ON c.CustomerId = o.CustomerId
   WHERE o.[Status] = 'Paid'
GROUP BY o.CustomerId, c.FullName
  HAVING COUNT(*) > 1
ORDER BY PaidOrdersCount DESC, c.FullName

-- 6.
SELECT * FROM Products
SELECT * FROM OrderItems
SELECT * FROM Orders
  -- Using subquery
	SELECT TOP 5 p.ProductName, SUM(oi.Quantity) TotalQty
	  FROM Products p
	  JOIN OrderItems oi ON p.ProductId = oi.ProductId 
	 WHERE oi.OrderId IN 
	 -- subquery
		   (
			  SELECT OrderId
			    FROM Orders
			   WHERE [Status] != 'Cancelled'
		   )
  GROUP BY oi.ProductId, p.ProductName
  ORDER BY TotalQty DESC, p.ProductName

  -- only joins
  	SELECT TOP 5 p.ProductName, SUM(oi.Quantity) TotalQty
	  FROM Products p
	  JOIN OrderItems oi ON p.ProductId = oi.ProductId
	  -- using join
	  JOIN Orders o ON oi.OrderId = o.OrderId
	 WHERE o.[Status] != 'Cancelled'
  GROUP BY oi.ProductId, p.ProductName
  ORDER BY TotalQty DESC, p.ProductName

  -- 7.
	-- only joins
	SELECT c.CategoryName, 
		   --COUNT(*) AS ProductItemsCount, 
		   SUM(Quantity) AS ProductsSoldQty,
		   SUM(Quantity*UnitPrice) AS Revenue
	  FROM Categories c
	  JOIN Products p ON c.CategoryId = p.CategoryId
	  JOIN OrderItems oi ON p.ProductId = oi.ProductId
	  JOIN Orders o ON oi.OrderId = o.OrderId
	 WHERE o.[Status] != 'Cancelled'
  GROUP BY c.CategoryName
  ORDER BY Revenue DESC

  -- joins and subqueries
    SELECT c.CategoryName, 
		   --COUNT(*) AS ProductItemsCount, 
		   SUM(Quantity) AS ProductsSoldQty,
		   SUM(Quantity*UnitPrice) AS Revenue
	  FROM Categories c
	  JOIN Products p ON c.CategoryId = p.CategoryId
	  JOIN OrderItems oi ON p.ProductId = oi.ProductId
	 WHERE oi.OrderId IN 
		   (
			  SELECT OrderId
			    FROM Orders
			   WHERE [Status] != 'Cancelled'
		   )
  GROUP BY c.CategoryName
  ORDER BY Revenue DESC

  -- 8.
	SELECT * FROM Cities
	SELECT * FROM Customers
	SELECT * FROM Orders
	SELECT * FROM OrderItems

	SELECT x.CityName, 
		   CONVERT(DECIMAL(10,2), AVG(oi.Quantity* oi.UnitPrice)) AS AvgOrderValue
	  FROM Cities c
	  JOIN Customers cst ON c.CityId = cst.CityId
	  JOIN Orders o ON cst.CustomerId = o. CustomerId
	  JOIN OrderItems oi ON o.OrderId = oi.OrderId
	 WHERE o.[Status] IN ('Paid', 'Shipped')
  GROUP BY c.CityName

  SELECT x.CityName, 
		 CONVERT(DECIMAL(10,2), AVG(x.SumOrderValue)) AS AvgOrderValue
	FROM
		(
			SELECT c.CityId,
				   c.CityName, 
		           SUM(oi.Quantity* oi.UnitPrice) AS SumOrderValue
			  FROM Cities c
			  JOIN Customers cst ON c.CityId = cst.CityId
			  JOIN Orders o ON cst.CustomerId = o. CustomerId
			  JOIN OrderItems oi ON o.OrderId = oi.OrderId
			 WHERE o.[Status] IN ('Paid', 'Shipped')
		  GROUP BY c.CityId, c.CityName, o.OrderId
		) AS x
	GROUP BY x.CityName

  -- 9.







