CREATE TABLE [dbo].[DeliveryAddresses]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[AddressName] [nvarchar] (40) COLLATE Cyrillic_General_CI_AS NOT NULL,
[FirstName] [nvarchar] (21) COLLATE Cyrillic_General_CI_AS NOT NULL,
[LastName] [nvarchar] (21) COLLATE Cyrillic_General_CI_AS NOT NULL,
[ZipCode] [nvarchar] (10) COLLATE Cyrillic_General_CI_AS NOT NULL,
[Country] [nvarchar] (64) COLLATE Cyrillic_General_CI_AS NOT NULL,
[Region] [nvarchar] (64) COLLATE Cyrillic_General_CI_AS NULL,
[City] [nvarchar] (64) COLLATE Cyrillic_General_CI_AS NOT NULL,
[AddressLine1] [nvarchar] (256) COLLATE Cyrillic_General_CI_AS NOT NULL,
[AddressLine2] [nvarchar] (256) COLLATE Cyrillic_General_CI_AS NULL,
[AddressLine3] [nvarchar] (256) COLLATE Cyrillic_General_CI_AS NULL,
[Phone] [nvarchar] (21) COLLATE Cyrillic_General_CI_AS NULL,
[State] [nvarchar] (64) COLLATE Cyrillic_General_CI_AS NULL,
[RowVersion] [timestamp] NOT NULL,
[RoomNumber] [nvarchar] (max) COLLATE Cyrillic_General_CI_AS NULL,
[Discriminator] [nvarchar] (128) COLLATE Cyrillic_General_CI_AS NOT NULL,
[User_Id] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[DeliveryAddresses] ADD CONSTRAINT [PK_dbo.DeliveryAddresses] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_User_Id] ON [dbo].[DeliveryAddresses] ([User_Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DeliveryAddresses] ADD CONSTRAINT [FK_dbo.DeliveryAddresses_dbo.Users_User_Id] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[Users] ([Id])
GO
