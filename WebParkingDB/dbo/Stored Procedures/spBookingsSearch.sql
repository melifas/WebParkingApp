
CREATE PROCEDURE [dbo].[spBookingsSearch]
	@lastName nvarchar(50)
	

AS
BEGIN

set nocount on;

select b.*,g.FirstName,g.LatName,g.Phone,g.Email,p.ParkingNumber,p.ParkingTypeId,pt.Title,pt.Desription,pt.Price 
from dbo.Bookings b
inner join dbo.Clients g on  b.ClientId = g.Id
inner join dbo.Parkings p on  b.ParkingId = p.Id
inner join dbo.ParkingTypes pt on  p.ParkingTypeId = pt.Id
where g.LatName = @lastName
END