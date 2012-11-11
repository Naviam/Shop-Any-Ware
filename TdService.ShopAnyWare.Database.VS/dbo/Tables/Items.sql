CREATE TABLE [dbo].[Items] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (64)   NOT NULL,
    [Quantity]          INT             NOT NULL,
    [Size]              NVARCHAR (64)   NULL,
    [Color]             NVARCHAR (64)   NULL,
    [Dimensions_Length] DECIMAL (18, 2) NULL,
    [Dimensions_Height] DECIMAL (18, 2) NULL,
    [Dimensions_Width]  DECIMAL (18, 2) NULL,
    [Dimensions_Girth]  DECIMAL (18, 2) NULL,
    [Weight_Pounds]     INT             NULL,
    [Weight_Ounces]     DECIMAL (18, 2) NULL,
    [Price]             DECIMAL (18, 2) NOT NULL,
    [Package_Id]        INT             NULL,
    [Order_Id]          INT             NULL,
    CONSTRAINT [PK_dbo.Items] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Items_dbo.Orders_Order_Id] FOREIGN KEY ([Order_Id]) REFERENCES [dbo].[Orders] ([Id]),
    CONSTRAINT [FK_dbo.Items_dbo.Packages_Package_Id] FOREIGN KEY ([Package_Id]) REFERENCES [dbo].[Packages] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Package_Id]
    ON [dbo].[Items]([Package_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Order_Id]
    ON [dbo].[Items]([Order_Id] ASC);

