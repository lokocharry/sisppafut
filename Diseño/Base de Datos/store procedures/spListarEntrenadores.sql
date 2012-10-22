-- Author:		Milagros Cruz
-- Create date: 22-10-2012
-- Description:	Este SP permite listar la información de los entrenadores
-- =============================================
CREATE PROCEDURE spListarEntrenadores

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT *
    FROM Entrenador
    
END
GO
