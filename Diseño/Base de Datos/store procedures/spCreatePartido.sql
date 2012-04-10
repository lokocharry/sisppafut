CREATE PROCEDURE spCreatePartido
(
			@CodLiga int
           ,@CodEquipoL int
           ,@CodEquipoV int
           ,@CodEstadio int
           ,@GolesLocal int
           ,@GolesVisita int
           ,@Fecha date
)
AS
BEGIN
if(@GolesLocal = null)
begin
	set @GolesLocal = 0;
end
if(@GolesVisita = 0)
begin
	set @GolesVisita = 0;
end
if(@Fecha = null)
begin
	set @Fecha = null;
end
INSERT INTO [SISPPAFUT].[dbo].[Partido]
           ([CodLiga]
           ,[CodEquipoL]
           ,[CodEquipoV]
           ,[CodEstadio]
           ,[GolesLocal]
           ,[GolesVisita]
           ,[Fecha])
     VALUES
           (@CodLiga
           ,@CodEquipoL
           ,@CodEquipoV
           ,@CodEstadio
           ,@GolesLocal
           ,@GolesVisita
           ,@Fecha)
    RETURN @@IDENTITY
END
GO


