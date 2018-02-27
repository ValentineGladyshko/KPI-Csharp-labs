
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/10/2018 21:11:43
-- Generated from EDMX file: C:\Users\Kappi\Source\Repos\KPI-Csharp-labs\test\test\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [test];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ClientsSet'
CREATE TABLE [dbo].[ClientsSet] (
    [ClientID] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(255)  NOT NULL,
    [LastName] nvarchar(255)  NOT NULL
);
GO

-- Creating table 'OrdersSet'
CREATE TABLE [dbo].[OrdersSet] (
    [OrderID] int IDENTITY(1,1) NOT NULL,
    [ClientID] int  NOT NULL,
    [ProductID] int  NOT NULL,
    [Count] int  NOT NULL,
    [Date] datetime  NOT NULL
);
GO

-- Creating table 'ProductsSet'
CREATE TABLE [dbo].[ProductsSet] (
    [ProductID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(255)  NOT NULL,
    [Price] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ClientID] in table 'ClientsSet'
ALTER TABLE [dbo].[ClientsSet]
ADD CONSTRAINT [PK_ClientsSet]
    PRIMARY KEY CLUSTERED ([ClientID] ASC);
GO

-- Creating primary key on [OrderID] in table 'OrdersSet'
ALTER TABLE [dbo].[OrdersSet]
ADD CONSTRAINT [PK_OrdersSet]
    PRIMARY KEY CLUSTERED ([OrderID] ASC);
GO

-- Creating primary key on [ProductID] in table 'ProductsSet'
ALTER TABLE [dbo].[ProductsSet]
ADD CONSTRAINT [PK_ProductsSet]
    PRIMARY KEY CLUSTERED ([ProductID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ClientID] in table 'OrdersSet'
ALTER TABLE [dbo].[OrdersSet]
ADD CONSTRAINT [FK_ClientsOrders]
    FOREIGN KEY ([ClientID])
    REFERENCES [dbo].[ClientsSet]
        ([ClientID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientsOrders'
CREATE INDEX [IX_FK_ClientsOrders]
ON [dbo].[OrdersSet]
    ([ClientID]);
GO

-- Creating foreign key on [ProductID] in table 'OrdersSet'
ALTER TABLE [dbo].[OrdersSet]
ADD CONSTRAINT [FK_ProductsOrders]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[ProductsSet]
        ([ProductID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductsOrders'
CREATE INDEX [IX_FK_ProductsOrders]
ON [dbo].[OrdersSet]
    ([ProductID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------