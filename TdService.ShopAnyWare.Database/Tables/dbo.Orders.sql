CREATE TABLE [dbo].[Orders]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[OrderNumber] [nvarchar] (40) COLLATE Cyrillic_General_CI_AS NULL,
[TrackingNumber] [nvarchar] (40) COLLATE Cyrillic_General_CI_AS NULL,
[CreatedDate] [datetime] NOT NULL,
[ReceivedDate] [datetime] NULL,
[ReturnedDate] [datetime] NULL,
[DisposedDate] [datetime] NULL,
[Status] [int] NOT NULL,
[Retailer_Id] [int] NULL,
[User_Id] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Orders] ADD CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Retailer_Id] ON [dbo].[Orders] ([Retailer_Id]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_User_Id] ON [dbo].[Orders] ([User_Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Orders] ADD CONSTRAINT [FK_dbo.Orders_dbo.Retailers_Retailer_Id] FOREIGN KEY ([Retailer_Id]) REFERENCES [dbo].[Retailers] ([Id])
GO
ALTER TABLE [dbo].[Orders] ADD CONSTRAINT [FK_dbo.Orders_dbo.Users_User_Id] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[Users] ([Id])
GO
