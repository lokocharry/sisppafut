USE [SEGURIDAD]
GO

/****** Object:  StoredProcedure [dbo].[spListarFuncionalidadxRol]    Script Date: 09/10/2012 12:42:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spListarFuncionalidadxRol]
(
		@idRol int
)
AS
BEGIN
SELECT	F.idFuncionalidad, F.nombreFuncionalidad
FROM	RolFuncionalidad RF JOIN Funcionalidad F ON RF.idFuncionalidad = F.idFuncionalidad
WHERE	RF.idRol = @idRol
END

GO


