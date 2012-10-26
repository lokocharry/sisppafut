using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.DL.DALC
{
    public class PronosticoClienteDALC
    {
        public void insertarPronosticoCliente(PronosticoClienteBE objPronosticoClienteBE)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_InsertarPronosticoCliente = null;

            SqlParameter prm_CodigoUsuario;
            SqlParameter prm_CodigoPartido;
            SqlParameter prm_Pronostico;

            String sqlInsertarPronosticoCliente;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);

                sqlInsertarPronosticoCliente = "spCreatePronosticoCliente";

                cmd_InsertarPronosticoCliente = new SqlCommand(sqlInsertarPronosticoCliente, conexion);
                cmd_InsertarPronosticoCliente.CommandType = CommandType.StoredProcedure;

                prm_CodigoUsuario = new SqlParameter();
                prm_CodigoUsuario.ParameterName = "@idUsuario";
                prm_CodigoUsuario.SqlDbType = SqlDbType.Int;
                prm_CodigoUsuario.Value = objPronosticoClienteBE.CodigoUsuario;

                prm_CodigoPartido = new SqlParameter();
                prm_CodigoPartido.ParameterName = "@CodPartido";
                prm_CodigoPartido.SqlDbType = SqlDbType.Int;
                prm_CodigoPartido.Value = objPronosticoClienteBE.CodigoPartido;

                prm_Pronostico = new SqlParameter();
                prm_Pronostico.ParameterName = "@Pronostico";
                prm_Pronostico.SqlDbType = SqlDbType.VarChar;
                prm_Pronostico.Size = 5;
                prm_Pronostico.Value = objPronosticoClienteBE.Pronostico;

                cmd_InsertarPronosticoCliente.Parameters.Add(prm_CodigoUsuario);
                cmd_InsertarPronosticoCliente.Parameters.Add(prm_CodigoPartido);
                cmd_InsertarPronosticoCliente.Parameters.Add(prm_Pronostico);

                cmd_InsertarPronosticoCliente.Connection.Open();
                cmd_InsertarPronosticoCliente.ExecuteNonQuery();

            }
            catch (Exception)
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Dispose();
                }

                throw;
            }
            finally
            {
                cmd_InsertarPronosticoCliente.Connection.Close();
                conexion.Dispose();
            }
        }

        public List<PronosticoClienteBE> listarPronosticosCliente(int codCliente)
        {
            SqlConnection conexion = null;
            SqlDataReader dr_pronosticoCliente;
            SqlCommand cmd_pronosticosCliente = null;
            String sqlPronosticosClienteListar;
            SqlParameter prm_cliente;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlPronosticosClienteListar = "spListarPronosticoCliente";

                cmd_pronosticosCliente = conexion.CreateCommand();
                cmd_pronosticosCliente.CommandText = sqlPronosticosClienteListar;
                cmd_pronosticosCliente.CommandType = CommandType.StoredProcedure;

                prm_cliente = new SqlParameter();
                prm_cliente.ParameterName = "@CodUsuario";
                prm_cliente.SqlDbType = SqlDbType.Int;
                prm_cliente.Value = codCliente;

                cmd_pronosticosCliente.Parameters.Add(prm_cliente);
                cmd_pronosticosCliente.Connection.Open();
                dr_pronosticoCliente = cmd_pronosticosCliente.ExecuteReader();

                List<PronosticoClienteBE> lista_pronosticosCliente;
                PronosticoClienteBE objPronosticoClienteBE;

                lista_pronosticosCliente = new List<PronosticoClienteBE>();

                while (dr_pronosticoCliente.Read())
                {
                    objPronosticoClienteBE = new PronosticoClienteBE();

                    objPronosticoClienteBE.CodigoUsuario = dr_pronosticoCliente.GetInt32(dr_pronosticoCliente.GetOrdinal("idUsuario"));
                    objPronosticoClienteBE.CodigoPartido = dr_pronosticoCliente.GetInt32(dr_pronosticoCliente.GetOrdinal("CodPartido"));
                    objPronosticoClienteBE.Pronostico = dr_pronosticoCliente.GetString(dr_pronosticoCliente.GetOrdinal("Pronostico"));

                    lista_pronosticosCliente.Add(objPronosticoClienteBE);
                }

                return lista_pronosticosCliente;
            }
            catch (Exception)
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    cmd_pronosticosCliente.Connection.Close();
                    conexion.Dispose();
                }
                throw;
            }
            finally
            {
                cmd_pronosticosCliente.Connection.Close();
                conexion.Dispose();
            }
        }

    }
}
