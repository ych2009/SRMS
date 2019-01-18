
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/17/2019 11:56:20
-- Generated from EDMX file: C:\Users\Administrator\source\repos\SRMS\SRMS\Models\SRMSModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SRMS1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_lineinfoSetdeviceinfoSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[deviceinfoSet] DROP CONSTRAINT [FK_lineinfoSetdeviceinfoSet];
GO
IF OBJECT_ID(N'[dbo].[FK_lineinfoSetmanipulatorinfoSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[manipulatorinfoSet] DROP CONSTRAINT [FK_lineinfoSetmanipulatorinfoSet];
GO
IF OBJECT_ID(N'[dbo].[FK_lineinfoSetlineworkinfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[lineworkinfoSet] DROP CONSTRAINT [FK_lineinfoSetlineworkinfo];
GO
IF OBJECT_ID(N'[dbo].[FK_lineworkinfoworkdetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[workdetailSet] DROP CONSTRAINT [FK_lineworkinfoworkdetail];
GO
IF OBJECT_ID(N'[dbo].[FK_deviceinfoSetdeviceworkinginfoSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[deviceworkinginfoSet] DROP CONSTRAINT [FK_deviceinfoSetdeviceworkinginfoSet];
GO
IF OBJECT_ID(N'[dbo].[FK_lineworkinfoproductinfoSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[lineworkinfoSet] DROP CONSTRAINT [FK_lineworkinfoproductinfoSet];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[deviceinfoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[deviceinfoSet];
GO
IF OBJECT_ID(N'[dbo].[deviceworkinginfoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[deviceworkinginfoSet];
GO
IF OBJECT_ID(N'[dbo].[lineinfoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[lineinfoSet];
GO
IF OBJECT_ID(N'[dbo].[manipulatorinfoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[manipulatorinfoSet];
GO
IF OBJECT_ID(N'[dbo].[productinfoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[productinfoSet];
GO
IF OBJECT_ID(N'[dbo].[lineworkinfoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[lineworkinfoSet];
GO
IF OBJECT_ID(N'[dbo].[workdetailSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[workdetailSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'deviceinfoSet'
CREATE TABLE [dbo].[deviceinfoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [code] nvarchar(max)  NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [productor] nvarchar(max)  NOT NULL,
    [devicetype] nvarchar(max)  NOT NULL,
    [totallifetime] int  NOT NULL,
    [usedlifetime] int  NOT NULL,
    [buildtime] datetime  NOT NULL,
    [lineinfoSetId] int  NOT NULL
);
GO

-- Creating table 'deviceworkinginfoSet'
CREATE TABLE [dbo].[deviceworkinginfoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [runningstatus] bit  NOT NULL,
    [mainspeed] int  NOT NULL,
    [errorcount] int  NOT NULL,
    [totalcount] int  NOT NULL,
    [buildtime] datetime  NOT NULL,
    [isruning] bit  NOT NULL,
    [isfinished] bit  NOT NULL,
    [iswarning] bit  NOT NULL,
    [deviceinfoSet_Id] int  NOT NULL
);
GO

-- Creating table 'lineinfoSet'
CREATE TABLE [dbo].[lineinfoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [code] nvarchar(max)  NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [buildtime] datetime  NOT NULL
);
GO

-- Creating table 'manipulatorinfoSet'
CREATE TABLE [dbo].[manipulatorinfoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [code] nvarchar(max)  NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [status] bit  NOT NULL,
    [x] int  NOT NULL,
    [y] int  NOT NULL,
    [speed] int  NOT NULL,
    [catchnum] int  NOT NULL,
    [buildtime] datetime  NOT NULL,
    [lineinfoSetId] int  NOT NULL
);
GO

-- Creating table 'productinfoSet'
CREATE TABLE [dbo].[productinfoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [code] nvarchar(max)  NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [infos] nvarchar(max)  NOT NULL,
    [buildtime] datetime  NOT NULL
);
GO

-- Creating table 'lineworkinfoSet'
CREATE TABLE [dbo].[lineworkinfoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [code] nvarchar(max)  NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [sampletime] nvarchar(max)  NOT NULL,
    [totalnum] int  NOT NULL,
    [finishnum] int  NOT NULL,
    [errornum] int  NOT NULL,
    [bulidtime] datetime  NOT NULL,
    [lineinfoSetId] int  NOT NULL,
    [productinfoSetId] int  NOT NULL
);
GO

-- Creating table 'workdetailSet'
CREATE TABLE [dbo].[workdetailSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [finishnum] int  NOT NULL,
    [lineworkinfoId] int  NOT NULL,
    [buildtime] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'deviceinfoSet'
ALTER TABLE [dbo].[deviceinfoSet]
ADD CONSTRAINT [PK_deviceinfoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'deviceworkinginfoSet'
ALTER TABLE [dbo].[deviceworkinginfoSet]
ADD CONSTRAINT [PK_deviceworkinginfoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'lineinfoSet'
ALTER TABLE [dbo].[lineinfoSet]
ADD CONSTRAINT [PK_lineinfoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'manipulatorinfoSet'
ALTER TABLE [dbo].[manipulatorinfoSet]
ADD CONSTRAINT [PK_manipulatorinfoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'productinfoSet'
ALTER TABLE [dbo].[productinfoSet]
ADD CONSTRAINT [PK_productinfoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'lineworkinfoSet'
ALTER TABLE [dbo].[lineworkinfoSet]
ADD CONSTRAINT [PK_lineworkinfoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'workdetailSet'
ALTER TABLE [dbo].[workdetailSet]
ADD CONSTRAINT [PK_workdetailSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [lineinfoSetId] in table 'deviceinfoSet'
ALTER TABLE [dbo].[deviceinfoSet]
ADD CONSTRAINT [FK_lineinfoSetdeviceinfoSet]
    FOREIGN KEY ([lineinfoSetId])
    REFERENCES [dbo].[lineinfoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_lineinfoSetdeviceinfoSet'
CREATE INDEX [IX_FK_lineinfoSetdeviceinfoSet]
ON [dbo].[deviceinfoSet]
    ([lineinfoSetId]);
GO

-- Creating foreign key on [lineinfoSetId] in table 'manipulatorinfoSet'
ALTER TABLE [dbo].[manipulatorinfoSet]
ADD CONSTRAINT [FK_lineinfoSetmanipulatorinfoSet]
    FOREIGN KEY ([lineinfoSetId])
    REFERENCES [dbo].[lineinfoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_lineinfoSetmanipulatorinfoSet'
CREATE INDEX [IX_FK_lineinfoSetmanipulatorinfoSet]
ON [dbo].[manipulatorinfoSet]
    ([lineinfoSetId]);
GO

-- Creating foreign key on [lineinfoSetId] in table 'lineworkinfoSet'
ALTER TABLE [dbo].[lineworkinfoSet]
ADD CONSTRAINT [FK_lineinfoSetlineworkinfo]
    FOREIGN KEY ([lineinfoSetId])
    REFERENCES [dbo].[lineinfoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_lineinfoSetlineworkinfo'
CREATE INDEX [IX_FK_lineinfoSetlineworkinfo]
ON [dbo].[lineworkinfoSet]
    ([lineinfoSetId]);
GO

-- Creating foreign key on [lineworkinfoId] in table 'workdetailSet'
ALTER TABLE [dbo].[workdetailSet]
ADD CONSTRAINT [FK_lineworkinfoworkdetail]
    FOREIGN KEY ([lineworkinfoId])
    REFERENCES [dbo].[lineworkinfoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_lineworkinfoworkdetail'
CREATE INDEX [IX_FK_lineworkinfoworkdetail]
ON [dbo].[workdetailSet]
    ([lineworkinfoId]);
GO

-- Creating foreign key on [deviceinfoSet_Id] in table 'deviceworkinginfoSet'
ALTER TABLE [dbo].[deviceworkinginfoSet]
ADD CONSTRAINT [FK_deviceinfoSetdeviceworkinginfoSet]
    FOREIGN KEY ([deviceinfoSet_Id])
    REFERENCES [dbo].[deviceinfoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_deviceinfoSetdeviceworkinginfoSet'
CREATE INDEX [IX_FK_deviceinfoSetdeviceworkinginfoSet]
ON [dbo].[deviceworkinginfoSet]
    ([deviceinfoSet_Id]);
GO

-- Creating foreign key on [productinfoSetId] in table 'lineworkinfoSet'
ALTER TABLE [dbo].[lineworkinfoSet]
ADD CONSTRAINT [FK_lineworkinfoproductinfoSet]
    FOREIGN KEY ([productinfoSetId])
    REFERENCES [dbo].[productinfoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_lineworkinfoproductinfoSet'
CREATE INDEX [IX_FK_lineworkinfoproductinfoSet]
ON [dbo].[lineworkinfoSet]
    ([productinfoSetId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------