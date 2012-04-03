USE [SISPPAFUT]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Cordero, Rodolfo
-- Create date: 29/03/2012
-- Description:	Este Procedure devuelve la lista de todos los estadios que estan registrados.
-- =============================================
CREATE PROCEDURE [dbo].[spListarEstadios]
AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT 
		e.CodEstadio,
		e.CodPais,
		e.AnioFundacion,
		e.Nombre,
		e.Ciudad,
		e.Aforo		
		
	FROM 
		Estadio e			
	
END


GO
