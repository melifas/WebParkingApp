CREATE TABLE [dbo].[Parking]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ParkingNumber] NVARCHAR(50) NOT NULL, 
    [ParkingTypeId] INT NOT NULL, 
    [ClientId] INT NOT NULL, 
    [BookingId] INT NOT NULL, 
    CONSTRAINT [FK_Parking_ParkingTypes] FOREIGN KEY (ParkingTypeId) REFERENCES ParkingTypes(Id), 
    CONSTRAINT [FK_Parking_Client] FOREIGN KEY (ClientId) REFERENCES Client(Id), 
    CONSTRAINT [FK_Parking_Bookings] FOREIGN KEY (BookingId) REFERENCES Bookings(Id) 
)
