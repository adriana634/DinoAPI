CREATE PROCEDURE [dbo].[spDinosaur_GetAll]
AS
BEGIN
	SELECT Id, Genera
	FROM [dbo].[Dinosaur]
END