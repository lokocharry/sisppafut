using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.DL.DALC
{
    public class JugadorPartidoDALC
    {
        public void insertarJugadorPartido(JugadorPartidoBE objJugadorPartidoBE)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_InsertarJugador = null;

            SqlParameter prm_CodigoPartido;
            SqlParameter prm_CodigoJugador;
            SqlParameter prm_Estado;

            String sqlInsertarJugador;

            try
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);

                sqlInsertarJugador = "spCreateJugadorPartido";

                cmd_InsertarJugador = new SqlCommand(sqlInsertarJugador, conexion);
                cmd_InsertarJugador.CommandType = CommandType.StoredProcedure;

                prm_CodigoJugador = new SqlParameter();
                prm_CodigoJugador.ParameterName = "@CodJugador";
                prm_CodigoJugador.SqlDbType = SqlDbType.Int;
                prm_CodigoJugador.Value = objJugadorPartidoBE.Codigo_jugador;

                prm_CodigoPartido = new SqlParameter();
                prm_CodigoPartido.ParameterName = "@CodPartido";
                prm_CodigoPartido.SqlDbType = SqlDbType.Int;
                prm_CodigoPartido.Value = objJugadorPartidoBE.Codigo_partido;

                prm_Estado = new SqlParameter();
                prm_Estado.ParameterName = "@Estado";
                prm_Estado.SqlDbType = SqlDbType.Int;
                prm_Estado.Value = objJugadorPartidoBE.Estado;

                cmd_InsertarJugador.Parameters.Add(prm_CodigoJugador);
                cmd_InsertarJugador.Parameters.Add(prm_CodigoPartido);
                cmd_InsertarJugador.Parameters.Add(prm_Estado);

                cmd_InsertarJugador.Connection.Open();
                cmd_InsertarJugador.ExecuteNonQuery();
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
                cmd_InsertarJugador.Connection.Close();
                conexion.Dispose();
            }
        }
    }
}
