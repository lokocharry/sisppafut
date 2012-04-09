CREATE PROCEDURE spReadEquipo
(
	@Nombre varchar(20)
)
AS
BEGIN
	SELECT e.CodEquipo, e.Nombre, e.Ciudad
	FROM Equipo e
	WHERE e.Nombre = @Nombre
END