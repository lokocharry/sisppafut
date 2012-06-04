USE [SISPPAFUT]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Cordero, Rodolfo
-- Create date: 04/06/2012
-- Description:	Este Procedure devuelve la lista todos los partidos, jugados o no.
-- =============================================
CREATE PROCEDURE [dbo].[spListarPartidos]
AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT 
		p.CodPartido,
		p.CodLiga,
		p.CodEquipoL,
		p.CodEquipoV,
		p.CodEstadio,
		p.GolesLocal,
		p.GolesVisita,
		p.Fecha
		
	FROM 
		Partido p		
	
END


GO

