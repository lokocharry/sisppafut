USE [SEGURIDAD]
GO

/****** Object:  StoredProcedure [dbo].[spVerificarFuncionalidadExiste]    Script Date: 09/10/2012 12:42:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spVerificarFuncionalidadExiste]
(
		@nombre varchar(50)
)
AS
BEGIN
SELECT	COUNT(*) as 'Cantidad'
FROM	Funcionalidad F
WHERE	F.nombreFuncionalidad = @nombre
END
GO


