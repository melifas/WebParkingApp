-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spAvailableParkingsToday 
	
	
AS
BEGIN
	DECLARE @startDate as date = getDate();
	DECLARE @endDate as date = getDate();
	set nocount on;
/****** Εμφάνιση ένωσης πινάκων  ******/
select t.Id,t.Title,t.Desription,t.Price,COUNT(Title) AS remainingPositions
from dbo.Parkings p
inner join dbo.ParkingTypes t on t.Id=p.ParkingTypeId
/****** συνέχιση του query για αυτά που δεν είναι booked  ******/
where p.Id not in(
select b.ParkingId
from dbo.Bookings b
where (@startDate< b .StartDate and @endDate>b.EndDate)
or (b.StartDate<= @startDate and @endDate<b.EndDate)
or (b.StartDate<=@startDate and @startDate<b.EndDate)
)
group by t.Id,t.Title,t.Desription,t.Price
END