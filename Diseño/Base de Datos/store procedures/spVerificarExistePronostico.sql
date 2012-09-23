CREATE PROCEDURE spVerificarExistePronostico
(
		@codPartido int
)
AS
BEGIN
SELECT	COUNT(*) AS 'CANTIDAD'
FROM	Pronostico P
WHERE	P.CodPartido = @codPartido
END