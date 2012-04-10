-- Creación de logins
-- Usuario: 
--			Administrador del Sistema: es el usuario que interactúa con el sistema y el que deberá suministrar de data a la base de datos histórica.
--			Maestro/Supervisor: es el usuario que solo se encargará de entrenar al sistema.
--			Apostador: es el usuario que solo dispondrá de la opción de ver pronósticos.
--			Equipo: son los usuarios que desarrollan el sistema.

CREATE LOGIN SISPPAFUTequipo
	with Password = 'equipo';
	
CREATE LOGIN SISPPAFUTadmin
	with Password = 'admin';

CREATE LOGIN SISPPAFUTmaestro
	with Password = 'maestro';

CREATE LOGIN SISPPAFUTapostador
	with Password = 'apostador';

USE SISPPAFUT;
GO

CREATE USER equipo for LOGIN SISPPAFUTequipo;
GO

ALTER USER equipo with DEFAULT_SCHEMA = dbo;
GO

CREATE USER adminn for LOGIN SISPPAFUTadmin;
GO

CREATE SCHEMA administrador AUTHORIZATION dbo
	GRANT EXECUTE ON OBJECT::dbo.spCreateCompeticion TO adminn
	GRANT EXECUTE ON OBJECT::dbo.spCreateEquipo TO adminn
	GRANT EXECUTE ON OBJECT::dbo.spCreateEstadio TO adminn
	GRANT EXECUTE ON OBJECT::dbo.spCreateExcepcion TO adminn
	GRANT EXECUTE ON OBJECT::dbo.spCreateLiga TO adminn
	GRANT EXECUTE ON OBJECT::dbo.spCreateLigaEquipo TO adminn
	GRANT EXECUTE ON OBJECT::dbo.spCreateLog TO adminn
	GRANT EXECUTE ON OBJECT::dbo.spCreatePais TO adminn
	GRANT EXECUTE ON OBJECT::dbo.spEquipoVerificarRepetido TO adminn
	GRANT EXECUTE ON OBJECT::dbo.spLigaVerificarRepetido TO adminn
	GRANT EXECUTE ON OBJECT::dbo.spListarCompeticion TO adminn
	GRANT EXECUTE ON OBJECT::dbo.spListarEquipos TO adminn
	GRANT EXECUTE ON OBJECT::dbo.spListarEstadios TO adminn
	GRANT EXECUTE ON OBJECT::dbo.spListarEstadiosDeEquipo TO adminn
	GRANT EXECUTE ON OBJECT::dbo.spListarLigas TO adminn
	GRANT EXECUTE ON OBJECT::dbo.spListarPaises TO adminn
	GRANT EXECUTE ON OBJECT::dbo.spPaisVerificarRepetido TO adminn
	GRANT EXECUTE ON OBJECT::dbo.spReadEquipo TO adminn



GO

ALTER USER adminn with DEFAULT_SCHEMA = administrador;
GO

