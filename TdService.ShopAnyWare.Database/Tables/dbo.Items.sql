CREATE TABLE [dbo].[Items]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (64) COLLATE Cyrillic_General_CI_AS NOT NULL,
[Quantity] [int] NOT NULL,
[Size] [nvarchar] (64) COLLATE Cyrillic_General_CI_AS NULL,
[Color] [nvarchar] (64) COLLATE Cyrillic_General_CI_AS NULL,
[Dimensions_Length] [decimal] (18, 2) NULL,
[Dimensions_Height] [decimal] (18, 2) NULL,
[Dimensions_Width] [decimal] (18, 2) NULL,
[Dimensions_Girth] [decimal] (18, 2) NULL,
[Weight_Pounds] [int] NULL,
[Weight_Ounces] [decimal] (18, 2) NULL,
[Price] [decimal] (18, 2) NOT NULL,
[Package_Id] [int] NULL,
[Order_Id] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Items] ADD CONSTRAINT [PK_dbo.Items] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Order_Id] ON [dbo].[Items] ([Order_Id]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Package_Id] ON [dbo].[Items] ([Package_Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Items] ADD CONSTRAINT [FK_dbo.Items_dbo.Orders_Order_Id] FOREIGN KEY ([Order_Id]) REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[Items] ADD CONSTRAINT [FK_dbo.Items_dbo.Packages_Package_Id] FOREIGN KEY ([Package_Id]) REFERENCES [dbo].[Packages] ([Id])
GO
