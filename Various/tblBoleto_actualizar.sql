USE [DBEventos]
GO
 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblBoleto_Actualizar]

@pr_Codigo				int,
@pr_IDCliente			int,
@pr_IDEvento			int,
@pr_IDTipoBoleto		int


AS
BEGIN
	SET NOCOUNT ON;

	UPDATE		tblBoleto 

	SET			IDCLiente = @pr_IDCliente,
				IDEvento = @pr_IDEvento, 
				IDTipoBoleto = @pr_IDTipoBoleto
				
	WHERE		ID = @pr_Codigo
END
GO



