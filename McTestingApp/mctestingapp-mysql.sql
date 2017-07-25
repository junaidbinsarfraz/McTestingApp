
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/16/2017 13:08:47
-- Generated from EDMX file: E:\Github\McTestingApp\McTestingApp\McTestingApp.edmx
-- --------------------------------------------------

USE mctestingapp;

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
CREATE TABLE Users (
    Id bigint auto_increment primary key NOT NULL,
    Name varchar(500)  NULL,
    Username varchar(500)  NULL,
    Password varchar(500)  NULL,
    Role varchar(500)  NULL,
    Email varchar(500)  NULL,
    Designation varchar(500)  NULL
);

-- Creating table 'Tests1'
CREATE TABLE Tests1 (
    Id bigint auto_increment primary key NOT NULL,
    Name varchar(500)  NULL,
    Designation varchar(500)  NULL,
    Published bit(1) default false
);

-- Creating table 'Results'
CREATE TABLE Results (
    Id bigint auto_increment primary key NOT NULL,
    MarksObtain varchar(500)  NULL,
    Taken bit(1) default false,
    TestId bigint  NOT NULL,
    User_Id bigint  NOT NULL
);

-- Creating table 'Questions'
CREATE TABLE Questions (
    Id bigint auto_increment primary key NOT NULL,
    QuestionNo varchar(500)  NULL,
    Description varchar(500)  NULL,
    TestId bigint  NOT NULL
);

-- Creating table 'Choices'
CREATE TABLE Choices (
    Id bigint auto_increment primary key NOT NULL,
    ChoiceNumber varchar(500)  NULL,
    Question_Id bigint  NOT NULL,
    RightChoiceQuestion_Id bigint  NOT NULL
);

-- Creating table 'Files'
CREATE TABLE Files (
    Id bigint auto_increment primary key NOT NULL,
    Name varchar(500)  NULL,
    Type varchar(500)  NULL,
    Path varchar(500)  NULL
);
