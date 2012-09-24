-- Author:		Milagros Cruz
-- Create date: 24-09-2012
-- Description:	Este SP sirve para verificar si existe una asociación de Usuario-Funcionalidad ya registrada
-- =============================================
CREATE PROCEDURE spVerificarUsuarioFuncionalidadExiste 
	@idUsuario int, @idFuncionalidad int
AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT COUNT(*) AS 'Cantidad'
	FROM UsuarioFuncionalidad
	WHERE idUsuario = @idUsuario AND idFuncionalidad = @idFuncionalidad

END
GO
