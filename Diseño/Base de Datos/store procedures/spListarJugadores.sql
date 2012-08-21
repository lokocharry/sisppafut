USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spListarJugadores]    Script Date: 08/17/2012 16:28:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Cordero, Rodolfo
-- Create date: 14/05/2012
-- Description:	Este Procedure devuelve la lista de todos los jugadores.
-- =============================================
CREATE PROCEDURE [dbo].[spListarJugadores]
AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT 
		j.CodJugador,
		j.Nombres,
		j.Apellidos,
		j.Nacionalidad,
		j.FechaNacimiento,
		j.Posicion,
		j.Altura,
		j.Peso
		
	FROM 
		Jugador j
	
	ORDER BY j.Apellidos, j.Nombres
	
END
GO


