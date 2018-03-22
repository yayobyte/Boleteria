USE [DBEventos]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tblProveedorxEvento_Grid]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		PxE.IDProveedorxEvento, PROV.Nombre, eve.NombreEvento

	FROM		tblProveedorxEvento AS PxE
		INNER JOIN tblProveedor as PROV
			ON PxE.IDProveedor = PROV.ID
		INNER JOIN tblEvento as EVE
			ON PxE.IDEvento = EVE.ID
END