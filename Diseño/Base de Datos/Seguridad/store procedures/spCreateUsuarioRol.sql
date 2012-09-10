USE [SEGURIDAD]
GO

/****** Object:  StoredProcedure [dbo].[spCreateUsuarioRol]    Script Date: 09/10/2012 12:41:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spCreateUsuarioRol]
(
		@idUsuario int,
		@idRol int
)
AS
BEGIN
INSERT INTO [SEGURIDAD].[dbo].[UsuarioRol]
           ([idUsuario]
           ,[idRol])
     VALUES
           (@idUsuario
           ,@idRol)
END

GO


