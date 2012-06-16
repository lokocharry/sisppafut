using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.DL.DALC
{
    public class PronosticoDALC
    {
        public int insertar_Pronostico(PronosticoBE objPronosticoBE)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_PronosticoInsertar;

            SqlParameter prm_CodigoPronostico;
            SqlParameter prm_CodigoPartido;
            SqlParameter prm_Pronostico;
            SqlParameter prm_PorcentajeLocal;
            SqlParameter prm_PorcentajeEmpate;
            SqlParameter prm_PorcentajeVisita;

            int iCodigoPronostico;

            String sqlPronosticoInsertar;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlPronosticoInsertar = "spCreatePronostico";

                cmd_PronosticoInsertar = new SqlCommand(sqlPronosticoInsertar, conexion);
                cmd_PronosticoInsertar.CommandType = CommandType.StoredProcedure;

                prm_CodigoPronostico = new SqlParameter();
                prm_CodigoPronostico.Direction = ParameterDirection.ReturnValue;
                prm_CodigoPronostico.SqlDbType = SqlDbType.Int;

                prm_CodigoPartido = new SqlParameter();
                prm_CodigoPartido.ParameterName = "@codPartido";
                prm_CodigoPartido.SqlDbType = SqlDbType.Int;
                prm_CodigoPartido.Value = objPronosticoBE.CodigoPartido;

                prm_Pronostico = new SqlParameter();
                prm_Pronostico.ParameterName = "@pronostico";
                prm_Pronostico.SqlDbType = SqlDbType.VarChar;
                prm_Pronostico.Size = 5;
                prm_Pronostico.Value = objPronosticoBE.Pronostico.ToCharArray();

                prm_PorcentajeLocal = new SqlParameter();
                prm_PorcentajeLocal.ParameterName = "@porcentajeLocal";
                prm_PorcentajeLocal.SqlDbType = SqlDbType.Decimal;
                prm_PorcentajeLocal.Value = objPronosticoBE.PorcentajeLocal;

                prm_PorcentajeEmpate = new SqlParameter();
                prm_PorcentajeEmpate.ParameterName = "@porcentajeEmpate";
                prm_PorcentajeEmpate.SqlDbType = SqlDbType.Decimal;
                prm_PorcentajeEmpate.Value = objPronosticoBE.PorcentajeEmpate;

                prm_PorcentajeVisita = new SqlParameter();
                prm_PorcentajeVisita.ParameterName = "@porcentajeVisita";
                prm_PorcentajeVisita.SqlDbType = SqlDbType.Decimal;
                prm_PorcentajeVisita.Value = objPronosticoBE.PorcentajeVisita;

                cmd_PronosticoInsertar.Parameters.Add(prm_CodigoPronostico);
                cmd_PronosticoInsertar.Parameters.Add(prm_CodigoPartido);
                cmd_PronosticoInsertar.Parameters.Add(prm_Pronostico);
                cmd_PronosticoInsertar.Parameters.Add(prm_PorcentajeLocal);
                cmd_PronosticoInsertar.Parameters.Add(prm_PorcentajeEmpate);
                cmd_PronosticoInsertar.Parameters.Add(prm_PorcentajeVisita);

                cmd_PronosticoInsertar.Connection.Open();
                cmd_PronosticoInsertar.ExecuteNonQuery();

                iCodigoPronostico = Convert.ToInt32(prm_CodigoPronostico.Value);

                cmd_PronosticoInsertar.Connection.Close();
                conexion.Dispose();

                return iCodigoPronostico;
            }
            catch (Exception)
            {
                conexion.Dispose();
                throw;
            }

        }

        public void actualizar_Pronostico(int codPronostico, String pronostico, Decimal porcentajeLocal, Decimal porcentajeEmpate, Decimal porcentajeVisita)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_actualizarPronostico;
            String sqlUpdatePronostico;

            SqlParameter prm_codigoPronostico;
            SqlParameter prm_pronostico;
            SqlParameter prm_porcentajeLocal;
            SqlParameter prm_porcentajeEmpate;
            SqlParameter prm_porcentajeVisita;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlUpdatePronostico = "spUpdatePronostico";
                cmd_actualizarPronostico = new SqlCommand(sqlUpdatePronostico, conexion);
                cmd_actualizarPronostico.CommandType = CommandType.StoredProcedure;

                prm_codigoPronostico = new SqlParameter();
                prm_codigoPronostico.ParameterName = "@codPronostico";
                prm_codigoPronostico.SqlDbType = SqlDbType.Int;
                prm_codigoPronostico.Value = codPronostico;

                prm_pronostico = new SqlParameter();
                prm_pronostico.ParameterName = "@pronostico";
                prm_pronostico.SqlDbType = SqlDbType.VarChar;
                prm_pronostico.Size = 5;
                prm_pronostico.Value = pronostico.ToCharArray();

                prm_porcentajeLocal = new SqlParameter();
                prm_porcentajeLocal.ParameterName = "@porcentajeLocal";
                prm_porcentajeLocal.SqlDbType = SqlDbType.Decimal;
                prm_porcentajeLocal.Value = porcentajeLocal;

                prm_porcentajeEmpate = new SqlParameter();
                prm_porcentajeLocal.ParameterName = "@porcentajeEmpate";
                prm_porcentajeLocal.SqlDbType = SqlDbType.Decimal;
                prm_porcentajeLocal.Value = porcentajeEmpate;

                prm_porcentajeVisita = new SqlParameter();
                prm_porcentajeLocal.ParameterName = "@porcentajeVisita";
                prm_porcentajeLocal.SqlDbType = SqlDbType.Decimal;
                prm_porcentajeLocal.Value = porcentajeVisita;

                cmd_actualizarPronostico.Parameters.Add(prm_codigoPronostico);
                cmd_actualizarPronostico.Parameters.Add(prm_pronostico);
                cmd_actualizarPronostico.Parameters.Add(prm_porcentajeLocal);
                cmd_actualizarPronostico.Parameters.Add(prm_porcentajeEmpate);
                cmd_actualizarPronostico.Parameters.Add(prm_porcentajeVisita);

                cmd_actualizarPronostico.Connection.Open();
                cmd_actualizarPronostico.ExecuteNonQuery();
                cmd_actualizarPronostico.Connection.Close();
                conexion.Dispose();
            }
            catch (Exception)
            {
                conexion.Dispose();
                throw;
            }
        }

        public List<PronosticoBE> listar_Pronosticos()
        {
            SqlConnection conexion = null;
            SqlDataReader dr_pronosticos;
            SqlCommand cmd_pronosticos;
            String sqlPronosticosListar;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlPronosticosListar = "spListarPronosticos";
                cmd_pronosticos = new SqlCommand(sqlPronosticosListar, conexion);
                cmd_pronosticos.Connection.Open();
                dr_pronosticos = cmd_pronosticos.ExecuteReader();

                List<PronosticoBE> lista_pronosticos;
                PronosticoBE objPronosticoBE;
                lista_pronosticos = new List<PronosticoBE>();

                while (dr_pronosticos.Read())
                {
                    objPronosticoBE = new PronosticoBE();

                    objPronosticoBE.CodigoPronostico = dr_pronosticos.GetInt32(dr_pronosticos.GetOrdinal("CodPronostico"));
                    objPronosticoBE.CodigoPartido = dr_pronosticos.GetInt32(dr_pronosticos.GetOrdinal("CodPartido"));
                    objPronosticoBE.Pronostico = dr_pronosticos.GetString(dr_pronosticos.GetOrdinal("Pronostico"));
                    objPronosticoBE.PorcentajeLocal = dr_pronosticos.GetDecimal(dr_pronosticos.GetOrdinal("PorcentajeLocal"));
                    objPronosticoBE.PorcentajeEmpate = dr_pronosticos.GetDecimal(dr_pronosticos.GetOrdinal("PorcentajeEmpate"));
                    objPronosticoBE.PorcentajeVisita = dr_pronosticos.GetDecimal(dr_pronosticos.GetOrdinal("PorcentajeVisita"));

                    lista_pronosticos.Add(objPronosticoBE);
                }

                cmd_pronosticos.Connection.Close();
                conexion.Dispose();

                return lista_pronosticos;
            }
            catch (Exception ex)
            {
                conexion.Dispose();
                throw;
            }

        }
    }
}
