--Задача 1: Процедура с OUTPUT - Брой книги на автор в библиотека
ALTER PROC dbo.usp_GetAuthorBooksCountInLibrary(
	@LibraryId INT, @AuthorName NVARCHAR(100),	@BooksCount INT OUTPUT)
AS
BEGIN
	DECLARE @hasLibrary BIT -- 1 has, 0 - has not
	DECLARE @hasAuthor BIT -- 1 has, 0 - has not

	SELECT @hasLibrary = COUNT(*)
	  FROM Libraries
	 WHERE Id = @LibraryId

	 SELECT @hasAuthor = COUNT(*)
	  FROM Authors
	 WHERE [Name] = @AuthorName

	 IF(@hasLibrary = 0 OR @hasAuthor = 0)
		SET @BooksCount = NULL
	ELSE
		SELECT @BooksCount = COUNT(*)
		  FROM Authors a
		  JOIN Books b ON a.Id = b.AuthorId
		  JOIN LibrariesBooks lb ON b.Id = lb.BookId
		 WHERE a.[Name] = @AuthorName AND lb.LibraryId = @LibraryId
END

DECLARE @bookNumbers INT
EXEC dbo.usp_GetAuthorBooksCountInLibrary 1, 'Jane Austen', @bookNumbers OUTPUT
SELECT @bookNumbers


--Задача 2 (Функция): Най-ново издание по жанр

ALTER FUNCTION dbo.udf_GetNewestBookTitleByGenre(@GenreName NVARCHAR(30))
RETURNS NVARCHAR(100) AS
BEGIN
	  DECLARE @hasGenre BIT
	  DECLARE @nbTitle NVARCHAR(100)

	  SELECT @hasGenre = COUNT(*)
	    FROM Genres
	   WHERE [Name] = @GenreName

	  IF(@hasGenre = 0)
		 SET @nbTitle = NULL
	  ELSE
		  SELECT TOP(1) @nbTitle = b.Title
			FROM Books b
			JOIN Genres g ON b.GenreId = g.Id
		   WHERE g.[Name] = @GenreName
		ORDER BY b.YearPublished DESC, b.Title

	RETURN @nbTitle
END

SELECT [Name] AS Genre, dbo.udf_GetNewestBookTitleByGenre([Name]) AS 'Newest Book'
  FROM Genres
-- If has no genre --> print NULL
SELECT dbo.udf_GetNewestBookTitleByGenre('xxxxxxx') AS 'Newest Book'



