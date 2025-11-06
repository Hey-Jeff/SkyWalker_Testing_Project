CREATE TABLE [dbo].[DETALLEFACTURA] (
    [idDetalleFactura] INT             IDENTITY (1, 1) NOT NULL,
    [idFactura]        INT             NOT NULL,
    [idProducto]       INT             NOT NULL,
    [cantidad]         INT             NOT NULL,
    [precioUnitario]   DECIMAL (10, 2) NOT NULL,
    [subtotal]         DECIMAL (10, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([idDetalleFactura] ASC),
    FOREIGN KEY ([idFactura]) REFERENCES [dbo].[FACTURA] ([idFactura]),
    FOREIGN KEY ([idProducto]) REFERENCES [dbo].[PRODUCTOS] ([idProducto])
);

