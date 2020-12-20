USE [testuserdatabase]
GO
/****** Object:  StoredProcedure [dbo].[build_all]    Script Date: 20/12/2020 14:13:58 ******/
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
END;
