USE [SEGURIDAD]
GO

/****** Object:  StoredProcedure [dbo].[spListarFuncionalidadxUsuario]    Script Date: 09/10/2012 12:42:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spListarFuncionalidadxUsuario]
(
		@idUsuario int
)
AS
BEGIN
SELECT	F.idFuncionalidad, F.nombreFuncionalidad
FROM	UsuarioFuncionalidad UF JOIN Funcionalidad F ON UF.idFuncionalidad = F.idFuncionalidad
WHERE	UF.idUsuario = @idUsuario
END

GO


