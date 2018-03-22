USE [DBEventos]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[tblProducto_Combo]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		ID as Codigo, NombreProducto as Nombre
	FROM		tblProducto
	ORDER BY	Nombre 
END
