CREATE PROCEDURE spReadRankingEquipo
(
		@anio int,
		@mes int,
		@codPais int
)
AS
BEGIN
SELECT e.Nombre, r.Posicion, r.Puntos, p.Nombre
  FROM Equipo e join RankingEquipo r on e.CodEquipo = r.CodEquipo, Pais p
  WHERE r.Anio = @anio and
		r.Mes = @mes and
		p.CodPais = @codPais
  ORDER BY r.Posicion
END
GO