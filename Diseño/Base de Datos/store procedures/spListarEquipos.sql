CREATE procedure [dbo].[spListarEquipos]
(
	@Pais varchar (20)
)
as
begin
	select e.Nombre
	from Equipo e join Pais p on e.CodPais = p.CodPais
	where p.Nombre = @Pais
end