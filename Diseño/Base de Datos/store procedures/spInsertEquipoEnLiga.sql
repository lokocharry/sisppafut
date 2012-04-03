USE [SISPPAFUT]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[spInsertEquipoEnLiga]
(
	@codLiga int,
	@codEquipo int
)
as
begin
INSERT INTO [SISPPAFUT].[dbo].[LigaEquipo]
           ([CodEquipo]
           ,[CodLiga])
     VALUES
           (@codLiga
           ,@codEquipo)
end

GO

