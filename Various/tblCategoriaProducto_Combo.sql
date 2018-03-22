USE [DBEventos]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblCategoriaProducto_Combo]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		IDCategoriaProducto AS Codigo, NombreCategoria AS Nombre
	FROM		tblCategoriaProducto
	ORDER BY	Nombre 
END
