
CREATE PROCEDURE EliminarEmpleado
    @idEmpleado INT
AS
BEGIN
    DELETE FROM EMPLEADOS WHERE idEmpleado = @idEmpleado;
END;
