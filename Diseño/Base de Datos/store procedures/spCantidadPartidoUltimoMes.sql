CREATE PROCEDURE spCantidadPartidoUltimoMes
(
		@codEquipo int,
		@Fecha date
)
AS
BEGIN
SELECT	COUNT(*) AS 'NUMERO PARTIDOS'
FROM	Partido P
WHERE	(DATEDIFF(day,P.Fecha,@Fecha))>0	AND
		(DATEDIFF(day,P.Fecha,@Fecha))<31	AND		
		(P.CodEquipoL = @codEquipo 
		OR P.CodEquipoV = @codEquipo)
END
