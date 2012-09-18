USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spActualizarSuspension]    Script Date: 09/18/2012 15:22:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spActualizarSuspension]
(
		@CodJugador int,
		@codLiga int,
		@Tipo int
)
AS
BEGIN
   IF(@Tipo = 1) -- Tarjeta Amarilla
   begin
   UPDATE [SISPPAFUT].[dbo].[Suspension]   
   SET [QAmarillas] = QAmarillas + 1
   where CodJugador = @CodJugador and CodLiga = @codLiga
   end
   IF(@Tipo = 2) -- Tarjeta Roja
   begin
   UPDATE [SISPPAFUT].[dbo].[Suspension]
   SET [QRojas] = QRojas + 1
   where CodJugador = @CodJugador and CodLiga = @codLiga
   end
   IF(@Tipo = 3) -- Se reinicia los contadores
   begin
   UPDATE [SISPPAFUT].[dbo].[Suspension]
   set	[QAmarillas] = 0,
		[QRojas] = 0
   where CodJugador = @CodJugador and CodLiga = @codLiga
   end
END

GO


