USE [master]
GO
/****** Object:  Database [DBEventos]    Script Date: 22/11/2015 4:52:47 p. m. ******/
CREATE DATABASE [DBEventos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBEventos', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\DBEventos.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DBEventos_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\DBEventos_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DBEventos] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBEventos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBEventos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBEventos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBEventos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBEventos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBEventos] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBEventos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBEventos] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DBEventos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBEventos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBEventos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBEventos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBEventos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBEventos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBEventos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBEventos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBEventos] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBEventos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBEventos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBEventos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBEventos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBEventos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBEventos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBEventos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBEventos] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DBEventos] SET  MULTI_USER 
GO
ALTER DATABASE [DBEventos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBEventos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBEventos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBEventos] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [DBEventos]
GO
/****** Object:  StoredProcedure [dbo].[Boleto_Consultar]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Boleto_Consultar]

@pr_Codigo			int

AS
BEGIN
    -- Insert statements for procedure here
	SELECT		BOL.ID, TBOL.Nombre, CLI.Nombre , EVE.NombreEvento

	FROM		tblBoleto AS BOL
		INNER JOIN tblTipoBoleto AS TBOL 
			ON BOL.IDTipoBoleto = TBOL.IDTipoBoleto 
		INNER JOIN tblCliente AS CLI
			ON BOL.IDCLiente = CLI.ID
		INNER JOIN tblEvento AS EVE
			ON BOL.IDEvento = EVE.ID 
	WHERE BOL.IDCLiente = @pr_Codigo
END

GO
/****** Object:  StoredProcedure [dbo].[tblArtista_Combo]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[tblArtista_Combo]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		ID AS Codigo, Nombre AS Nombre
	FROM		tblArtista
	ORDER BY	Nombre 
END

GO
/****** Object:  StoredProcedure [dbo].[tblBoleto_Actualizar]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblBoleto_Actualizar]

@pr_Codigo				int,
@pr_IDCliente			int,
@pr_IDEvento			int,
@pr_IDTipoBoleto		int


AS
BEGIN
	SET NOCOUNT ON;

	UPDATE		tblBoleto 

	SET			IDCLiente = @pr_IDCliente,
				IDEvento = @pr_IDEvento, 
				IDTipoBoleto = @pr_IDTipoBoleto
				
	WHERE		ID = @pr_Codigo
END

GO
/****** Object:  StoredProcedure [dbo].[tblBoleto_Borrar]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblBoleto_Borrar]

@pr_Codigo				int

AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM		tblBoleto 
	WHERE		ID = @pr_Codigo
END


GO
/****** Object:  StoredProcedure [dbo].[tblBoleto_Grabar]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[tblBoleto_Grabar]


@pr_IDCliente			int,
@pr_IDEvento			int,
@pr_IDTipoBoleto		int


AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO tblBoleto (IDCLiente, IDEvento, IDTipoBoleto)
	VALUES (@pr_IDCliente, @pr_IDEvento, @pr_IDTipoBoleto)
END

GO
/****** Object:  StoredProcedure [dbo].[tblBoleto_Grid]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tblBoleto_Grid]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		BOL.ID, TBOL.Nombre, CLI.Nombre , EVE.NombreEvento

	FROM		tblBoleto AS BOL
		INNER JOIN tblTipoBoleto AS TBOL 
			ON BOL.IDTipoBoleto = TBOL.IDTipoBoleto 
		INNER JOIN tblCliente AS CLI
			ON BOL.IDCLiente = CLI.ID
		INNER JOIN tblEvento AS EVE
			ON BOL.IDEvento = EVE.ID 
	
END
GO
/****** Object:  StoredProcedure [dbo].[tblCategoriaProducto_Combo]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblCategoriaProducto_Combo]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		IDCategoriaProducto AS Codigo, NombreCategoria AS Nombre
	FROM		tblCategoriaProducto
	ORDER BY	Nombre 
END

GO
/****** Object:  StoredProcedure [dbo].[tblCliente_Actualizar]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblCliente_Actualizar]

@pr_Codigo			int,
@pr_Nombre			varchar(50),
@pr_Correo			varchar(50)


AS
BEGIN
	SET NOCOUNT ON;

	UPDATE		tblCliente

	SET			Nombre = @pr_Nombre,
				Correo = @pr_Correo
				
				
	WHERE		ID = @pr_Codigo
END

GO
/****** Object:  StoredProcedure [dbo].[tblCliente_Borrar]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblCliente_Borrar]

@pr_Codigo				int

AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM		tblCliente
	WHERE		ID = @pr_Codigo
END


GO
/****** Object:  StoredProcedure [dbo].[tblCliente_Combo]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblCliente_Combo]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		ID as Codigo, Nombre as Nombre
	FROM		tblCliente
	ORDER BY	Nombre 
END

GO
/****** Object:  StoredProcedure [dbo].[tblCliente_Grabar]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[tblCliente_Grabar]


@pr_Nombre			varchar(50),
@pr_Correo			varchar(50)


AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO tblCliente (Nombre, Correo)
	VALUES (@pr_Nombre, @pr_Correo)
END

GO
/****** Object:  StoredProcedure [dbo].[tblCliente_Grid]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tblCliente_Grid]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		ID, Nombre, Correo
	FROM		tblCliente
	
END


GO
/****** Object:  StoredProcedure [dbo].[tblEvento_Actualizar]    Script Date: 22/11/2015 4:52:48 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[tblEvento_Borrar]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblEvento_Borrar]

@pr_Codigo				int

AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM		tblEvento
	WHERE		ID = @pr_Codigo
END


GO
/****** Object:  StoredProcedure [dbo].[tblEvento_Combo]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblEvento_Combo]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		ID as Codigo, NombreEvento as Nombre
	FROM		tblEvento
	ORDER BY	Nombre 
END

GO
/****** Object:  StoredProcedure [dbo].[tblEvento_Grabar]    Script Date: 22/11/2015 4:52:48 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[tblEvento_Grid]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tblEvento_Grid]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		EVE.ID , EVE.NombreEvento , EVE.fecha,
				EST.Nombre , EST.Capacidad, TEVE.NombreTipoEvento,
				ART.Nombre
				

	FROM		tblEvento AS EVE
		INNER JOIN tblEstablecimiento AS EST
			ON EVE.IDEstablecimiento = EST.ID
		INNER JOIN tblArtista AS ART
			ON EVE.IDArtista = ART.ID
		INNER JOIN	tblTipoEvento AS TEVE
			ON EVE.IDTipoEvento = TEVE.ID
		
END
GO
/****** Object:  StoredProcedure [dbo].[tblNacionalidad_Combo]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblNacionalidad_Combo]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		ID as Codigo, NombreNacionalidad as Nombre
	FROM		tblNacionalidad
	ORDER BY	Nombre 
END

GO
/****** Object:  StoredProcedure [dbo].[tblProducto_Combo]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[tblProducto_Combo]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		ID as Codigo, NombreProducto as Nombre
	FROM		tblProducto
	ORDER BY	Nombre 
END

GO
/****** Object:  StoredProcedure [dbo].[tblProveedor_Combo]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblProveedor_Combo]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		ID as Codigo, Nombre as Nombre
	FROM		tblProveedor
	ORDER BY	Nombre 
END

GO
/****** Object:  StoredProcedure [dbo].[tblProveedorxEvento_Actualizar]    Script Date: 22/11/2015 4:52:48 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[tblProveedorxEvento_Borrar]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblProveedorxEvento_Borrar]

@pr_Codigo				int

AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM		tblProveedorxEvento
	WHERE		IDProveedorxEvento = @pr_Codigo
END


GO
/****** Object:  StoredProcedure [dbo].[tblProveedorxEvento_Grabar]    Script Date: 22/11/2015 4:52:48 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[tblProveedorxEvento_Grid]    Script Date: 22/11/2015 4:52:48 p. m. ******/
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
GO
/****** Object:  StoredProcedure [dbo].[tblTipoBoleto_Combo]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[tblTipoBoleto_Combo]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		IDTipoBoleto as Codigo, Nombre as Nombre
	FROM		tblTipoBoleto
	ORDER BY	Nombre 
END

GO
/****** Object:  StoredProcedure [dbo].[tblTipoProveedor_Combo]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[tblTipoProveedor_Combo]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		IDTipoProveedor as Codigo, NombreTipoProveedor as Nombre
	FROM		tblTipoProveedor
	ORDER BY	Nombre 
END

GO
/****** Object:  StoredProcedure [dbo].[tblVentaProveedor_Actualizar]    Script Date: 22/11/2015 4:52:48 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[tblVentaProveedor_Borrar]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblVentaProveedor_Borrar]

@pr_Codigo				int

AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM		tblVentaProveedor
	WHERE		IDVenta = @pr_Codigo
END


GO
/****** Object:  StoredProcedure [dbo].[tblVentaProveedor_Grabar]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[tblVentaProveedor_Grabar]


@pr_IDVenta			int,
@pr_IDProveedor			int,
@pr_IDProducto			int


AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO tblVentaProveedor (IDVenta, IDProveedor, IDProducto)
	VALUES (@pr_IDVenta, @pr_IDProveedor, @pr_IDProducto)
END

GO
/****** Object:  StoredProcedure [dbo].[tblVentaProveedor_Grid]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tblVentaProveedor_Grid]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT		V.IDVenta, P.NombreProducto , PROV.Nombre

	FROM		tblVentaProveedor AS V
		INNER JOIN tblProducto AS P
			ON V.IDProducto = P.ID
		INNER JOIN tblProveedor as PROV
			ON V.IDProducto = PROV.ID
END


GO
/****** Object:  Table [dbo].[tblArtista]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblArtista](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](32) NOT NULL,
	[IDNacionalidad] [int] NOT NULL,
	[IDTipoArtista] [int] NOT NULL,
 CONSTRAINT [PK_tblArtista] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblBoleto]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBoleto](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDCLiente] [int] NOT NULL,
	[IDEvento] [int] NOT NULL,
	[IDTipoBoleto] [int] NOT NULL,
 CONSTRAINT [PK_tblBoleto] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[IDCLiente] ASC,
	[IDEvento] ASC,
	[IDTipoBoleto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCategoriaProducto]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCategoriaProducto](
	[IDCategoriaProducto] [int] IDENTITY(1,1) NOT NULL,
	[NombreCategoria] [varchar](32) NOT NULL,
 CONSTRAINT [PK_tblCategoriaProducto] PRIMARY KEY CLUSTERED 
(
	[IDCategoriaProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblCliente]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCliente](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Correo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblEstablecimiento]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblEstablecimiento](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](32) NOT NULL,
	[Capacidad] [int] NOT NULL,
	[Ciudad] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblEstablecimiento] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblEvento]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblEvento](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NombreEvento] [varchar](32) NOT NULL,
	[IDArtista] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[IDTipoEvento] [int] NOT NULL,
	[IDEstablecimiento] [int] NOT NULL,
 CONSTRAINT [PK_tblEvento] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblProducto]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblProducto](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NombreProducto] [varchar](32) NOT NULL,
	[IDCategoria] [int] NOT NULL,
 CONSTRAINT [PK_tblProducto] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblProveedor]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblProveedor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](32) NOT NULL,
	[IDTipoProveedor] [int] NOT NULL,
 CONSTRAINT [PK_tblProveedor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblProveedorxEvento]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProveedorxEvento](
	[IDProveedorxEvento] [int] IDENTITY(1,1) NOT NULL,
	[IDProveedor] [int] NOT NULL,
	[IDEvento] [int] NOT NULL,
 CONSTRAINT [PK_tblProveedorxEvento] PRIMARY KEY CLUSTERED 
(
	[IDProveedorxEvento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblTipoArtista]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblTipoArtista](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NombreTipoArtista] [varchar](32) NOT NULL,
 CONSTRAINT [PK_tblTipoArtista] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblTipoBoleto]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblTipoBoleto](
	[IDTipoBoleto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](32) NOT NULL,
 CONSTRAINT [PK_tblTipoBoleto] PRIMARY KEY CLUSTERED 
(
	[IDTipoBoleto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblTipoEvento]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblTipoEvento](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NombreTipoEvento] [varchar](32) NOT NULL,
 CONSTRAINT [PK_tblTipoEvento] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblTipoProveedor]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblTipoProveedor](
	[IDTipoProveedor] [int] NOT NULL,
	[NombreTipoProveedor] [varchar](32) NOT NULL,
 CONSTRAINT [PK_tblTipoProveedor] PRIMARY KEY CLUSTERED 
(
	[IDTipoProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblVentaProveedor]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVentaProveedor](
	[IDVenta] [int] IDENTITY(1,1) NOT NULL,
	[IDProveedor] [int] NOT NULL,
	[IDProducto] [int] NOT NULL,
 CONSTRAINT [PK_tblVentaProveedor] PRIMARY KEY CLUSTERED 
(
	[IDVenta] ASC,
	[IDProveedor] ASC,
	[IDProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tlbNacionalidad]    Script Date: 22/11/2015 4:52:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tlbNacionalidad](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NombreNacionalidad] [varchar](32) NOT NULL,
 CONSTRAINT [PK_tlbNacionalidad] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[tblArtista]  WITH CHECK ADD  CONSTRAINT [FK_tblArtista_tblTipoArtista] FOREIGN KEY([IDTipoArtista])
REFERENCES [dbo].[tblTipoArtista] ([ID])
GO
ALTER TABLE [dbo].[tblArtista] CHECK CONSTRAINT [FK_tblArtista_tblTipoArtista]
GO
ALTER TABLE [dbo].[tblArtista]  WITH CHECK ADD  CONSTRAINT [FK_tblArtista_tlbNacionalidad] FOREIGN KEY([IDNacionalidad])
REFERENCES [dbo].[tlbNacionalidad] ([ID])
GO
ALTER TABLE [dbo].[tblArtista] CHECK CONSTRAINT [FK_tblArtista_tlbNacionalidad]
GO
ALTER TABLE [dbo].[tblBoleto]  WITH CHECK ADD  CONSTRAINT [FK_tblBoleto_Cliente] FOREIGN KEY([IDCLiente])
REFERENCES [dbo].[tblCliente] ([ID])
GO
ALTER TABLE [dbo].[tblBoleto] CHECK CONSTRAINT [FK_tblBoleto_Cliente]
GO
ALTER TABLE [dbo].[tblBoleto]  WITH CHECK ADD  CONSTRAINT [FK_tblBoleto_tblEvento] FOREIGN KEY([IDEvento])
REFERENCES [dbo].[tblEvento] ([ID])
GO
ALTER TABLE [dbo].[tblBoleto] CHECK CONSTRAINT [FK_tblBoleto_tblEvento]
GO
ALTER TABLE [dbo].[tblBoleto]  WITH CHECK ADD  CONSTRAINT [FK_tblBoleto_tblTipoBoleto] FOREIGN KEY([IDTipoBoleto])
REFERENCES [dbo].[tblTipoBoleto] ([IDTipoBoleto])
GO
ALTER TABLE [dbo].[tblBoleto] CHECK CONSTRAINT [FK_tblBoleto_tblTipoBoleto]
GO
ALTER TABLE [dbo].[tblEvento]  WITH CHECK ADD  CONSTRAINT [FK_tblEvento_tblArtista] FOREIGN KEY([IDArtista])
REFERENCES [dbo].[tblArtista] ([ID])
GO
ALTER TABLE [dbo].[tblEvento] CHECK CONSTRAINT [FK_tblEvento_tblArtista]
GO
ALTER TABLE [dbo].[tblEvento]  WITH CHECK ADD  CONSTRAINT [FK_tblEvento_tblEstablecimiento] FOREIGN KEY([IDEstablecimiento])
REFERENCES [dbo].[tblEstablecimiento] ([ID])
GO
ALTER TABLE [dbo].[tblEvento] CHECK CONSTRAINT [FK_tblEvento_tblEstablecimiento]
GO
ALTER TABLE [dbo].[tblEvento]  WITH CHECK ADD  CONSTRAINT [FK_tblEvento_tblTipoEvento] FOREIGN KEY([IDTipoEvento])
REFERENCES [dbo].[tblTipoEvento] ([ID])
GO
ALTER TABLE [dbo].[tblEvento] CHECK CONSTRAINT [FK_tblEvento_tblTipoEvento]
GO
ALTER TABLE [dbo].[tblProducto]  WITH CHECK ADD  CONSTRAINT [FK_tblProducto_tblCategoriaProducto] FOREIGN KEY([IDCategoria])
REFERENCES [dbo].[tblCategoriaProducto] ([IDCategoriaProducto])
GO
ALTER TABLE [dbo].[tblProducto] CHECK CONSTRAINT [FK_tblProducto_tblCategoriaProducto]
GO
ALTER TABLE [dbo].[tblProveedor]  WITH CHECK ADD  CONSTRAINT [FK_tblProveedor_tblTipoProveedor] FOREIGN KEY([IDTipoProveedor])
REFERENCES [dbo].[tblTipoProveedor] ([IDTipoProveedor])
GO
ALTER TABLE [dbo].[tblProveedor] CHECK CONSTRAINT [FK_tblProveedor_tblTipoProveedor]
GO
ALTER TABLE [dbo].[tblProveedorxEvento]  WITH CHECK ADD  CONSTRAINT [FK_tblProveedorxEvento_tblEvento1] FOREIGN KEY([IDEvento])
REFERENCES [dbo].[tblEvento] ([ID])
GO
ALTER TABLE [dbo].[tblProveedorxEvento] CHECK CONSTRAINT [FK_tblProveedorxEvento_tblEvento1]
GO
ALTER TABLE [dbo].[tblProveedorxEvento]  WITH CHECK ADD  CONSTRAINT [FK_tblProveedorxEvento_tblProveedor] FOREIGN KEY([IDProveedor])
REFERENCES [dbo].[tblProveedor] ([ID])
GO
ALTER TABLE [dbo].[tblProveedorxEvento] CHECK CONSTRAINT [FK_tblProveedorxEvento_tblProveedor]
GO
ALTER TABLE [dbo].[tblVentaProveedor]  WITH CHECK ADD  CONSTRAINT [FK_tblVentaProveedor_tblProducto] FOREIGN KEY([IDProducto])
REFERENCES [dbo].[tblProducto] ([ID])
GO
ALTER TABLE [dbo].[tblVentaProveedor] CHECK CONSTRAINT [FK_tblVentaProveedor_tblProducto]
GO
ALTER TABLE [dbo].[tblVentaProveedor]  WITH CHECK ADD  CONSTRAINT [FK_tblVentaProveedor_tblProveedor] FOREIGN KEY([IDProveedor])
REFERENCES [dbo].[tblProveedor] ([ID])
GO
ALTER TABLE [dbo].[tblVentaProveedor] CHECK CONSTRAINT [FK_tblVentaProveedor_tblProveedor]
GO
USE [master]
GO
ALTER DATABASE [DBEventos] SET  READ_WRITE 
GO
