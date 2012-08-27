CREATE PROCEDURE spCreateTransferenciaJugadorNuevoEquipo
	@CodEquipoNuevo int, @CodJugador int
AS
BEGIN

	SET NOCOUNT ON;
	
	DELETE JugadorEquipo
	WHERE CodJugador = @CodJugador
	
	INSERT INTO JugadorEquipo
	(CodEquipo, CodJugador)
	VALUES
	(@CodEquipoNuevo, @CodJugador)
	
	DECLARE @Liga int
	
	SET @Liga = (SELECT CodLiga FROM LigaEquipo WHERE CodEquipo = @CodEquipoNuevo)
	
	INSERT INTO HistorialJugadorEquipo
	(CodJugador, CodEquipo, CodLiga)
	VALUES 
	(@CodJugador,@CodEquipoNuevo,@Liga)

END
GO
