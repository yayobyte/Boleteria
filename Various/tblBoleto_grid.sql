USE [DBEventos]
GO
/****** Object:  StoredProcedure [dbo].[Servicio_Grid]    Script Date: 21/11/2015 4:15:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[tblBoleto_Grid]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		BOL.ID, TBOL.Nombre, CLI.Nombre , EVE.NombreEvento

	FROM		tblBoleto AS BOL
		INNER JOIN tblTipoBoleto AS TBOL 
			ON BOL.IDTipoBoleto = TBOL.IDTipoBoleto 
		INNER JOIN tblCliente AS CLI
			ON BOL.IDCLiente = CLI.ID
		INNER JOIN tblEvento AS EVE
			ON BOL.IDEvento = EVE.ID 
	
END