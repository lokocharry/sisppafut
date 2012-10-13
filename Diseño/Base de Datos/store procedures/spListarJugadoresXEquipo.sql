USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spListarJugadoresXEquipo]    Script Date: 10/11/2012 15:14:25 ******/
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
	
SELECT	J.CodJugador, J.Nombres, J.Apellidos, J.Nacionalidad, J.FechaNacimiento, J.Posicion, J.Altura, J.Peso
FROM	Jugador J join JugadorEquipo JE on J.CodJugador = JE.CodJugador
WHERE	JE.CodEquipo = @CodEquipo AND J.Posicion = 'Portero'
UNION ALL
SELECT	J.CodJugador, J.Nombres, J.Apellidos, J.Nacionalidad, J.FechaNacimiento, J.Posicion, J.Altura, J.Peso
FROM	Jugador J join JugadorEquipo JE on J.CodJugador = JE.CodJugador
WHERE	JE.CodEquipo = @CodEquipo AND J.Posicion = 'Defensa'
UNION ALL
SELECT	J.CodJugador, J.Nombres, J.Apellidos, J.Nacionalidad, J.FechaNacimiento, J.Posicion, J.Altura, J.Peso
FROM	Jugador J join JugadorEquipo JE on J.CodJugador = JE.CodJugador
WHERE	JE.CodEquipo = @CodEquipo AND J.Posicion = 'Centrocampista'
UNION ALL
SELECT	J.CodJugador, J.Nombres, J.Apellidos, J.Nacionalidad, J.FechaNacimiento, J.Posicion, J.Altura, J.Peso
FROM	Jugador J join JugadorEquipo JE on J.CodJugador = JE.CodJugador
WHERE	JE.CodEquipo = @CodEquipo AND J.Posicion = 'Delantero'
			
END

GO


