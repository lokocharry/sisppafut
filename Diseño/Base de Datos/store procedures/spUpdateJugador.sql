/* DE UN JUGADOR DE FÚTBOL, SOLO NOS INTERESA CAMBIAR LA ALTURA Y PESO 
(SON VARIABLES DE LA RED NEURONAL)*/
CREATE PROCEDURE spUpdateJugador
(
		@CodJugador int,
		@Altura numeric(5,2),
		@Peso numeric(5,2)
)
AS
BEGIN
UPDATE [SISPPAFUT].[dbo].[Jugador]
   SET [Altura] = @Altura
      ,[Peso] = @Peso
 WHERE CodJugador = @CodJugador
END
GO