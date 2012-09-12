-- Author:		Cruz Donayre, Milagros
-- Create date: 10/09/2012
-- Description:	Este SP muestra la tabla de posiciones para una competicion en una temporada determinada
-- =============================================
ALTER PROCEDURE spListarTablaPosiciones
		@CodLiga int
AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT ROW_NUMBER() OVER(ORDER BY T.PuntosLocal+T.PuntosVisita DESC, T.GolesAnotadosLocal DESC, T.GolesEncajadosLocal ASC) AS 'Posición',(T.PuntosLocal+T.PuntosVisita)AS 'Puntos', (T.PartidosJugadosLocal+T.PartidosJugadosVisita) AS 'PJ', (T.VictoriasLocal + T.VictoriasVisita) AS 'G', (T.EmpatesLocal + T.EmpatesVisita) AS 'E', (T.DerrotasLocal + T.DerrotasVisita) AS 'P', (T.GolesAnotadosLocal + T.GolesAnotadosVisita) AS 'GA', (T.GolesEncajadosLocal + T.GolesEncajadosVisita) AS 'GE', T.PartidosJugadosLocal, T.VictoriasLocal, T.EmpatesLocal, T.DerrotasLocal, T.GolesAnotadosLocal, T.GolesEncajadosLocal, T.PartidosJugadosVisita, T.VictoriasVisita, T.EmpatesVisita, T.DerrotasVisita, T.GolesAnotadosVisita, T.GolesEncajadosVisita
	FROM Tabla T JOIN Liga L ON (T.CodLiga = L.CodLiga)
	WHERE T.CodLiga = @CodLiga

END
GO
