USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spUpdatePronostico]    Script Date: 09/04/2012 23:26:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spUpdatePronostico]
(
	@codPartido int,
	@pronostico varchar(5),
	@porcentajeLocal decimal(5,2),
	@porcentajeEmpate decimal(5,2),
	@porcentajeVisita decimal(5,2)
)
AS
BEGIN
	UPDATE [SISPPAFUT].[dbo].[Pronostico]
	SET [Pronostico] = @pronostico,
		[PorcentajeLocal] = @porcentajeLocal,
		[PorcentajeEmpate] = @porcentajeEmpate,
		[PorcentajeVisita] = @porcentajeVisita
	WHERE CodPartido = @codPartido
END


GO


