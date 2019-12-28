CREATE TABLE [dbo].[ParkingTypes] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Title]      NVARCHAR (50)  NOT NULL,
    [Desription] NVARCHAR (MAX) NOT NULL,
    [Price]      MONEY          NOT NULL,
    CONSTRAINT [PK_ParkingTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);


