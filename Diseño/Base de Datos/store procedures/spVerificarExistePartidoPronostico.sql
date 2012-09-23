CREATE PROCEDURE spVerificarExistePartidoPronostico
(
		@codPartido int
)
AS
BEGIN
SELECT	COUNT(*) AS 'CANTIDAD'
FROM	PartidoPronosticado PP
WHERE	PP.idPartido = @codPartido and PP.c_Resultado = '?'
END