CREATE TABLE [dbo].[PRODUCTOS] (
    [idProducto]  INT             IDENTITY (1, 1) NOT NULL,
    [nombre]      VARCHAR (255)   NOT NULL,
    [descripcion] TEXT            NULL,
    [precio]      DECIMAL (10, 2) NOT NULL,
    [categoria]   VARCHAR (100)   NULL,
    [stockActual] INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([idProducto] ASC)
);

