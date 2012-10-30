CREATE TABLE [dbo].[Transactions]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[OperationAmount] [decimal] (18, 2) NOT NULL,
[OperationDescription] [nvarchar] (max) COLLATE Cyrillic_General_CI_AS NULL,
[Commission] [decimal] (18, 2) NOT NULL,
[Date] [datetime] NOT NULL,
[TransactionAmount] [decimal] (18, 2) NOT NULL,
[TransactionStatus] [int] NOT NULL,
[Currency_Id] [int] NULL,
[Wallet_Id] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Transactions] ADD CONSTRAINT [PK_dbo.Transactions] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Currency_Id] ON [dbo].[Transactions] ([Currency_Id]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Wallet_Id] ON [dbo].[Transactions] ([Wallet_Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Transactions] ADD CONSTRAINT [FK_dbo.Transactions_dbo.Currencies_Currency_Id] FOREIGN KEY ([Currency_Id]) REFERENCES [dbo].[Currencies] ([Id])
GO
ALTER TABLE [dbo].[Transactions] ADD CONSTRAINT [FK_dbo.Transactions_dbo.Wallets_Wallet_Id] FOREIGN KEY ([Wallet_Id]) REFERENCES [dbo].[Wallets] ([Id])
GO
