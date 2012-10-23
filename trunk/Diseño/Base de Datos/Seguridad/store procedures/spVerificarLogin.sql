USE [SEGURIDAD]
GO

/****** Object:  StoredProcedure [dbo].[spVerificarLogin]    Script Date: 10/22/2012 23:46:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Author:		Milagros Cruz Donayre
-- Create date: 24/09/2012
-- Description:	Este SP permite verificar que el usuario puede loguearse
-- =============================================
CREATE PROCEDURE [dbo].[spVerificarLogin]
	@nombreUsuario varchar(40), @contrasenia varchar(15)
AS
BEGIN
	SET NOCOUNT ON;

   SELECT idUsuario
   FROM Usuario
   WHERE nombreUsuario = @nombreUsuario collate Modern_Spanish_CS_AS AND contrasenia = @contrasenia collate Modern_Spanish_CS_AS
   
   
END

GO


