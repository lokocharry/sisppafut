USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spListarPartidosPronosticados]    Script Date: 09/22/2012 20:59:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spListarPartidosPronosticados]
AS
BEGIN
SELECT [idPartido]
      ,[c_QEquiposLiga]
      ,[c_Mes]
      --,[c_QEquiposMundial]
      --,[c_QAsistencia]
      ,[c_Local_PosLiga]
      ,[c_Local_Pts]
      ,[c_Local]
      ,[c_Local_PosRankMund]
      --,[c_Local_GoleadorSuspendido]
      --,[c_Local_ArqueroSuspendido]
      ,[c_Local_QExpulsados]
      ,[c_Local_QSuspendidos]
      ,[c_Local_GolesAnotados]
      ,[c_Local_GolesEncajados]
      ,[c_Local_PromEdad]
      ,[c_Local_QPartidosMes]
      ,[c_Visita_PosLiga]
      ,[c_Visita_Pts]
      ,[c_Visita]
      ,[c_Visita_PosRankMund]
      --,[c_Visita_GoleadorSuspendido]
      --,[c_Visita_ArqueroSuspendido]
      ,[c_Visita_QExpulsados]
      ,[c_Visita_QSuspendidos]
      ,[c_Visita_GolesAnotados]
      ,[c_Visita_GolesEncajados]
      ,[c_Visita_PromEdad]
      ,[c_Visita_QPartidosMes]
      ,[c_Resultado]
  FROM [SISPPAFUT].[dbo].[PartidoPronosticado]
  WHERE	c_Resultado = 'L' OR c_Resultado = 'E' OR c_Resultado = 'V'
END

GO


