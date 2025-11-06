
CREATE PROCEDURE ActualizarProducto
    @idProducto INT,
    @nombre VARCHAR(255),
    @descripcion TEXT,
    @precio DECIMAL(10, 2),
    @categoria VARCHAR(100),
    @stockActual INT
AS
BEGIN
    UPDATE PRODUCTOS
    SET nombre = @nombre,
        descripcion = @descripcion,
        precio = @precio,
        categoria = @categoria,
        stockActual = @stockActual
    WHERE idProducto = @idProducto;
END;
