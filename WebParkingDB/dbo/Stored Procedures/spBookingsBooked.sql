-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spBookingsBooked 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT dbo.Bookings.*,dbo.Clients.FirstName,dbo.Clients.LatName,dbo.Clients.Phone,dbo.Clients.Email,dbo.Parkings.ParkingNumber
FROM dbo.Bookings,dbo.Clients,dbo.Parkings
WHERE dbo.Bookings.ClientId = Clients.Id and dbo.Bookings.ParkingId = dbo.Parkings.Id AND dbo.Bookings.CheckedIn=1
END