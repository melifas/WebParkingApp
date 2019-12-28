CREATE PROCEDURE spBookingInsert

	@clientId int,
	@parkingId int,
	@startDate date,
	@endDate date,
	@totalCost money
AS

begin

set nocount on;
	insert into dbo.Bookings(ClientId,ParkingId,StartDate,EndDate,TotalPrice)
	values (@clientId,@parkingId,@startDate,@endDate,@totalCost)
end