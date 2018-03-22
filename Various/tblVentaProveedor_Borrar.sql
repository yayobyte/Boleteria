USE [DBEventos]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblVentaProveedor_Borrar]

@pr_Codigo				int

AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM		tblVentaProveedor
	WHERE		IDVenta = @pr_Codigo
END

