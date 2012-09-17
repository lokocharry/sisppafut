using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using UPC.Seguridad.BL.BE;

namespace UPC.Seguridad.DL.DALC
{
    public class FuncionalidadDALC
    {
        public int insertar_funcionalidad(FuncionalidadBE objFuncionalidadBE)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_funcionalidad_insertar = null;

            SqlParameter prm_idFuncionalidad;
            SqlParameter prm_NombreFuncionalidad;
            SqlParameter prm_DescripcionFuncionalidad;

            int iCodigoFuncionalidad;
            String sqlFuncionalidadInsertar;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);

                sqlFuncionalidadInsertar = "spCreateFuncionalidad";

                cmd_funcionalidad_insertar = new SqlCommand(sqlFuncionalidadInsertar, conexion);
                cmd_funcionalidad_insertar.CommandType = CommandType.StoredProcedure;

                prm_idFuncionalidad = new SqlParameter();
                prm_idFuncionalidad.Direction = ParameterDirection.ReturnValue;
                prm_idFuncionalidad.SqlDbType = SqlDbType.Int;

                prm_NombreFuncionalidad = new SqlParameter();
                prm_NombreFuncionalidad.ParameterName = "@nombreFuncionalidad";
                prm_NombreFuncionalidad.SqlDbType = SqlDbType.VarChar;
                prm_NombreFuncionalidad.Size = 50;
                prm_NombreFuncionalidad.Value = objFuncionalidadBE.NombreFuncionalidad;

                prm_DescripcionFuncionalidad = new SqlParameter();
                prm_DescripcionFuncionalidad.ParameterName = "@descripcionFuncionalidad";
                prm_DescripcionFuncionalidad.SqlDbType = SqlDbType.VarChar;
                prm_DescripcionFuncionalidad.Size = 200;
                prm_DescripcionFuncionalidad.Value = objFuncionalidadBE.DescripcionFuncionalidad;

                cmd_funcionalidad_insertar.Parameters.Add(prm_idFuncionalidad);
                cmd_funcionalidad_insertar.Parameters.Add(prm_NombreFuncionalidad);
                cmd_funcionalidad_insertar.Parameters.Add(prm_DescripcionFuncionalidad);

                cmd_funcionalidad_insertar.Connection.Open();
                cmd_funcionalidad_insertar.ExecuteNonQuery();

                iCodigoFuncionalidad = Convert.ToInt32(prm_idFuncionalidad.Value);

                return iCodigoFuncionalidad;

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
                cmd_funcionalidad_insertar.Connection.Close();
                conexion.Dispose();
            }

        }
    }
}
