USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spUpdatePartidoPronosticado]    Script Date: 09/23/2012 14:08:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUpdatePartidoPronosticado]
(
		   @idPartido int,
		   @c_mes int,
           @c_QEquiposLiga int,
           --@c_QEquiposMundial int,
           --@c_QAsistencia int,
           @c_Local_PosLiga int,
           @c_Local_Pts int,
           @c_Local bit,
           @c_Local_PosRankMund int,
           --@c_Local_GoleadorSuspendido bit,
           --@c_Local_ArqueroSuspendido bit,
           @c_Local_QExpulsados int,
           @c_Local_QSuspendidos int,
           @c_Local_GolesAnotados int,
           @c_Local_GolesEncajados int,
           @c_Local_PromEdad decimal(5,2),
           @c_Local_QPartidosMes int,
           @c_Visita_PosLiga int,
           @c_Visita_Pts int,
           @c_Visita bit,
           @c_Visita_PosRankMund int,
           --@c_Visita_GoleadorSuspendido bit,
           --@c_Visita_ArqueroSuspendido bit,
           @c_Visita_QExpulsados int,
           @c_Visita_QSuspendidos int,
           @c_Visita_GolesAnotados int,
           @c_Visita_GolesEncajados int,
           @c_Visita_PromEdad decimal(5,2),
           @c_Visita_QPartidosMes int,
           @c_Resultado varchar(5)
)
AS
BEGIN
UPDATE	PartidoPronosticado
SET		c_QEquiposLiga = @c_QEquiposLiga,
		c_Mes = @c_Mes,
		--c_QEquiposMundial = @c_QEquiposMundial,
		--c_QAsistencia = @c_QAsistencia,
		c_Local_PosLiga = @c_Local_PosLiga,
		c_Local_Pts = @c_Local_Pts,
		c_Local = @c_Local,
		c_Local_PosRankMund = @c_Local_PosRankMund,
		--c_Local_GoleadorSuspendido = @c_Local_GoleadorSuspendido,
		--c_Local_ArqueroSuspendido = @c_Local_ArqueroSuspendido,
		c_Local_QExpulsados = @c_Local_QExpulsados,
		c_Local_QSuspendidos = @c_Local_QSuspendidos,
		c_Local_GolesAnotados = @c_Local_GolesAnotados,
		c_Local_GolesEncajados = @c_Local_GolesEncajados,
		c_Local_PromEdad = @c_Local_PromEdad,
		c_Local_QPartidosMes = @c_Local_QPartidosMes,
		c_Visita_PosLiga = @c_Visita_PosLiga,
		c_Visita_Pts = @c_Visita_Pts,
		c_Visita = @c_Visita,
		c_Visita_PosRankMund = @c_Visita_PosRankMund,
		--c_Visita_GoleadorSuspendido = @c_Visita_GoleadorSuspendido,
		--c_Visita_ArqueroSuspendido = @c_Visita_ArqueroSuspendido,
		c_Visita_QExpulsados = @c_Visita_QExpulsados,
		c_Visita_QSuspendidos = @c_Visita_QSuspendidos,
		c_Visita_GolesAnotados = @c_Visita_GolesAnotados,
		c_Visita_GolesEncajados = @c_Visita_GolesEncajados,
		c_Visita_PromEdad = @c_Visita_PromEdad,
		c_Visita_QPartidosMes = @c_Visita_QPartidosMes,
		c_Resultado = @c_Resultado
		
WHERE	idPartido = @idPartido
END
GO


