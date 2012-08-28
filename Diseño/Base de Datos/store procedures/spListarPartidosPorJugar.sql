CREATE PROCEDURE spListarPartidosPorJugar
	
AS
BEGIN
	SET NOCOUNT ON;

    SELECT L.Nombre, L.Temporada, EA.Nombre, EB.Nombre, ES.Nombre, P.Fecha
    FROM Partido P JOIN Liga L ON (P.CodLiga = L.CodLiga) JOIN Equipo EA ON (P.CodEquipoL = EA.CodEquipo) JOIN Equipo EB ON (P.CodEquipoV = EB.CodEquipo) JOIN Estadio ES ON (P.CodEstadio = ES.CodEstadio)
    WHERE GolesLocal is NULL OR GolesVisita is NULL
END
GO
