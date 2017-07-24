
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/16/2017 13:08:47
-- Generated from EDMX file: E:\Github\McTestingApp\McTestingApp\McTestingApp.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [mctestingapp];
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

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Username] nvarchar(max)  NULL,
    [Password] nvarchar(max)  NULL,
    [Role] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NULL,
    [Designation] nvarchar(max)  NULL
);
GO

-- Creating table 'Tests1'
CREATE TABLE [dbo].[Tests1] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Designation] nvarchar(max)  NULL
);
GO

-- Creating table 'Results'
CREATE TABLE [dbo].[Results] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [MarksObtain] nvarchar(max)  NULL,
    [TestId] bigint  NOT NULL,
    [User_Id] bigint  NOT NULL
);
GO

-- Creating table 'Questions'
CREATE TABLE [dbo].[Questions] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [QuestionNo] nvarchar(max)  NULL,
    [Description] nvarchar(max)  NULL,
    [TestId] bigint  NOT NULL
);
GO

-- Creating table 'Choices'
CREATE TABLE [dbo].[Choices] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [ChoiceNumber] nvarchar(max)  NULL,
    [Question_Id] bigint  NOT NULL,
    [RightChoiceQuestion_Id] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tests1'
ALTER TABLE [dbo].[Tests1]
ADD CONSTRAINT [PK_Tests1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Results'
ALTER TABLE [dbo].[Results]
ADD CONSTRAINT [PK_Results]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Questions'
ALTER TABLE [dbo].[Questions]
ADD CONSTRAINT [PK_Questions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Choices'
ALTER TABLE [dbo].[Choices]
ADD CONSTRAINT [PK_Choices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_Id] in table 'Results'
ALTER TABLE [dbo].[Results]
ADD CONSTRAINT [FK_ResultUser]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ResultUser'
CREATE INDEX [IX_FK_ResultUser]
ON [dbo].[Results]
    ([User_Id]);
GO

-- Creating foreign key on [TestId] in table 'Results'
ALTER TABLE [dbo].[Results]
ADD CONSTRAINT [FK_TestResult]
    FOREIGN KEY ([TestId])
    REFERENCES [dbo].[Tests1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestResult'
CREATE INDEX [IX_FK_TestResult]
ON [dbo].[Results]
    ([TestId]);
GO

-- Creating foreign key on [Question_Id] in table 'Choices'
ALTER TABLE [dbo].[Choices]
ADD CONSTRAINT [FK_ChoiceQuestion]
    FOREIGN KEY ([Question_Id])
    REFERENCES [dbo].[Questions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChoiceQuestion'
CREATE INDEX [IX_FK_ChoiceQuestion]
ON [dbo].[Choices]
    ([Question_Id]);
GO

-- Creating foreign key on [RightChoiceQuestion_Id] in table 'Choices'
ALTER TABLE [dbo].[Choices]
ADD CONSTRAINT [FK_RightChoice]
    FOREIGN KEY ([RightChoiceQuestion_Id])
    REFERENCES [dbo].[Questions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RightChoice'
CREATE INDEX [IX_FK_RightChoice]
ON [dbo].[Choices]
    ([RightChoiceQuestion_Id]);
GO

-- Creating foreign key on [TestId] in table 'Questions'
ALTER TABLE [dbo].[Questions]
ADD CONSTRAINT [FK_TestQuestion]
    FOREIGN KEY ([TestId])
    REFERENCES [dbo].[Tests1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestQuestion'
CREATE INDEX [IX_FK_TestQuestion]
ON [dbo].[Questions]
    ([TestId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------