USE [DBEventos]
GO
/****** Object:  StoredProcedure [dbo].[tblCliente_Grid]    Script Date: 11/23/2015 12:58:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tblTipoArtista_Grid]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		ID as Id, NombreTipoArtista as TipoArtista
	FROM		tblTipoArtista 
	
END