CREATE TABLE [dbo].[Profiles]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[FirstName] [nvarchar] (21) COLLATE Cyrillic_General_CI_AS NOT NULL,
[LastName] [nvarchar] (21) COLLATE Cyrillic_General_CI_AS NOT NULL,
[NotifyOnOrderStatusChanged] [bit] NOT NULL,
[NotifyOnPackageStatusChanged] [bit] NOT NULL,
[RowVersion] [timestamp] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Profiles] ADD CONSTRAINT [PK_dbo.Profiles] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
