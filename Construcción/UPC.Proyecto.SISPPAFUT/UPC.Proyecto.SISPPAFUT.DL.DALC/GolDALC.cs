using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.DL.DALC
{
    public class GolDALC
    {
        public int insertar_Gol(GolBE objGolBE)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_InsertarGol = null;

            SqlParameter prm_Codigo;
            SqlParameter prm_CodigoPartido;
            SqlParameter prm_CodigoJugador;
            SqlParameter prm_Minuto;

            int iCodigoGol;

            String sqlInsertarGol;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);

                sqlInsertarGol = "spCreateGolPartido";

                cmd_InsertarGol = new SqlCommand(sqlInsertarGol, conexion);
                cmd_InsertarGol.CommandType = CommandType.StoredProcedure;

                prm_Codigo = new SqlParameter();
                prm_Codigo.Direction = ParameterDirection.ReturnValue;
                prm_Codigo.SqlDbType = SqlDbType.Int;

                prm_CodigoJugador = new SqlParameter();
                prm_CodigoJugador.ParameterName = "@CodJugador";
                prm_CodigoJugador.SqlDbType = SqlDbType.Int;
                prm_CodigoJugador.Value = objGolBE.Codigo_jugador;

                prm_CodigoPartido = new SqlParameter();
                prm_CodigoPartido.ParameterName = "@CodPartido";
                prm_CodigoPartido.SqlDbType = SqlDbType.Int;
                prm_CodigoPartido.Value = objGolBE.Codigo_partido;

                prm_Minuto = new SqlParameter();
                prm_Minuto.ParameterName = "@Minuto";
                prm_Minuto.SqlDbType = SqlDbType.Int;
                prm_Minuto.Value = objGolBE.Minuto_gol;

                cmd_InsertarGol.Parameters.Add(prm_Codigo);
                cmd_InsertarGol.Parameters.Add(prm_CodigoJugador);
                cmd_InsertarGol.Parameters.Add(prm_CodigoPartido);
                cmd_InsertarGol.Parameters.Add(prm_Minuto);

                cmd_InsertarGol.Connection.Open();
                cmd_InsertarGol.ExecuteNonQuery();

                iCodigoGol = Convert.ToInt32(prm_Codigo.Value);

                return iCodigoGol;
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
                cmd_InsertarGol.Connection.Close();
                conexion.Dispose();
            }
        }
    }
}
