
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/17/2021 18:50:26
-- Generated from EDMX file: C:\Users\Antía\Desktop\FIC\MAD\MiniPortal-src-4.2.1\Model\Photogram.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MAD_BD];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

DROP TABLE DarFav, SigueA, TieneAsociadas, EtiquetaSet, Comentarios, Publicaciones, Usuarios;
GO

-- Creating table 'Usuarios'
CREATE TABLE [Usuarios] (
    [usrId] bigint IDENTITY(1,1) NOT NULL,
    [loginName] varchar(30)  NOT NULL,
    [password] varchar(30)  NOT NULL,
    [name] varchar(30)  NOT NULL,
    [email] varchar(30)  NOT NULL,
    [pais] varchar(30)  NULL,
    [idioma] varchar(30)  NULL,

    CONSTRAINT [PK_UserProfile] PRIMARY KEY (usrId),
	CONSTRAINT [UniqueKey_Login] UNIQUE (loginName)
);
GO
-- Creating table 'Publicaciones'
CREATE TABLE [Publicaciones] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Usuario] bigint  NOT NULL,
    [imagen] nvarchar(280)  NOT NULL,
    [titulo] nvarchar(30)  NOT NULL,
    [descripcion] nvarchar(280)  NOT NULL,
    [fecha] time  NOT NULL,
    [categoria] nvarchar(30)  NOT NULL,
    [f] float  NULL,
    [ISO] int  NULL,
    [t] int  NULL,
    [wb] int  NULL,

    CONSTRAINT [PK_Publi] PRIMARY KEY (Id),
    CONSTRAINT [FK_User] FOREIGN KEY ([Usuario]) REFERENCES [Usuarios] ([usrId])
    ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO

-- Creating table 'Comentarios'
CREATE TABLE [Comentarios] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Usuario] bigint  NOT NULL,
    [PublicacionId] bigint  NOT NULL,
    [texto] nvarchar(280)  NOT NULL,

    CONSTRAINT [PK_Comment] PRIMARY KEY (Id),

    CONSTRAINT [FK_UserC] FOREIGN KEY ([Usuario]) REFERENCES [Usuarios] ([usrId])
    ON DELETE NO ACTION ON UPDATE NO ACTION,

    CONSTRAINT [FK_PubC] FOREIGN KEY ([PublicacionId]) REFERENCES [Publicaciones] ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO

-- Creating table 'EtiquetaSet'
CREATE TABLE [EtiquetaSet] (
    [tag] nvarchar(30)  NOT NULL,

    CONSTRAINT [PK_Tag] PRIMARY KEY (tag)
);
GO

-- Creating table 'SigueA'
CREATE TABLE [SigueA] (
    [UsuarioSeguidor] bigint  NOT NULL,
    [UsuarioSeguido] bigint  NOT NULL,

    CONSTRAINT [PK_Follow] PRIMARY KEY ([UsuarioSeguidor], [UsuarioSeguido] ASC),

    CONSTRAINT [FK_User1] FOREIGN KEY ([UsuarioSeguido]) REFERENCES [Usuarios] ([usrId])
    ON DELETE NO ACTION ON UPDATE NO ACTION,
    CONSTRAINT [FK_User2] FOREIGN KEY ([UsuarioSeguidor]) REFERENCES [Usuarios] ([usrId])
    ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO

-- Creating table 'DarFav'
CREATE TABLE [DarFav] (
    [UsuariosWhoLikes] bigint  NOT NULL,
    [PublicacionGustadas_Id] bigint  NOT NULL,

    CONSTRAINT [PK_Likes] PRIMARY KEY ([UsuariosWhoLikes], [PublicacionGustadas_Id] ASC),

    CONSTRAINT [FK_UserLikes] FOREIGN KEY ([UsuariosWhoLikes]) REFERENCES [Usuarios] ([usrId])
    ON DELETE NO ACTION ON UPDATE NO ACTION,

    CONSTRAINT [FK_PubLiked] FOREIGN KEY ([PublicacionGustadas_Id]) REFERENCES [Publicaciones] ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO

-- Creating table 'TieneAsociadas'
CREATE TABLE [TieneAsociadas] (
    [Publicaciones_Id] bigint  NOT NULL,
    [Etiquetas_tag] nvarchar(30)  NOT NULL

    CONSTRAINT [PK_Tagged] PRIMARY KEY ([Publicaciones_Id], [Etiquetas_tag] ASC),

    CONSTRAINT [FK_PubTagged] FOREIGN KEY ([Publicaciones_Id]) REFERENCES [Publicaciones] ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION,

    CONSTRAINT [FK_PubTag] FOREIGN KEY ([Etiquetas_tag]) REFERENCES [EtiquetaSet] ([tag])
    ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO

PRINT N'Tables created.'
GO