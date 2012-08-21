USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spPartidosPronosticados]    Script Date: 08/20/2012 11:15:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spPartidosPronosticados]
AS
BEGIN
	SELECT	DISTINCT pro.CodPartido, p1.Nombre, l1.Nombre, e1.Nombre, e2.Nombre, f1.Fecha
	FROM	Equipo e1, Equipo e2, Liga l1, Pais p1, Competicion c2,
			Pronostico pro, PartidoPronosticado RPPro,
			Liga l2 join Partido f1 on l2.CodLiga = f1.CodLiga			
	WHERE	f1.CodEquipoL = e1.CodEquipo and
			f1.CodEquipoV = e2.CodEquipo and
			f1.CodLiga = l1.CodLiga and
			p1.CodPais = c2.CodPais and
			c2.CodCompeticion = l1.CodCompeticion and
			pro.CodPartido = RPPro.idPartido and
			pro.CodPartido = f1.CodPartido
END
GO


