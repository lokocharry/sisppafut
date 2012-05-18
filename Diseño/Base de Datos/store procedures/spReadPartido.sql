USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spReadPartido]    Script Date: 05/17/2012 18:39:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Martinez, Renzo
-- Create date: 17/05/2012
-- Description:	Este Procedure devuelve buscar un partido por su codigo.
-- =============================================
CREATE PROCEDURE [dbo].[spReadPartido]
(
	@CodPartido int
)

AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT *
				
	FROM 
		Partido p	
	
	WHERE
		p.CodPartido = @CodPartido
			
END
GO


