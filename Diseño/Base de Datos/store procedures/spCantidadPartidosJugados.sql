USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spCantidadPartidosJugados]    Script Date: 06/09/2012 00:42:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/*
Se muestra las cantidad de partidos que un jugador ha jugado en un aliga especifica
*/

CREATE PROCEDURE [dbo].[spCantidadPartidosJugados]
(
	@CodJugador int,
	@CodLiga int
)
AS
BEGIN
	
	SELECT	COUNT(*) AS 'NUMERO'

	FROM
		JugadorPartido as jp
		JOIN (Partido partido JOIN Liga liga ON partido.CodLiga = liga.CodLiga)
		ON jp.CodPartido = partido.CodPartido
	
	WHERE
		jp.CodJugador = @CodJugador AND liga.CodLiga = @CodLiga	
END

GO

