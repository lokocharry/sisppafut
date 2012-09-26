USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[spListarFuncionalidadxUsuario]    Script Date: 09/26/2012 17:00:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spListarFuncionalidadxUsuario]
(
		@idUsuario int
)
AS
BEGIN
SELECT	F.idFuncionalidad, F.nombreFuncionalidad
FROM	UsuarioFuncionalidad UF JOIN Funcionalidad F ON UF.idFuncionalidad = F.idFuncionalidad
WHERE	UF.idUsuario = @idUsuario
ORDER BY F.idFuncionalidad
END
