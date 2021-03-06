USE [testuserdatabase]
GO
/****** Object:  StoredProcedure [dbo].[hash_pass]    Script Date: 20/12/2020 16:47:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[hash_pass] @email nvarchar(30), @pass nvarchar(32), @out varchar(256) OUT
AS
BEGIN
	SET @out = CONVERT(varchar(256), HASHBYTES('SHA2_256', @pass + CONVERT(varchar(256), HASHBYTES('SHA2_256', @email), 2)), 2);
END