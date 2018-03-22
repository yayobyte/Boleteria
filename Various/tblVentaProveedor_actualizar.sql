USE [DBEventos]
GO
 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblVentaProveedor_Actualizar]

@pr_Codigo			int,
@pr_IDProveedor			int,
@pr_IDProducto			int


AS
BEGIN
	SET NOCOUNT ON;

	UPDATE		 tblVentaProveedor

	SET			IDProveedor = @pr_IDProveedor,
				IDProducto = @pr_IDProducto
				
	WHERE		IDVenta = @pr_Codigo
END
GO



