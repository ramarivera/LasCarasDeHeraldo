
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/10/2015 17:37:39
-- Generated from EDMX file: D:\Dropbox\UTN\FRCU\TALLER DE PROGRAMACIÓN\Visual Studio 2015 Ramiro\LasCarasDeHeraldo\LasCarasDeHeraldo\Modelo.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Reclamos];
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

-- Creating table 'ReclamoSet'
CREATE TABLE [dbo].[ReclamoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Comentario] nvarchar(max)  NOT NULL,
    [Titulo] nvarchar(max)  NOT NULL,
    [Adherentes_Id] int  NOT NULL
);
GO

-- Creating table 'EstadoSet'
CREATE TABLE [dbo].[EstadoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UsuarioSet'
CREATE TABLE [dbo].[UsuarioSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [TipoUsuario] nvarchar(max)  NOT NULL,
    [TipoUser_Id] int  NOT NULL
);
GO

-- Creating table 'AreaSet'
CREATE TABLE [dbo].[AreaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TipoUsuarioSet'
CREATE TABLE [dbo].[TipoUsuarioSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'HistoricoSet'
CREATE TABLE [dbo].[HistoricoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Comentario] nvarchar(max)  NOT NULL,
    [Reclamo_Id] int  NOT NULL,
    [Estado_Id] int  NOT NULL,
    [Area_Id] int  NOT NULL
);
GO

-- Creating table 'ReclamoUsuario'
CREATE TABLE [dbo].[ReclamoUsuario] (
    [ReclamoUsuario_Usuario_Id] int  NOT NULL,
    [Usuario_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ReclamoSet'
ALTER TABLE [dbo].[ReclamoSet]
ADD CONSTRAINT [PK_ReclamoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EstadoSet'
ALTER TABLE [dbo].[EstadoSet]
ADD CONSTRAINT [PK_EstadoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsuarioSet'
ALTER TABLE [dbo].[UsuarioSet]
ADD CONSTRAINT [PK_UsuarioSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AreaSet'
ALTER TABLE [dbo].[AreaSet]
ADD CONSTRAINT [PK_AreaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TipoUsuarioSet'
ALTER TABLE [dbo].[TipoUsuarioSet]
ADD CONSTRAINT [PK_TipoUsuarioSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HistoricoSet'
ALTER TABLE [dbo].[HistoricoSet]
ADD CONSTRAINT [PK_HistoricoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ReclamoUsuario_Usuario_Id], [Usuario_Id] in table 'ReclamoUsuario'
ALTER TABLE [dbo].[ReclamoUsuario]
ADD CONSTRAINT [PK_ReclamoUsuario]
    PRIMARY KEY CLUSTERED ([ReclamoUsuario_Usuario_Id], [Usuario_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ReclamoUsuario_Usuario_Id] in table 'ReclamoUsuario'
ALTER TABLE [dbo].[ReclamoUsuario]
ADD CONSTRAINT [FK_ReclamoUsuario_Reclamo]
    FOREIGN KEY ([ReclamoUsuario_Usuario_Id])
    REFERENCES [dbo].[ReclamoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Usuario_Id] in table 'ReclamoUsuario'
ALTER TABLE [dbo].[ReclamoUsuario]
ADD CONSTRAINT [FK_ReclamoUsuario_Usuario]
    FOREIGN KEY ([Usuario_Id])
    REFERENCES [dbo].[UsuarioSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ReclamoUsuario_Usuario'
CREATE INDEX [IX_FK_ReclamoUsuario_Usuario]
ON [dbo].[ReclamoUsuario]
    ([Usuario_Id]);
GO

-- Creating foreign key on [Adherentes_Id] in table 'ReclamoSet'
ALTER TABLE [dbo].[ReclamoSet]
ADD CONSTRAINT [FK_ReclamoUsuario1]
    FOREIGN KEY ([Adherentes_Id])
    REFERENCES [dbo].[UsuarioSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ReclamoUsuario1'
CREATE INDEX [IX_FK_ReclamoUsuario1]
ON [dbo].[ReclamoSet]
    ([Adherentes_Id]);
GO

-- Creating foreign key on [Reclamo_Id] in table 'HistoricoSet'
ALTER TABLE [dbo].[HistoricoSet]
ADD CONSTRAINT [FK_ReclamoHistorico]
    FOREIGN KEY ([Reclamo_Id])
    REFERENCES [dbo].[ReclamoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ReclamoHistorico'
CREATE INDEX [IX_FK_ReclamoHistorico]
ON [dbo].[HistoricoSet]
    ([Reclamo_Id]);
GO

-- Creating foreign key on [Estado_Id] in table 'HistoricoSet'
ALTER TABLE [dbo].[HistoricoSet]
ADD CONSTRAINT [FK_HistoricoEstado]
    FOREIGN KEY ([Estado_Id])
    REFERENCES [dbo].[EstadoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HistoricoEstado'
CREATE INDEX [IX_FK_HistoricoEstado]
ON [dbo].[HistoricoSet]
    ([Estado_Id]);
GO

-- Creating foreign key on [Area_Id] in table 'HistoricoSet'
ALTER TABLE [dbo].[HistoricoSet]
ADD CONSTRAINT [FK_HistoricoArea]
    FOREIGN KEY ([Area_Id])
    REFERENCES [dbo].[AreaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HistoricoArea'
CREATE INDEX [IX_FK_HistoricoArea]
ON [dbo].[HistoricoSet]
    ([Area_Id]);
GO

-- Creating foreign key on [TipoUser_Id] in table 'UsuarioSet'
ALTER TABLE [dbo].[UsuarioSet]
ADD CONSTRAINT [FK_UsuarioTipoUsuario]
    FOREIGN KEY ([TipoUser_Id])
    REFERENCES [dbo].[TipoUsuarioSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioTipoUsuario'
CREATE INDEX [IX_FK_UsuarioTipoUsuario]
ON [dbo].[UsuarioSet]
    ([TipoUser_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------