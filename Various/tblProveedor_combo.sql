USE [DBEventos]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblProveedor_Combo]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		ID as Codigo, Nombre as Nombre
	FROM		tblProveedor
	ORDER BY	Nombre 
END
