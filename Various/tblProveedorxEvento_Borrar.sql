USE [DBEventos]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblProveedorxEvento_Borrar]

@pr_Codigo				int

AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM		tblProveedorxEvento
	WHERE		IDProveedorxEvento = @pr_Codigo
END

