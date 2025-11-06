CREATE TABLE [dbo].[EMPLEADOS] (
    [idEmpleado]   INT           IDENTITY (1, 1) NOT NULL,
    [nombre]       VARCHAR (255) NOT NULL,
    [apellido]     VARCHAR (255) NOT NULL,
    [puesto]       VARCHAR (100) NULL,
    [contacto]     VARCHAR (255) NULL,
    [fechaIngreso] DATE          NULL,
    PRIMARY KEY CLUSTERED ([idEmpleado] ASC)
);

