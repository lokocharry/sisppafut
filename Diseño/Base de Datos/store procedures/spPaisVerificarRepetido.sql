USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spPaisVerificarRepetido]    Script Date: 03/31/2012 01:04:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Martinez Hernanadez, Renzo
-- Create date: 28/08/2010
-- Description:	Este Store Procedure permire verificar si el nombre del país ingresado ya existe
-- =============================================
CREATE PROCEDURE [dbo].[spPaisVerificarRepetido]
(
	@Nombre varchar(20)
)

AS
BEGIN

	SET NOCOUNT ON;

    SELECT 
		COUNT(*) as 'Cantidad'
		
	FROM 
		Pais p
	
	WHERE
		p.Nombre = @Nombre
END

GO


