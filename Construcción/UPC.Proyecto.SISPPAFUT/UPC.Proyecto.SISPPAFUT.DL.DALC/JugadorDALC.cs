using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.DL.DALC
{
    public class JugadorDALC
    {
        public int insertar_Jugador(JugadorBE objJugadorBE)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_JugadorInsertar = null;

            SqlParameter prm_CodigoJugador;
            SqlParameter prm_Nombres;
            SqlParameter prm_Apellidos;
            SqlParameter prm_Nacionalidad;
            SqlParameter prm_Fecha;
            SqlParameter prm_Posicion;
            SqlParameter prm_Altura;
            SqlParameter prm_Peso;

            int iCodigoJugador;

            String sqlJugadorInsertar;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);

                sqlJugadorInsertar = "spCreateJugador";

                cmd_JugadorInsertar = new SqlCommand(sqlJugadorInsertar, conexion);
                cmd_JugadorInsertar.CommandType = CommandType.StoredProcedure;

                prm_CodigoJugador = new SqlParameter();
                prm_CodigoJugador.Direction = ParameterDirection.ReturnValue;
                prm_CodigoJugador.SqlDbType = SqlDbType.Int;

                prm_Nombres = new SqlParameter();
                prm_Nombres.ParameterName = "@Nombres";
                prm_Nombres.SqlDbType = SqlDbType.VarChar;
                prm_Nombres.Size = 20;
                prm_Nombres.Value = objJugadorBE.Nombres;

                prm_Apellidos = new SqlParameter();
                prm_Apellidos.ParameterName = "@Apellidos";
                prm_Apellidos.SqlDbType = SqlDbType.VarChar;
                prm_Apellidos.Size = 20;
                prm_Apellidos.Value = objJugadorBE.Apellidos;

                prm_Nacionalidad = new SqlParameter();
                prm_Nacionalidad.ParameterName = "@Nacionalidad";
                prm_Nacionalidad.SqlDbType = SqlDbType.VarChar;
                prm_Nacionalidad.Size = 20;
                prm_Nacionalidad.Value = objJugadorBE.Nacionalidad;

                prm_Fecha = new SqlParameter();
                prm_Fecha.ParameterName = "@FechaNacimiento";
                prm_Fecha.SqlDbType = SqlDbType.Date;
                prm_Fecha.Value = objJugadorBE.FechaNacimiento;

                prm_Posicion = new SqlParameter();
                prm_Posicion.ParameterName = "@Posicion";
                prm_Posicion.SqlDbType = SqlDbType.VarChar;
                prm_Posicion.Size = 15;
                prm_Posicion.Value = objJugadorBE.Posicion;

                prm_Altura = new SqlParameter();
                prm_Altura.ParameterName = "@Altura";
                prm_Altura.SqlDbType = SqlDbType.Decimal;
                prm_Altura.Value = objJugadorBE.Altura;

                prm_Peso = new SqlParameter();
                prm_Peso.ParameterName = "@Peso";
                prm_Peso.SqlDbType = SqlDbType.Decimal;
                prm_Peso.Value = objJugadorBE.Peso;

                cmd_JugadorInsertar.Parameters.Add(prm_CodigoJugador);
                cmd_JugadorInsertar.Parameters.Add(prm_Nombres);
                cmd_JugadorInsertar.Parameters.Add(prm_Apellidos);
                cmd_JugadorInsertar.Parameters.Add(prm_Nacionalidad);
                cmd_JugadorInsertar.Parameters.Add(prm_Posicion);
                cmd_JugadorInsertar.Parameters.Add(prm_Peso);
                cmd_JugadorInsertar.Parameters.Add(prm_Altura);
                cmd_JugadorInsertar.Parameters.Add(prm_Fecha);

                cmd_JugadorInsertar.Connection.Open();
                cmd_JugadorInsertar.ExecuteNonQuery();

                iCodigoJugador = Convert.ToInt32(prm_CodigoJugador.Value);

                return iCodigoJugador;
            }

            catch (Exception ex)
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Dispose();
                }

                throw;
            }

            finally
            {
                cmd_JugadorInsertar.Connection.Close();
                conexion.Dispose();
            }
        }
    }
}
