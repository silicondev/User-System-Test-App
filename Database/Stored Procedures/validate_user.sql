USE [testuserdatabase]
GO
/****** Object:  StoredProcedure [dbo].[validate_user]    Script Date: 20/12/2020 16:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[validate_user] @email nvarchar(30), @pass nvarchar(32) -- Returns user id if validation is successful, -2 if user does not exist and -1 if password is incorrect
AS
BEGIN
	DECLARE @userFind int, @userId int, @hashedPass varchar(256), @getHashed varchar(256);

	SET @userFind = (
		SELECT COUNT(*) FROM Users WHERE Users.Email = @email
	);

	IF @userFind != 1
	BEGIN
		RETURN -2;
	END

	SET @userId = (
		SELECT Users.Id FROM Users WHERE Users.Email = @email
	)

	EXEC dbo.hash_pass @email, @pass, @hashedPass OUTPUT;
	SET @getHashed = (
		SELECT Users.Pass FROM Users WHERE Users.Id = @userId
	)

	IF @hashedPass != @getHashed
	BEGIN
		RETURN -1;
	END
	ELSE
	BEGIN
		RETURN @userId;
	END
END