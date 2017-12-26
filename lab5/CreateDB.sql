-- Create Database and Tables:

USE [master]
CREATE DATABASE [CSharpDB]
GO

USE [CSharpDB]
GO

CREATE TABLE [Clients] (
	[ClientID] INT IDENTITY(1,1) NOT NULL,
    [FirstName] NVARCHAR(255) NOT NULL,
    [LastName] NVARCHAR(255) NOT NULL,
    CONSTRAINT PK_ClientID PRIMARY KEY CLUSTERED ([ClientID]))
GO

CREATE TABLE [Joys] (
	[JoyID] INT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(255) NOT NULL,
	[Price] INT NOT NULL,
    CONSTRAINT PK_FoodTypeID PRIMARY KEY CLUSTERED ([JoyID]))
GO

CREATE TABLE [OrderTypes] (
	[OrderTypeID] INT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(255) NOT NULL,
	[Ñoefficient] FLOAT NOT NULL,
    CONSTRAINT PK_OrderTypeID PRIMARY KEY CLUSTERED ([OrderTypeID]))
GO

CREATE TABLE [Orders] (
	[OrderID] INT IDENTITY(1,1) NOT NULL,
    [ClientID] INT NOT NULL,
	[JoyID] INT NOT NULL,
	[OrderTypeID] INT NOT NULL,
	[Date] DATE NOT NULL,
    CONSTRAINT PK_OrderID PRIMARY KEY CLUSTERED ([OrderID]),
	CONSTRAINT FK_OrderClientID FOREIGN KEY([ClientID]) REFERENCES[Clients]([ClientID]),
	CONSTRAINT FK_OrderJoyID FOREIGN KEY([JoyID]) REFERENCES[Joys]([JoyID]),
	CONSTRAINT FK_OrderTypeID FOREIGN KEY([OrderTypeID]) REFERENCES[OrderTypes]([OrderTypeID]))
GO

CREATE TABLE [Discounts] (
	[DiscountID] INT IDENTITY(1,1) NOT NULL,
	[ClientID] INT NOT NULL,
	[Discount] FLOAT NOT NULL,
    CONSTRAINT PK_DiscountID PRIMARY KEY CLUSTERED ([DiscountID]),
	CONSTRAINT FK_DiscountID FOREIGN KEY([ClientID]) REFERENCES[Clients]([ClientID]))
GO

INSERT INTO [Clients] ([FirstName], [LastName])
VALUES ('Valentine', 'Gladyshko'),
       ('Svetlana', 'Reutskaya'),
       ('Anna', 'Khuda')
GO

INSERT INTO [Joys] ([Name], [Price])
VALUES ('Train', 1499),
	   ('Car', 499),
	   ('Teddy bear', 299),
	   ('Unicorn', 329),
	   ('Robot', 1999),
	   ('Barby', 899)
GO

INSERT INTO [OrderTypes] ([Name], [Ñoefficient])
VALUES ('Sale', 1.0),
	   ('Repair', 0.4),
	   ('Master class', 2.0)
GO

INSERT INTO [Orders] ([Date], [ClientID], [JoyID], [OrderTypeID])
VALUES ('2017-09-23', 3, 1, 1),
       ('2016-12-12', 1, 6, 2),
	   ('2016-11-12', 1, 4, 3),
       ('2014-08-09', 3, 4, 1),
       ('2017-04-30', 2, 3, 1),
       ('2016-02-01', 3, 2, 1),
       ('2011-05-05', 3, 2, 2),
       ('2014-03-08', 2, 4, 1),
       ('2016-04-11', 3, 5, 2)
GO

INSERT INTO [Discounts] ([ClientID], [Discount])
VALUES (1, 0.8),
	   (2, 1.0),
	   (3, 1.1)
GO
