CREATE TABLE [dbo].[Currencies] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [Entity]         NVARCHAR (64) NULL,
    [Name]           NVARCHAR (64) NULL,
    [AlphabeticCode] NCHAR (3)     NOT NULL,
    [NumericCode]    NCHAR (3)     NOT NULL,
    [MinorUnit]      INT           NOT NULL,
    CONSTRAINT [PK_dbo.Currencies] PRIMARY KEY CLUSTERED ([Id] ASC)
);

