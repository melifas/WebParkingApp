CREATE TABLE [dbo].[Parkings] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [ParkingNumber] NVARCHAR (50) NOT NULL,
    [ParkingTypeId] INT           NOT NULL,
    CONSTRAINT [PK_Parkings] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Parkings_ParkingTypes] FOREIGN KEY ([ParkingTypeId]) REFERENCES [dbo].[ParkingTypes] ([Id])
);


