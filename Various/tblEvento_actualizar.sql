USE [DBEventos]
GO
 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblEvento_Actualizar]

@pr_Codigo			int,
@pr_NombreEvento		varchar(32),
@pr_IDArtista			int,
@pr_Fecha			date,
@pr_IDTipoEvento		int,
@pr_IDEstablecimiento		int



AS
BEGIN
	SET NOCOUNT ON;

	UPDATE		tblEvento

	SET			NombreEvento = @pr_NombreEvento,		
				IDArtista = @pr_IDArtista, 
				Fecha = @pr_Fecha,
				IDTipoEvento = @pr_IDTipoEvento,
				IDEstablecimiento = @pr_IDEstablecimiento		
				
	WHERE		ID = @pr_Codigo
END
GO



