USE [DBEventos]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[tblTipoProveedor_Combo]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		IDTipoProveedor as Codigo, NombreTipoProveedor as Nombre
	FROM		tblTipoProveedor
	ORDER BY	Nombre 
END
