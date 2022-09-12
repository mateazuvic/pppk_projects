
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/05/2022 10:08:22
-- Generated from EDMX file: C:\Users\Teodor\Desktop\ALGEBRA 5\PPPK\ApartmentsManger\ApartmentsManger\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Apartments];
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

-- Creating table 'Apartment'
CREATE TABLE [dbo].[Apartment] (
    [IDApartment] int IDENTITY(1,1) NOT NULL,
    [Address] nvarchar(50)  NOT NULL,
    [City] nvarchar(20)  NOT NULL,
    [Contact] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Rooms'
CREATE TABLE [dbo].[Rooms] (
    [IDRoom] int IDENTITY(1,1) NOT NULL,
    [Number] int  NOT NULL,
    [Capacity] int  NOT NULL,
    [ApartmentIDApartment] int  NOT NULL,
    [UploadedFileID] int  NULL
);
GO

-- Creating table 'UploadedFiles'
CREATE TABLE [dbo].[UploadedFiles] (
    [IDUploadedFile] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [ContentType] nvarchar(50)  NOT NULL,
    [Content] varbinary(max)  NOT NULL,
    [ApartmentIDApartment] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IDApartment] in table 'Apartment'
ALTER TABLE [dbo].[Apartment]
ADD CONSTRAINT [PK_Apartment]
    PRIMARY KEY CLUSTERED ([IDApartment] ASC);
GO

-- Creating primary key on [IDRoom] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [PK_Rooms]
    PRIMARY KEY CLUSTERED ([IDRoom] ASC);
GO

-- Creating primary key on [IDUploadedFile] in table 'UploadedFiles'
ALTER TABLE [dbo].[UploadedFiles]
ADD CONSTRAINT [PK_UploadedFiles]
    PRIMARY KEY CLUSTERED ([IDUploadedFile] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ApartmentIDApartment] in table 'UploadedFiles'
ALTER TABLE [dbo].[UploadedFiles]
ADD CONSTRAINT [FK_ApartmentUploadedFile]
    FOREIGN KEY ([ApartmentIDApartment])
    REFERENCES [dbo].[Apartment]
        ([IDApartment])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ApartmentUploadedFile'
CREATE INDEX [IX_FK_ApartmentUploadedFile]
ON [dbo].[UploadedFiles]
    ([ApartmentIDApartment]);
GO

-- Creating foreign key on [ApartmentIDApartment] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [FK_ApartmentRoom]
    FOREIGN KEY ([ApartmentIDApartment])
    REFERENCES [dbo].[Apartment]
        ([IDApartment])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ApartmentRoom'
CREATE INDEX [IX_FK_ApartmentRoom]
ON [dbo].[Rooms]
    ([ApartmentIDApartment]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------