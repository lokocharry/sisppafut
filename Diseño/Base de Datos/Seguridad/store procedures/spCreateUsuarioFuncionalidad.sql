USE [SEGURIDAD]
GO

/****** Object:  StoredProcedure [dbo].[spCreateUsuarioFuncionalidad]    Script Date: 09/10/2012 12:41:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spCreateUsuarioFuncionalidad]
(
			@idUsuario int
           ,@idFuncionalidad int
)
AS
BEGIN
INSERT INTO [SEGURIDAD].[dbo].[UsuarioFuncionalidad]
           ([idUsuario]
           ,[idFuncionalidad])
     VALUES
           (@idUsuario
           ,@idFuncionalidad)
END

GO


