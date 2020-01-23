CREATE TABLE [dbo].[Clients] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (50)  NOT NULL,
    [LatName]   NVARCHAR (50)  NOT NULL,
    [Phone]     INT            NULL,
    [Email]     NVARCHAR (50)  NULL,
    [ImagePath] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED ([Id] ASC)
);






