
CREATE PROCEDURE ActualizarEmpleado
    @idEmpleado INT,
    @nombre VARCHAR(255),
    @apellido VARCHAR(255),
    @puesto VARCHAR(100),
    @contacto VARCHAR(255)
AS
BEGIN
    UPDATE EMPLEADOS
    SET nombre = @nombre,
        apellido = @apellido,
        puesto = @puesto,
        contacto = @contacto
    WHERE idEmpleado = @idEmpleado;
END;
