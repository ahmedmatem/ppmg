DROP FUNCTION IF EXISTS dbo.udf_IsShoeAvailableInEUSize
ALTER FUNCTION dbo.udf_IsShoeAvailableInEUSize(@ShoeModel NVARCHAR(30), @EUSize DECIMAL(5,2))
RETURNS BIT AS
BEGIN
	DECLARE @exists BIT
	DECLARE @hasModel BIT

	--SELECT @hasModel = COUNT(*)
	--  FROM Shoes
	-- WHERE Model = @ShoeModel

	IF NOT EXISTS(SELECT 1 FROM Shoes WHERE Model = @ShoeModel)
		SET @exists = NULL
	ELSE
		SELECT @exists = COUNT(*)
		  FROM Shoes s
		  JOIN ShoesSizes ss ON s.Id = ss.ShoeId
		  JOIN Sizes sz ON ss.SizeId = sz.Id
		 WHERE s.Model = @ShoeModel AND sz.EU = @EUSize

	 RETURN @exists
END

SELECT Model, dbo.udf_IsShoeAvailableInEUSize('Dummy model', 39) AS '39 EU', 
dbo.udf_IsShoeAvailableInEUSize(Model, 41) AS '41 EU', 
dbo.udf_IsShoeAvailableInEUSize(Model, 43) AS '43 EU'
  FROM Shoes

DROP PROC dbo.usp_GetMostOrderedShoeModelByUser
CREATE PROC dbo.usp_GetMostOrderedShoeModelByUser(
	@Username NVARCHAR(50),
	@ShoeModel NVARCHAR(30) OUTPUT) AS
BEGIN
	WITH modelCounter (Model, ModelCount) AS
	  (SELECT TOP(1) Model, COUNT(*) AS ModelCount
		FROM Users u
		JOIN Orders o ON u.Id = o.UserId
		JOIN Shoes s ON o.ShoeId = s.Id
	   WHERE u.Username = @Username
	GROUP BY s.Model
	ORDER BY COUNT(*) DESC)

	SELECT @ShoeModel = Model
	  FROM modelCounter
END

DECLARE @mostPopularModel NVARCHAR(30)
EXEC dbo.usp_GetMostOrderedShoeModelByUser 'mking', @mostPopularModel OUTPUT
SELECT @mostPopularModel