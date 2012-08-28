-- 0: AMARILLA ; 1: ROJA
CREATE PROCEDURE spCantidadRojasUltimoPartido
(
		@codPartido int,
		@codEquipo int,
		@codLiga int
)
AS
BEGIN
SELECT		COUNT(AP.Tipo) AS 'ROJAS'
FROM		AmonestacionPartido AP JOIN JugadorEquipo JE ON AP.CodJugador = JE.CodJugador 
			JOIN LigaEquipo LE ON JE.CodEquipo = LE.CodEquipo 
			JOIN Equipo E ON LE.CodEquipo = E.CodEquipo 
			JOIN Liga L ON LE.CodLiga = L.CodLiga
WHERE		AP.CodPartido	=	@codPartido	AND
			AP.Tipo			=	1	AND
			L.CodLiga		=	@codLiga	AND
			E.CodEquipo		=	@codEquipo
END