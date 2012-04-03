USE [SISPPAFUT]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Cordero, Rodolfo
-- Create date: 29/03/2012
-- Description:	Este Procedure devuelve la lista de todos las Ligas que estan registrados.
-- =============================================
CREATE PROCEDURE [dbo].[spListarLigas]
AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT 
		l.CodLiga,
		l.CodCompeticion,
		l.Temporada,
		l.Nombre,
		l.QEquipos
		
	FROM 
		Liga l			
	
END


GO


