
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/03/2021 11:39:10
-- Generated from EDMX file: D:\DEMOEKZ\Entity\labaEntity\User.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [C:\USERS\RUSLAN\DOCUMENTS\CUMSERVER.MDF];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_productProvider]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[productSet] DROP CONSTRAINT [FK_productProvider];
GO
IF OBJECT_ID(N'[dbo].[FK_Userproduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[productSet] DROP CONSTRAINT [FK_Userproduct];
GO
IF OBJECT_ID(N'[dbo].[FK_BonusUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BonusSet] DROP CONSTRAINT [FK_BonusUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[productSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[productSet];
GO
IF OBJECT_ID(N'[dbo].[ProviderSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProviderSet];
GO
IF OBJECT_ID(N'[dbo].[BonusSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BonusSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Role] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Balance] int  NULL
);
GO

-- Creating table 'productSet'
CREATE TABLE [dbo].[productSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Price] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [PhotoPath] varbinary(max)  NOT NULL,
    [ProviderId] int  NOT NULL
);
GO

-- Creating table 'ProviderSet'
CREATE TABLE [dbo].[ProviderSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NameProvider] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BonusSet'
CREATE TABLE [dbo].[BonusSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AmountBonus] nvarchar(max)  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'BasketItemSet'
CREATE TABLE [dbo].[BasketItemSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Price] int  NOT NULL,
    [Count] smallint  NOT NULL DEFAULT 0,
    [UserId] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'productSet'
ALTER TABLE [dbo].[productSet]
ADD CONSTRAINT [PK_productSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProviderSet'
ALTER TABLE [dbo].[ProviderSet]
ADD CONSTRAINT [PK_ProviderSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BonusSet'
ALTER TABLE [dbo].[BonusSet]
ADD CONSTRAINT [PK_BonusSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BasketItemSet'
ALTER TABLE [dbo].[BasketItemSet]
ADD CONSTRAINT [PK_BasketItemSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProviderId] in table 'productSet'
ALTER TABLE [dbo].[productSet]
ADD CONSTRAINT [FK_productProvider]
    FOREIGN KEY ([ProviderId])
    REFERENCES [dbo].[ProviderSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_productProvider'
CREATE INDEX [IX_FK_productProvider]
ON [dbo].[productSet]
    ([ProviderId]);
GO

-- Creating foreign key on [User_Id] in table 'BonusSet'
ALTER TABLE [dbo].[BonusSet]
ADD CONSTRAINT [FK_BonusUser]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BonusUser'
CREATE INDEX [IX_FK_BonusUser]
ON [dbo].[BonusSet]
    ([User_Id]);
GO

-- Creating foreign key on [UserId] in table 'BasketItemSet'
ALTER TABLE [dbo].[BasketItemSet]
ADD CONSTRAINT [FK_UserBasketItem]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserBasketItem'
CREATE INDEX [IX_FK_UserBasketItem]
ON [dbo].[BasketItemSet]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------