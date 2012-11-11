CREATE TABLE [dbo].[Profiles] (
    [Id]                           INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]                    NVARCHAR (21) NOT NULL,
    [LastName]                     NVARCHAR (21) NOT NULL,
    [NotifyOnOrderStatusChanged]   BIT           NOT NULL,
    [NotifyOnPackageStatusChanged] BIT           NOT NULL,
    [RowVersion]                   ROWVERSION    NOT NULL,
    CONSTRAINT [PK_dbo.Profiles] PRIMARY KEY CLUSTERED ([Id] ASC)
);

