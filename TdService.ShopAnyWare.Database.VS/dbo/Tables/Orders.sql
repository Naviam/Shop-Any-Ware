CREATE TABLE [dbo].[Orders] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [OrderNumber]    NVARCHAR (40) NULL,
    [TrackingNumber] NVARCHAR (40) NULL,
    [CreatedDate]    DATETIME      NOT NULL,
    [ReceivedDate]   DATETIME      NULL,
    [ReturnedDate]   DATETIME      NULL,
    [DisposedDate]   DATETIME      NULL,
    [Status]         INT           NOT NULL,
    [Retailer_Id]    INT           NULL,
    [User_Id]        INT           NULL,
    CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Orders_dbo.Retailers_Retailer_Id] FOREIGN KEY ([Retailer_Id]) REFERENCES [dbo].[Retailers] ([Id]),
    CONSTRAINT [FK_dbo.Orders_dbo.Users_User_Id] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[Users] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Retailer_Id]
    ON [dbo].[Orders]([Retailer_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_User_Id]
    ON [dbo].[Orders]([User_Id] ASC);

