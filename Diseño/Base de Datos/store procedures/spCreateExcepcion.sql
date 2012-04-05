USE [SISPPAFUT]
GO

/****** Object:  StoredProcedure [dbo].[uspInsertarExcepcion]    Script Date: 04/05/2012 12:19:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[spCreateExcepcion]
(
	@Mensaje varchar(8000),
	@StackTrace varchar(8000),
	@FechaCliente Datetime,
	@CodUsuario int,
	@IPCliente varchar(30)
)
AS
BEGIN
	
	INSERT INTO
		Excepcion
		(
			Mensaje,
			StackTrace,
			FechaCliente,
			FechaServidor,
			CodUsuario,	
			IPCliente
		)
	VALUES
		(
			@Mensaje,
			@StackTrace,
			@FechaCliente,
			getdate(),
			@CodUsuario,	
			@IPCliente
		)

	RETURN @@IDENTITY
END

GO


