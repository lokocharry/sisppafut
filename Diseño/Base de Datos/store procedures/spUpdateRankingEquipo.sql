USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spUpdateRankingEquipo]    Script Date: 05/21/2012 17:06:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- No es para actualizar cada mes la posición y puntos de un equipo
-- Es para modificar en caso se insertó mal un dato.
CREATE PROCEDURE [dbo].[spUpdateRankingEquipo]
(
		@codEquipo int,
		@anio int,
		@mes int,
		@posición int,
		@puntos int
)
AS
BEGIN
UPDATE [SISPPAFUT].[dbo].[RankingEquipo]
   SET [Posicion] = @posición
	  ,[Anio] = @anio
      ,[Mes] = @mes
      ,[Puntos] = @puntos
 WHERE CodEquipo = @codEquipo
END

GO


