USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spListarEquipos]    Script Date: 04/13/2012 23:24:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spListarEquipos]
(
	@Pais varchar (20)
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
	from Equipo e join Pais p on e.CodPais = p.CodPais
	where p.Nombre = @Pais
end
GO


