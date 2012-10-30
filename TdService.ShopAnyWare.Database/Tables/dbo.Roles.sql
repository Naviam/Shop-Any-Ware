CREATE TABLE [dbo].[Roles]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (64) COLLATE Cyrillic_General_CI_AS NOT NULL,
[Description] [nvarchar] (256) COLLATE Cyrillic_General_CI_AS NULL,
[RowVersion] [timestamp] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Roles] ADD CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
