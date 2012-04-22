USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spCreateJugador]    Script Date: 04/21/2012 18:36:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spCreateJugador]
(
			@Nombres varchar(20)
           ,@Apellidos varchar(20)
           ,@Nacionalidad varchar(20)
           ,@FechaNacimiento date
           ,@Posicion varchar(15)
           ,@Altura numeric(5,2)
           ,@Peso numeric(5,2)
)
AS
BEGIN
INSERT INTO [SISPPAFUT].[dbo].[Jugador]
           ([Nombres]
           ,[Apellidos]
           ,[Nacionalidad]
           ,[FechaNacimiento]
           ,[Posicion]
           ,[Altura]
           ,[Peso])
     VALUES
           (@Nombres
           ,@Apellidos
           ,@Nacionalidad
           ,@FechaNacimiento
           ,@Posicion
           ,@Altura
           ,@Peso)
     RETURN @@IDENTITY
END

GO


