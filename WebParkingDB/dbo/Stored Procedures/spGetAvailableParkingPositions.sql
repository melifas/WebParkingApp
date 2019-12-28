CREATE PROCEDURE spGetAvailableParkingPositions

	@startDate date,
	@endDate date,
	@roomTypeID int
AS

begin

	set nocount on;

	select p.*	
	from dbo.Parkings p
	inner join dbo.ParkingTypes t on t.Id=p.ParkingTypeId
	/****** συνέχιση του query για αυτά που δεν είναι booked  ******/
	where p.ParkingTypeId=@roomTypeID 
	and p.Id not in(
	select b.ParkingId
	from dbo.Bookings b
	where (@startDate< b .StartDate and @endDate>b.EndDate)
	or (b.StartDate<= @startDate and @endDate<b.EndDate)
	or (b.StartDate<=@startDate and @startDate<b.EndDate)
	)

end