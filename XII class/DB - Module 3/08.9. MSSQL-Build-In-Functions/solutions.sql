SELECT * FROM People

--A) Стрингови функции (CONCAT, SUBSTRING, REPLACE, LTRIM/RTRIM, LEN, 
--LEFT/RIGHT, LOWER/UPPER, REVERSE, REPLICATE) 

--1. Пълно име (People)
SELECT CONCAT(FirstName, ' ', LastName) AS 'Full Name' 
  FROM People

--2. Нормализирани имейли (People)
SELECT LOWER(Email) AS 'Lower Email', UPPER(Email) AS 'Upper Email'
  FROM People

--3. Инициали 
--People: изведете инициали като A.P. с LEFT + UPPER.
SELECT LEFT(FirstName, 1) + '.' + SUBSTRING(LastName, 1, 1) + '.' AS Initials 
  FROM People
 
--4. Банер „маска“ 
--People: постройте маска REPLICATE('*', LEN(FirstName)) до всяко собствено име. 
SELECT FirstName, REPLICATE('*', LEN(FirstName)) AS 'FirstName Mask'
  FROM People

--5. Премахване на интервали 
--Articles: умишлено върнете низ с водещи/завършващи интервали и ги махнете с 
--LTRIM/RTRIM (напр. SELECT ' spaced ' и покажете трим). 
SELECT * FROM Articles

--6. Преглед на статия 
--Articles: покажете Id, Author, SUBSTRING(Content,1,40) + '…' AS Preview. 
SELECT Id, Author, LEFT(Content, 40) + '...' AS Preview
  FROM Articles

--7. Цензуриране 
--Albums: заменете (case-insensitive) „blood“ в Title с *****, използвайки 
--REPLACE върху LOWER (подсказка: подзаявка с понижен регистър).
SELECT * FROM Albums
SELECT REPLACE(Title, 'blood', '*****') AS Censore
  FROM Albums

--8. Псевдо-SKU 
--Albums: построете SKU от RIGHT на годината (от ReleaseOn), LEFT на 
--заглавието и Id (напр. BM-17-0001). Комбинирайте с функции за дати.
SELECT UPPER(LEFT(Title, 2)) + RIGHT(ISNULL(ReleaseOn, GETDATE()), 4) + '-' + RIGHT('0000' + CAST(Id AS varchar(10)), 4) AS SKU
  FROM Albums

--9. Палиндроми 
--People: покажете имената, при които REVERSE(LOWER(FirstName)) = 
--LOWER(FirstName). 
SELECT FirstName
  FROM People
 WHERE LOWER(FirstName) = LOWER(REVERSE(FirstName))

-- 10. Ориентировъчен брой думи 
--Articles: изчислете брой думи като LEN(Content) - LEN(REPLACE(Content,' ','')) + 1. 
SELECT Content, LEN(Content) - LEN(REPLACE(Content,' ','')) + 1 AS 'Words Count'
  FROM Articles

--B) Математически функции (ABS, SQRT, POWER, ROUND, FLOOR, CEILING, PI) 
--11. Закръглена заплата 

--People: покажете Salary, закръглена до 0, 1 и 2 знака с ROUND.
SELECT ROUND(Salary, 0) AS 'Salary 0', ROUND(Salary, 1) AS 'Salary 1', ROUND(Salary, 2) AS 'Salary 2' 
  FROM People

--12. Крайни суми с отстъпка 
--Orders: изчислете FinalAmount = Amount * (1 - ISNULL(DiscountPercent,0)/100.0); 
--покажете и варианти с FLOOR и CEILING. 
SELECT Amount, DiscountPercent,  CAST(Amount * (1 - ISNULL(DiscountPercent, 0)/100.0) as DECIMAL(10, 2)) AS FinalAmount
  FROM Orders

SELECT Amount, DiscountPercent,  CONVERT(DECIMAL(10, 2), Amount * (1 - ISNULL(DiscountPercent, 0)/100.0)) AS FinalAmount
  FROM Orders

--13. Играчка „разстояние“ 
--Изчислете SQRT(POWER(3,2)+POWER(4,2)), за да демонстрирате SQRT/POWER в 
--един SELECT.
SELECT SQRT(POWER(3,2)+POWER(4,2)) AS Calc

--14. Абсолютна грешка 
--При фиксирана целева заплата (напр. 3000) покажете ABS(Salary-3000) като 
--отклонение и сортирайте възходящо. 
  SELECT FirstName, LastName, Salary, ABS(Salary - 3000) AS 'Salary around 3000' 
    FROM People
ORDER BY 'Salary around 3000'

--15. Проба с π 
--Върнете PI() и ROUND(PI(), 4) като упражнение с константи. 
SELECT ROUND(PI(), 4) AS [pi]

