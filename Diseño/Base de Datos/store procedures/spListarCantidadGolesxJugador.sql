USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spListarCantidadGolesxJugador]    Script Date: 06/09/2012 00:42:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Martinez, Renzo
-- Create date: 09/06/2012
-- Description:	Este Procedure devuelve la lista de jugadores con la cantidad de goles que han marcado dentro de una liga especifica.
-- =============================================
CREATE PROCEDURE [dbo].[spListarCantidadGolesxJugador]
(
	@CodEquipo int,
	@CodLiga int 
)

AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT	gp.CodJugador, COUNT(gp.CodGol) as 'Cantidad' 

	FROM	GolPartido gp
			JOIN (Partido p JOIN Liga l ON p.CodLiga = l.CodLiga) ON gp.CodPartido = p.CodPartido
			JOIN (Equipo e JOIN JugadorEquipo je ON e.CodEquipo = je.CodEquipo) ON gp.CodJugador = je.CodJugador
			
	WHERE	e.CodEquipo = 12 AND 
			l.CodLiga = 4
		
	GROUP BY gp.CodJugador
			
END
GO

