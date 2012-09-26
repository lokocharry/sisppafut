USE [SISPPAFUT]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cordero, Rodolfo
-- Create date: 26/09/2012
-- Description:	Este Procedure devuelve la lista de pronosticos del cliente(usuario)
-- =============================================
CREATE PROCEDURE [dbo].[spListarPronosticoCliente]
(
	@CodUsuario int
)

AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT 
		idUsuario,
		CodPartido,
		Pronostico
				
	FROM 
		PronosticoCliente	
	WHERE
		idUsuario=@CodUsuario
			
END




GO


