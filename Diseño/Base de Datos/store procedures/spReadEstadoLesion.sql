USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spReadEstadoLesion]    Script Date: 06/18/2012 15:04:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spReadEstadoLesion]
(
	@CodJugador int, 
	@Fecha date
)
AS
BEGIN
	declare @estado varchar(20)

	SELECT @estado = 'NO LESIONADO'

	SELECT @estado = 'LESIONADO'
	FROM 
		LesionPartido lp
		JOIN Partido p ON lp.CodPartido = p.CodPartido
	
	WHERE
		lp.CodJugador = @CodJugador AND
		DATEDIFF(DAY, p.Fecha, @Fecha) < lp.Tiempodescanso
	
	SELECT @estado as 'Estado'	
END
GO

