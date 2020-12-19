USE testuserdatabase
GO
ALTER PROCEDURE dbo.print_all
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
