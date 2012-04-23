/* De un partido solo nos interesa actualizar la fecha del partido (atrasa o adelanta) */
/* Los goles son actualizados con otro SP*/
CREATE PROCEDURE spUpdatePartido
(
		@CodPartido int,
		@Fecha Date
)
AS
BEGIN
UPDATE [SISPPAFUT].[dbo].[Partido]
   SET [Fecha] = @Fecha
 WHERE CodPartido = @CodPartido
END
GO
