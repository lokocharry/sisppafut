USE [SEGURIDAD]
GO

/****** Object:  StoredProcedure [dbo].[spListarRolxUsuario]    Script Date: 09/10/2012 12:42:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spListarRolxUsuario]
(
		@idUsuario int
)
AS
BEGIN
SELECT	R.idRol, R.nombreRol
FROM	UsuarioRol UR JOIN Rol R ON UR.idRol = R.idRol
WHERE	UR.idUsuario = @idUsuario
END

GO


