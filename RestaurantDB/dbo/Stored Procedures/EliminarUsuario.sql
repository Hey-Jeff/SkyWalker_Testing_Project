
CREATE PROCEDURE EliminarUsuario
    @idUsuario INT
AS
BEGIN
    DELETE FROM USUARIOS WHERE idUsuario = @idUsuario;
END;
