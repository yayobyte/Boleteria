USE [DBEventos]
GO
/****** Object:  StoredProcedure [dbo].[Servicio_Combo]    Script Date: 19/11/2015 8:10:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[tblCliente_Combo]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		ID as Codigo, Nombre as Nombre
	FROM		tblCliente
	ORDER BY	Nombre 
END