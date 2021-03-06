USE [DBEventos]
GO
/****** Object:  StoredProcedure [dbo].[Boleto_Consultar]    Script Date: 11/22/2015 5:51:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblBoleto_Consultar]

@pr_Codigo			int

AS
BEGIN
    -- Insert statements for procedure here
	SELECT		BOL.ID, TBOL.Nombre, CLI.Nombre , EVE.NombreEvento

	FROM		tblBoleto AS BOL
		INNER JOIN tblTipoBoleto AS TBOL 
			ON BOL.IDTipoBoleto = TBOL.IDTipoBoleto 
		INNER JOIN tblCliente AS CLI
			ON BOL.IDCLiente = CLI.ID
		INNER JOIN tblEvento AS EVE
			ON BOL.IDEvento = EVE.ID 
	WHERE BOL.IDCLiente = @pr_Codigo
END
