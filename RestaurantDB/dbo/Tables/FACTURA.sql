CREATE TABLE [dbo].[FACTURA] (
    [idFactura]    INT             IDENTITY (1, 1) NOT NULL,
    [idCarrito]    INT             NOT NULL,
    [idUsuario]    INT             NOT NULL,
    [fechaFactura] DATETIME        NOT NULL,
    [totalFactura] DECIMAL (10, 2) NOT NULL,
    [metodoPago]   VARCHAR (100)   NULL,
    [idEmpleado]   INT             NULL,
    PRIMARY KEY CLUSTERED ([idFactura] ASC),
    FOREIGN KEY ([idCarrito]) REFERENCES [dbo].[CARRITO] ([idCarrito]),
    FOREIGN KEY ([idEmpleado]) REFERENCES [dbo].[EMPLEADOS] ([idEmpleado]),
    FOREIGN KEY ([idUsuario]) REFERENCES [dbo].[USUARIOS] ([idUsuario]),
    UNIQUE NONCLUSTERED ([idCarrito] ASC)
);

