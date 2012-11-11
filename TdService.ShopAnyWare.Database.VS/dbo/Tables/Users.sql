CREATE TABLE [dbo].[Users] (
    [Id]             INT              IDENTITY (1, 1) NOT NULL,
    [Email]          NVARCHAR (256)   NOT NULL,
    [Password]       NVARCHAR (64)    NOT NULL,
    [ActivationCode] UNIQUEIDENTIFIER NOT NULL,
    [Activated]      BIT              NOT NULL,
    [RowVersion]     ROWVERSION       NOT NULL,
    [Profile_Id]     INT              NULL,
    [Wallet_Id]      INT              NULL,
    CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Users_dbo.Profiles_Profile_Id] FOREIGN KEY ([Profile_Id]) REFERENCES [dbo].[Profiles] ([Id]),
    CONSTRAINT [FK_dbo.Users_dbo.Wallets_Wallet_Id] FOREIGN KEY ([Wallet_Id]) REFERENCES [dbo].[Wallets] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Profile_Id]
    ON [dbo].[Users]([Profile_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Wallet_Id]
    ON [dbo].[Users]([Wallet_Id] ASC);

