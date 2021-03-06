USE [DBEventos]
GO
/****** Object:  StoredProcedure [dbo].[tblEvento_Grid]    Script Date: 11/22/2015 7:38:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[tblEvento_Grid]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		EVE.ID AS Id, EVE.NombreEvento AS NombreEvento, EVE.fecha AS Fecha,
				EST.Nombre AS NombreEstablecimiento, EST.Capacidad AS Capacidad, TEVE.NombreTipoEvento AS NombreTipoEvento,
				ART.Nombre
				

	FROM		tblEvento AS EVE
		INNER JOIN tblEstablecimiento AS EST
			ON EVE.IDEstablecimiento = EST.ID
		INNER JOIN tblArtista AS ART
			ON EVE.IDArtista = ART.ID
		INNER JOIN	tblTipoEvento AS TEVE
			ON EVE.IDTipoEvento = TEVE.ID
		
END