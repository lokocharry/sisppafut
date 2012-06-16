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
        public void crear_Suspension(int codJugador)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_CrearSuspension;
            SqlParameter prm_Codigo;
            String sqlSuspensionCrear;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlSuspensionCrear = "spCreateSuspensionXJugador";

                cmd_CrearSuspension = new SqlCommand(sqlSuspensionCrear, conexion);
                cmd_CrearSuspension.CommandType = CommandType.StoredProcedure;

                prm_Codigo = new SqlParameter();
                prm_Codigo.ParameterName = "@CodJugador";
                prm_Codigo.SqlDbType = SqlDbType.Int;
                prm_Codigo.Value = codJugador;

                cmd_CrearSuspension.Parameters.Add(prm_Codigo);

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

        public void actualizar_Suspension(int codJugador, int tipo)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_ActualizarSuspension;

            SqlParameter prm_Codigo;
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

                prm_Tipo = new SqlParameter();
                prm_Tipo.ParameterName = "@Tipo";
                prm_Tipo.SqlDbType = SqlDbType.Int;
                prm_Tipo.Value = tipo;

                cmd_ActualizarSuspension.Parameters.Add(prm_Codigo);
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

        public String leer_EstadoSuspension(int codJugador)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_LeerEstadoSuspension = null;
            SqlParameter prm_Codigo;
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

                cmd_LeerEstadoSuspension.Parameters.Add(prm_Codigo);
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

    }
}
