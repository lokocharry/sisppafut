USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spCreateAmonestacionPartido]    Script Date: 04/22/2012 15:31:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spCreateAmonestacionPartido]
(
			@CodPartido int,
			@CodJugador int,
			@Tipo bit,		-- 1: Tarjeta Roja 0: Tarjeta Amarilla
			@Minuto int
)
AS
BEGIN
INSERT INTO [SISPPAFUT].[dbo].[AmonestacionPartido]
           ([CodPartido]
           ,[CodJugador]
           ,[Tipo]
           ,[Minuto])
     VALUES
           (@CodPartido
           ,@CodJugador
           ,@Tipo
           ,@Minuto)
     RETURN @@identity
END

GO


