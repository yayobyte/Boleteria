USE [DBEventos]
GO
/****** Object:  StoredProcedure [dbo].[Servicio_Borrar]    Script Date: 21/11/2015 4:10:56 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblBoleto_Borrar]

@pr_Codigo				int

AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM		tblBoleto 
	WHERE		ID = @pr_Codigo
END

