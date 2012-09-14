USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spUpdatePartido]    Script Date: 09/14/2012 17:39:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/* De un partido solo nos interesa actualizar la fecha del partido (atrasa o adelanta) */
/* Los goles son actualizados con otro SP*/
CREATE PROCEDURE [dbo].[spUpdatePartido]
(
		@CodPartido int,
		@Fecha Datetime
)
AS
BEGIN
UPDATE [SISPPAFUT].[dbo].[Partido]
   SET [Fecha] = @Fecha
 WHERE CodPartido = @CodPartido
END

GO


