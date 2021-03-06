USE [DBEventos]
GO
/****** Object:  StoredProcedure [dbo].[tblVentaProveedor_Grid]    Script Date: 11/22/2015 10:33:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[tblVentaProveedor_Grid]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		V.IDVenta, P.NombreProducto , PROV.Nombre

	FROM		tblVentaProveedor AS V
		INNER JOIN tblProducto AS P
			ON V.IDProducto = P.ID
		INNER JOIN tblProveedor as PROV
			ON V.IDProveedor = PROV.ID
END