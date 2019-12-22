CREATE TABLE [dbo].[ParkingTypes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] VARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Price] MONEY NOT NULL 
)
