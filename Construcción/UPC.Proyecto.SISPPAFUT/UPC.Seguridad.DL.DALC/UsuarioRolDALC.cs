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
