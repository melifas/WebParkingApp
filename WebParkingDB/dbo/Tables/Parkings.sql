CREATE TABLE [dbo].[Parkings]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ParkingNumber] NVARCHAR(50) NOT NULL, 
    [ParkingTypeId] INT NOT NULL, 
    [ClientId] INT NOT NULL, 
    [BookingId] INT NOT NULL, 
    CONSTRAINT [FK_Parking_ParkingTypes] FOREIGN KEY (ParkingTypeId) REFERENCES ParkingTypes(Id), 
    CONSTRAINT [FK_Parking_Bookings] FOREIGN KEY (BookingId) REFERENCES Bookings(Id), 
    CONSTRAINT [FK_Parking_Clients] FOREIGN KEY (ClientId) REFERENCES Clients(Id) 
)
