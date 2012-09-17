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

        public int verificar_existeFuncionalidad(String nombreFuncionalidad)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_funcionalidad = null;
            SqlDataReader dr_funcionalidad = null;
            SqlParameter prm_nombreFuncionalidad;

            String sqlFuncionalidadInsertar;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);

                sqlFuncionalidadInsertar = "spVerificarFuncionalidadExiste";

                cmd_funcionalidad = new SqlCommand(sqlFuncionalidadInsertar, conexion);
                cmd_funcionalidad.CommandType = CommandType.StoredProcedure;

                prm_nombreFuncionalidad = new SqlParameter();
                prm_nombreFuncionalidad.ParameterName = "@nombre";
                prm_nombreFuncionalidad.SqlDbType = SqlDbType.VarChar;
                prm_nombreFuncionalidad.Size = 50;
                prm_nombreFuncionalidad.Value = nombreFuncionalidad;

                cmd_funcionalidad.Parameters.Add(prm_nombreFuncionalidad);

                cmd_funcionalidad.Connection.Open();
                dr_funcionalidad = cmd_funcionalidad.ExecuteReader();

                int Cantidad = 0;

                while (dr_funcionalidad.Read())
                {
                    Cantidad = dr_funcionalidad.GetInt32(dr_funcionalidad.GetOrdinal("Cantidad"));
                }

                cmd_funcionalidad.Connection.Close();
                conexion.Dispose();

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
                cmd_funcionalidad.Connection.Close();
                conexion.Dispose();
            }
        }

        public List<FuncionalidadBE> listar_Funcionalid()
        {
            SqlConnection conexion = null;
            SqlCommand cmd_funcionalidad = null;
            SqlDataReader dr_funcionalidad = null;

            String sql_listarfuncionalidad;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);

                sql_listarfuncionalidad = "spListarFuncionalidades";

                cmd_funcionalidad = new SqlCommand(sql_listarfuncionalidad, conexion);
                cmd_funcionalidad.CommandType = CommandType.StoredProcedure;

                cmd_funcionalidad.Connection.Open();
                dr_funcionalidad = cmd_funcionalidad.ExecuteReader();

                List<FuncionalidadBE> lst_func = new List<FuncionalidadBE>();

                while (dr_funcionalidad.Read())
                {
                    FuncionalidadBE objFuncionalidadBE = new FuncionalidadBE();

                    objFuncionalidadBE.idFuncionalidad = dr_funcionalidad.GetInt32(dr_funcionalidad.GetOrdinal("idFuncionalidad"));
                    objFuncionalidadBE.NombreFuncionalidad = dr_funcionalidad.GetString(dr_funcionalidad.GetOrdinal("nombreFuncionalidad"));

                    lst_func.Add(objFuncionalidadBE);
                }

                cmd_funcionalidad.Connection.Close();
                conexion.Dispose();

                return lst_func;

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
                cmd_funcionalidad.Connection.Close();
                conexion.Dispose();
            }
        }
    }
}
