USE [DBEventos]
GO
 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[tblBoleto_Grabar]


@pr_IDCliente			int,
@pr_IDEvento			int,
@pr_IDTipoBoleto		int


AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO tblBoleto (IDCLiente, IDEvento, IDTipoBoleto)
	VALUES (@pr_IDCliente, @pr_IDEvento, @pr_IDTipoBoleto)
END
GO

