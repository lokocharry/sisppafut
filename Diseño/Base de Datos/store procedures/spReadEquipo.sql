CREATE PROCEDURE [dbo].[spReadEquipo]
(
	@Nombre varchar(20)
)
AS
BEGIN
	SELECT 
	e.CodEquipo,
	e.CodPais,
	e.Nombre,
	e.AnioFundacion,
	e.Ciudad,
	e.CodEstadioPrincipal,
	isNull(e.CodEstadioAlterno,0) as 'CodEstadioAlterno'
	FROM Equipo e
	WHERE e.Nombre = @Nombre
END