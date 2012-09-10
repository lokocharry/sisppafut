USE [SEGURIDAD]
GO

/****** Object:  StoredProcedure [dbo].[spListarFuncionalidades]    Script Date: 09/10/2012 12:42:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spListarFuncionalidades]
AS
BEGIN
SELECT [idFuncionalidad]
      ,[nombreFuncionalidad]
  FROM [SEGURIDAD].[dbo].[Funcionalidad]
END

GO


