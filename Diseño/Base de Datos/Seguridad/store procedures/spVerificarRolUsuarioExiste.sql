-- Author:		Milagros Cruz
-- Create date: 19-09-2012
-- Description:	Este SP permite validar que no exista un RolXFuncionalidad registrado
-- =============================================
CREATE PROCEDURE spVerificarRolUsuarioExiste
	@idRol int, @idUsuario int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT COUNT(*) as 'Cantidad'
	FROM UsuarioRol
	WHERE idRol = @idRol AND idUsuario = @idUsuario

END
GO
