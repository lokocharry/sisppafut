USE [SEGURIDAD]
GO

/****** Object:  StoredProcedure [dbo].[spVerificarRolExiste]    Script Date: 09/10/2012 12:42:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spVerificarRolExiste]
(
		@nombre varchar(30)
)
AS
BEGIN
SELECT	COUNT(*) as 'Cantidad'
FROM	Rol R
WHERE	R.nombreRol = @nombre
END
GO


