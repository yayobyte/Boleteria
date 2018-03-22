USE [DBEventos]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblNacionalidad_Combo]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		ID as Codigo, NombreNacionalidad as Nombre
	FROM		tblNacionalidad
	ORDER BY	Nombre 
END
