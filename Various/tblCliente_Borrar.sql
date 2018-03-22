USE [DBEventos]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblCliente_Borrar]

@pr_Codigo				int

AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM		tblCliente
	WHERE		ID = @pr_Codigo
END

