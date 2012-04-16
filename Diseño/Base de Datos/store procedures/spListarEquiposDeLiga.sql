USE [SISPPAFUT]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spListarEquiposDeLiga]
(
	@CodigoLiga int
)
as
begin
	select
	e.CodEquipo,
	e.CodPais,
	e.Nombre,
	e.AnioFundacion,
	e.Ciudad,
	e.CodEstadioPrincipal,
	isNull(e.CodEstadioAlterno,0) as 'CodEstadioAlterno'
	from Equipo e join LigaEquipo l on e.CodEquipo = l.CodEquipo
	where l.CodLiga = @CodigoLiga
end
GO
