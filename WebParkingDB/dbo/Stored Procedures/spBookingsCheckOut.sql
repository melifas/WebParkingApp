-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spBookingsCheckOut
	-- Add the parameters for the stored procedure here
		@Id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SET NOCOUNT ON;
	update dbo.Bookings
	set CheckedIn = 0
	where Id = @Id
END