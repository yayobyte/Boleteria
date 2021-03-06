USE [DBEventos]
GO
/****** Object:  StoredProcedure [dbo].[tblCliente_Grid]    Script Date: 11/23/2015 12:58:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tblArtista_Grid]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		ART.ID as Id, ART.Nombre as NombreArtista, NAC.NombreNacionalidad AS Nacionalidad, TART.NombreTipoArtista AS TipoArtista
	FROM		tblArtista AS ART
		INNER JOIN tlbNacionalidad AS NAC 
			ON ART.IDNacionalidad = NAC.ID
		INNER JOIN tblTipoArtista AS TART
			ON ART.IDTipoArtista = TART.ID
	
END