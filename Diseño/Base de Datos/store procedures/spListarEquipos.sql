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
	e.CodEstadioAlterno	
	from Equipo e join Pais p on e.CodPais = p.CodPais
	where p.Nombre = @Pais
end