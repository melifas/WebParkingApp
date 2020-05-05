-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spAvailableParkingPositionsWithStringParams
	-- Add the parameters for the stored procedure here
	@startDate varchar,
	@endDate varchar,
	@roomTypeID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

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
END