--C) Дата/час функции (GETDATE, DATEADD, DATEDIFF, DATEPART, DATENAME, 
--EOMONTH) 

--16. Стаж в месеци 
--People: месеци на служба = DATEDIFF(MONTH, HireDate, GETDATE()).
SELECT FirstName, LastName, DATEDIFF(MONTH, HireDate, GETDATE()) AS 'months of experience' 
  FROM People

--17. Тримесечие и ден от седмицата (име) 
--Orders: покажете DATEPART(QUARTER, OrderDate) и DATENAME(weekday, OrderDate).
SELECT DATENAME(weekday, OrderDate) AS 'weekday', DATEPART(QUARTER, OrderDate) AS [Quarter]
  FROM Orders

--18. Доставка в края на месеца 
--Orders: изчислете ShipOn = EOMONTH(OrderDate); ако е уикенд (с 
--DATEPART(weekday, …)), преместете до следващия понеделник с DATEADD. 
SELECT OrderDate, DATENAME(weekday, OrderDate) AS [Order day], EOMONTH(OrderDate) AS [Last day in month], 
		CASE 
			WHEN DATENAME(weekday, OrderDate) = 'Saturday' THEN DATENAME(weekday, DATEADD(day, 2, OrderDate))
			WHEN DATENAME(weekday, OrderDate) = 'Sunday' THEN DATENAME(weekday, DATEADD(day, 1, OrderDate))
			ELSE DATENAME(weekday, OrderDate)
		END AS ShipOn
  FROM Orders

--19. Новогодишни промоции 
--Поръчки на 31 декември или 1 януари: отбележете редовете с DATENAME(month, 
--OrderDate) и бележка „Holiday Promo“. 
SELECT OrderDate,
		CASE 
			WHEN DATEPART(month, OrderDate) = 'December' AND DATEPART(day, OrderDate) = 31 
				THEN 'Holiday Promo'
			WHEN DATENAME(month, OrderDate) = 'January' AND DATEPART(day, OrderDate) = 1
				THEN 'Holiday Promo'
			ELSE 'NO Promo '
		END AS Notes
  FROM Orders

--20. Следваща оценка 
--People: планирайте NextReview = DATEADD(year, 1, HireDate).
SELECT HireDate, DATEADD(year, 1, HireDate) AS NextReview
  FROM People

--21. Възраст на статия 
--Articles: минути от публикуване = DATEDIFF(MINUTE, PublishedAt, GETDATE()). 
SELECT DATEDIFF(MINUTE, PublishedAt, GETDATE()) AS [Article Age]
  FROM Articles

--D) Преобразуване на типове и NULL (CAST, CONVERT, ISNULL) 

--22. Безопасни отстъпки 
--Orders: заменете NULL в DiscountPercent с 0 чрез ISNULL и пресметнете крайната цена.
SELECT Amount, DiscountPercent, CAST(Amount * (1 - ISNULL(DiscountPercent, 0) / 100.0) as DECIMAL(18,2)) AS [Final Amount]
  FROM Orders

SELECT Amount, DiscountPercent, CONVERT(DECIMAL(18, 2), Amount * (1 - ISNULL(DiscountPercent, 0) / 100.0)) AS [Final Amount]
  FROM Orders

--23. Форматиране на дата 
--Orders: покажете CONVERT(VARCHAR(10), OrderDate, 104) (dd.mm.yyyy) и 
--CONVERT(VARCHAR(10), OrderDate, 23) (ISO). 
SELECT CONVERT(VARCHAR(10), OrderDate) AS 'Converted date'
  FROM Orders

--24. Етикет „Заплата“ 
--People: изведете CAST(Salary AS VARCHAR(10)) + ' BGN' като текстов етикет. 
SELECT CAST(Salary as VARCHAR(10)) + ' BGN' AS 'Salary'
  FROM People

--25. Низ → дата 
--Демонстрирайте парсване: SELECT CONVERT(date, '2025-03-15') AS ParsedDate; 

SELECT DATEADD(DAY, 3, CONVERT(DATE, '01/02/2030')) AS ParsedDate

--26. Филтър по домейн 
--People: имейли, завършващи на @example.com (използвайте %@example.com). 
SELECT *
  FROM People
 WHERE Email LIKE '%@example.com'

--27. Начало/край на заглавие 
--Albums: заглавия, започващи с Blood или завършващи на lines. 
SELECT *
  FROM Albums
 WHERE Title LIKE 'Blood%' OR Title LIKE '%lines'

--28. Уайлдкард за една буква 
--People: собствени имена с 5 букви, където третата е r (използвайте __r__). 
SELECT *
  FROM People
 WHERE FirstName LIKE '__a_' -- --> ivan