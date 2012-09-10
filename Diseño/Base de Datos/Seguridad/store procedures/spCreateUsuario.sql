USE [SEGURIDAD]
GO

/****** Object:  StoredProcedure [dbo].[spCreateUsuario]    Script Date: 09/10/2012 12:41:47 ******/
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
    RETURN @@IDENTITY
END

GO


