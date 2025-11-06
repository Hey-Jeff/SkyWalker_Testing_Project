CREATE TABLE [dbo].[INVENTARIOPORUBICACION] (
    [idInventarioUbicacion] INT      IDENTITY (1, 1) NOT NULL,
    [idProducto]            INT      NOT NULL,
    [idUbicacion]           INT      NOT NULL,
    [stockUbicacion]        INT      NOT NULL,
    [fechaActualizacion]    DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([idInventarioUbicacion] ASC),
    FOREIGN KEY ([idProducto]) REFERENCES [dbo].[PRODUCTOS] ([idProducto]),
    FOREIGN KEY ([idUbicacion]) REFERENCES [dbo].[UBICACIONES] ([idUbicacion]),
    CONSTRAINT [UQ_ProductoUbicacion] UNIQUE NONCLUSTERED ([idProducto] ASC, [idUbicacion] ASC)
);

