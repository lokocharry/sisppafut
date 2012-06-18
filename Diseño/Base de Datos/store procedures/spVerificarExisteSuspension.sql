USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spVerificarExisteSuspension]    Script Date: 06/18/2012 15:03:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spVerificarExisteSuspension]
(
	@CodJugador int
)
AS
BEGIN

	declare	@estado int
	SELECT	@estado = 0
	
	SELECT	@estado = 1
	FROM	[SISPPAFUT].[dbo].[Suspension]
	WHERE	CodJugador = @CodJugador
	
	SELECT @estado AS 'Resultado';
END

GO

