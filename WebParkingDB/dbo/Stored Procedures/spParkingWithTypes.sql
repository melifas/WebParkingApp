-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spParkingWithTypes]
	
AS
BEGIN
	
SET NOCOUNT ON;

SELECT dbo.Parkings.*,dbo.ParkingTypes.Desription,dbo.ParkingTypes.Title,dbo.ParkingTypes.Price
FROM dbo.Parkings,dbo.ParkingTypes
WHERE dbo.Parkings.ParkingTypeId = dbo.ParkingTypes.Id
END