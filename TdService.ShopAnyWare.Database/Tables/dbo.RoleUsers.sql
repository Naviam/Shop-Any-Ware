CREATE TABLE [dbo].[RoleUsers]
(
[Role_Id] [int] NOT NULL,
[User_Id] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[RoleUsers] ADD CONSTRAINT [PK_dbo.RoleUsers] PRIMARY KEY CLUSTERED  ([Role_Id], [User_Id]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Role_Id] ON [dbo].[RoleUsers] ([Role_Id]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_User_Id] ON [dbo].[RoleUsers] ([User_Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[RoleUsers] ADD CONSTRAINT [FK_dbo.RoleUsers_dbo.Roles_Role_Id] FOREIGN KEY ([Role_Id]) REFERENCES [dbo].[Roles] ([Id]) ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleUsers] ADD CONSTRAINT [FK_dbo.RoleUsers_dbo.Users_User_Id] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
GO
