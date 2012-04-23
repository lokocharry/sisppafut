CREATE PROCEDURE spCreateGolPartido
(
		@CodPartido int,
		@CodJugador int,
		@Minuto int -- Rango de valores: 0-90
)
AS
BEGIN
INSERT INTO [SISPPAFUT].[dbo].[GolPartido]
           ([CodPartido]
           ,[CodJugador]
           ,[Minuto])
     VALUES
           (@CodPartido
           ,@CodJugador
           ,@Minuto)
    RETURN @@IDENTITY
END
GO