CREATE DATABASE [vendimia]
GO
USE [vendimia]
GO

/****** Object:  Table [dbo].[clientes]    Script Date: 22/01/2017 05:24:46 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[clientes](
	[clave_cliente] [int] NULL,
	[nom_cliente] [varchar](50) NULL,
	[rfc_cliente] [varchar](30) NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[articulos]    Script Date: 22/01/2017 05:24:05 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[articulos](
	[clave_articulo] [int] NULL,
	[desc_articulo] [varchar](100) NULL,
	[modelo] [varchar](20) NULL,
	[precio] [money] NULL,
	[existencia] [int] NULL
) ON [PRIMARY]

GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[configuracion](
	[tasa] [float] NULL,
	[enganche] [float] NULL,
	[plazo] [int] NULL
) ON [PRIMARY]

GO
insert into configuracion values (0.0,0,0)
Go
/****** Object:  Table [dbo].[ventas]    Script Date: 22/01/2017 05:25:50 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ventas](
	[folio_venta] [int] NULL,
	[clave_cliente] [int] NULL,
	[nombre] [varchar](50) NULL,
	[total] [float] NULL,
	[fecha] [varchar](10) NULL,
	[plazo] [int] NULL
) ON [PRIMARY]

GO

