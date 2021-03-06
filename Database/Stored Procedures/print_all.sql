USE [testuserdatabase]
GO
/****** Object:  StoredProcedure [dbo].[print_all]    Script Date: 20/12/2020 16:47:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[print_all]
AS
BEGIN
	SELECT
		Users.Id,
		Users.FirstName,
		Users.LastName,
		Users.Email,
		Users.DateOfBirth,
		Users.Pass,
		Vehicles.Reg,
		Vehicles.DateRegistered
	FROM Users
	LEFT JOIN Vehicles ON Users.Id = Vehicles.UserId
END
