CREATE PROCEDURE [dbo].[spUser_GetAll]
AS
Begin 
	select Id,FirstName,LastName from dbo.[User]
End
