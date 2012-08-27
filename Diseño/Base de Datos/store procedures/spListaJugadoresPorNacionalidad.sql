CREATE PROCEDURE spListaJugadoresPorNacionalidad
	@Nacionalidad varchar(20)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT CodJugador, Nombres, Apellidos, Nacionalidad, FechaNacimiento, Posicion, Altura, peso
	FROM Jugador
	WHERE Nacionalidad = @Nacionalidad
END
GO
