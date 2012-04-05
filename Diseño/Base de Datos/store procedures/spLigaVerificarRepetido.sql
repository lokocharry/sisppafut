USE [SISPPAFUT]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Cordero, Rodolfo
-- Create date: 29/03/2012
-- Description:	Este Store Procedure permire verificar si el nombre de la liga ingresada ya existe
-- =============================================
CREATE PROCEDURE [dbo].[spLigaVerificarRepetido]
(
	@Nombre varchar(30)
)

AS
BEGIN

	SET NOCOUNT ON;

    SELECT 
		COUNT(*) as 'Cantidad'
		
	FROM 
		Liga l
	
	WHERE
		l.Nombre = @Nombre
END

GO


