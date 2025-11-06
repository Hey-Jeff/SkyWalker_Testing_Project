
CREATE PROCEDURE EliminarCarrito
    @idCarrito INT
AS
BEGIN
    DELETE FROM DETALLECARRITO WHERE idCarrito = @idCarrito;
    DELETE FROM CARRITO WHERE idCarrito = @idCarrito;
END;
