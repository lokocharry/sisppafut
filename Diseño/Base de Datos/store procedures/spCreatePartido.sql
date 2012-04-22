USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spCreatePartido]    Script Date: 04/21/2012 22:54:20 ******/
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
           ,@Fecha date
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


