USE [DBEventos]
GO
 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblCliente_Actualizar]

@pr_Codigo			int,
@pr_Nombre			varchar(50),
@pr_Correo			varchar(50)


AS
BEGIN
	SET NOCOUNT ON;

	UPDATE		tblCliente

	SET			Nombre = @pr_Nombre,
				Correo = @pr_Correo
				
				
	WHERE		ID = @pr_Codigo
END
GO



