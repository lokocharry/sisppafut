-- Author:		Milagros Cruz Donayre
-- Create date: 24/09/2012
-- Description:	Este SP permite verificar que el usuario puede loguearse
-- =============================================
CREATE PROCEDURE spVerificarLogin
	@nombreUsuario varchar(40), @contrasenia varchar(15)
AS
BEGIN
	SET NOCOUNT ON;

   SELECT COUNT(*) AS 'Cantidad'
   FROM Usuario
   WHERE nombreUsuario = @nombreUsuario AND contrasenia = @contrasenia   
   
END
GO
