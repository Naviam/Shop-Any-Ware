CREATE TABLE [dbo].[Wallets]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Amount] [decimal] (18, 2) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Wallets] ADD CONSTRAINT [PK_dbo.Wallets] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
