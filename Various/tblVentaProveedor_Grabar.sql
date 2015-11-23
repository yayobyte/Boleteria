USE [DBEventos]
GO
/****** Object:  StoredProcedure [dbo].[tblVentaProveedor_Grabar]    Script Date: 11/22/2015 10:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[tblVentaProveedor_Grabar]


@pr_IDProveedor			int,
@pr_IDProducto			int


AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO tblVentaProveedor ( IDProveedor, IDProducto)
	VALUES ( @pr_IDProveedor, @pr_IDProducto)
END
