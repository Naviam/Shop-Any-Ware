CREATE TABLE [dbo].[Packages] (
    [Id]                 INT             IDENTITY (1, 1) NOT NULL,
    [Name]               NVARCHAR (21)   NULL,
    [Status]             INT             NOT NULL,
    [CreatedDate]        DATETIME        NOT NULL,
    [DispatchedDate]     DATETIME        NULL,
    [DeliveredDate]      DATETIME        NULL,
    [DispatchMethod]     INT             NOT NULL,
    [Weight_Pounds]      INT             NULL,
    [Weight_Ounces]      DECIMAL (18, 2) NULL,
    [Dimensions_Length]  DECIMAL (18, 2) NULL,
    [Dimensions_Height]  DECIMAL (18, 2) NULL,
    [Dimensions_Width]   DECIMAL (18, 2) NULL,
    [Dimensions_Girth]   DECIMAL (18, 2) NULL,
    [RowVersion]         VARBINARY (MAX) NULL,
    [DeliveryAddress_Id] INT             NULL,
    [User_Id]            INT             NULL,
    CONSTRAINT [PK_dbo.Packages] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Packages_dbo.DeliveryAddresses_DeliveryAddress_Id] FOREIGN KEY ([DeliveryAddress_Id]) REFERENCES [dbo].[DeliveryAddresses] ([Id]),
    CONSTRAINT [FK_dbo.Packages_dbo.Users_User_Id] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[Users] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_DeliveryAddress_Id]
    ON [dbo].[Packages]([DeliveryAddress_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_User_Id]
    ON [dbo].[Packages]([User_Id] ASC);

