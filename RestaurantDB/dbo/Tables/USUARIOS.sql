CREATE TABLE [dbo].[USUARIOS] (
    [idUsuario]    INT           IDENTITY (1, 1) NOT NULL,
    [nombre]       VARCHAR (255) NOT NULL,
    [apellido]     VARCHAR (255) NOT NULL,
    [email]        VARCHAR (255) NOT NULL,
    [telefono]     VARCHAR (20)  NULL,
    [passwordHash] VARCHAR (255) NOT NULL,
    [rol]          VARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([idUsuario] ASC),
    UNIQUE NONCLUSTERED ([email] ASC)
);

