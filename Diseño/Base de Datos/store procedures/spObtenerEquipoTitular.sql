USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spObtenerEquipoTitular]    Script Date: 09/14/2012 14:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spObtenerEquipoTitular]
(
		@codEquipo int
)
AS
begin
((SELECT	top(1)*
 FROM	Jugador J JOIN  (SELECT	COUNT(*) AS 'qPartidos',T.CodJugador
						 FROM	Jugador T, JugadorPartido JOIN Partido ON (JugadorPartido.CodPartido = Partido.CodPartido) JOIN Liga ON (Liga.CodLiga = Partido.CodLiga)
						 WHERE	JugadorPartido.Estado = 1	AND
								JugadorPartido.CodJugador = T.CodJugador
						 GROUP BY T.CodJugador) AS G ON j.CodJugador = G.CodJugador JOIN JugadorEquipo ON J.CodJugador = JugadorEquipo.CodJugador
 WHERE	J.Posicion = 'Portero'	AND
		JugadorEquipo.CodEquipo = @codEquipo)
UNION
(SELECT	top(4)*
 FROM	Jugador J JOIN  (SELECT	COUNT(*) AS 'qPartidos',T.CodJugador
						 FROM	Jugador T, JugadorPartido JOIN Partido ON (JugadorPartido.CodPartido = Partido.CodPartido) JOIN Liga ON (Liga.CodLiga = Partido.CodLiga)
						 WHERE	JugadorPartido.Estado = 1	AND
								JugadorPartido.CodJugador = T.CodJugador
						 GROUP BY T.CodJugador) AS G ON j.CodJugador = G.CodJugador JOIN JugadorEquipo ON J.CodJugador = JugadorEquipo.CodJugador
 WHERE	J.Posicion = 'Defensa'	AND
		JugadorEquipo.CodEquipo = @codEquipo)
UNION
(SELECT	top(4)*
 FROM	Jugador J JOIN  (SELECT	COUNT(*) AS 'qPartidos',T.CodJugador
						 FROM	Jugador T, JugadorPartido JOIN Partido ON (JugadorPartido.CodPartido = Partido.CodPartido) JOIN Liga ON (Liga.CodLiga = Partido.CodLiga)
						 WHERE	JugadorPartido.Estado = 1	AND
								JugadorPartido.CodJugador = T.CodJugador
						 GROUP BY T.CodJugador) AS G ON j.CodJugador = G.CodJugador JOIN JugadorEquipo ON J.CodJugador = JugadorEquipo.CodJugador
 WHERE	J.Posicion = 'Centrocampista'	AND
		JugadorEquipo.CodEquipo = @codEquipo)
UNION
(SELECT	top(2)*
 FROM	Jugador J JOIN  (SELECT	COUNT(*) AS 'qPartidos',T.CodJugador
						 FROM	Jugador T, JugadorPartido JOIN Partido ON (JugadorPartido.CodPartido = Partido.CodPartido) JOIN Liga ON (Liga.CodLiga = Partido.CodLiga)
						 WHERE	JugadorPartido.Estado = 1	AND
								JugadorPartido.CodJugador = T.CodJugador
						 GROUP BY T.CodJugador) AS G ON j.CodJugador = G.CodJugador JOIN JugadorEquipo ON J.CodJugador = JugadorEquipo.CodJugador
 WHERE	J.Posicion = 'Delantero'	AND
		JugadorEquipo.CodEquipo = @codEquipo))
end
GO


