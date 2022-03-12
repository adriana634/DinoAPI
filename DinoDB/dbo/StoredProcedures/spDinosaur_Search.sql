CREATE PROCEDURE [dbo].[spDinosaur_Search]
	@criteria nvarchar(32)
AS
BEGIN
	SELECT Id, Genera
	FROM [dbo].[Dinosaur]
	WHERE Genera LIKE @criteria + '%';
END