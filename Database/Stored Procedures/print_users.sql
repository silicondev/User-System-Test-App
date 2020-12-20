USE [testuserdatabase]
GO
/****** Object:  StoredProcedure [dbo].[print_users]    Script Date: 20/12/2020 16:54:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[print_users]
AS
BEGIN
	SELECT 
		Users.Id,
		Users.FirstName,
		Users.LastName,
		Users.Email,
		Users.DateOfBirth,
		(SELECT COUNT(*) FROM Vehicles WHERE Users.Id = Vehicles.UserId) AS Vehicles
	FROM Users
	LEFT JOIN Vehicles ON Users.Id = Vehicles.UserId;
END