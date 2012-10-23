USE [SEGURIDAD]
GO

/****** Object:  StoredProcedure [dbo].[spCreateUsuario]    Script Date: 10/22/2012 23:11:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spCreateUsuario]
(
			@nombreUsuario varchar(40)           
           ,@nombre varchar(50)
           ,@apellidoPaterno varchar(50)
           ,@apellidoMaterno varchar(50)           
           ,@fechaNac date
           ,@contrasenia varchar(15)
)
AS
BEGIN
INSERT INTO [SEGURIDAD].[dbo].[Usuario]
           ([nombreUsuario]           
           ,[nombre]
           ,[apellidoPaterno]
           ,[apellidoMaterno]
           ,[fechaNac]
           ,[contrasenia])           
     VALUES
           (@nombreUsuario           
           ,@nombre
           ,@apellidoPaterno
           ,@apellidoMaterno
           ,@fechaNac
           ,@contrasenia)    
    declare @codUserNew int
    set @codUserNew = @@IDENTITY
    insert into [SISPPAFUT].[dbo].[UsuarioReferencia]
				(idUsuario,nombreUsuario)values(@codUserNew,@nombreUsuario)
    return @codUserNew
END

GO


