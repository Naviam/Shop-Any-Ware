CREATE TABLE [dbo].[Retailers] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (256)  NULL,
    [Category]    NVARCHAR (256)  NULL,
    [Url]         NVARCHAR (256)  NOT NULL,
    [Description] NVARCHAR (1000) NULL,
    CONSTRAINT [PK_dbo.Retailers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [rc_Url] UNIQUE NONCLUSTERED ([Url] ASC)
);

