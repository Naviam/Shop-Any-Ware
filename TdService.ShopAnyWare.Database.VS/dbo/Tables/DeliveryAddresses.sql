CREATE TABLE [dbo].[DeliveryAddresses] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [AddressName]   NVARCHAR (40)  NOT NULL,
    [FirstName]     NVARCHAR (21)  NOT NULL,
    [LastName]      NVARCHAR (21)  NOT NULL,
    [ZipCode]       NVARCHAR (10)  NOT NULL,
    [Country]       NVARCHAR (64)  NOT NULL,
    [Region]        NVARCHAR (64)  NULL,
    [City]          NVARCHAR (64)  NOT NULL,
    [AddressLine1]  NVARCHAR (256) NOT NULL,
    [AddressLine2]  NVARCHAR (256) NULL,
    [AddressLine3]  NVARCHAR (256) NULL,
    [Phone]         NVARCHAR (21)  NULL,
    [State]         NVARCHAR (64)  NULL,
    [RowVersion]    ROWVERSION     NOT NULL,
    [RoomNumber]    NVARCHAR (MAX) NULL,
    [Discriminator] NVARCHAR (128) NOT NULL,
    [User_Id]       INT            NULL,
    CONSTRAINT [PK_dbo.DeliveryAddresses] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.DeliveryAddresses_dbo.Users_User_Id] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[Users] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_User_Id]
    ON [dbo].[DeliveryAddresses]([User_Id] ASC);

