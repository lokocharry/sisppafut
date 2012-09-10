USE [SEGURIDAD]
GO

/****** Object:  StoredProcedure [dbo].[spVerificarLoginExiste]    Script Date: 09/10/2012 12:42:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spVerificarLoginExiste]
(
		@nombre varchar(40)
)
AS
BEGIN
SELECT	COUNT(*) as 'Cantidad'
FROM	Usuario U
WHERE	U.nombreUsuario = @nombre
END
GO


