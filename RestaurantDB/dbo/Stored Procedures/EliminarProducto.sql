
CREATE PROCEDURE EliminarProducto
    @idProducto INT
AS
BEGIN
    DELETE FROM PRODUCTOS WHERE idProducto = @idProducto;
END;
