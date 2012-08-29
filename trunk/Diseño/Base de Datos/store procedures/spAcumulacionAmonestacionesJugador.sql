USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spAcumulacionAmonestacionesJugador]    Script Date: 08/28/2012 23:21:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spAcumulacionAmonestacionesJugador]
(
		@codEquipo	int,
		@codLiga	int
)
AS
BEGIN
SELECT		COUNT(*) AS 'qAmonestaciones', AP.CodJugador
FROM		AmonestacionPartido AP JOIN Jugador J ON AP.CodJugador = J.CodJugador JOIN JugadorEquipo JE ON J.CodJugador = JE.CodJugador JOIN LigaEquipo LE ON JE.CodEquipo = LE.CodEquipo
WHERE		JE.CodEquipo	= @codEquipo	AND
			LE.CodLiga		= @codLiga		AND
			AP.Tipo			= 0
GROUP BY	AP.CodJugador
END
GO


