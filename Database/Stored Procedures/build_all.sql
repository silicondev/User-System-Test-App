USE [testuserdatabase]
GO
/****** Object:  StoredProcedure [dbo].[build_all]    Script Date: 20/12/2020 17:17:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[build_all]
AS
BEGIN
	DROP TABLE Users;
	DROP TABLE Vehicles;

	CREATE TABLE Users (
		Id int IDENTITY(1,1) PRIMARY KEY,
		FirstName varchar(256),
		LastName varchar(256) NOT NULL,
		Email nvarchar(30) NOT NULL,
		DateOfBirth date,
		Pass varchar(256) NOT NULL
	);

	CREATE TABLE Vehicles (
		Id int IDENTITY(1,1) PRIMARY KEY,
		UserId int NOT NULL,
		Descript nvarchar(256) NOT NULL,
		Reg varchar(20),
		DateRegistered date
	);

	
	DBCC CHECKIDENT ('Users', RESEED, 1);
	DBCC CHECKIDENT ('Vehicles', RESEED, 1);

	DECLARE @today date;
	SET @today = (SELECT GETDATE());
	EXEC dbo.add_user NULL, 'sysAdmin', 'sysAdmin@test.com', @today, 'Password1'; -- I know this is insecure in real world scenarios but the app always needs at least 1 account.
END;
