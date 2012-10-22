-- Author:		Milagros Cruz
-- Create date: 15-10-2012
-- Description:	Este SP permite registrar un entrenador en el sistema
-- =============================================
CREATE PROCEDURE spCreateEntrenador
	@CodEntrenador int, @CodEquipo int, @Nombres varchar(20), 
	@Apellidos varchar(20), @Nacionalidad varchar(20),
	@FechaNacimiento datetime
	
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO Entrenador
	(CodEntrenador, CodEquipo, Nombres, Apellidos, Nacionalidad, FechaNacimiento)
	VALUES
	(@CodEntrenador, @CodEquipo, @Nombres, @Apellidos, @Nacionalidad, @FechaNacimiento)
	
	RETURN @@IDENTITY

END
GO
