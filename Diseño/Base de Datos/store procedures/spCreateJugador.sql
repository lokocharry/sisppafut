CREATE PROCEDURE spCreateJugador
(
			@CodEquipo int
           ,@Nombres varchar(20)
           ,@Apellidos varchar(20)
           ,@Nacionalidad varchar(20)
           ,@FechaNacimiento date
           ,@Posicion varchar(15)
           ,@Altura decimal(3,2)
           ,@Peso decimal(3,2)
)
AS
BEGIN
INSERT INTO [SISPPAFUT].[dbo].[Jugador]
           ([CodEquipo]
           ,[Nombres]
           ,[Apellidos]
           ,[Nacionalidad]
           ,[FechaNacimiento]
           ,[Posicion]
           ,[Altura]
           ,[Peso])
     VALUES
           (@CodEquipo
           ,@Nombres
           ,@Apellidos
           ,@Nacionalidad
           ,@FechaNacimiento
           ,@Posicion
           ,@Altura
           ,@Peso)
     RETURN @@IDENTITY
END
GO