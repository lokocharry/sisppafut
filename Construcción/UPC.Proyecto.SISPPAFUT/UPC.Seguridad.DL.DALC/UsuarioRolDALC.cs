using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using UPC.Seguridad.BL.BE;

namespace UPC.Seguridad.DL.DALC
{
    public class UsuarioRolDALC
    {
        public void asignar_Rol(int codUsuario, int codRol)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_RolAsignar = null;

            SqlParameter prm_CodigoUsuario;
            SqlParameter prm_CodigoRol;

            String sqlRolAsignar;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlRolAsignar = "spCreateUsuarioRol";

                cmd_RolAsignar = new SqlCommand(sqlRolAsignar, conexion);
                cmd_RolAsignar.CommandType = CommandType.StoredProcedure;

                prm_CodigoUsuario = new SqlParameter();
                prm_CodigoUsuario.ParameterName = "@idUsuario";
                prm_CodigoUsuario.SqlDbType = SqlDbType.Int;
                prm_CodigoUsuario.Value = codUsuario;

                prm_CodigoRol = new SqlParameter();
                prm_CodigoRol.ParameterName = "@idRol";
                prm_CodigoRol.SqlDbType = SqlDbType.Int;
                prm_CodigoRol.Value = codRol;

                cmd_RolAsignar.Parameters.Add(prm_CodigoRol);
                cmd_RolAsignar.Parameters.Add(prm_CodigoUsuario);

                cmd_RolAsignar.Connection.Open();
                cmd_RolAsignar.ExecuteNonQuery();
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
                cmd_RolAsignar.Connection.Close();
                conexion.Dispose();
            }

        }
    }
}
