
CREATE PROCEDURE ActualizarUsuario
    @idUsuario INT,
    @nombre VARCHAR(255),
    @apellido VARCHAR(255),
    @telefono VARCHAR(20),
    @rol VARCHAR(50)
AS
BEGIN
    UPDATE USUARIOS
    SET nombre = @nombre,
        apellido = @apellido,
        telefono = @telefono,
        rol = @rol
    WHERE idUsuario = @idUsuario;
END;
