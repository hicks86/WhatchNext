
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/04/2016 18:35:35
-- Generated from EDMX file: C:\Users\rhys\Documents\Visual Studio 2015\Projects\WhatchNext\WhatchNext.DataAccess\WhatchNext.DataAccess.Ef\CoreModel\WhatchNextModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [WhatchNextDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ShowsMostPopularShows]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MostPopularShows] DROP CONSTRAINT [FK_ShowsMostPopularShows];
GO
IF OBJECT_ID(N'[dbo].[FK_ShowsShowImages]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShowImages] DROP CONSTRAINT [FK_ShowsShowImages];
GO
IF OBJECT_ID(N'[dbo].[FK_ShowsShowVideos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShowVideos] DROP CONSTRAINT [FK_ShowsShowVideos];
GO
IF OBJECT_ID(N'[dbo].[FK_RankingPopularShowsPopularShowsData]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RankingPopularShows] DROP CONSTRAINT [FK_RankingPopularShowsPopularShowsData];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Shows]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Shows];
GO
IF OBJECT_ID(N'[dbo].[ShowImages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShowImages];
GO
IF OBJECT_ID(N'[dbo].[ShowVideos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShowVideos];
GO
IF OBJECT_ID(N'[dbo].[MostPopularShows]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MostPopularShows];
GO
IF OBJECT_ID(N'[dbo].[ShowsDatas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShowsDatas];
GO
IF OBJECT_ID(N'[dbo].[RankingPopularShows]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RankingPopularShows];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Shows'
CREATE TABLE [dbo].[Shows] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Overview] nvarchar(max)  NOT NULL,
    [Rating] float  NOT NULL,
    [Slug] nvarchar(max)  NOT NULL,
    [TraktApiId] int  NOT NULL,
    [TvdbApiId] int  NOT NULL,
    [ImdbApiId] nvarchar(max)  NOT NULL,
    [TmdbApiId] int  NULL,
    [TvRageApiId] int  NULL
);
GO

-- Creating table 'ShowImages'
CREATE TABLE [dbo].[ShowImages] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ImageType] nvarchar(max)  NOT NULL,
    [AspectRatio] float  NOT NULL,
    [FilePath] nvarchar(max)  NOT NULL,
    [Height] int  NOT NULL,
    [Width] int  NOT NULL,
    [Iso6391] nvarchar(max)  NULL,
    [VoteAverage] float  NOT NULL,
    [ShowsId] int  NOT NULL
);
GO

-- Creating table 'ShowVideos'
CREATE TABLE [dbo].[ShowVideos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Key] nvarchar(max)  NOT NULL,
    [Site] nvarchar(max)  NOT NULL,
    [Size] int  NOT NULL,
    [ShowsId] int  NOT NULL
);
GO

-- Creating table 'MostPopularShows'
CREATE TABLE [dbo].[MostPopularShows] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ShowsId] int  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [Rating] float  NOT NULL,
    [Ranking] int  NOT NULL,
    [EndDate] datetime  NOT NULL
);
GO

-- Creating table 'ShowDatas'
CREATE TABLE [dbo].[ShowDatas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ShowId] int  NOT NULL,
    [JsonConfiguration] nvarchar(max)  NOT NULL,
    [Version] int  NOT NULL
);
GO

-- Creating table 'RankingPopularShows'
CREATE TABLE [dbo].[RankingPopularShows] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PopularShowsDataId] int  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [Rating] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Shows'
ALTER TABLE [dbo].[Shows]
ADD CONSTRAINT [PK_Shows]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ShowImages'
ALTER TABLE [dbo].[ShowImages]
ADD CONSTRAINT [PK_ShowImages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ShowVideos'
ALTER TABLE [dbo].[ShowVideos]
ADD CONSTRAINT [PK_ShowVideos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MostPopularShows'
ALTER TABLE [dbo].[MostPopularShows]
ADD CONSTRAINT [PK_MostPopularShows]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ShowDatas'
ALTER TABLE [dbo].[ShowDatas]
ADD CONSTRAINT [PK_ShowDatas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RankingPopularShows'
ALTER TABLE [dbo].[RankingPopularShows]
ADD CONSTRAINT [PK_RankingPopularShows]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ShowsId] in table 'MostPopularShows'
ALTER TABLE [dbo].[MostPopularShows]
ADD CONSTRAINT [FK_ShowsMostPopularShows]
    FOREIGN KEY ([ShowsId])
    REFERENCES [dbo].[Shows]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ShowsMostPopularShows'
CREATE INDEX [IX_FK_ShowsMostPopularShows]
ON [dbo].[MostPopularShows]
    ([ShowsId]);
GO

-- Creating foreign key on [ShowsId] in table 'ShowImages'
ALTER TABLE [dbo].[ShowImages]
ADD CONSTRAINT [FK_ShowsShowImages]
    FOREIGN KEY ([ShowsId])
    REFERENCES [dbo].[Shows]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ShowsShowImages'
CREATE INDEX [IX_FK_ShowsShowImages]
ON [dbo].[ShowImages]
    ([ShowsId]);
GO

-- Creating foreign key on [ShowsId] in table 'ShowVideos'
ALTER TABLE [dbo].[ShowVideos]
ADD CONSTRAINT [FK_ShowsShowVideos]
    FOREIGN KEY ([ShowsId])
    REFERENCES [dbo].[Shows]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ShowsShowVideos'
CREATE INDEX [IX_FK_ShowsShowVideos]
ON [dbo].[ShowVideos]
    ([ShowsId]);
GO

-- Creating foreign key on [PopularShowsDataId] in table 'RankingPopularShows'
ALTER TABLE [dbo].[RankingPopularShows]
ADD CONSTRAINT [FK_RankingPopularShowsPopularShowsData]
    FOREIGN KEY ([PopularShowsDataId])
    REFERENCES [dbo].[ShowDatas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RankingPopularShowsPopularShowsData'
CREATE INDEX [IX_FK_RankingPopularShowsPopularShowsData]
ON [dbo].[RankingPopularShows]
    ([PopularShowsDataId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------