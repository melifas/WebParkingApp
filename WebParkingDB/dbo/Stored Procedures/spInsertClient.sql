CREATE PROCEDURE [dbo].[spInsertClient]
	@firstName nvarchar(50),
	@lastName  nvarchar(50),
	@ImagePath nvarchar(50),
	@email nvarchar(50),
	@phone nvarchar(50)
AS
begin
	set nocount on;

	if not exists (select 1 from dbo.Clients where FirstName = @firstName and LatName = @lastName)
	begin
	insert into dbo.Clients(FirstName, LatName, ImagePath,Email,Phone)
	values (@firstName, @lastName,@ImagePath,@email,@phone)
	end

	select *
	from dbo.Clients
	where FirstName = @firstName and LatName = @lastName
end