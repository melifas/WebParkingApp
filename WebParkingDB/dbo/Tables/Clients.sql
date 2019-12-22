CREATE TABLE [dbo].[Clients]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Phone] INT NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [BookingId] INT NOT NULL, 
    CONSTRAINT [FK_Client_Bookings] FOREIGN KEY (BookingId) REFERENCES Bookings(Id)
)
