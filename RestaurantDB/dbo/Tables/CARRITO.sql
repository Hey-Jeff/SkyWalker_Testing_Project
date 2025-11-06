CREATE TABLE [dbo].[CARRITO] (
    [idCarrito]     INT             IDENTITY (1, 1) NOT NULL,
    [idUsuario]     INT             NOT NULL,
    [fechaCreacion] DATETIME        NOT NULL,
    [estado]        VARCHAR (50)    NOT NULL,
    [total]         DECIMAL (10, 2) NOT NULL,
    [idUbicacion]   INT             NULL,
    PRIMARY KEY CLUSTERED ([idCarrito] ASC),
    FOREIGN KEY ([idUbicacion]) REFERENCES [dbo].[UBICACIONES] ([idUbicacion]),
    FOREIGN KEY ([idUsuario]) REFERENCES [dbo].[USUARIOS] ([idUsuario])
);

