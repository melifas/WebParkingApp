CREATE PROCEDURE [dbo].[spParkingPositionsNotBooked] 
	
AS
BEGIN	
	SET NOCOUNT ON;

	SELECT *
	from dbo.Parkings p
	where p.Id not in(
			SELECT dbo.Parkings.Id AS Id
			FROM dbo.Bookings,dbo.Parkings
			WHERE  dbo.Bookings.ParkingId = dbo.Parkings.Id
	                 )
END