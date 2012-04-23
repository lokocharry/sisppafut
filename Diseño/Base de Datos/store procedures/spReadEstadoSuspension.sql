CREATE PROCEDURE spReadEstadoSuspension
(
		@CodJugador int
)
AS
BEGIN
declare @estado varchar(20)
SELECT @estado = 'NO SUSPENDIDO'
SELECT @estado = 'SUSPENDIDO'
  FROM [SISPPAFUT].[dbo].[Suspension]
  WHERE CodJugador = 1 and (QAmarillas = 5 or QRojas = 1)
SELECT @estado AS 'Estado de suspensión';
END
GO