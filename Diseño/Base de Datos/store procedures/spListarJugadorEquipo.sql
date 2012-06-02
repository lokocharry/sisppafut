CREATE PROCEDURE spListarJugadorEquipo
AS
BEGIN
SELECT [CodEquipo]
      ,[CodJugador]
  FROM [SISPPAFUT].[dbo].[JugadorEquipo]
END
GO