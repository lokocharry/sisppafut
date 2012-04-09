USE [SISPPAFUT]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Cordero, Rodolfo
-- Create date: 09/04/2012
-- Description:	Este Procedure devuelve la lista de los estadios registrados a un equipo.
-- =============================================
CREATE PROCEDURE [dbo].[spListarEstadiosDeEquipo]
(
	@Codigo int
)

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
		Equipo eq, Estadio e	
	
	WHERE
		eq.CodEquipo = @Codigo AND( eq.CodEstadioPrincipal = e.CodEstadio OR eq.CodEstadioAlterno = e.CodEstadio)
			
END


GO
