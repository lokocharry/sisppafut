USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spCreateEstadio]    Script Date: 03/28/2012 22:26:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[spCreateEstadio]
(
	@codPais int,
	@anioFundacion int,
	@nombre varchar(20),
	@ciudad varchar(20),
	@aforo int
)
as
begin
INSERT INTO [SISPPAFUT].[dbo].[Estadio]
           ([CodPais]
           ,[AnioFundacion]
           ,[Nombre]
           ,[Ciudad]
           ,[Aforo])
     VALUES
           (@codPais
           ,@anioFundacion
           ,@nombre
           ,@ciudad
           ,@aforo)
    return @@identity
end

GO

