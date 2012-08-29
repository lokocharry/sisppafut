USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spLeerHistorialJugador]    Script Date: 08/29/2012 09:12:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spLeerHistorialJugador]
					@CodJugador int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT J.CodJugador, J.Nombres, J.Apellidos, E.Nombre
	FROM HistorialJugadorEquipo HJ JOIN Equipo E ON (HJ.CodEquipo = E.CodEquipo) JOIN Jugador J ON (HJ.CodJugador = J.CodJugador)
	WHERE HJ.CodJugador = @CodJugador

END

GO


