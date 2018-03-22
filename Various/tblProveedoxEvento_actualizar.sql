USE [DBEventos]
GO
 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblProveedorxEvento_Actualizar]

@pr_Codigo			int,
@pr_IDProveedor			int,
@pr_IDEvento			int


AS
BEGIN
	SET NOCOUNT ON;

	UPDATE		 tblProveedorxEvento

	SET			IDProveedor = @pr_IDProveedor,
				IDEvento = @pr_IDEvento
				
	WHERE		IDProveedorxEvento = @pr_Codigo
END
GO



