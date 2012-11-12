using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.DL.DALC
{
    public class LesionPartidoDALC
    {
        public void insertar_LesionPartido(LesionPartidoBE objLesionPartidoBE)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_InsertarLesion = null;

            SqlParameter prm_CodigoPartido;
            SqlParameter prm_CodigoJugador;
            SqlParameter prm_Tipo;
            SqlParameter prm_TiempoDescanso;

            String sqlInsertarLesion;

            try
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);

                sqlInsertarLesion = "spCreateLesionPartido";

                cmd_InsertarLesion = new SqlCommand(sqlInsertarLesion, conexion);
                cmd_InsertarLesion.CommandType = CommandType.StoredProcedure;

                prm_CodigoJugador = new SqlParameter();
                prm_CodigoJugador.ParameterName = "@CodJugador";
                prm_CodigoJugador.SqlDbType = SqlDbType.Int;
                prm_CodigoJugador.Value = objLesionPartidoBE.Codigo_jugador;

                prm_CodigoPartido = new SqlParameter();
                prm_CodigoPartido.ParameterName = "@CodPartido";
                prm_CodigoPartido.SqlDbType = SqlDbType.Int;
                prm_CodigoPartido.Value = objLesionPartidoBE.Codigo_partido;

                prm_TiempoDescanso = new SqlParameter();
                prm_TiempoDescanso.ParameterName = "@Tiempodescanso";
                prm_TiempoDescanso.SqlDbType = SqlDbType.Int;
                prm_TiempoDescanso.Value = objLesionPartidoBE.Dias_descanso;

                prm_Tipo = new SqlParameter();
                prm_Tipo.ParameterName = "@Tipo";
                prm_Tipo.SqlDbType = SqlDbType.VarChar;
                prm_Tipo.Size = 20;
                prm_Tipo.Value = objLesionPartidoBE.Tipo_lesion;

                cmd_InsertarLesion.Parameters.Add(prm_CodigoJugador);
                cmd_InsertarLesion.Parameters.Add(prm_CodigoPartido);
                cmd_InsertarLesion.Parameters.Add(prm_TiempoDescanso);
                cmd_InsertarLesion.Parameters.Add(prm_Tipo);

                cmd_InsertarLesion.Connection.Open();
                cmd_InsertarLesion.ExecuteNonQuery();
            }

            catch (Exception)
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Dispose();
                }

                throw;
            }

            finally
            {
                cmd_InsertarLesion.Connection.Close();
                conexion.Dispose();
            }
        }
    }
}
