USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spAcumulacionAmonestacionesJugador]    Script Date: 10/12/2012 14:25:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spAcumulacionAmonestacionesJugador]
(
		@codEquipo	int,
		@codLiga	int,
		@Fecha		datetime
)
AS
BEGIN
SELECT		COUNT(*) AS 'qAmonestaciones', AP.CodJugador
FROM		AmonestacionPartido AP JOIN Jugador J ON AP.CodJugador = J.CodJugador 
								   JOIN JugadorEquipo JE ON J.CodJugador = JE.CodJugador 
								   JOIN LigaEquipo LE ON JE.CodEquipo = LE.CodEquipo
								   JOIN Partido P ON AP.CodPartido = P.CodPartido
WHERE		DATEDIFF(day,P.Fecha,@Fecha)>0 AND
			JE.CodEquipo	= @codEquipo	AND
			LE.CodLiga		= @codLiga		AND
			AP.Tipo			= 0				AND
			P.CodLiga		= @codLiga
GROUP BY	AP.CodJugador
END


GO


