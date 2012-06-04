USE [SISPPAFUT]
GO
/****** Object:  StoredProcedure [dbo].[spListaPartidosSinJugar]    Script Date: 06/04/2012 18:22:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Se lista aquellos partidos que ya debiero haberse jugado, 
pero que no se han guardado datos en la tabla de 'JugadorPartido', 
dato mínimo para verificar que un partido se ha efectuado
*/
ALTER PROCEDURE [dbo].[spListaPartidosSinJugar]
AS
BEGIN
	SELECT	DISTINCT f1.CodPartido, p1.Nombre, l1.Nombre, e1.Nombre, e2.Nombre , f1.Fecha
	FROM	Partido f1, Equipo e1, Equipo e2, Liga l1,
			Liga l2 join (Competicion c2 join Pais p1 on c2.CodPais = p1.CodPais) on (l2.CodCompeticion = c2.CodCompeticion)
	WHERE	f1.CodEquipoL = e1.CodEquipo and
			f1.CodEquipoV = e2.CodEquipo and
			l1.CodLiga = f1.CodLiga and
			DATEDIFF(DAY, f1.Fecha, GETDATE())>0 AND
			(	SELECT	COUNT(*)
				FROM	JugadorPartido JP
				WHERE	JP.CodPartido = f1.CodPartido
			)=0
END
