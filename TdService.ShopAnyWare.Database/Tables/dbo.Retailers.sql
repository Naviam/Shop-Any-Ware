CREATE TABLE [dbo].[Retailers]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (256) COLLATE Cyrillic_General_CI_AS NULL,
[Category] [nvarchar] (256) COLLATE Cyrillic_General_CI_AS NULL,
[Url] [nvarchar] (256) COLLATE Cyrillic_General_CI_AS NOT NULL,
[Description] [nvarchar] (1000) COLLATE Cyrillic_General_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Retailers] ADD CONSTRAINT [PK_dbo.Retailers] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Retailers] ADD CONSTRAINT [rc_Url] UNIQUE NONCLUSTERED  ([Url]) ON [PRIMARY]
GO
