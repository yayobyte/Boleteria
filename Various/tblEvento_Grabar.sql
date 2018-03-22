USE [DBEventos]
GO
 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[tblEvento_Grabar]


@pr_NombreEvento		varchar(32),
@pr_IDArtista			int,
@pr_Fecha			date,	
@pr_IDTipoEvento		int,
@pr_IDEstablecimiento		int

AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO tblEvento (NombreEvento, IDArtista, Fecha, IDTipoEvento, IDEstablecimiento)
	VALUES (@pr_NombreEvento, @pr_IDArtista, @pr_Fecha, @pr_IDTipoEvento, @pr_IDEstablecimiento)
END
GO

