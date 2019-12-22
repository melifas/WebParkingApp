CREATE TABLE [dbo].[Bookings]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ClientId] INT NOT NULL, 
    [ParkingId] INT NOT NULL, 
    [StartDate] DATETIME NOT NULL, 
    [EndDate] DATETIME NOT NULL, 
    [TotalPrice] MONEY NOT NULL, 
    CONSTRAINT [FK_Bookings_Clients] FOREIGN KEY (ClientId) REFERENCES Clients(Id), 
    CONSTRAINT [FK_Bookings_Parkings] FOREIGN KEY (ParkingId) REFERENCES Parkings(Id)
)
