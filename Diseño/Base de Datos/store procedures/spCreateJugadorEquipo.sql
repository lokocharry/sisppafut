CREATE PROCEDURE spCreateJugadorEquipo
(
		@CodEquipo int,
		@CodJugador int
)
AS
BEGIN
INSERT INTO [SISPPAFUT].[dbo].[JugadorEquipo]
           ([CodEquipo]
           ,[CodJugador])
     VALUES
           (@CodEquipo
           ,@CodJugador)
END
GO