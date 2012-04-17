USE [SISPPAFUT]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Cordero, Rodolfo
-- Create date: 17/04/2012
-- Description:	Este Procedure devuelve la lista de los estadios registrados a un pais.
-- =============================================
CREATE PROCEDURE [dbo].[spListarEstadiosDePais]
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
		Pais p, Estadio e	
	
	WHERE
		p.CodPais = e.CodPais AND e.CodPais = @Codigo
			
END


GO
