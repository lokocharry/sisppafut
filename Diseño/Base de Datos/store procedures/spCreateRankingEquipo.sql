USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spCreateRankingEquipo]    Script Date: 06/12/2012 18:50:35 ******/
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
IF((SELECT COUNT(*) FROM RankingEquipo r WHERE r.CodEquipo = @codEquipo AND r.Mes = @mes AND r.Anio = @anio) > 0)
BEGIN
	UPDATE	RankingEquipo
	SET		Posicion = @posicion,			
			Puntos = @puntos
	WHERE	CodEquipo = @codEquipo and
			Anio = @anio and
			Mes = @mes			
	RETURN	-2 -- Se ha actualizado un registro
END
ELSE
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
end

GO


