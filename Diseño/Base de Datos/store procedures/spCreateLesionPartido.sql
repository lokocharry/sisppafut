USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spCreateLesionPartido]    Script Date: 04/22/2012 15:33:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spCreateLesionPartido]
(
			@CodPartido int,
			@CodJugador int,
			@Tipo varchar (20), -- Hay muchos tipos: esguince leve, fractura de craneo, contractura, etc
			@Tiempodescanso int -- En días
)
AS
BEGIN
INSERT INTO [SISPPAFUT].[dbo].[LesionPartido]
           ([CodPartido]
           ,[CodJugador]
           ,[Tipo]
           ,[Tiempodescanso])
     VALUES
           (@CodPartido
           ,@CodJugador
           ,@Tipo
           ,@Tiempodescanso)
END

GO


