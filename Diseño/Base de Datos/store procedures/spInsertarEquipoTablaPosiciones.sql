CREATE PROCEDURE spInsertarEquipoTablaPosiciones
(
		   @CodLiga int,
           @CodEquipo int,
           @PuntosLocal int,
           @PartidosJugadosLocal int,
           @VictoriasLocal int,
           @EmpatesLocal int,
           @DerrotasLocal int,
           @GolesAnotadosLocal int,
           @GolesEncajadosLocal int,
           @PuntosVisita int,
           @PartidosJugadosVisita int,
           @VictoriasVisita int,
           @EmpatesVisita int,
           @DerrotasVisita int,
           @GolesAnotadosVisita int,
           @GolesEncajadosVisita int
)
AS
BEGIN
INSERT INTO [SISPPAFUT].[dbo].[Tabla]
           ([CodLiga]
           ,[CodEquipo]
           ,[PuntosLocal]
           ,[PartidosJugadosLocal]
           ,[VictoriasLocal]
           ,[EmpatesLocal]
           ,[DerrotasLocal]
           ,[GolesAnotadosLocal]
           ,[GolesEncajadosLocal]
           ,[PuntosVisita]
           ,[PartidosJugadosVisita]
           ,[VictoriasVisita]
           ,[EmpatesVisita]
           ,[DerrotasVisita]
           ,[GolesAnotadosVisita]
           ,[GolesEncajadosVisita])
     VALUES
           (@CodLiga,
            @CodEquipo,
            @PuntosLocal,
            @PartidosJugadosLocal,
            @VictoriasLocal,
            @EmpatesLocal,
            @DerrotasLocal,
            @GolesAnotadosLocal,
            @GolesEncajadosLocal,
            @PuntosVisita,
            @PartidosJugadosVisita,
            @VictoriasVisita,
            @EmpatesVisita,
            @DerrotasVisita,
            @GolesAnotadosVisita,
            @GolesEncajadosVisita)
     RETURN @@identity
END
GO


