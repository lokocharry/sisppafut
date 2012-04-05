create procedure spListarCompeticion
(
	@Pais varchar (20)
)
as
begin
	select c.Nombre
	from Competicion c join Pais p on c.CodPais = p.CodPais
	where p.Nombre = @Pais
end