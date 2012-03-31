USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spListarPaises]    Script Date: 03/31/2012 01:03:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Martinez Hernández, Renzo
-- Create date: 29/03/2012
-- Description:	Este Procedure devuelve la lista de todos los Paise que estan registrados.
-- =============================================
CREATE PROCEDURE [dbo].[spListarPaises]
AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT 
		p.CodPais,
		p.Nombre
		
	FROM 
		Pais p			
	
END


GO


