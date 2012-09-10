USE [SEGURIDAD]
GO

/****** Object:  StoredProcedure [dbo].[spCreateRol]    Script Date: 09/10/2012 12:41:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spCreateRol]
(
			@nombreRol varchar(30),
			@claveRol varchar(15),
			@descripcionRol varchar(200)
)
AS
BEGIN
INSERT INTO [SEGURIDAD].[dbo].[Rol]
           ([nombreRol]
           ,[claveRol]
           ,[descripcionRol])
     VALUES
           (@nombreRol
           ,@claveRol
           ,@descripcionRol)
     RETURN @@IDENTITY
END

GO


