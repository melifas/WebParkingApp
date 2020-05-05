CREATE TABLE [dbo].[Bookings] (
    [Id]         INT   IDENTITY (1, 1) NOT NULL,
    [ClientId]   INT   NULL,
    [ParkingId]  INT   NULL,
    [StartDate]  DATE  NULL,
    [EndDate]    DATE  NULL,
    [TotalPrice] MONEY NULL,
    [CheckedIn]  BIT   CONSTRAINT [DF_Bookings_CheckedIn] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Bookings_Clients] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Clients] ([Id]),
    CONSTRAINT [FK_Bookings_Parkings] FOREIGN KEY ([ParkingId]) REFERENCES [dbo].[Parkings] ([Id])
);




