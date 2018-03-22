USE [DBEventos]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblEstablecimiento_Combo]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		ID AS Codigo, Nombre AS Nombre
	FROM		tblEstablecimiento
	ORDER BY	Nombre 
END
