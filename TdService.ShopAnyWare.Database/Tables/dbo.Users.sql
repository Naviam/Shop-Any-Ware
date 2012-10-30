CREATE TABLE [dbo].[Users]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Email] [nvarchar] (256) COLLATE Cyrillic_General_CI_AS NOT NULL,
[Password] [nvarchar] (64) COLLATE Cyrillic_General_CI_AS NOT NULL,
[ActivationCode] [uniqueidentifier] NOT NULL,
[Activated] [bit] NOT NULL,
[RowVersion] [timestamp] NOT NULL,
[Profile_Id] [int] NULL,
[Wallet_Id] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users] ADD CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Profile_Id] ON [dbo].[Users] ([Profile_Id]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Wallet_Id] ON [dbo].[Users] ([Wallet_Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users] ADD CONSTRAINT [FK_dbo.Users_dbo.Profiles_Profile_Id] FOREIGN KEY ([Profile_Id]) REFERENCES [dbo].[Profiles] ([Id])
GO
ALTER TABLE [dbo].[Users] ADD CONSTRAINT [FK_dbo.Users_dbo.Wallets_Wallet_Id] FOREIGN KEY ([Wallet_Id]) REFERENCES [dbo].[Wallets] ([Id])
GO
