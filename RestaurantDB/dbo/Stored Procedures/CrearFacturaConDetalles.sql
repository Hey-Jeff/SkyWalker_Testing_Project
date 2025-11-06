CREATE PROCEDURE CrearFacturaConDetalles
    @idCarrito INT,
    @idUsuario INT,
    @idEmpleado INT,
    @metodoPago VARCHAR(100)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @totalFactura DECIMAL(10,2);
        SELECT @totalFactura = SUM(subtotal) FROM DETALLECARRITO WHERE idCarrito = @idCarrito;

        INSERT INTO FACTURA (idCarrito, idUsuario, fechaFactura, totalFactura, metodoPago, idEmpleado)
        VALUES (@idCarrito, @idUsuario, GETDATE(), @totalFactura, @metodoPago, @idEmpleado);

        DECLARE @idFactura INT = SCOPE_IDENTITY();

        INSERT INTO DETALLEFACTURA (idFactura, idProducto, cantidad, precioUnitario, subtotal)
        SELECT @idFactura, idProducto, cantidad, precioUnitario, subtotal
        FROM DETALLECARRITO WHERE idCarrito = @idCarrito;

        UPDATE PRODUCTOS
        SET stockActual = stockActual - dc.cantidad
        FROM PRODUCTOS p
        INNER JOIN DETALLECARRITO dc ON p.idProducto = dc.idProducto
        WHERE dc.idCarrito = @idCarrito;

        UPDATE CARRITO SET estado = 'Facturado' WHERE idCarrito = @idCarrito;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
