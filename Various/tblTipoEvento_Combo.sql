USE [DBEventos]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblTipoEvento_Combo]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		ID AS Codigo, NombreTipoEvento AS Nombre
	FROM		tblTipoEvento
	ORDER BY	Nombre 
END
