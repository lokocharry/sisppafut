USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spCreateCompeticion]    Script Date: 03/28/2012 22:25:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[spCreateCompeticion]
(
	@codPais int,
	@nombre varchar(20)
)
as
begin
INSERT INTO [SISPPAFUT].[dbo].[Competicion]
           ([CodPais]
           ,[Nombre])
     VALUES
           (@codPais
           ,@nombre)
     return @@identity
end

GO

