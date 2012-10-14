-- Author:		Milagros Cruz
-- Create date: 14-10-212
-- Description:	Este SP permite listar las actividades registradas antes de una fecha
-- =============================================
CREATE PROCEDURE uspLogListarFecha
	@Fecha Datetime
AS
BEGIN

	SET NOCOUNT ON;

    SELECT *
    FROM Log
    WHERE Fecha <= @Fecha
    
END
GO
