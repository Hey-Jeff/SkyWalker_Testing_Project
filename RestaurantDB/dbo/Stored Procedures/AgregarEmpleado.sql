
-- EMPLEADOS
CREATE PROCEDURE AgregarEmpleado
    @nombre VARCHAR(255),
    @apellido VARCHAR(255),
    @puesto VARCHAR(100),
    @contacto VARCHAR(255),
    @fechaIngreso DATE
AS
BEGIN
    INSERT INTO EMPLEADOS (nombre, apellido, puesto, contacto, fechaIngreso)
    VALUES (@nombre, @apellido, @puesto, @contacto, @fechaIngreso);
END;
