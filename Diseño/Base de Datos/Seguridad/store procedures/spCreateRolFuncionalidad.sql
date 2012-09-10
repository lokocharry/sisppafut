USE [SEGURIDAD]
GO

/****** Object:  StoredProcedure [dbo].[spCreateRolFuncionalidad]    Script Date: 09/10/2012 12:41:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spCreateRolFuncionalidad]
(
		@idRol int,
		@idFuncionalidad int
)
AS
BEGIN
INSERT INTO [SEGURIDAD].[dbo].[RolFuncionalidad]
           ([idRol]
           ,[idFuncionalidad])
     VALUES
           (@idRol
           ,@idFuncionalidad)
END

GO


