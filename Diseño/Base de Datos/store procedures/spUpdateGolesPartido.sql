USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spUpdateGolesPartido]    Script Date: 09/19/2012 11:15:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateGolesPartido]
(
	@CodPartido int,
	@GolesLocal int,
	@GolesVisita int
) 

AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE Partido
		
	SET
		GolesLocal = @GolesLocal,
		GolesVisita = @GolesVisita
	
	WHERE
		CodPartido = @CodPartido	
		
	-- Se actualiza la tabla
	declare @Liga int
	set @Liga = (select L.CodLiga from Liga L join Partido P on P.CodLiga = L.CodLiga where P.CodPartido = @CodPartido)
	declare @codEqL int
	set @codEqL = (select P.CodEquipoL from Partido P where P.CodPartido = @CodPartido)
	declare @codEqV int
	set @codEqV = (select P.CodEquipoV from Partido P where P.CodPartido = @CodPartido)
	if(@GolesLocal>@GolesVisita)
	begin
		UPDATE	[SISPPAFUT].[dbo].[Tabla]
		SET		[PuntosLocal] = PuntosLocal+3
				,[PartidosJugadosLocal] = PartidosJugadosLocal+1
				,[VictoriasLocal] = VictoriasLocal+1
				--,[EmpatesLocal] = <EmpatesLocal, int,>
				--,[DerrotasLocal] = <DerrotasLocal, int,>
				,[GolesAnotadosLocal] = GolesAnotadosLocal+@GolesLocal
				,[GolesEncajadosLocal] = GolesEncajadosLocal+@GolesVisita      
		WHERE	CodLiga = @Liga and
				CodEquipo = @CodEqL
		UPDATE	[SISPPAFUT].[dbo].[Tabla]
		SET		[PartidosJugadosVisita] = PartidosJugadosVisita+1
				--,[VictoriasLocal] = VictoriasLocal+1
				--,[EmpatesLocal] = <EmpatesLocal, int,>
				,[DerrotasVisita] = DerrotasVisita + 1
				,[GolesAnotadosVisita] = GolesAnotadosVisita+@GolesVisita
				,[GolesEncajadosVisita] = GolesEncajadosVisita+@GolesLocal
		WHERE	CodLiga = @Liga and
				CodEquipo = @codEqV
	end
	else
	if(@GolesLocal < @GolesVisita)
	begin
	--begin derrota del local
		UPDATE	[SISPPAFUT].[dbo].[Tabla]
		SET		[PuntosVisita] = PuntosVisita+3
				,[PartidosJugadosVisita] = PartidosJugadosVisita+1
				,[VictoriasVisita] = VictoriasVisita+1
				--,[EmpatesLocal] = <EmpatesLocal, int,>
				--,[DerrotasLocal] = <DerrotasLocal, int,>
				,[GolesAnotadosVisita] = GolesAnotadosVisita+@GolesVisita
				,[GolesEncajadosVisita] = GolesEncajadosVisita+@GolesLocal
		WHERE	CodLiga = @Liga and
				CodEquipo = @codEqV
		UPDATE	[SISPPAFUT].[dbo].[Tabla]
		SET		[PartidosJugadosLocal] = PartidosJugadosLocal+1
				--,[VictoriasLocal] = VictoriasLocal+1
				--,[EmpatesLocal] = <EmpatesLocal, int,>
				,[DerrotasLocal] = DerrotasLocal + 1
				,[GolesAnotadosLocal] = GolesAnotadosLocal+@GolesLocal
				,[GolesEncajadosLocal] = GolesEncajadosLocal+@GolesVisita
		WHERE	CodLiga = @Liga and
				CodEquipo = @codEqL
	--end derrota del local
	end
	else
	if(@GolesLocal = @GolesVisita)
	begin
	--begin empate
		UPDATE	[SISPPAFUT].[dbo].[Tabla]
		SET		[PuntosLocal] = PuntosLocal +1
				,[PartidosJugadosLocal] = PartidosJugadosLocal+1
				,[EmpatesLocal] = EmpatesLocal+1
				,[GolesAnotadosLocal] = GolesAnotadosLocal+@GolesLocal
				,[GolesEncajadosLocal] = GolesEncajadosLocal +@GolesVisita
		WHERE	CodLiga = @Liga and
				CodEquipo = @codEqL
		UPDATE	[SISPPAFUT].[dbo].[Tabla]
		SET		[PuntosVisita] = PuntosVisita +1
				,[PartidosJugadosVisita] = PartidosJugadosVisita+1
				,[EmpatesVisita] = EmpatesVisita+1
				,[GolesAnotadosVisita] = GolesAnotadosVisita+@GolesVisita
				,[GolesEncajadosVisita] = GolesEncajadosVisita+@GolesLocal
		WHERE	CodLiga = @Liga and
				CodEquipo = @codEqV
	--end empate
	end
END

GO


