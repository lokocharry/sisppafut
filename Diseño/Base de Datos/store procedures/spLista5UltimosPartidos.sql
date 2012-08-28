USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spLista5UltimosPartidos]    Script Date: 08/28/2012 08:51:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/*
Se lista aquellos partidos que ya debiero haberse jugado, 
pero que no se han guardado datos en la tabla de 'JugadorPartido', 
dato mínimo para verificar que un partido se ha efectuado
*/
CREATE PROCEDURE [dbo].[spLista5UltimosPartidos]
(
	@CodEquipo int,
	@CodLiga int
)
AS
BEGIN
	SELECT	TOP 5
			equipo_local.Nombre, 
			equipo_visita.Nombre, 
			partido.GolesLocal, 
			partido.GolesVisita, 
			partido.Fecha,
			liga.Nombre,
			partido.CodPartido
			
	FROM	Partido as partido
			JOIN Liga as liga ON partido.CodLiga = liga.CodLiga
			JOIN Equipo as equipo_local ON partido.CodEquipoL = equipo_local.CodEquipo
			JOIN Equipo as equipo_visita ON partido.CodEquipoV = equipo_visita.CodEquipo
					
	WHERE	(partido.CodEquipoL = @CodEquipo OR partido.CodEquipoV = @CodEquipo) AND
			partido.CodLiga = @CodLiga AND
			partido.GolesLocal >= 0 AND
			partido.GolesVisita >= 0
			
	ORDER BY partido.Fecha DESC		
END



GO


