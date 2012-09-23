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
                conexion = new SqlConnection(Properties.Settings.Default.sCadena);
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

        public int Verificar_ExisteRolUsuario(int codUsuario, int codRol)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_verificarexiste = null;

            SqlParameter prm_CodigoUsuario;
            SqlParameter prm_CodigoRol;

            SqlDataReader dr_verificar;

            String sqlRolAsignar;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.sCadena);
                sqlRolAsignar = "spVerificarRolUsuarioExiste";

                cmd_verificarexiste = new SqlCommand(sqlRolAsignar, conexion);
                cmd_verificarexiste.CommandType = CommandType.StoredProcedure;

                prm_CodigoUsuario = new SqlParameter();
                prm_CodigoUsuario.ParameterName = "@idUsuario";
                prm_CodigoUsuario.SqlDbType = SqlDbType.Int;
                prm_CodigoUsuario.Value = codUsuario;

                prm_CodigoRol = new SqlParameter();
                prm_CodigoRol.ParameterName = "@idRol";
                prm_CodigoRol.SqlDbType = SqlDbType.Int;
                prm_CodigoRol.Value = codRol;

                cmd_verificarexiste.Parameters.Add(prm_CodigoRol);
                cmd_verificarexiste.Parameters.Add(prm_CodigoUsuario);

                cmd_verificarexiste.Connection.Open();
                dr_verificar =  cmd_verificarexiste.ExecuteReader();

                int Cantidad = 0;

                while (dr_verificar.Read())
                {
                    Cantidad = dr_verificar.GetInt32(dr_verificar.GetOrdinal("Cantidad"));
                }

                return Cantidad;
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
                cmd_verificarexiste.Connection.Close();
                conexion.Dispose();
            }
        }
    }
}
