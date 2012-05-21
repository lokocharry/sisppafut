USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spCreateRankingEquipo]    Script Date: 05/21/2012 17:05:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spCreateRankingEquipo]
(
			@codEquipo int,
			@posicion int,
			@anio int,
			@mes int,
			@puntos int
)
AS
BEGIN
INSERT INTO [SISPPAFUT].[dbo].[RankingEquipo]
           ([CodEquipo]
           ,[Posicion]
           ,[Anio]
           ,[Mes]
           ,[Puntos])
     VALUES
           (@codEquipo
           ,@posicion
           ,@anio
           ,@mes
           ,@puntos)
     return @@IDENTITY
END

GO


