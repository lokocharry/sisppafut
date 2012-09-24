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

        public int Verificar_UsuarioXFuncionalidadExiste(int idUsuario, int idFuncionalidad)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_usuarioFunc = null;
            SqlDataReader dr_usuarioFunc = null;
            SqlParameter prm_idusuario;
            SqlParameter prm_idfuncionalidad;

            String sql_verificarexiste;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.sCadena);

                sql_verificarexiste = "spVerificarUsuarioFuncionalidadExiste";

                cmd_usuarioFunc = new SqlCommand(sql_verificarexiste, conexion);
                cmd_usuarioFunc.CommandType = CommandType.StoredProcedure;

                prm_idusuario = new SqlParameter();
                prm_idusuario.ParameterName = "@idUsuario";
                prm_idusuario.SqlDbType = SqlDbType.Int;
                prm_idusuario.Value = idUsuario;

                prm_idfuncionalidad = new SqlParameter();
                prm_idfuncionalidad.ParameterName = "@idFuncionalidad";
                prm_idfuncionalidad.SqlDbType = SqlDbType.Int;
                prm_idfuncionalidad.Value = idFuncionalidad;

                cmd_usuarioFunc.Parameters.Add(prm_idusuario);
                cmd_usuarioFunc.Parameters.Add(prm_idfuncionalidad);

                cmd_usuarioFunc.Connection.Open();
                dr_usuarioFunc = cmd_usuarioFunc.ExecuteReader();

                int Cantidad = 0;

                while (dr_usuarioFunc.Read())
                {
                    Cantidad = dr_usuarioFunc.GetInt32(dr_usuarioFunc.GetOrdinal("Cantidad"));
                }

                cmd_usuarioFunc.Connection.Close();
                cmd_usuarioFunc.Connection.Dispose();

                return Cantidad;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<FuncionalidadBE> listar_FuncionalidadesXUsuario(int idUsuario)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_funcionalidad = null;
            SqlDataReader dr_funcionalidad = null;
            SqlParameter prm_idusuario;

            String sql_funcionalidadListar;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.sCadena);

                sql_funcionalidadListar = "spListarFuncionalidadxUsuario";

                cmd_funcionalidad = new SqlCommand(sql_funcionalidadListar, conexion);
                cmd_funcionalidad.CommandType = CommandType.StoredProcedure;

                prm_idusuario = new SqlParameter();
                prm_idusuario.ParameterName = "@idUsuario";
                prm_idusuario.SqlDbType = SqlDbType.Int;
                prm_idusuario.Value = idUsuario;

                cmd_funcionalidad.Parameters.Add(prm_idusuario);

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
