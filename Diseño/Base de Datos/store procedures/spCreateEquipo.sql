USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spCreateEquipo]    Script Date: 03/28/2012 22:26:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[spCreateEquipo]
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

