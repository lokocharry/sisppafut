using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.DL.DALC
{
    public class SuspensionDALC
    {
        public void crear_Suspension(SuspensionBE objSuspensionBE)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_CrearSuspension;
            SqlParameter prm_codJugador;
            SqlParameter prm_codLiga;
            String sqlSuspensionCrear;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlSuspensionCrear = "spCreateSuspensionXJugador";

                cmd_CrearSuspension = new SqlCommand(sqlSuspensionCrear, conexion);
                cmd_CrearSuspension.CommandType = CommandType.StoredProcedure;

                prm_codJugador = new SqlParameter();
                prm_codJugador.ParameterName = "@CodJugador";
                prm_codJugador.SqlDbType = SqlDbType.Int;
                prm_codJugador.Value = objSuspensionBE.CodigoJugador;

                prm_codLiga = new SqlParameter();
                prm_codLiga.ParameterName = "@CodLiga";
                prm_codLiga.SqlDbType = SqlDbType.Int;
                prm_codLiga.Value = objSuspensionBE.CodLiga;

                cmd_CrearSuspension.Parameters.Add(prm_codJugador);
                cmd_CrearSuspension.Parameters.Add(prm_codLiga);

                cmd_CrearSuspension.Connection.Open();
                cmd_CrearSuspension.ExecuteNonQuery();
            }
            catch (Exception)
            {
                conexion.Dispose();
                throw;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Dispose();
                    conexion = null;
                }
            }
        }

        public void actualizar_Suspension(int codJugador, int codLiga, int tipo)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_ActualizarSuspension;

            SqlParameter prm_Codigo;
            SqlParameter prm_Liga;
            SqlParameter prm_Tipo;

            String sqlSuspensionActualizar;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlSuspensionActualizar = "spActualizarSuspension";

                cmd_ActualizarSuspension = new SqlCommand(sqlSuspensionActualizar, conexion);
                cmd_ActualizarSuspension.CommandType = CommandType.StoredProcedure;

                prm_Codigo = new SqlParameter();
                prm_Codigo.ParameterName = "@CodJugador";
                prm_Codigo.SqlDbType = SqlDbType.Int;
                prm_Codigo.Value = codJugador;

                prm_Liga = new SqlParameter();
                prm_Liga.ParameterName = "@CodLiga";
                prm_Liga.SqlDbType = SqlDbType.Int;
                prm_Liga.Value = codLiga;

                prm_Tipo = new SqlParameter();
                prm_Tipo.ParameterName = "@Tipo";
                prm_Tipo.SqlDbType = SqlDbType.Int;
                prm_Tipo.Value = tipo;

                cmd_ActualizarSuspension.Parameters.Add(prm_Codigo);
                cmd_ActualizarSuspension.Parameters.Add(prm_Liga);
                cmd_ActualizarSuspension.Parameters.Add(prm_Tipo);

                cmd_ActualizarSuspension.Connection.Open();
                cmd_ActualizarSuspension.ExecuteNonQuery();
            }
            catch (Exception)
            {
                conexion.Dispose();
                throw;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Dispose();
                    conexion = null;
                }
            }
        }

        public String leer_EstadoSuspension(int codJugador, int codLiga)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_LeerEstadoSuspension = null;
            SqlParameter prm_Codigo;
            SqlParameter prm_Liga;
            String sqlReadSuspension;
            String sEstado = null;
            SqlDataReader dr_suspension;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlReadSuspension = "spReadEstadoSuspension";

                cmd_LeerEstadoSuspension = new SqlCommand(sqlReadSuspension, conexion);
                cmd_LeerEstadoSuspension.CommandType = CommandType.StoredProcedure;

                prm_Codigo = new SqlParameter();
                prm_Codigo.ParameterName = "@CodJugador";
                prm_Codigo.SqlDbType = SqlDbType.Int;
                prm_Codigo.Value = codJugador;

                prm_Liga = new SqlParameter();
                prm_Liga.ParameterName = "@CodLiga";
                prm_Liga.SqlDbType = SqlDbType.Int;
                prm_Liga.Value = codJugador;

                cmd_LeerEstadoSuspension.Parameters.Add(prm_Codigo);
                cmd_LeerEstadoSuspension.Parameters.Add(prm_Liga);
                cmd_LeerEstadoSuspension.Connection.Open();
                dr_suspension = cmd_LeerEstadoSuspension.ExecuteReader();

                if (dr_suspension.Read())
                {
                    sEstado = dr_suspension.GetString(dr_suspension.GetOrdinal("Estado de suspensión"));
                }
                return sEstado;
            }
            catch (Exception)
            {
                conexion.Dispose();
                throw;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Dispose();
                    conexion = null;
                }
            }
        }

        //Esta funcion no dice si el Jugador ha sido suspendido alguna vez...
        public int jugadorHaSidoSuspendido(int codJugador)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_ExisteSuspension = null;
            SqlParameter prm_Codigo;
            String sqlExisteSuspension;
            SqlDataReader dr_suspension;

            int suspendido = 0;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlExisteSuspension = "spVerificarExisteSuspension";

                cmd_ExisteSuspension = new SqlCommand(sqlExisteSuspension, conexion);
                cmd_ExisteSuspension.CommandType = CommandType.StoredProcedure;

                prm_Codigo = new SqlParameter();
                prm_Codigo.ParameterName = "@CodJugador";
                prm_Codigo.SqlDbType = SqlDbType.Int;
                prm_Codigo.Value = codJugador;

                cmd_ExisteSuspension.Parameters.Add(prm_Codigo);
                cmd_ExisteSuspension.Connection.Open();
                dr_suspension = cmd_ExisteSuspension.ExecuteReader();

                if (dr_suspension.Read())
                {
                    suspendido = dr_suspension.GetInt32(dr_suspension.GetOrdinal("Resultado"));
                }

                return suspendido;
            }
            catch (Exception)
            {
                conexion.Dispose();
                throw;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Dispose();
                    conexion = null;
                }
            }
        }

        public Boolean consultar_ArqueroSuspendido(int codEquipo, int codLiga)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            SqlParameter prm_CodEquipo;
            SqlParameter prm_CodLiga;
            String sqlReadArqueroSuspension;
            String sEstado = null;
            SqlDataReader dr;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlReadArqueroSuspension = "spArqueroSuspendido";

                cmd = new SqlCommand(sqlReadArqueroSuspension, conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                prm_CodEquipo = new SqlParameter();
                prm_CodEquipo.ParameterName = "@CodEquipo";
                prm_CodEquipo.SqlDbType = SqlDbType.Int;
                prm_CodEquipo.Value = codEquipo;

                prm_CodLiga = new SqlParameter();
                prm_CodLiga.ParameterName = "@CodLiga";
                prm_CodLiga.SqlDbType = SqlDbType.Int;
                prm_CodLiga.Value = codLiga;

                cmd.Parameters.Add(prm_CodEquipo);
                cmd.Parameters.Add(prm_CodLiga);

                cmd.Connection.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    sEstado = dr.GetString(dr.GetOrdinal("Estado de suspensión"));
                }

                if (sEstado == "NO SUSPENDIDO")
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {
                conexion.Dispose();
                throw;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Dispose();
                    conexion = null;
                }
            }
        }

        public Boolean consultar_GoleadorSuspendido(int codEquipo, int codLiga)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            SqlParameter prm_CodEquipo;
            SqlParameter prm_CodLiga;
            String sqlReadGoleadorSuspension;
            String sEstado = null;
            SqlDataReader dr;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlReadGoleadorSuspension = "spGoleadorSuspendido";

                cmd = new SqlCommand(sqlReadGoleadorSuspension, conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                prm_CodEquipo = new SqlParameter();
                prm_CodEquipo.ParameterName = "@CodEquipo";
                prm_CodEquipo.SqlDbType = SqlDbType.Int;
                prm_CodEquipo.Value = codEquipo;

                prm_CodLiga = new SqlParameter();
                prm_CodLiga.ParameterName = "@CodLiga";
                prm_CodLiga.SqlDbType = SqlDbType.Int;
                prm_CodLiga.Value = codLiga;

                cmd.Parameters.Add(prm_CodEquipo);
                cmd.Parameters.Add(prm_CodLiga);

                cmd.Connection.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    sEstado = dr.GetString(dr.GetOrdinal("Estado de suspensión"));
                }

                if (sEstado == "NO SUSPENDIDO")
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {
                conexion.Dispose();
                throw;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Dispose();
                    conexion = null;
                }
            }
        }

        public List<SuspensionBE> CantidadJugadoresSuspendidos(int codEquipo, int codLiga)
        {
            SqlConnection conexion = null;
            SqlDataReader dr;
            SqlCommand cmd = null;
            String sql;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sql = "spAcumulacionAmonestacionesJugador";
                cmd = conexion.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection.Open();
                dr = cmd.ExecuteReader();

                List<SuspensionBE> lst;
                SuspensionBE objBE;

                lst = new List<SuspensionBE>();

                while (dr.Read())
                {
                    objBE = new SuspensionBE();

                    objBE.CodigoJugador = dr.GetInt32(dr.GetOrdinal("CodJugador"));
                    objBE.QAmarillas = dr.GetInt32(dr.GetOrdinal("qAmonestaciones"));
                    
                    lst.Add(objBE);
                }

                return lst;
            }

            catch (Exception)
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                    conexion.Dispose();
                }

                throw;
            }

            finally
            {
                cmd.Connection.Close();
                conexion.Dispose();
            }
        }
    }
}
