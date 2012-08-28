CREATE PROCEDURE spObtenerPromedioEdadEquipoTitular
(
		@codEquipo int,
		@codLiga int
)
AS
BEGIN
SELECT	AVG(DATEDIFF(YEAR,X.FechaNacimiento,GETDATE())*1.00) AS 'PROMEDIO'
FROM	Jugador X JOIN
((SELECT	top(1) J.CodJugador, J.Nombres, J.Apellidos, J.FechaNacimiento
 FROM	Jugador J JOIN  (SELECT	COUNT(JugadorPartido.CodJugador) AS 'qPartidos', JugadorPartido.CodJugador
						 FROM	Jugador T, JugadorPartido JOIN Partido ON (JugadorPartido.CodPartido = Partido.CodPartido) JOIN Liga ON (Liga.CodLiga = Partido.CodLiga)
						 WHERE	JugadorPartido.Estado = 1	AND
								JugadorPartido.CodJugador = T.CodJugador AND
								Liga.CodLiga = @codLiga
						 GROUP BY JugadorPartido.CodJugador) AS G ON j.CodJugador = G.CodJugador JOIN JugadorEquipo ON J.CodJugador = JugadorEquipo.CodJugador
 WHERE	J.Posicion = 'Portero'	AND
		JugadorEquipo.CodEquipo = @codEquipo)
UNION
(SELECT	top(4) J.CodJugador, J.Nombres, J.Apellidos, J.FechaNacimiento
 FROM	Jugador J JOIN  (SELECT	COUNT(JugadorPartido.CodJugador) AS 'qPartidos', JugadorPartido.CodJugador
						 FROM	Jugador T, JugadorPartido JOIN Partido ON (JugadorPartido.CodPartido = Partido.CodPartido) JOIN Liga ON (Liga.CodLiga = Partido.CodLiga)
						 WHERE	JugadorPartido.Estado = 1	AND
								JugadorPartido.CodJugador = T.CodJugador AND
								Liga.CodLiga = @codLiga
						 GROUP BY JugadorPartido.CodJugador) AS G ON j.CodJugador = G.CodJugador JOIN JugadorEquipo ON J.CodJugador = JugadorEquipo.CodJugador
 WHERE	J.Posicion = 'Defensa'	AND
		JugadorEquipo.CodEquipo = @codEquipo)
UNION
(SELECT	top(4) J.CodJugador, J.Nombres, J.Apellidos, J.FechaNacimiento
 FROM	Jugador J JOIN  (SELECT	COUNT(JugadorPartido.CodJugador) AS 'qPartidos', JugadorPartido.CodJugador
						 FROM	Jugador T, JugadorPartido JOIN Partido ON (JugadorPartido.CodPartido = Partido.CodPartido) JOIN Liga ON (Liga.CodLiga = Partido.CodLiga)
						 WHERE	JugadorPartido.Estado = 1	AND
								JugadorPartido.CodJugador = T.CodJugador AND
								Liga.CodLiga = @codLiga
						 GROUP BY JugadorPartido.CodJugador) AS G ON j.CodJugador = G.CodJugador JOIN JugadorEquipo ON J.CodJugador = JugadorEquipo.CodJugador
 WHERE	J.Posicion = 'Centrocampista'	AND
		JugadorEquipo.CodEquipo = @codEquipo)
UNION
(SELECT	top(2) J.CodJugador, J.Nombres, J.Apellidos, J.FechaNacimiento
 FROM	Jugador J JOIN  (SELECT	COUNT(JugadorPartido.CodJugador) AS 'qPartidos', JugadorPartido.CodJugador
						 FROM	Jugador T, JugadorPartido JOIN Partido ON (JugadorPartido.CodPartido = Partido.CodPartido) JOIN Liga ON (Liga.CodLiga = Partido.CodLiga)
						 WHERE	JugadorPartido.Estado = 1	AND
								JugadorPartido.CodJugador = T.CodJugador AND
								Liga.CodLiga = @codLiga
						 GROUP BY JugadorPartido.CodJugador) AS G ON j.CodJugador = G.CodJugador JOIN JugadorEquipo ON J.CodJugador = JugadorEquipo.CodJugador
 WHERE	J.Posicion = 'Delantero'	AND
		JugadorEquipo.CodEquipo = @codEquipo)) AS J ON J.CodJugador = X.CodJugador
		
end