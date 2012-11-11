CREATE TABLE [dbo].[Transactions] (
    [Id]                   INT             IDENTITY (1, 1) NOT NULL,
    [OperationAmount]      DECIMAL (18, 2) NOT NULL,
    [OperationDescription] NVARCHAR (MAX)  NULL,
    [Commission]           DECIMAL (18, 2) NOT NULL,
    [Date]                 DATETIME        NOT NULL,
    [TransactionAmount]    DECIMAL (18, 2) NOT NULL,
    [TransactionStatus]    INT             NOT NULL,
    [Currency_Id]          INT             NULL,
    [Wallet_Id]            INT             NULL,
    CONSTRAINT [PK_dbo.Transactions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Transactions_dbo.Currencies_Currency_Id] FOREIGN KEY ([Currency_Id]) REFERENCES [dbo].[Currencies] ([Id]),
    CONSTRAINT [FK_dbo.Transactions_dbo.Wallets_Wallet_Id] FOREIGN KEY ([Wallet_Id]) REFERENCES [dbo].[Wallets] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Currency_Id]
    ON [dbo].[Transactions]([Currency_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Wallet_Id]
    ON [dbo].[Transactions]([Wallet_Id] ASC);

