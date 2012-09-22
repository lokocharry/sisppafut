USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spGoleadorSuspendido]    Script Date: 09/21/2012 23:52:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGoleadorSuspendido]
(
	@CodEquipo int,
	@CodLiga int
)
AS
BEGIN
	declare @CodJugador int;
	set @CodJugador =	(SELECT	ju.CodJugador as '@CodJugador'
						 FROM	Jugador ju join (
								SELECT	DISTINCT top(1)j.CodJugador, j.Nombres, j.Apellidos, j.Posicion,
										(SELECT	COUNT(gp.CodGol) as 'Cantidad'
										 FROM	GolPartido gp
												JOIN (Partido p JOIN Liga l ON p.CodLiga = l.CodLiga) ON gp.CodPartido = p.CodPartido
										 WHERE	gp.CodJugador = j.CodJugador and--@CodJugador AND 
												l.CodLiga = @CodLiga
										 GROUP BY gp.CodJugador) AS 'QGolesAnotados'
								FROM	Equipo eq, GolPartido gp, JugadorEquipo je, Jugador j
								WHERE	eq.CodEquipo = @CodEquipo	
										and je.CodEquipo = @CodEquipo	
										and gp.CodJugador = j.CodJugador
								ORDER BY 5 DESC) AS k on ju.CodJugador = k.CodJugador)
	EXECUTE spReadEstadoSuspension @CodJugador, @CodLiga
END

GO


