USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spCreateEquipo]    Script Date: 07/16/2012 16:39:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spCreateEquipo]
(
	@codPais int,
	@nombre varchar(20),
	@anioFundacion int,
	@ciudad varchar (20),
	@codEstadioPrincipal int,
	@codEstadioAlterno int
)
as
begin
if(@codEstadioAlterno = null)
begin
INSERT INTO [SISPPAFUT].[dbo].[Equipo]
           ([CodPais]
           ,[Nombre]
           ,[AnioFundacion]
           ,[Ciudad]
           ,[CodEstadioPrincipal]
           ,[CodEstadioAlterno])
     VALUES
           (@codPais
           ,@nombre
           ,@anioFundacion
           ,@ciudad
           ,@codEstadioPrincipal
           ,null)
end
else
INSERT INTO [SISPPAFUT].[dbo].[Equipo]
           ([CodPais]
           ,[Nombre]
           ,[AnioFundacion]
           ,[Ciudad]
           ,[CodEstadioPrincipal]
           ,[CodEstadioAlterno])
     VALUES
           (@codPais
           ,@nombre
           ,@anioFundacion
           ,@ciudad
           ,@codEstadioPrincipal
           ,@codEstadioAlterno)
    return @@identity
end

GO


