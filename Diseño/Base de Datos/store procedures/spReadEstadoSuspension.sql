USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spReadEstadoSuspension]    Script Date: 09/16/2012 21:04:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spReadEstadoSuspension]
(
		@CodJugador int,
		@CodLiga int
)
AS
BEGIN
declare @estado varchar(20)
SELECT @estado = 'NO SUSPENDIDO'
SELECT @estado = 'SUSPENDIDO'
  FROM [SISPPAFUT].[dbo].[Suspension]
  WHERE CodJugador = @CodJugador and 
		CodLiga = @CodLiga and (QAmarillas = 5 or QRojas = 1)
SELECT @estado AS 'Estado de suspensión';
END

GO


