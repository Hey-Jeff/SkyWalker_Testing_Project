
-- PRODUCTOS
CREATE PROCEDURE AgregarProducto
    @nombre VARCHAR(255),
    @descripcion TEXT,
    @precio DECIMAL(10, 2),
    @categoria VARCHAR(100),
    @stockActual INT
AS
BEGIN
    INSERT INTO PRODUCTOS (nombre, descripcion, precio, categoria, stockActual)
    VALUES (@nombre, @descripcion, @precio, @categoria, @stockActual);
END;
