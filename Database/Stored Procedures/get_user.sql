USE [testuserdatabase]
GO
/****** Object:  StoredProcedure [dbo].[get_user]    Script Date: 20/12/2020 18:38:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[get_user] @id int
AS
BEGIN
	SELECT 
		Users.Id,
		Users.FirstName,
		Users.LastName,
		Users.Email,
		Users.DateOfBirth,
		Users.IsAdmin
	FROM Users
	WHERE Users.Id = @id
END