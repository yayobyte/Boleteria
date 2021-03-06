USE [master]
GO
/****** Object:  Database [DBEventos]    Script Date: 21/11/2015 2:17:01 p. m. ******/
CREATE DATABASE [DBEventos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBEventos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DBEventos.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DBEventos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DBEventos_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
ALTER DATABASE [DBEventos] SET  ENABLE_BROKER 
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
ALTER DATABASE [DBEventos] SET RECOVERY FULL 
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
EXEC sys.sp_db_vardecimal_storage_format N'DBEventos', N'ON'
GO
USE [DBEventos]
GO
/****** Object:  Table [dbo].[tblArtista]    Script Date: 21/11/2015 2:17:01 p. m. ******/
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
/****** Object:  Table [dbo].[tblBoleto]    Script Date: 21/11/2015 2:17:01 p. m. ******/
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
/****** Object:  Table [dbo].[tblCategoriaProducto]    Script Date: 21/11/2015 2:17:01 p. m. ******/
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
/****** Object:  Table [dbo].[tblCliente]    Script Date: 21/11/2015 2:17:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCliente](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](32) NOT NULL,
	[Telefono] [int] NOT NULL,
	[Correo] [varchar](32) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblEstablecimiento]    Script Date: 21/11/2015 2:17:01 p. m. ******/
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
	[IDCiudad] [int] NOT NULL,
 CONSTRAINT [PK_tblEstablecimiento] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblEvento]    Script Date: 21/11/2015 2:17:01 p. m. ******/
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
	[IDProveedorxEvento] [int] NOT NULL,
 CONSTRAINT [PK_tblEvento] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblProducto]    Script Date: 21/11/2015 2:17:01 p. m. ******/
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
/****** Object:  Table [dbo].[tblProveedor]    Script Date: 21/11/2015 2:17:01 p. m. ******/
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
/****** Object:  Table [dbo].[tblProveedorxEvento]    Script Date: 21/11/2015 2:17:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProveedorxEvento](
	[IDProveedorxEvento] [int] IDENTITY(1,1) NOT NULL,
	[IDPoveedor] [int] NOT NULL,
 CONSTRAINT [PK_tblProveedorxEvento_1] PRIMARY KEY CLUSTERED 
(
	[IDProveedorxEvento] ASC,
	[IDPoveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblTipoArtista]    Script Date: 21/11/2015 2:17:01 p. m. ******/
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
/****** Object:  Table [dbo].[tblTipoBoleto]    Script Date: 21/11/2015 2:17:01 p. m. ******/
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
/****** Object:  Table [dbo].[tblTipoEvento]    Script Date: 21/11/2015 2:17:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblTipoEvento](
	[ID] [int] NOT NULL,
	[NombreTipoEvento] [varchar](32) NOT NULL,
 CONSTRAINT [PK_tblTipoEvento] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblTipoProveedor]    Script Date: 21/11/2015 2:17:01 p. m. ******/
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
/****** Object:  Table [dbo].[tblVentaProveedor]    Script Date: 21/11/2015 2:17:01 p. m. ******/
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
/****** Object:  Table [dbo].[tlbNacionalidad]    Script Date: 21/11/2015 2:17:01 p. m. ******/
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
ALTER TABLE [dbo].[tblBoleto]  WITH CHECK ADD  CONSTRAINT [FK_tblBoleto_tblCliente] FOREIGN KEY([IDCLiente])
REFERENCES [dbo].[tblCliente] ([ID])
GO
ALTER TABLE [dbo].[tblBoleto] CHECK CONSTRAINT [FK_tblBoleto_tblCliente]
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
ALTER TABLE [dbo].[tblProveedorxEvento]  WITH CHECK ADD  CONSTRAINT [FK_tblProveedorxEvento_tblEvento] FOREIGN KEY([IDProveedorxEvento])
REFERENCES [dbo].[tblEvento] ([ID])
GO
ALTER TABLE [dbo].[tblProveedorxEvento] CHECK CONSTRAINT [FK_tblProveedorxEvento_tblEvento]
GO
ALTER TABLE [dbo].[tblProveedorxEvento]  WITH CHECK ADD  CONSTRAINT [FK_tblProveedorxEvento_tblProveedor] FOREIGN KEY([IDPoveedor])
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
