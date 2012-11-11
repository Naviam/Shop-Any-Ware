CREATE TABLE [dbo].[Roles] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (64)  NOT NULL,
    [Description] NVARCHAR (256) NULL,
    [RowVersion]  ROWVERSION     NOT NULL,
    CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED ([Id] ASC)
);

