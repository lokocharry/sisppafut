USE [SISPPAFUT]
GO
/****** Object:  StoredProcedure [dbo].[spCreatePronostico]    Script Date: 29/05/2012 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spCreatePronostico]
(
	@codPartido int,
	@pronostico varchar(5),
	@porcentajeLocal decimal(5,2),
	@porcentajeEmpate decimal(5,2),
	@porcentajeVisita decimal(5,2)
)
as
begin
INSERT INTO [SISPPAFUT].[dbo].Pronostico
           ([CodPartido]
           ,[Pronostico]
           ,[PorcentajeLocal]
           ,[PorcentajeEmpate]
           ,[PorcentajeVisita])
     VALUES
           (@codPartido
           ,@pronostico
           ,@porcentajeLocal
           ,@porcentajeEmpate
           ,@porcentajeVisita)
    return @@identity
end