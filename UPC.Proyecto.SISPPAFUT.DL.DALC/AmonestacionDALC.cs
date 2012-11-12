using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.DL.DALC
{
    public class AmonestacionDALC
    {
        public int insertar_Amonestacion(AmonestacionBE objAmonestacionBE)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_InsertarAmonestacion;

            SqlParameter prm_Codigo;
            SqlParameter prm_CodigoPartido;
            SqlParameter prm_CodigoJugador;
            SqlParameter prm_Tipo;
            SqlParameter prm_Minuto;

            int iCodigoAmonestacion;

            String sqlInsertarAmonestacion;

            try
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);

                sqlInsertarAmonestacion = "spCreateAmonestacionPartido";

                cmd_InsertarAmonestacion = new SqlCommand(sqlInsertarAmonestacion, conexion);
                cmd_InsertarAmonestacion.CommandType = CommandType.StoredProcedure;

                prm_Codigo = new SqlParameter();
                prm_Codigo.Direction = ParameterDirection.ReturnValue;
                prm_Codigo.SqlDbType = SqlDbType.Int;

                prm_CodigoJugador = new SqlParameter();
                prm_CodigoJugador.ParameterName = "@CodJugador";
                prm_CodigoJugador.SqlDbType = SqlDbType.Int;
                prm_CodigoJugador.Value = objAmonestacionBE.Codigo_jugador;

                prm_CodigoPartido = new SqlParameter();
                prm_CodigoPartido.ParameterName = "@CodPartido";
                prm_CodigoPartido.SqlDbType = SqlDbType.Int;
                prm_CodigoPartido.Value = objAmonestacionBE.Codigo_partido;

                prm_Minuto = new SqlParameter();
                prm_Minuto.ParameterName = "@Minuto";
                prm_Minuto.SqlDbType = SqlDbType.Int;
                prm_Minuto.Value = objAmonestacionBE.Minuto;

                prm_Tipo = new SqlParameter();
                prm_Tipo.ParameterName = "@Tipo";
                prm_Tipo.SqlDbType = SqlDbType.Bit;
                prm_Tipo.Value = objAmonestacionBE.Tipo;

                cmd_InsertarAmonestacion.Parameters.Add(prm_Codigo);
                cmd_InsertarAmonestacion.Parameters.Add(prm_CodigoJugador);
                cmd_InsertarAmonestacion.Parameters.Add(prm_CodigoPartido);
                cmd_InsertarAmonestacion.Parameters.Add(prm_Minuto);
                cmd_InsertarAmonestacion.Parameters.Add(prm_Tipo);

                cmd_InsertarAmonestacion.Connection.Open();
                cmd_InsertarAmonestacion.ExecuteNonQuery();

                iCodigoAmonestacion = Convert.ToInt32(prm_Codigo.Value);

                return iCodigoAmonestacion;
            }

            catch(Exception)
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
