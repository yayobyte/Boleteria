USE [DBEventos]
GO
 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[tblProveedorxEvento_Grabar]


@pr_IDProveedor		int,
@pr_IDEvento		int

AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO tblProveedorxEvento (IDProveedor, IDEvento)
	VALUES (@pr_IDProveedor, @pr_IDEvento)
END
GO

