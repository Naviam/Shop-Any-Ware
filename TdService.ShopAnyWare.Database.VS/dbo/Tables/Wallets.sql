CREATE TABLE [dbo].[Wallets] (
    [Id]     INT             IDENTITY (1, 1) NOT NULL,
    [Amount] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_dbo.Wallets] PRIMARY KEY CLUSTERED ([Id] ASC)
);

