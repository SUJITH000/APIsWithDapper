CREATE PROCEDURE [dbo].[spUser_insert]
	@FirstName varchar(50),
	@LastName varchar(50)
as
Begin
	insert into dbo.[User](FirstName,LastName) values(@FirstName,@LastName)
End