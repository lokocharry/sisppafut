USE [SISPPAFUT]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Cordero, Rodolfo
-- Create date: 10/04/2012
-- Description:	Este Procedure devuelve la lista de las ligas pertenecientes a una competicion.
-- =============================================
CREATE PROCEDURE [dbo].[spListarLigasPorCompeticion]
(
	@CodCompeticion int
)

AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT 
		l.CodLiga,
		l.CodCompeticion,
		l.Nombre,
		l.Temporada,
		l.QEquipos	
	FROM 
		Liga l, Competicion c	
	WHERE
		l.CodCompeticion = @CodCompeticion AND l.CodCompeticion = c.CodCompeticion
			
END


GO
