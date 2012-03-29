USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spCreateLigaEquipo]    Script Date: 03/28/2012 22:27:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[spCreateLigaEquipo]
(
	@codLiga int,
	@codEquipo int
)
as
begin
INSERT INTO [SISPPAFUT].[dbo].[LigaEquipo]
           ([CodLiga]
           ,[CodEquipo])
     VALUES
           (@codLiga
           ,@codEquipo)
end

GO

