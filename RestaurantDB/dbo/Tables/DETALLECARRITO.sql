CREATE TABLE [dbo].[DETALLECARRITO] (
    [idDetalleCarrito] INT             IDENTITY (1, 1) NOT NULL,
    [idCarrito]        INT             NOT NULL,
    [idProducto]       INT             NOT NULL,
    [cantidad]         INT             NOT NULL,
    [precioUnitario]   DECIMAL (10, 2) NOT NULL,
    [subtotal]         DECIMAL (10, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([idDetalleCarrito] ASC),
    FOREIGN KEY ([idCarrito]) REFERENCES [dbo].[CARRITO] ([idCarrito]),
    FOREIGN KEY ([idProducto]) REFERENCES [dbo].[PRODUCTOS] ([idProducto])
);

