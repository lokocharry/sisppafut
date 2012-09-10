USE [SEGURIDAD]
GO

/****** Object:  StoredProcedure [dbo].[spCreateFuncionalidad]    Script Date: 09/10/2012 12:41:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spCreateFuncionalidad]
(
			@nombreFuncionalidad varchar(50)
           ,@descripcionFuncionalidad varchar(200)
)
AS
BEGIN
INSERT INTO [SEGURIDAD].[dbo].[Funcionalidad]
           ([nombreFuncionalidad]
           ,[descripcionFuncionalidad])
     VALUES
           (@nombreFuncionalidad
           ,@descripcionFuncionalidad)
     RETURN @@IDENTITY
END

GO


