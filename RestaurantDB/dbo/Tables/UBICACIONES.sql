CREATE TABLE [dbo].[UBICACIONES] (
    [idUbicacion] INT           IDENTITY (1, 1) NOT NULL,
    [nombre]      VARCHAR (255) NOT NULL,
    [tipo]        VARCHAR (100) NULL,
    [capacidad]   INT           NULL,
    [estado]      VARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([idUbicacion] ASC)
);

