USE testuserdatabase
GO
ALTER PROCEDURE add_user @fName varchar(256) NULL, @lName varchar(256), @email nvarchar(30), @dob date NULL, @pass nvarchar(32)
AS
BEGIN
	BEGIN TRAN
		
		
		DECLARE @SaltedPass varchar(256), @error int, @state int;
		SET @error = 0;
		SET @state = 0;
		SET @SaltedPass = 'NullPass';
		

		IF @pass IS NULL
		BEGIN
			SET @error = 1;
			SET @state = 1;
		END
		ELSE
		BEGIN
			SET @SaltedPass = hashbytes('SHA2_256', @pass + convert(varchar(256), hashbytes('SHA2_256', @email)));
			IF @SaltedPass IS NULL
			BEGIN
				SET @error = 1;
				SET @state = 2;
			END
		END

		IF @lName IS NULL OR @email IS NULL
		BEGIN
			SET @error = 1;
			SET @state = 3;
		END

		IF @error = 1
		BEGIN
			RAISERROR('Non nullable values were inputted as null.', 1, @state);
			ROLLBACK TRAN;
		END
		ELSE
		BEGIN
			IF @fName IS NULL AND @dob IS NOT NULL
			BEGIN
				INSERT INTO dbo.Users (LastName, Email, DateOfBirth, Pass) VALUES (@lName, @email, @dob, @SaltedPass);
			END
			IF @fName IS NOT NULL AND @dob IS NULL
			BEGIN
				INSERT INTO dbo.Users (FirstName, LastName, Email, Pass) VALUES (@fName, @lName, @email, @SaltedPass);
			END
			IF @fName IS NOT NULL AND @dob IS NOT NULL
			BEGIN
				INSERT INTO dbo.Users (FirstName, LastName, Email, DateOfBirth, Pass) VALUES (@fName, @lName, @email, @dob, @SaltedPass)
			END
			COMMIT TRAN
		END
END