USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spPosicionEquipoTabla]    Script Date: 08/23/2012 17:38:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spPosicionEquipoTabla]
(
	@CodLiga	int
)
AS
BEGIN
	SELECT	*, ROW_NUMBER() OVER(ORDER BY Tabla.PuntosLocal+Tabla.PuntosVisita DESC, Tabla.GolesAnotadosLocal DESC, Tabla.GolesEncajadosLocal ASC) AS 'Posición'
	FROM	Tabla
	WHERE	Tabla.CodLiga = @CodLiga
END
GO


