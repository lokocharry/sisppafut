CREATE PROCEDURE spCreateJugadorPartido
(
		@CodPartido int,
		@CodJugador int,
		@Estado bit -- 1: titular, 0:suplente
)
AS
BEGIN
INSERT INTO [SISPPAFUT].[dbo].[JugadorPartido]
           ([CodPartido]
           ,[CodJugador]
           ,[Estado])
     VALUES
           (@CodPartido
           ,@CodJugador
           ,@Estado)
END
GO