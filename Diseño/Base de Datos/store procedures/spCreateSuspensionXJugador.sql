CREATE PROCEDURE spCreateSuspensionXJugador
(
			@CodJugador int
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
           ,[QRojas])
     VALUES
           (@CodJugador
           ,@QAmarillas
           ,@QRojas)
END
GO


