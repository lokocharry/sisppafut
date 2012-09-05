CREATE PROCEDURE spListarPronosticosParaApostar
AS
BEGIN
SELECT	p.CodPronostico, p.CodPartido, l.CodLiga,
		e1.Nombre AS 'Equipo Local', e2.Nombre AS 'Equipo Visita', 
		p.Pronostico, pp.fecha AS 'Fecha'
FROM	Equipo e1, Equipo e2, Pronostico p join Partido pp on p.CodPartido = pp.CodPartido join Liga l on pp.CodLiga = l.CodLiga
WHERE	e1.CodEquipo = pp.CodEquipoL and
		e2.CodEquipo = pp.CodEquipoV
END