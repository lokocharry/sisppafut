USE [SISPPAFUT]
GO
/****** Object:  StoredProcedure [dbo].[spCreateLog]    Script Date: 04/05/2012 13:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spCreateLog]
(
			@CodOperacion int
           ,@Tabla varchar(50)
           ,@Usuario varchar(50)          
           ,@IP varchar(23)
           ,@Razon varchar(500)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    INSERT INTO [SISPPAFUT].[dbo].[Log]
           ([CodOperacion]
           ,[Tabla]
           ,[Usuario]
           ,[Fecha]
           ,[IP]
           ,[Razon])
     VALUES
           (
			@CodOperacion,
			@Tabla,
			@Usuario,
			GETDATE(),
			@IP,
			@Razon
           )
END

