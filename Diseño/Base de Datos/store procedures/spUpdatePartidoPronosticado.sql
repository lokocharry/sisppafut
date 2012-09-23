CREATE PROCEDURE spUpdatePartidoPronosticado
(
		@idPartido int,
		@c_Resultado varchar(5)
)
AS
BEGIN
UPDATE	PartidoPronosticado
SET		c_Resultado = @c_Resultado
WHERE	idPartido = @idPartido
END