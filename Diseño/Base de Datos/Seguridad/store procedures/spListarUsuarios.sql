USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[spListarUsuarios]    Script Date: 09/19/2012 17:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spListarUsuarios]
AS
BEGIN
SELECT *    
  FROM [SEGURIDAD].[dbo].[Usuario]
END
