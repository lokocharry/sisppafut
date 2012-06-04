USE [SISPPAFUT]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Cordero, Rodolfo
-- Create date: 29/03/2012
-- Description:	Este Procedure devuelve la lista de todos los pronosticos.
-- =============================================
CREATE PROCEDURE [dbo].[spListarPronosticos]
AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT 
		p.CodPronostico,
		p.CodPartido,
		p.Pronostico,
		p.PorcentajeLocal,
		p.PorcentajeEmpate,
		p.PorcentajeVisita
		
	FROM 
		Pronostico p		
	
END


GO


