CREATE PROCEDURE spListarPartidosDesarrollados
AS
BEGIN
SELECT DISTINCT	P.CodPartido, PA.Nombre, L.Nombre, EA.Nombre, EB.Nombre, P.Fecha
FROM			Partido P JOIN Liga L ON (P.CodLiga = L.CodLiga) JOIN Equipo EA ON (P.CodEquipoL = EA.CodEquipo) JOIN Equipo EB ON (P.CodEquipoV = EB.CodEquipo) JOIN Estadio ES ON (P.CodEstadio = ES.CodEstadio) JOIN Competicion CO ON (CO.CodCompeticion = L.CodCompeticion) JOIN Pais PA ON (PA.CodPais = CO.CodPais)
WHERE			GolesLocal >= 0 OR GolesVisita >= 0
END
