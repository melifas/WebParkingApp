CREATE TABLE [dbo].[Bookings]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ClientId] INT NOT NULL, 
    CONSTRAINT [FK_Bookings_Client] FOREIGN KEY (ClientId) REFERENCES Client(Id)
)
