CREATE PROCEDURE AgregarUsuario
    @nombre VARCHAR(255),
    @apellido VARCHAR(255),
    @email VARCHAR(255),
    @telefono VARCHAR(20),
    @passwordHash VARCHAR(255),
    @rol VARCHAR(50)
AS
BEGIN
    INSERT INTO USUARIOS (nombre, apellido, email, telefono, passwordHash, rol)
    VALUES (@nombre, @apellido, @email, @telefono, @passwordHash, @rol);
END;
