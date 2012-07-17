USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spUpdateEquipo]    Script Date: 07/16/2012 17:07:41 ******/
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
	if (@CodEstadioPrincipal = null)
	begin
		UPDATE [SISPPAFUT].[dbo].[Equipo]
		SET [CodEstadioPrincipal] = CodEstadioPrincipal
		WHERE CodEquipo = @CodEquipo
	end
	IF (@codEstadioPrincipal is not null)
	begin
		UPDATE [SISPPAFUT].[dbo].[Equipo]
		SET [CodEstadioPrincipal] = @CodEstadioPrincipal
		WHERE CodEquipo = @CodEquipo
	end
	if(@CodEstadioAlterno = null)
	begin
		UPDATE [SISPPAFUT].[dbo].[Equipo]
		SET [CodEstadioAlterno] = null
		WHERE CodEquipo = @CodEquipo
	end
	if (@CodEstadioAlterno is not NULL)
	begin
		UPDATE [SISPPAFUT].[dbo].[Equipo]
		SET [CodEstadioAlterno] = @CodEstadioAlterno
		WHERE CodEquipo = @CodEquipo
	end
END

GO


