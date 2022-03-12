CREATE PROCEDURE [dbo].[spDinosaur_Get]
	@Id int
AS
BEGIN
	SELECT Id, Genera
	FROM [dbo].[Dinosaur]
	WHERE Id = @Id;
END