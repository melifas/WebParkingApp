CREATE PROCEDURE [dbo].[spBookingDetails]
	
AS
BEGIN

	SET NOCOUNT ON;

SELECT dbo.Bookings.*,dbo.Clients.FirstName,dbo.Clients.LatName,dbo.Clients.Phone,dbo.Clients.Email,dbo.Parkings.ParkingNumber
FROM dbo.Bookings,dbo.Clients,dbo.Parkings
WHERE dbo.Bookings.ClientId = Clients.Id and dbo.Bookings.ParkingId = dbo.Parkings.Id
END