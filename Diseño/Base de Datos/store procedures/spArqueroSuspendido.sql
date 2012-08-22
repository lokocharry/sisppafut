CREATE PROCEDURE [dbo].[spArqueroSuspendido]
(
	@CodEquipo int,
	@CodLiga int
)
AS
BEGIN
	declare @CodJugador int;
	set @CodJugador = (SELECT	ju.CodJugador as '@CodJugador'
	FROM	Jugador ju join 
	(SELECT	DISTINCT top(1)j.CodJugador, --, j.Nombres, j.Apellidos, j.Posicion,
			(SELECT	COUNT(*)-- AS 'NUMERO'
			 FROM	JugadorPartido as jp
					JOIN (Partido partido JOIN Liga liga ON partido.CodLiga = liga.CodLiga)
					ON jp.CodPartido = partido.CodPartido
			 WHERE	jp.CodJugador = j.CodJugador AND liga.CodLiga = @CodLiga
			)AS 'QPartidosJugados'
	FROM	Equipo eq, JugadorPartido jp, JugadorEquipo je, Jugador j
	WHERE	eq.CodEquipo = @CodEquipo	and je.CodEquipo = @CodEquipo	and
			je.CodJugador = j.CodJugador	and j.Posicion = 'Portero'	and 
			jp.CodJugador = j.CodJugador) AS k on ju.CodJugador = k.CodJugador)
	EXECUTE spReadEstadoSuspension @CodJugador	
END