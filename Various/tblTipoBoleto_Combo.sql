USE [DBEventos]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[tblTipoBoleto_Combo]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		IDTipoBoleto as Codigo, Nombre as Nombre
	FROM		tblTipoBoleto
	ORDER BY	Nombre 
END
