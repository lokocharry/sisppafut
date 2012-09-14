USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spCreatePartido]    Script Date: 09/14/2012 17:35:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spCreatePartido]
(
			@CodLiga int
           ,@CodEquipoL int
           ,@CodEquipoV int
           ,@CodEstadio int
           --,@GolesLocal int
           --,@GolesVisita int
           ,@Fecha datetime
)
AS
BEGIN
declare @GolesLocal int
declare @GolesVisita int
set @GolesLocal = NULL;
set @GolesVisita = NULL;
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


