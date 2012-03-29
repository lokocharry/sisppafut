USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spCreateLiga]    Script Date: 03/28/2012 22:27:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[spCreateLiga]
(
	@codCompeticion int,
	@temporada varchar(10),
	@nombre varchar (30),
	@qEquipos int
)
as
begin
INSERT INTO [SISPPAFUT].[dbo].[Liga]
           ([CodCompeticion]
           ,[Temporada]
           ,[Nombre]
           ,[QEquipos])
     VALUES
           (@codCompeticion
           ,@temporada
           ,@nombre
           ,@qEquipos)
     return @@identity
end

GO

