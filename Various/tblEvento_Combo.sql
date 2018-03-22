USE [DBEventos]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblEvento_Combo]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		ID as Codigo, NombreEvento as Nombre
	FROM		tblEvento
	ORDER BY	Nombre 
END