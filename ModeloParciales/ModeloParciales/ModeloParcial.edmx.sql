
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/19/2019 15:21:31
-- Generated from EDMX file: C:\Users\User\Source\Repos\Jamf99\InformationSystemsModel\ModeloParciales\ModeloParciales\ModeloParcial.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Parciales];
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
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Parciales'
CREATE TABLE [dbo].[Parciales] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nota] float  NOT NULL,
    [CursoGrupo] int  NOT NULL,
    [CursoAñoSem] int  NOT NULL,
    [CursoMateriaId] int  NOT NULL,
    [EstudianteId] int  NOT NULL
);
GO

-- Creating table 'Cursos'
CREATE TABLE [dbo].[Cursos] (
    [Grupo] int  NOT NULL,
    [AñoSem] int  NOT NULL,
    [MateriaId] int  NOT NULL
);
GO

-- Creating table 'Materias'
CREATE TABLE [dbo].[Materias] (
    [Id] int  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Estudiantes'
ALTER TABLE [dbo].[Estudiantes]
ADD CONSTRAINT [PK_Estudiantes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id], [CursoGrupo], [CursoAñoSem], [CursoMateriaId] in table 'Parciales'
ALTER TABLE [dbo].[Parciales]
ADD CONSTRAINT [PK_Parciales]
    PRIMARY KEY CLUSTERED ([Id], [CursoGrupo], [CursoAñoSem], [CursoMateriaId] ASC);
GO

-- Creating primary key on [Grupo], [AñoSem], [MateriaId] in table 'Cursos'
ALTER TABLE [dbo].[Cursos]
ADD CONSTRAINT [PK_Cursos]
    PRIMARY KEY CLUSTERED ([Grupo], [AñoSem], [MateriaId] ASC);
GO

-- Creating primary key on [Id] in table 'Materias'
ALTER TABLE [dbo].[Materias]
ADD CONSTRAINT [PK_Materias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MateriaId] in table 'Cursos'
ALTER TABLE [dbo].[Cursos]
ADD CONSTRAINT [FK_CursoMateria]
    FOREIGN KEY ([MateriaId])
    REFERENCES [dbo].[Materias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CursoMateria'
CREATE INDEX [IX_FK_CursoMateria]
ON [dbo].[Cursos]
    ([MateriaId]);
GO

-- Creating foreign key on [CursoGrupo], [CursoAñoSem], [CursoMateriaId] in table 'Parciales'
ALTER TABLE [dbo].[Parciales]
ADD CONSTRAINT [FK_ParcialCurso]
    FOREIGN KEY ([CursoGrupo], [CursoAñoSem], [CursoMateriaId])
    REFERENCES [dbo].[Cursos]
        ([Grupo], [AñoSem], [MateriaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ParcialCurso'
CREATE INDEX [IX_FK_ParcialCurso]
ON [dbo].[Parciales]
    ([CursoGrupo], [CursoAñoSem], [CursoMateriaId]);
GO

-- Creating foreign key on [EstudianteId] in table 'Parciales'
ALTER TABLE [dbo].[Parciales]
ADD CONSTRAINT [FK_EstudianteParcial]
    FOREIGN KEY ([EstudianteId])
    REFERENCES [dbo].[Estudiantes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EstudianteParcial'
CREATE INDEX [IX_FK_EstudianteParcial]
ON [dbo].[Parciales]
    ([EstudianteId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------