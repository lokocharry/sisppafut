USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spPartidoVerificarCantidad]    Script Date: 05/20/2012 00:44:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Martínez, Meneses
-- Create date: 19/05/2012
-- Description:	Este Store Procedure permire verificar si la cantidad de partidos ya es el límite del permitido
-- =============================================
CREATE PROCEDURE [dbo].[spPartidoVerificarCantidad]
(
	@codLiga int
)
AS
BEGIN
	declare @tPartidos int
	declare @codigoLiga int
	declare @resultado varchar(13)
	set @codigoLiga = @codLiga;
	set @tPartidos = (select (L.QEquipos-1)*L.QEquipos from Liga L where L.CodLiga = @codigoLiga);
	if(@tPartidos > (select COUNT(*) from Partido P where P.CodLiga = @codigoLiga))
    	set @resultado = 'Registrar'
    else
		set @resultado = 'No registrar'
	select @resultado as 'Resultado'
END



GO


