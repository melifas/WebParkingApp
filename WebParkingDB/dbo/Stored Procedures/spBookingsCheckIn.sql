CREATE PROCEDURE [dbo].[spBookingsCheckIn]
	@Id int
AS
BEGIN
	
	SET NOCOUNT ON;
	update dbo.Bookings
	set CheckedIn = 1
	where Id = @Id
    
END