USE [DBEventos]
GO
/****** Object:  StoredProcedure [dbo].[tblCliente_Grid]    Script Date: 11/23/2015 12:58:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tblTipoBoleto_Grid]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		IDTipoBoleto AS Id, Nombre as TipoBoleto
	FROM		tblTipoBoleto
	
END