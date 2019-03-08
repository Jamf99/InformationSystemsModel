
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/08/2019 17:05:41
-- Generated from EDMX file: C:\Users\User\Source\Repos\Jamf99\InformationSystemsModel\Ejercicio\Ejercicio\Modelo.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Library];
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

-- Creating table 'Estudiantes'
CREATE TABLE [dbo].[Estudiantes] (
    [CodEst] int IDENTITY(1,1) NOT NULL,
    [NomEst] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Materias'
CREATE TABLE [dbo].[Materias] (
    [CodMat] int IDENTITY(1,1) NOT NULL,
    [NomMat] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EstudianteMateria'
CREATE TABLE [dbo].[EstudianteMateria] (
    [Estudiantes_CodEst] int  NOT NULL,
    [Materias_CodMat] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CodEst] in table 'Estudiantes'
ALTER TABLE [dbo].[Estudiantes]
ADD CONSTRAINT [PK_Estudiantes]
    PRIMARY KEY CLUSTERED ([CodEst] ASC);
GO

-- Creating primary key on [CodMat] in table 'Materias'
ALTER TABLE [dbo].[Materias]
ADD CONSTRAINT [PK_Materias]
    PRIMARY KEY CLUSTERED ([CodMat] ASC);
GO

-- Creating primary key on [Estudiantes_CodEst], [Materias_CodMat] in table 'EstudianteMateria'
ALTER TABLE [dbo].[EstudianteMateria]
ADD CONSTRAINT [PK_EstudianteMateria]
    PRIMARY KEY CLUSTERED ([Estudiantes_CodEst], [Materias_CodMat] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Estudiantes_CodEst] in table 'EstudianteMateria'
ALTER TABLE [dbo].[EstudianteMateria]
ADD CONSTRAINT [FK_EstudianteMateria_Estudiante]
    FOREIGN KEY ([Estudiantes_CodEst])
    REFERENCES [dbo].[Estudiantes]
        ([CodEst])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Materias_CodMat] in table 'EstudianteMateria'
ALTER TABLE [dbo].[EstudianteMateria]
ADD CONSTRAINT [FK_EstudianteMateria_Materia]
    FOREIGN KEY ([Materias_CodMat])
    REFERENCES [dbo].[Materias]
        ([CodMat])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EstudianteMateria_Materia'
CREATE INDEX [IX_FK_EstudianteMateria_Materia]
ON [dbo].[EstudianteMateria]
    ([Materias_CodMat]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------