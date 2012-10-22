-- Author:		Milagros Cruz
-- Create date: 22-10-2012
-- Description:	Este SP permite listar la información de los entrenadores
-- =============================================
CREATE PROCEDURE spUpdateEntrenador
	@CodEntrenador int, @CodEquipo int, @Nombres varchar(20), 
	@Apellidos varchar(20), @Nacionalidad varchar(20),
	@FechaNacimiento datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE Entrenador
    SET CodEquipo = @CodEquipo, Nombres = @Nombres, Apellidos = @Apellidos, Nacionalidad = @Nacionalidad, FechaNacimiento = @FechaNacimiento
    WHERE CodEntrenador = @CodEntrenador
    
END
GO
