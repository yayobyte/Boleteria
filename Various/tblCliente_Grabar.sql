USE [DBEventos]
GO
 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[tblCliente_Grabar]


@pr_Nombre			varchar(50),
@pr_Correo			varchar(50)


AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO tblCliente (Nombre, Correo)
	VALUES (@pr_Nombre, @pr_Correo)
END
GO

