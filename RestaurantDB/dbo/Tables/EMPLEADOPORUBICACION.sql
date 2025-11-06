CREATE TABLE [dbo].[EMPLEADOPORUBICACION] (
    [idEmpleadoUbicacion] INT  IDENTITY (1, 1) NOT NULL,
    [idUbicacion]         INT  NOT NULL,
    [idEmpleado]          INT  NOT NULL,
    [fechaInicio]         DATE NOT NULL,
    [fechaFin]            DATE NULL,
    PRIMARY KEY CLUSTERED ([idEmpleadoUbicacion] ASC),
    FOREIGN KEY ([idEmpleado]) REFERENCES [dbo].[EMPLEADOS] ([idEmpleado]),
    FOREIGN KEY ([idUbicacion]) REFERENCES [dbo].[UBICACIONES] ([idUbicacion])
);

