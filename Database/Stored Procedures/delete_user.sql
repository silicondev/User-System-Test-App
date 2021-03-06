USE [testuserdatabase]
GO
/****** Object:  StoredProcedure [dbo].[delete_user]    Script Date: 20/12/2020 16:46:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[delete_user] @email nvarchar(30)
AS
BEGIN
	DECLARE @userFind int;

	SET @userFind = (
		SELECT COUNT(*) FROM Users WHERE Users.Email = @email
	);

	IF @userFind != 1
	BEGIN
		RETURN 1;
	END

	DELETE FROM Users WHERE Users.Email = @email;
	RETURN 0;
END