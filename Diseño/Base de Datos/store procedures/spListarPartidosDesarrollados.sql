USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spListarPartidosDesarrollados]    Script Date: 09/22/2012 20:39:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spListarPartidosDesarrollados]
AS
BEGIN
SELECT DISTINCT	P.CodPartido, PA.Nombre, L.Nombre, EA.Nombre, EB.Nombre, P.Fecha
FROM			Partido P JOIN Liga L ON (P.CodLiga = L.CodLiga) 
						  JOIN Equipo EA ON (P.CodEquipoL = EA.CodEquipo) 
						  JOIN Equipo EB ON (P.CodEquipoV = EB.CodEquipo) 
						  JOIN Estadio ES ON (P.CodEstadio = ES.CodEstadio) 
						  JOIN Competicion CO ON (CO.CodCompeticion = L.CodCompeticion) 
						  JOIN Pais PA ON (PA.CodPais = CO.CodPais)						  
WHERE			(P.GolesLocal >= 0 OR P.GolesVisita >= 0) AND
				((SELECT PP.c_Resultado FROM PartidoPronosticado PP WHERE PP.idPartido = P.CodPartido) = '?' OR
				 (SELECT COUNT(*) FROM PartidoPronosticado PP WHERE PP.idPartido = P.CodPartido) = 0)
END

GO


