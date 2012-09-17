USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spCreateSuspensionXJugador]    Script Date: 09/16/2012 20:13:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spCreateSuspensionXJugador]
(
			@CodJugador int,
			@CodLiga int
			-- cuando se registra un jugador, se registra sin amonestaciones
)
AS
BEGIN
declare @QAmarillas int
declare @QRojas int
set @QAmarillas = 0
set @QRojas = 0
INSERT INTO [SISPPAFUT].[dbo].[Suspension]
           ([CodJugador]
           ,[QAmarillas]
           ,[QRojas]
           ,[CodLiga])
     VALUES
           (@CodJugador
           ,@QAmarillas
           ,@QRojas
           ,@CodLiga)
END

GO


