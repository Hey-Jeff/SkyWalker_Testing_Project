
-- CARRITO
CREATE PROCEDURE CrearCarrito
    @idUsuario INT,
    @estado VARCHAR(50),
    @total DECIMAL(10, 2),
    @idUbicacion INT
AS
BEGIN
    INSERT INTO CARRITO (idUsuario, fechaCreacion, estado, total, idUbicacion)
    VALUES (@idUsuario, GETDATE(), @estado, @total, @idUbicacion);
END;
