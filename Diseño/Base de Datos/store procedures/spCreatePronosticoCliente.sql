-- Author:		Milagros Cruz
-- Create date: 14-10-2012
-- Description:	Este SP permite registrar el pronóstico de un cliente en la BD
-- =============================================
CREATE PROCEDURE spCreatePronosticoCliente
	@idUsuario int, @CodPartido int, @Pronostico varchar(5)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO PronosticoCliente
	(idUsuario, CodPartido, Pronostico)
	VALUES
	(@idUsuario, @CodPartido, @Pronostico)
   
END
GO
