USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spUpdateEquipo]    Script Date: 04/22/2012 21:11:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/* De un equipo solo nos interesa actualizar los estadios */
CREATE PROCEDURE [dbo].[spUpdateEquipo]
(
		@CodEquipo int,
		@CodEstadioPrincipal int,
		@CodEstadioAlterno int
)
AS
BEGIN
	BEGIN
		UPDATE [SISPPAFUT].[dbo].[Equipo]
		SET [CodEstadioPrincipal] = @CodEstadioPrincipal
		WHERE CodEquipo = @CodEquipo
	END
	BEGIN
		UPDATE [SISPPAFUT].[dbo].[Equipo]
		SET [CodEstadioAlterno] = @CodEstadioAlterno
		WHERE CodEquipo = @CodEquipo
	END
END

GO


