USE [SISPPAFUT]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Cordero, Rodolfo
-- Create date: 29/03/2012
-- Description:	Este Store Procedure permire verificar si el nombre del equipo ingresado ya existe
-- =============================================
CREATE PROCEDURE [dbo].[spEquipoVerificarRepetido]
(
	@Nombre varchar(20)
)

AS
BEGIN

	SET NOCOUNT ON;

    SELECT 
		COUNT(*) as 'Cantidad'
		
	FROM 
		Equipo e
	
	WHERE
		e.Nombre = @Nombre
END

GO