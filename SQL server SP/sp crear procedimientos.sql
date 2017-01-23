USE [vendimia]
GO

/****** Object:  StoredProcedure [dbo].[consulta_cliente]    Script Date: 22/01/2017 05:38:06 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[consulta_cliente]
  @clavecliente int
  AS
  select * from clientes where clave_cliente = @clavecliente 
GO


/****** Object:  StoredProcedure [dbo].[proc_agregaracliente]    Script Date: 22/01/2017 05:38:33 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[proc_agregaracliente]
  @nomcliente varchar(50),
  @clavecleinte int,
  @rfccliente varchar(20)
  As
  insert into clientes values (@clavecleinte,@nomcliente,@rfccliente) 
 
GO


/****** Object:  StoredProcedure [dbo].[proc_agregararti]    Script Date: 22/01/2017 05:39:02 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[proc_agregararti]
  @clavearticulo int,
  @descarticulo varchar(100),
  @modeloarticulo varchar(20),
  @precioarticulo money,
  @existenciaarticulo int
  As
  insert into articulos values(@clavearticulo,@descarticulo,@modeloarticulo,@precioarticulo,@existenciaarticulo)

GO
/****** Object:  StoredProcedure [dbo].[proc_configuracion]    Script Date: 22/01/2017 05:39:20 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[proc_configuracion]
@tasa float,
@enganche float,
@plazo int
As
UPDATE configuracion set tasa=@tasa, enganche = @enganche, plazo = @plazo 


GO


/****** Object:  StoredProcedure [dbo].[registro_venta]    Script Date: 22/01/2017 05:39:38 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[registro_venta]
   @folio int,
   @clave int,
   @nombre varchar(50),
   @total float,
   @fecha varchar(10),
   @plazo int
   AS 
   insert into ventas values ( @folio,@clave,@nombre,@total,@fecha,@plazo)
GO


/****** Object:  StoredProcedure [dbo].[actualizar_articulos]    Script Date: 22/01/2017 05:36:30 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[actualizar_articulos]
  @clave int, 
  @articulo varchar(50),
  @modelo varchar(20),
  @precio float,
  @existencia int 
  As 
  update articulos set desc_articulo = @articulo, modelo = @modelo, precio = @precio, existencia = @existencia where clave_articulo = @clave  

GO


/****** Object:  StoredProcedure [dbo].[actualizar_cliente]    Script Date: 22/01/2017 05:37:08 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[actualizar_cliente]
  @clave int ,
  @nombre varchar (50),
  @rfc varchar (20)
  As
  update clientes set nom_cliente = @nombre, rfc_cliente = @rfc where clave_cliente = @clave
GO


/****** Object:  StoredProcedure [dbo].[actualizar_existencia]    Script Date: 22/01/2017 05:37:27 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[actualizar_existencia] 
  @cantidad int,
  @articulo varchar(50)
  As
  update articulos set existencia = existencia - @cantidad  where desc_articulo = @articulo 
GO


/****** Object:  StoredProcedure [dbo].[consulta_cliente]    Script Date: 22/01/2017 05:38:06 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO