CREATE PROCEDURE spListaNacionalidades
AS
BEGIN
	SET NOCOUNT ON;

	SELECT distinct Nacionalidad
	FROM Jugador

END
GO
