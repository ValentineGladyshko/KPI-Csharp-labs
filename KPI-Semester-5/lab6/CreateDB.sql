-- Create Database and Tables:

USE [master]
CREATE DATABASE [CSharp]
GO

USE [CSharp]
GO

CREATE TABLE [Manufacturers] (
	[ManufacturerID] INT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(255) NOT NULL,
    CONSTRAINT PK_ManufacturerID PRIMARY KEY CLUSTERED ([ManufacturerID]))
GO

CREATE TABLE [Products] (
	[ProductID] INT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(255) NOT NULL,
	[Price] INT NOT NULL,
	[ManufacturerID] INT NOT NULL,
    CONSTRAINT PK_ProductID PRIMARY KEY CLUSTERED ([ProductID]),
	CONSTRAINT FK_ProductManufacturerID FOREIGN KEY([ManufacturerID]) REFERENCES[Manufacturers]([ManufacturerID]))
GO

CREATE TABLE [Stocks] (
	[StockID] INT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(255) NOT NULL,
    CONSTRAINT PK_Stock PRIMARY KEY CLUSTERED ([StockID]))
GO

CREATE TABLE [Supply] (
	[SupplyID] INT IDENTITY(1,1) NOT NULL,
	[Date] DATE NOT NULL,
	[ProductID] INT NOT NULL,
	[StockID] INT NOT NULL,
	[Count] INT NOT NULL,
    CONSTRAINT PK_SupplyID PRIMARY KEY CLUSTERED ([SupplyID]),
	CONSTRAINT FK_SupplyProductID FOREIGN KEY([ProductID]) REFERENCES[Products]([ProductID]),
	CONSTRAINT FK_SupplyStockID FOREIGN KEY([StockID]) REFERENCES[Stocks]([StockID]))
GO