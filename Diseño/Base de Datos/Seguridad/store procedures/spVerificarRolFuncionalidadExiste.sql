-- Author:		Milagros Cruz
-- Create date: 19-09-2012
-- Description:	Este SP permite validar que no exista un RolXFuncionalidad registrado
-- =============================================
CREATE PROCEDURE spVerificarRolFuncionalidadExiste
	@idRol int, @idFuncionalidad int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT COUNT(*) as 'Cantidad'
	FROM RolFuncionalidad
	WHERE idRol = @idRol AND idFuncionalidad = @idFuncionalidad

END
GO
