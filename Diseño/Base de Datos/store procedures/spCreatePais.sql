USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[spCreatePais]    Script Date: 03/28/2012 22:27:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[spCreatePais]
(
	@nombre varchar(20)
)
as
begin
INSERT INTO [SISPPAFUT].[dbo].[Pais]
           ([Nombre])
     VALUES
           (@nombre)
     return @@identity
end

GO

