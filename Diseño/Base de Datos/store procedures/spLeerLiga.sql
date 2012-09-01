CREATE PROCEDURE spLeerLiga
(
		@codLiga int
)
AS
BEGIN
SELECT	*
FROM	Liga
WHERE	Liga.CodLiga = @codLiga
END