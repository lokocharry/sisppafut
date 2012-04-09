USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spListarCompeticion]    Script Date: 04/09/2012 13:17:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spListarCompeticion]
(
	@Pais varchar (20)
)
as
begin
	select c.Nombre, c.CodCompeticion
	from Competicion c join Pais p on c.CodPais = p.CodPais
	where p.Nombre = @Pais
end
GO


