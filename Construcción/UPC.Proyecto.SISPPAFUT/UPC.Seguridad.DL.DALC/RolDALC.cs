using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using UPC.Seguridad.BL.BE;

namespace UPC.Seguridad.DL.DALC
{
    public class RolDALC
    {
        public int insertar_rol(RolBE objRolBE)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_rol_insertar = null;

            SqlParameter prm_idRol;
            SqlParameter prm_NombreRol;
            SqlParameter prm_claveRol;
            SqlParameter prm_descripcionRol;

            int iCodigoRol;
            String sqlRolInsertar;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);

                sqlRolInsertar = "spCreateRol";

                cmd_rol_insertar = new SqlCommand(sqlRolInsertar, conexion);
                cmd_rol_insertar.CommandType = CommandType.StoredProcedure;

                prm_idRol = new SqlParameter();
                prm_idRol.Direction = ParameterDirection.ReturnValue;
                prm_idRol.SqlDbType = SqlDbType.Int;

                prm_NombreRol = new SqlParameter();
                prm_NombreRol.ParameterName = "@nombreRol";
                prm_NombreRol.SqlDbType = SqlDbType.VarChar;
                prm_NombreRol.Size = 30;
                prm_NombreRol.Value = objRolBE.NombreRol;

                prm_claveRol = new SqlParameter();
                prm_claveRol.ParameterName = "@claveRol";
                prm_claveRol.SqlDbType = SqlDbType.VarChar;
                prm_claveRol.Size = 15;
                prm_claveRol.Value = objRolBE.ClaveRol;

                prm_descripcionRol = new SqlParameter();
                prm_descripcionRol.ParameterName = "@descripcionRol";
                prm_descripcionRol.SqlDbType = SqlDbType.VarChar;
                prm_descripcionRol.Size = 200;
                prm_descripcionRol.Value = objRolBE.DescripcionRol;

                cmd_rol_insertar.Parameters.Add(prm_idRol);
                cmd_rol_insertar.Parameters.Add(prm_NombreRol);
                cmd_rol_insertar.Parameters.Add(prm_claveRol);
                cmd_rol_insertar.Parameters.Add(prm_descripcionRol);

                cmd_rol_insertar.Connection.Open();
                cmd_rol_insertar.ExecuteNonQuery();

                iCodigoRol = Convert.ToInt32(prm_idRol.Value);

                return iCodigoRol;

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
                cmd_rol_insertar.Connection.Close();
                conexion.Dispose();
            }

        }
    }
}
