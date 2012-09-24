using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using UPC.Seguridad.BL.BE;

namespace UPC.Seguridad.DL.DALC
{
    public class UsuarioFuncionalidadDALC
    {
        public void insertar_UsuarioFuncionalidad(UsuarioFuncionalidadBE objUsuarioFuncionalidadBE)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_usuariofunc = null;

            SqlParameter prm_CodigoUsuario;
            SqlParameter prm_CodigoFuncionalidad;

            String sql_insertarRelacion;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.sCadena);
                sql_insertarRelacion = "spCreateUsuarioFuncionalidad";

                cmd_usuariofunc = new SqlCommand(sql_insertarRelacion, conexion);
                cmd_usuariofunc.CommandType = CommandType.StoredProcedure;

                prm_CodigoUsuario = new SqlParameter();
                prm_CodigoUsuario.ParameterName ="@idUsuario";
                prm_CodigoUsuario.SqlDbType = SqlDbType.Int;
                prm_CodigoUsuario.Value = objUsuarioFuncionalidadBE.idUsuario;

                prm_CodigoFuncionalidad = new SqlParameter();
                prm_CodigoFuncionalidad.ParameterName = "@idFuncionalidad";
                prm_CodigoFuncionalidad.SqlDbType = SqlDbType.Int;
                prm_CodigoFuncionalidad.Value = objUsuarioFuncionalidadBE.idFuncionalidad;

                cmd_usuariofunc.Parameters.Add(prm_CodigoUsuario);
                cmd_usuariofunc.Parameters.Add(prm_CodigoFuncionalidad);

                cmd_usuariofunc.Connection.Open();
                cmd_usuariofunc.ExecuteNonQuery();
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
                cmd_usuariofunc.Connection.Close();
                conexion.Dispose();
            }

        }
        }
}
