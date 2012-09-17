using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using UPC.Seguridad.BL.BE;


namespace UPC.Seguridad.DL.DALC
{
    public class RolXFuncionalidadDALC
    {
        public void insertar_RolXFuncionalidad(RolXFuncionalidadBE objRolFuncionalidadBE)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_rolFuncionalidad = null;

            SqlParameter prm_idRol;
            SqlParameter prm_idFuncionalidad;

            String sqlRolFuncInsertar;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);

                sqlRolFuncInsertar = "spCreateRolFuncionalidad";

                cmd_rolFuncionalidad = new SqlCommand(sqlRolFuncInsertar, conexion);
                cmd_rolFuncionalidad.CommandType = CommandType.StoredProcedure;

                prm_idRol = new SqlParameter();
                prm_idRol.ParameterName = "@idRol";
                prm_idRol.SqlDbType = SqlDbType.Int;
                prm_idRol.Value = objRolFuncionalidadBE.idRol;

                prm_idFuncionalidad = new SqlParameter();
                prm_idFuncionalidad.ParameterName = "@idFuncionalidad";
                prm_idFuncionalidad.SqlDbType = SqlDbType.Int;
                prm_idFuncionalidad.Value = objRolFuncionalidadBE.idFuncionalidad;

                cmd_rolFuncionalidad.Parameters.Add(prm_idRol);
                cmd_rolFuncionalidad.Parameters.Add(prm_idFuncionalidad);

                cmd_rolFuncionalidad.Connection.Open();
                cmd_rolFuncionalidad.ExecuteNonQuery();
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
                cmd_rolFuncionalidad.Connection.Close();
                conexion.Dispose();
            }
        }

        public List<FuncionalidadBE> listar_FuncionalidadesXRol(int idRol)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_funcionalidad = null;
            SqlDataReader dr_funcionalidad = null;
            SqlParameter prm_idrol;

            String sql_funcionalidadListar;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);

                sql_funcionalidadListar = "spListarFuncionalidadxRol";

                cmd_funcionalidad = new SqlCommand(sql_funcionalidadListar, conexion);
                cmd_funcionalidad.CommandType = CommandType.StoredProcedure;

                prm_idrol = new SqlParameter();
                prm_idrol.ParameterName = "@idRol";
                prm_idrol.SqlDbType = SqlDbType.Int;
                prm_idrol.Value = idRol;

                cmd_funcionalidad.Parameters.Add(prm_idrol);

                cmd_funcionalidad.Connection.Open();
                dr_funcionalidad = cmd_funcionalidad.ExecuteReader();

                List<FuncionalidadBE> lst_func = new List<FuncionalidadBE>();

                FuncionalidadBE objFuncionalidadBE;

                while (dr_funcionalidad.Read())
                {
                    objFuncionalidadBE = new FuncionalidadBE();

                    objFuncionalidadBE.idFuncionalidad = dr_funcionalidad.GetInt32(dr_funcionalidad.GetOrdinal("idFuncionalidad"));
                    objFuncionalidadBE.NombreFuncionalidad = dr_funcionalidad.GetString(dr_funcionalidad.GetOrdinal("nombreFuncionalidad"));

                    lst_func.Add(objFuncionalidadBE);
                }

                cmd_funcionalidad.Connection.Close();
                cmd_funcionalidad.Connection.Dispose();

                return lst_func;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
