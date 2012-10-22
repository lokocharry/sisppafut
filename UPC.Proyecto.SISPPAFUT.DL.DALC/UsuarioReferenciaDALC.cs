using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.DL.DALC
{
    public class UsuarioReferenciaDALC
    {
        public void insertar_UsuarioReferencia(UsuarioReferenciaBE objUsuarioReferenciaBE)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_UsuarioReferenciaInsertar = null;

            SqlParameter prm_CodigoUsuario;
            SqlParameter prm_NombreUsuario;

            String sqlUsuarioReferenciaInsertar;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                //Cambiar "Cadena" por la cadena de conexion a SISPPAFUT_seguridad
                sqlUsuarioReferenciaInsertar = "spCreateUsuarioReferencia";

                cmd_UsuarioReferenciaInsertar = new SqlCommand(sqlUsuarioReferenciaInsertar, conexion);
                cmd_UsuarioReferenciaInsertar.CommandType = CommandType.StoredProcedure;

                prm_CodigoUsuario = new SqlParameter();
                prm_CodigoUsuario.ParameterName = "@idUsuario";
                prm_CodigoUsuario.SqlDbType = SqlDbType.Int;
                prm_CodigoUsuario.Value = objUsuarioReferenciaBE.IdUsuario;

                prm_NombreUsuario = new SqlParameter();
                prm_NombreUsuario.ParameterName = "@nombreUsuario";
                prm_NombreUsuario.SqlDbType = SqlDbType.VarChar;
                prm_NombreUsuario.Size = 40;
                prm_NombreUsuario.Value = objUsuarioReferenciaBE.NombreUsuario;

                cmd_UsuarioReferenciaInsertar.Parameters.Add(prm_CodigoUsuario);
                cmd_UsuarioReferenciaInsertar.Parameters.Add(prm_NombreUsuario);

                cmd_UsuarioReferenciaInsertar.Connection.Open();
                cmd_UsuarioReferenciaInsertar.ExecuteNonQuery();
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
                cmd_UsuarioReferenciaInsertar.Connection.Close();
                conexion.Dispose();
            }
        }
    }
}
