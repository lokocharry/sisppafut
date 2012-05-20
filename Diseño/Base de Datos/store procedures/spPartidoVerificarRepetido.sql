USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spPartidoVerificarRepetido]    Script Date: 05/20/2012 00:21:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Martínez, Meneses
-- Create date: 19/05/2012
-- Description:	Este Store Procedure permire verificar si el partido de una liga ya existe
-- =============================================
CREATE PROCEDURE [dbo].[spPartidoVerificarRepetido]
(
	@codEqLocal int,
	@codEqVisitante int,
	@codLiga int
)
AS
BEGIN

	SET NOCOUNT ON;

    SELECT 
		COUNT(*) as 'Cantidad'
		
	FROM 
		Partido p
	
	WHERE
		p.CodEquipoL = @codEqLocal	and
		p.CodEquipoV = @codEqVisitante	and
		p.CodLiga = @codLiga
END



GO


