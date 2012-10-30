CREATE TABLE [dbo].[Currencies]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Entity] [nvarchar] (64) COLLATE Cyrillic_General_CI_AS NULL,
[Name] [nvarchar] (64) COLLATE Cyrillic_General_CI_AS NULL,
[AlphabeticCode] [nchar] (3) COLLATE Cyrillic_General_CI_AS NOT NULL,
[NumericCode] [nchar] (3) COLLATE Cyrillic_General_CI_AS NOT NULL,
[MinorUnit] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Currencies] ADD CONSTRAINT [PK_dbo.Currencies] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
