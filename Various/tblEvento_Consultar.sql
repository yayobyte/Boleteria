USE [DBEventos]
GO
/****** Object:  StoredProcedure [dbo].[Boleto_Consultar]    Script Date: 11/22/2015 5:51:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[tblEvento_Consultar]

@pr_NombreEvento			varchar(32)

AS
BEGIN
    -- Insert statements for procedure here
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
	WHERE EVE.NombreEvento LIKE '%'+@pr_NombreEvento+'%'
END