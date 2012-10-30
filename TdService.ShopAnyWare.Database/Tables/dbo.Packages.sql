CREATE TABLE [dbo].[Packages]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (21) COLLATE Cyrillic_General_CI_AS NULL,
[Status] [int] NOT NULL,
[CreatedDate] [datetime] NOT NULL,
[DispatchedDate] [datetime] NULL,
[DeliveredDate] [datetime] NULL,
[DispatchMethod] [int] NOT NULL,
[Weight_Pounds] [int] NULL,
[Weight_Ounces] [decimal] (18, 2) NULL,
[Dimensions_Length] [decimal] (18, 2) NULL,
[Dimensions_Height] [decimal] (18, 2) NULL,
[Dimensions_Width] [decimal] (18, 2) NULL,
[Dimensions_Girth] [decimal] (18, 2) NULL,
[RowVersion] [varbinary] (max) NULL,
[DeliveryAddress_Id] [int] NULL,
[User_Id] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Packages] ADD CONSTRAINT [PK_dbo.Packages] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_DeliveryAddress_Id] ON [dbo].[Packages] ([DeliveryAddress_Id]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_User_Id] ON [dbo].[Packages] ([User_Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Packages] ADD CONSTRAINT [FK_dbo.Packages_dbo.DeliveryAddresses_DeliveryAddress_Id] FOREIGN KEY ([DeliveryAddress_Id]) REFERENCES [dbo].[DeliveryAddresses] ([Id])
GO
ALTER TABLE [dbo].[Packages] ADD CONSTRAINT [FK_dbo.Packages_dbo.Users_User_Id] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[Users] ([Id])
GO
