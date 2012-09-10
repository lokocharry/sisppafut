USE [SEGURIDAD]
GO

/****** Object:  StoredProcedure [dbo].[spListarRoles]    Script Date: 09/10/2012 12:42:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spListarRoles]
AS
BEGIN
SELECT [idRol]
      ,[nombreRol]
  FROM [SEGURIDAD].[dbo].[Rol]
END

GO


