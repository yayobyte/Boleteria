USE [DBEventos]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblEvento_Borrar]

@pr_Codigo				int

AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM		tblEvento
	WHERE		ID = @pr_Codigo
END

