using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.DL.DALC
{
    public class EquipoDALC
    {
        public int insertar_Equipo(EquipoBE objEquipoBE)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_EquipoInsertar;

            SqlParameter prm_Codigo;
            SqlParameter prm_CodigoPais;
            SqlParameter prm_Nombre;
            SqlParameter prm_AnioFundacion;
            SqlParameter prm_Ciudad;
            SqlParameter prm_CodigoEstadioPrincipal;
            SqlParameter prm_CodigoEstadioAlterno;

            int iCodigoEquipo;

            String sqlEquipoInsertar;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);

                sqlEquipoInsertar = "spCreateEquipo";

                cmd_EquipoInsertar = new SqlCommand(sqlEquipoInsertar, conexion);
                cmd_EquipoInsertar.CommandType = CommandType.StoredProcedure;

                prm_Codigo = new SqlParameter();
                prm_Codigo.Direction = ParameterDirection.ReturnValue;
                prm_Codigo.SqlDbType = SqlDbType.Int;

                prm_CodigoPais = new SqlParameter();
                prm_CodigoPais.ParameterName = "@codPais";
                prm_CodigoPais.SqlDbType = SqlDbType.Int;
                prm_CodigoPais.Value = objEquipoBE.CodigoPais;

                prm_Nombre = new SqlParameter();
                prm_Nombre.ParameterName = "@nombre";
                prm_Nombre.SqlDbType = SqlDbType.VarChar;
                prm_Nombre.Size = 20;
                prm_Nombre.Value = objEquipoBE.NombreEquipo;

                prm_AnioFundacion = new SqlParameter();
                prm_AnioFundacion.ParameterName = "@anioFundacion";
                prm_AnioFundacion.SqlDbType = SqlDbType.Int;
                prm_AnioFundacion.Value = objEquipoBE.AnioFundacion;

                prm_Ciudad = new SqlParameter();
                prm_Ciudad.ParameterName = "@ciudad";
                prm_Ciudad.SqlDbType = SqlDbType.VarChar;
                prm_Ciudad.Size = 20;
                prm_Ciudad.Value = objEquipoBE.CiudadEquipo;

                prm_CodigoEstadioPrincipal = new SqlParameter();
                prm_CodigoEstadioPrincipal.ParameterName = "@codEstadioPrincipal";
                prm_CodigoEstadioPrincipal.SqlDbType = SqlDbType.Int;
                prm_CodigoEstadioPrincipal.Value = objEquipoBE.CodigoEstadioPrincipal;

                prm_CodigoEstadioAlterno = new SqlParameter();
                prm_CodigoEstadioAlterno.ParameterName = "@codEstadioAlterno";
                prm_CodigoEstadioAlterno.SqlDbType = SqlDbType.Int;
                if (objEquipoBE.CodigoEstadioAlterno != 0)
                {
                    prm_CodigoEstadioAlterno.Value = objEquipoBE.CodigoEstadioAlterno;
                }
                else
                {
                    prm_CodigoEstadioAlterno.Value = DBNull.Value;
                }

                cmd_EquipoInsertar.Parameters.Add(prm_Codigo);
                cmd_EquipoInsertar.Parameters.Add(prm_CodigoPais);
                cmd_EquipoInsertar.Parameters.Add(prm_Nombre);
                cmd_EquipoInsertar.Parameters.Add(prm_AnioFundacion);
                cmd_EquipoInsertar.Parameters.Add(prm_Ciudad);
                cmd_EquipoInsertar.Parameters.Add(prm_CodigoEstadioPrincipal);
                cmd_EquipoInsertar.Parameters.Add(prm_CodigoEstadioAlterno);

                cmd_EquipoInsertar.Connection.Open();
                cmd_EquipoInsertar.ExecuteNonQuery();

                iCodigoEquipo = Convert.ToInt32(prm_Codigo.Value);

                return iCodigoEquipo;
            }
            catch (Exception)
            {
                //cmd_EquipoInsertar.Connection.Close();
                conexion.Dispose();
                throw;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    //cmd_EquipoInsertar.Connection.Close();
                    conexion.Dispose();
                    conexion = null;
                }
            }
        }

        public int existe_Equipo(String nombre)
        {
            SqlConnection conexion = null;
            SqlDataReader dr_equipo;
            SqlCommand cmd_EquipoValidar;
            String sqlEquipoValidar;
            SqlParameter prm_Nombre;

            int cantidad = 0;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlEquipoValidar = "spEquipoVerificarRepetido";

                cmd_EquipoValidar = new SqlCommand(sqlEquipoValidar, conexion);
                cmd_EquipoValidar.CommandType = CommandType.StoredProcedure;

                prm_Nombre = new SqlParameter();
                prm_Nombre.ParameterName = "@Nombre";
                prm_Nombre.SqlDbType = SqlDbType.VarChar;
                prm_Nombre.Size = 20;
                prm_Nombre.Value = nombre;

                cmd_EquipoValidar.Parameters.Add(prm_Nombre);

                cmd_EquipoValidar.Connection.Open();
                dr_equipo = cmd_EquipoValidar.ExecuteReader();

                if (dr_equipo.Read())
                {
                    cantidad = dr_equipo.GetInt32(dr_equipo.GetOrdinal("Cantidad"));
                }

                cmd_EquipoValidar.Connection.Close();
                conexion.Dispose();

                return cantidad;
            }
            catch (Exception ex)
            {
                conexion.Dispose();
                throw;
            }
        }

        public List<EquipoBE> listar_Equipos(String Pais)
        {
            SqlConnection conexion = null;
            SqlDataReader dr_equipos;
            SqlCommand cmd_equipos;
            String sqlEquiposListar;
            SqlParameter _Pais;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlEquiposListar = "spListarEquipos";
                cmd_equipos = conexion.CreateCommand();
                cmd_equipos.CommandText = sqlEquiposListar;
                cmd_equipos.CommandType = CommandType.StoredProcedure;

                _Pais = cmd_equipos.CreateParameter();
                _Pais.ParameterName = "@Pais";
                _Pais.SqlDbType = SqlDbType.VarChar;
                _Pais.Size = 20;
                _Pais.SqlValue = Pais;

                cmd_equipos.Parameters.Add(_Pais);

                cmd_equipos.Connection.Open();
                dr_equipos = cmd_equipos.ExecuteReader();

                List<EquipoBE> lista_equipos;
                EquipoBE objEquipoBE;

                lista_equipos = new List<EquipoBE>();

                while (dr_equipos.Read())
                {
                    objEquipoBE = new EquipoBE();

                    objEquipoBE.CodigoEquipo = dr_equipos.GetInt32(dr_equipos.GetOrdinal("CodEquipo"));
                    objEquipoBE.CodigoPais = dr_equipos.GetInt32(dr_equipos.GetOrdinal("CodPais"));
                    objEquipoBE.NombreEquipo = dr_equipos.GetString(dr_equipos.GetOrdinal("Nombre"));
                    objEquipoBE.AnioFundacion = dr_equipos.GetInt32(dr_equipos.GetOrdinal("AnioFundacion"));
                    objEquipoBE.CiudadEquipo = dr_equipos.GetString(dr_equipos.GetOrdinal("Ciudad"));
                    objEquipoBE.CodigoEstadioPrincipal = dr_equipos.GetInt32(dr_equipos.GetOrdinal("CodEstadioPrincipal"));
                    if (dr_equipos.GetInt32(dr_equipos.GetOrdinal("CodEstadioAlterno")) != 0)
                        objEquipoBE.CodigoEstadioAlterno = dr_equipos.GetInt32(dr_equipos.GetOrdinal("CodEstadioAlterno"));
                    else
                        objEquipoBE.CodigoEstadioAlterno = 0;

                    lista_equipos.Add(objEquipoBE);
                }

                cmd_equipos.Connection.Close();
                conexion.Dispose();

                return lista_equipos;
            }

            catch (Exception ex)
            {
                conexion.Dispose();
                throw;
            }

        }

        public List<EquipoBE> listar_EquiposDeLiga(int codigoLiga)
        {
            SqlConnection conexion = null;
            SqlDataReader dr_equipos;
            SqlCommand cmd_equipos;
            String sqlEquiposListar;
            SqlParameter _Liga;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlEquiposListar = "spListarEquiposDeLiga";
                cmd_equipos = conexion.CreateCommand();
                cmd_equipos.CommandText = sqlEquiposListar;
                cmd_equipos.CommandType = CommandType.StoredProcedure;

                _Liga = cmd_equipos.CreateParameter();
                _Liga.ParameterName = "@CodigoLiga";
                _Liga.SqlDbType = SqlDbType.Int;
                _Liga.SqlValue = codigoLiga;

                cmd_equipos.Parameters.Add(_Liga);

                cmd_equipos.Connection.Open();
                dr_equipos = cmd_equipos.ExecuteReader();

                List<EquipoBE> lista_equipos;
                EquipoBE objEquipoBE;

                lista_equipos = new List<EquipoBE>();

                while (dr_equipos.Read())
                {
                    objEquipoBE = new EquipoBE();

                    objEquipoBE.CodigoEquipo = dr_equipos.GetInt32(dr_equipos.GetOrdinal("CodEquipo"));
                    objEquipoBE.CodigoPais = dr_equipos.GetInt32(dr_equipos.GetOrdinal("CodPais"));
                    objEquipoBE.NombreEquipo = dr_equipos.GetString(dr_equipos.GetOrdinal("Nombre"));
                    objEquipoBE.AnioFundacion = dr_equipos.GetInt32(dr_equipos.GetOrdinal("AnioFundacion"));
                    objEquipoBE.CiudadEquipo = dr_equipos.GetString(dr_equipos.GetOrdinal("Ciudad"));
                    objEquipoBE.CodigoEstadioPrincipal = dr_equipos.GetInt32(dr_equipos.GetOrdinal("CodEstadioPrincipal"));
                    if (dr_equipos.GetInt32(dr_equipos.GetOrdinal("CodEstadioAlterno")) != 0)
                        objEquipoBE.CodigoEstadioAlterno = dr_equipos.GetInt32(dr_equipos.GetOrdinal("CodEstadioAlterno"));
                    else
                        objEquipoBE.CodigoEstadioAlterno = 0;

                    lista_equipos.Add(objEquipoBE);
                }

                cmd_equipos.Connection.Close();
                conexion.Dispose();

                return lista_equipos;
            }

            catch (Exception ex)
            {
                conexion.Dispose();
                throw;
            }

        }

        public EquipoBE obtener_Equipo(String Equipo)
        {
            SqlConnection conexion = null;
            SqlDataReader dr_equipo;
            SqlCommand cmd;
            String sqlEquipoObtener;
            SqlParameter _Equipo;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlEquipoObtener = "spReadEquipo";
                cmd = conexion.CreateCommand();
                cmd.CommandText = sqlEquipoObtener;
                cmd.CommandType = CommandType.StoredProcedure;

                _Equipo = cmd.CreateParameter();
                _Equipo.ParameterName = "@Nombre";
                _Equipo.SqlDbType = SqlDbType.VarChar;
                _Equipo.Size = 20;
                _Equipo.SqlValue = Equipo;

                cmd.Parameters.Add(_Equipo);

                cmd.Connection.Open();
                dr_equipo = cmd.ExecuteReader();

                EquipoBE objEquipoBE;

                objEquipoBE = new EquipoBE();

                if (dr_equipo.Read())
                {
                    objEquipoBE.CodigoEquipo = dr_equipo.GetInt32(dr_equipo.GetOrdinal("CodEquipo"));
                    objEquipoBE.CodigoPais = dr_equipo.GetInt32(dr_equipo.GetOrdinal("CodPais"));
                    objEquipoBE.NombreEquipo = dr_equipo.GetString(dr_equipo.GetOrdinal("Nombre"));
                    objEquipoBE.AnioFundacion = dr_equipo.GetInt32(dr_equipo.GetOrdinal("AnioFundacion"));
                    objEquipoBE.CiudadEquipo = dr_equipo.GetString(dr_equipo.GetOrdinal("Ciudad"));
                    objEquipoBE.CodigoEstadioPrincipal = dr_equipo.GetInt32(dr_equipo.GetOrdinal("CodEstadioPrincipal"));
                    objEquipoBE.CodigoEstadioAlterno = dr_equipo.GetInt32(dr_equipo.GetOrdinal("CodEstadioAlterno"));
                }

                cmd.Connection.Close();
                conexion.Dispose();

                return objEquipoBE;
            }
            catch (Exception ex)
            {
                conexion.Dispose();
                throw;
            }

        }

        public void actualizar_equipo(int codigo_equipo, int codigo_estadioPrincipal, int codigo_estadioAlterno)
        {
            SqlConnection conexion = null;
            SqlCommand cmd;
            String sqlEquipoEditar;
            SqlParameter prm_equipo;
            SqlParameter prm_estadioPrincipal;
            SqlParameter prm_estadioAlterno;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlEquipoEditar = "spUpdateEquipo";
                cmd = new SqlCommand(sqlEquipoEditar, conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                prm_equipo = new SqlParameter();
                prm_equipo.ParameterName = "@CodEquipo";
                prm_equipo.SqlDbType = SqlDbType.Int;
                prm_equipo.SqlValue = codigo_equipo;

                prm_estadioPrincipal = new SqlParameter();
                prm_estadioPrincipal.ParameterName = "@CodEstadioPrincipal";
                prm_estadioPrincipal.SqlDbType = SqlDbType.Int;
                if (codigo_estadioPrincipal != 0)
                {
                    prm_estadioPrincipal.SqlValue = codigo_estadioPrincipal;
                }
                else
                {
                    prm_estadioPrincipal.SqlValue = DBNull.Value;
                }

                prm_estadioAlterno = new SqlParameter();
                prm_estadioAlterno.ParameterName = "@CodEstadioAlterno";
                prm_estadioAlterno.SqlDbType = SqlDbType.Int;
                if (codigo_estadioAlterno != 0)
                {
                    prm_estadioAlterno.SqlValue = codigo_estadioAlterno;
                }
                else
                {
                    prm_estadioAlterno.SqlValue = DBNull.Value;
                }

                cmd.Parameters.Add(prm_equipo);
                cmd.Parameters.Add(prm_estadioPrincipal);
                cmd.Parameters.Add(prm_estadioAlterno);

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                conexion.Dispose();
                throw;
            }
        }

        public Decimal obtener_PromedioEquipoTitular(int codEquipo, int codLiga)
        {
            SqlConnection conexion = null;
            SqlDataReader dr_equipo;
            SqlCommand cmd;
            String sqlObtenerPromEdad;
            SqlParameter _codEquipo;
            SqlParameter _codLiga;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlObtenerPromEdad = "spObtenerPromedioEdadEquipoTitular";
                cmd = conexion.CreateCommand();
                cmd.CommandText = sqlObtenerPromEdad;
                cmd.CommandType = CommandType.StoredProcedure;

                _codEquipo = cmd.CreateParameter();
                _codEquipo.ParameterName = "@codEquipo";
                _codEquipo.SqlDbType = SqlDbType.Int;
                _codEquipo.SqlValue = codEquipo;

                _codLiga = cmd.CreateParameter();
                _codLiga.ParameterName = "@codLiga";
                _codLiga.SqlDbType = SqlDbType.Int;
                _codLiga.SqlValue = codLiga;

                cmd.Parameters.Add(_codEquipo);
                cmd.Parameters.Add(_codLiga);

                cmd.Connection.Open();
                dr_equipo = cmd.ExecuteReader();

                Decimal promedioEdad = 0;

                if (dr_equipo.Read())
                {
                    promedioEdad = dr_equipo.GetDecimal(dr_equipo.GetOrdinal("PROMEDIO"));
                }

                cmd.Connection.Close();
                conexion.Dispose();

                return promedioEdad;
            }
            catch (Exception ex)
            {
                conexion.Dispose();
                throw;
            }

        }

        public int obtener_CantidadExpulsadosUltimoPartido(int codPartido, int codEquipo, int codLiga)
        {
            SqlConnection conexion = null;
            SqlDataReader dr_equipo;
            SqlCommand cmd;
            String sql;
            SqlParameter _codPartido;
            SqlParameter _codEquipo;
            SqlParameter _codLiga;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sql = "spCantidadRojasUltimoPartido";
                cmd = conexion.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;

                _codPartido = cmd.CreateParameter();
                _codPartido.ParameterName = "@codPartido";
                _codPartido.SqlDbType = SqlDbType.Int;
                _codPartido.SqlValue = codPartido;

                _codEquipo = cmd.CreateParameter();
                _codEquipo.ParameterName = "@codEquipo";
                _codEquipo.SqlDbType = SqlDbType.Int;
                _codEquipo.SqlValue = codEquipo;

                _codLiga = cmd.CreateParameter();
                _codLiga.ParameterName = "@codLiga";
                _codLiga.SqlDbType = SqlDbType.Int;
                _codLiga.SqlValue = codLiga;

                cmd.Parameters.Add(_codPartido);
                cmd.Parameters.Add(_codEquipo);
                cmd.Parameters.Add(_codLiga);

                cmd.Connection.Open();
                dr_equipo = cmd.ExecuteReader();

                int qExpulsados = 0;

                if (dr_equipo.Read())
                {
                    qExpulsados = dr_equipo.GetInt32(dr_equipo.GetOrdinal("ROJAS"));
                }

                cmd.Connection.Close();
                conexion.Dispose();

                return qExpulsados;
            }
            catch (Exception ex)
            {
                conexion.Dispose();
                throw;
            }

        }

        public int obtener_CantidadPartidosUltimoMes(int codEquipo, DateTime fecha)
        {
            SqlConnection conexion = null;
            SqlDataReader dr_equipo;
            SqlCommand cmd;
            String sql;
            
            SqlParameter _codEquipo;
            SqlParameter _fecha;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sql = "spCantidadPartidoUltimoMes";
                cmd = conexion.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;

                _codEquipo = cmd.CreateParameter();
                _codEquipo.ParameterName = "@codEquipo";
                _codEquipo.SqlDbType = SqlDbType.Int;
                _codEquipo.SqlValue = codEquipo;

                _fecha = cmd.CreateParameter();
                _fecha.ParameterName = "@Fecha";
                _fecha.SqlDbType = SqlDbType.Date;
                _fecha.SqlValue = fecha;

                cmd.Parameters.Add(_codEquipo);
                cmd.Parameters.Add(_fecha);

                cmd.Connection.Open();
                dr_equipo = cmd.ExecuteReader();

                int qPartidos = 0;

                if (dr_equipo.Read())
                {
                    qPartidos = dr_equipo.GetInt32(dr_equipo.GetOrdinal("NUMERO PARTIDOS"));
                }

                cmd.Connection.Close();
                conexion.Dispose();

                return qPartidos;
            }
            catch (Exception ex)
            {
                conexion.Dispose();
                throw;
            }

        }
    }
}
