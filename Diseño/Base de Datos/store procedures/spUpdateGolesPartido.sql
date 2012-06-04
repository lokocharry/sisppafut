USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spUpdateGolesPartido]    Script Date: 06/04/2012 16:16:21 ******/
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
END
GO

