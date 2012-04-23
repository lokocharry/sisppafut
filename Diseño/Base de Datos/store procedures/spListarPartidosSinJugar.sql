/*
Se lista aquellos partidos que ya debiero haberse jugado, 
pero que no se han guardado datos en la tabla de 'JugadorPartido', 
dato mínimo para verificar que un partido se ha efectuado
*/
CREATE PROCEDURE spListaPartidosSinJugar
AS
BEGIN
	SELECT	p1.Nombre, l1.Nombre, e1.Nombre, e2.Nombre , f1.Fecha
	FROM	Partido f1 join Equipo e1 on (f1.CodEquipoL = e1.CodEquipo),
			Partido f2 join Equipo e2 on (f2.CodEquipoV = e2.CodEquipo),
			Partido f3 join Liga l1 on (f3.CodLiga = l1.CodLiga),
			Liga l2 join (Competicion c2 join Pais p1 on c2.CodPais = p1.CodPais) on (l2.CodCompeticion = c2.CodCompeticion)
	WHERE	DATEDIFF(DAY, f1.Fecha, GETDATE())>0 AND
			(	SELECT	COUNT(*)
				FROM	JugadorPartido JP
				WHERE	JP.CodPartido = f1.CodPartido
			)=0
END
GO