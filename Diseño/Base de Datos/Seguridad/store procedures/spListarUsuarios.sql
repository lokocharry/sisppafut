USE [SEGURIDAD]
GO

/****** Object:  StoredProcedure [dbo].[spListarUsuarios]    Script Date: 09/10/2012 12:42:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spListarUsuarios]
AS
BEGIN
SELECT [idUsuario]
      ,[nombreUsuario]      
  FROM [SEGURIDAD].[dbo].[Usuario]
END

GO


