USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spListarJugadoresXEquipo]    Script Date: 05/17/2012 18:38:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Martinez, Renzo
-- Create date: 17/05/2012
-- Description:	Este Procedure devuelve la lista de jugadores por equipo(codigo).
-- =============================================
CREATE PROCEDURE [dbo].[spListarJugadoresXEquipo]
(
	@CodEquipo int
)

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
	
	JOIN
		JugadorEquipo je
	
	ON
		je.CodEquipo = @CodEquipo AND je.CodJugador = j.CodJugador
		--p.CodPais = e.CodPais AND e.CodPais = @Codigo
			
END




GO


