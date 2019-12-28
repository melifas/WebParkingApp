CREATE PROCEDURE spInsertClient
	@firstName nvarchar(50),
	@lastName  nvarchar(50)
AS
begin
	set nocount on;

	if not exists (select 1 from dbo.Clients where FirstName = @firstName and LatName = @lastName)
	begin
	insert into dbo.Clients(FirstName, LatName)
	values (@firstName, @lastName)
	end

	select *
	from dbo.Clients
	where FirstName = @firstName and LatName = @lastName
end