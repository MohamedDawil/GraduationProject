CREATE TABLE [fresh].[product] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (256) NOT NULL,
    [Freshness]   INT            NOT NULL,
    [ExpiryDate]  DATETIME2 (7)  NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [PickUpDate1] DATETIME2 (7)  NOT NULL,
    [PickUpDate2] DATETIME2 (7)  NOT NULL,
    [Claimed]     BIT            NOT NULL,
    [Collected]   BIT            NOT NULL,
    [Picture]     NVARCHAR (MAX) NOT NULL,
    [PublishDate] DATETIME2 (7)  NOT NULL,
    [GiverId]     NVARCHAR (450) NOT NULL,
    [ReceiverId]  NVARCHAR (450) NULL,
    [Location]    geography NOT NULL,
	[Street] NVARCHAR (MAX) NOT NULL,
	[City] NVARCHAR (MAX) NOT NULL,
	[ZipCode] NVARCHAR (MAX) NOT NULL,
    [IsDeleted] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([GiverId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    FOREIGN KEY ([ReceiverId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

