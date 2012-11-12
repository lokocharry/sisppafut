using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.DL.DALC
{
    public class PartidoPronosticadoDALC
    {
        public void insertar_PartidoPronosticado(PartidoPronosticadoBE objBE)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_PartidoPronosticadoInsertar;

            SqlParameter idPartido;
            SqlParameter c_QEquiposLiga;
            SqlParameter c_Mes;
            //SqlParameter c_QEquiposMundial;
            //SqlParameter c_QAsistencia;
            SqlParameter c_Local_PosLiga;
            SqlParameter c_Local_Pts;
            SqlParameter c_Local;
            SqlParameter c_Local_PosRankMund;
            //SqlParameter c_Local_GoleadorSuspendido;
            //SqlParameter c_Local_ArqueroSuspendido;
            SqlParameter c_Local_QExpulsados;
            SqlParameter c_Local_QSuspendidos;
            SqlParameter c_Local_GolesAnotados;
            SqlParameter c_Local_GolesEncajados;
            SqlParameter c_Local_PromEdad;
            SqlParameter c_Local_QPartidosMes;
            SqlParameter c_Visita_PosLiga;
            SqlParameter c_Visita_Pts;
            SqlParameter c_Visita;
            SqlParameter c_Visita_PosRankMund;
            //SqlParameter c_Visita_GoleadorSuspendido;
            //SqlParameter c_Visita_ArqueroSuspendido;
            SqlParameter c_Visita_QExpulsados;
            SqlParameter c_Visita_QSuspendidos;
            SqlParameter c_Visita_GolesAnotados;
            SqlParameter c_Visita_GolesEncajados;
            SqlParameter c_Visita_PromEdad;
            SqlParameter c_Visita_QPartidosMes;
            SqlParameter c_Resultado;

            int iCodigoPartidoPronosticado;

            String sqlPartidoPronosticadoInsertar;

            try
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);

                sqlPartidoPronosticadoInsertar = "spCreatePartidoPronosticado";

                cmd_PartidoPronosticadoInsertar = new SqlCommand(sqlPartidoPronosticadoInsertar, conexion);
                cmd_PartidoPronosticadoInsertar.CommandType = CommandType.StoredProcedure;

                idPartido = new SqlParameter();
                idPartido.ParameterName = "@idPartido";
                idPartido.SqlDbType = SqlDbType.Int;
                idPartido.Value = objBE.IdPartido;

                c_QEquiposLiga = new SqlParameter();
                c_QEquiposLiga.ParameterName = "@c_QEquiposLiga";
                c_QEquiposLiga.SqlDbType = SqlDbType.Int;
                c_QEquiposLiga.Value = objBE.C_QEquiposLiga;

                c_Mes = new SqlParameter();
                c_Mes.ParameterName = "@c_mes";
                c_Mes.SqlDbType = SqlDbType.Int;
                c_Mes.Value = objBE.C_Mes;
                /*
                c_QEquiposMundial = new SqlParameter();
                c_QEquiposMundial.ParameterName = "@c_QEquiposMundial";
                c_QEquiposMundial.SqlDbType = SqlDbType.Int;
                c_QEquiposMundial.Value = objBE.C_QEquiposMundial;

                c_QAsistencia = new SqlParameter();
                c_QAsistencia.ParameterName = "@c_QAsistencia";
                c_QAsistencia.SqlDbType = SqlDbType.Int;
                c_QAsistencia.Value = objBE.C_QAsistencia;
                */
                c_Local_PosLiga = new SqlParameter();
                c_Local_PosLiga.ParameterName = "@c_Local_PosLiga";
                c_Local_PosLiga.SqlDbType = SqlDbType.Int;
                c_Local_PosLiga.Value = objBE.C_Local_PosLiga;

                c_Local_Pts = new SqlParameter();
                c_Local_Pts.ParameterName = "@c_Local_Pts";
                c_Local_Pts.SqlDbType = SqlDbType.Int;
                c_Local_Pts.Value = objBE.C_Local_Pts;

                c_Local = new SqlParameter();
                c_Local.ParameterName = "@c_Local";
                c_Local.SqlDbType = SqlDbType.Bit;
                c_Local.Value = objBE.C_Local;

                c_Local_PosRankMund = new SqlParameter();
                c_Local_PosRankMund.ParameterName = "@c_Local_PosRankMund";
                c_Local_PosRankMund.SqlDbType = SqlDbType.Int;
                c_Local_PosRankMund.Value = objBE.C_Local_PosRankMund;
                /*
                c_Local_GoleadorSuspendido = new SqlParameter();
                c_Local_GoleadorSuspendido.ParameterName = "@c_Local_GoleadorSuspendido";
                c_Local_GoleadorSuspendido.SqlDbType = SqlDbType.Bit;
                c_Local_GoleadorSuspendido.Value = objBE.C_Local_GoleadorSuspendido;

                c_Local_ArqueroSuspendido = new SqlParameter();
                c_Local_ArqueroSuspendido.ParameterName = "@c_Local_ArqueroSuspendido";
                c_Local_ArqueroSuspendido.SqlDbType = SqlDbType.Bit;
                c_Local_ArqueroSuspendido.Value = objBE.C_Local_ArqueroSuspendido;
                */
                c_Local_QExpulsados = new SqlParameter();
                c_Local_QExpulsados.ParameterName = "@c_Local_QExpulsados";
                c_Local_QExpulsados.SqlDbType = SqlDbType.Int;
                c_Local_QExpulsados.Value = objBE.C_Local_QExpulsados;

                c_Local_QSuspendidos = new SqlParameter();
                c_Local_QSuspendidos.ParameterName = "@c_Local_QSuspendidos";
                c_Local_QSuspendidos.SqlDbType = SqlDbType.Int;
                c_Local_QSuspendidos.Value = objBE.C_Local_QSuspendidos;

                c_Local_GolesAnotados = new SqlParameter();
                c_Local_GolesAnotados.ParameterName = "@c_Local_GolesAnotados";
                c_Local_GolesAnotados.SqlDbType = SqlDbType.Int;
                c_Local_GolesAnotados.Value = objBE.C_Local_GolesAnotados;

                c_Local_GolesEncajados = new SqlParameter();
                c_Local_GolesEncajados.ParameterName = "@c_Local_GolesEncajados";
                c_Local_GolesEncajados.SqlDbType = SqlDbType.Int;
                c_Local_GolesEncajados.Value = objBE.C_Local_GolesEncajados;

                c_Local_PromEdad = new SqlParameter();
                c_Local_PromEdad.ParameterName = "@c_Local_PromEdad";
                c_Local_PromEdad.SqlDbType = SqlDbType.Decimal;
                c_Local_PromEdad.Value = objBE.C_Local_PromEdad;

                c_Local_QPartidosMes = new SqlParameter();
                c_Local_QPartidosMes.ParameterName = "@c_Local_QPartidosMes";
                c_Local_QPartidosMes.SqlDbType = SqlDbType.Int;
                c_Local_QPartidosMes.Value = objBE.C_Local_QPartidosMes;

                c_Visita_PosLiga = new SqlParameter();
                c_Visita_PosLiga.ParameterName = "@c_Visita_PosLiga";
                c_Visita_PosLiga.SqlDbType = SqlDbType.Int;
                c_Visita_PosLiga.Value = objBE.C_Visita_PosLiga;

                c_Visita_Pts = new SqlParameter();
                c_Visita_Pts.ParameterName = "@c_Visita_Pts";
                c_Visita_Pts.SqlDbType = SqlDbType.Int;
                c_Visita_Pts.Value = objBE.C_Visita_Pts;

                c_Visita = new SqlParameter();
                c_Visita.ParameterName = "@c_Visita";
                c_Visita.SqlDbType = SqlDbType.Bit;
                c_Visita.Value = objBE.C_Visita;

                c_Visita_PosRankMund = new SqlParameter();
                c_Visita_PosRankMund.ParameterName = "@c_Visita_PosRankMund";
                c_Visita_PosRankMund.SqlDbType = SqlDbType.Int;
                c_Visita_PosRankMund.Value = objBE.C_Visita_PosRankMund;
                /*
                c_Visita_GoleadorSuspendido = new SqlParameter();
                c_Visita_GoleadorSuspendido.ParameterName = "@c_Visita_GoleadorSuspendido";
                c_Visita_GoleadorSuspendido.SqlDbType = SqlDbType.Bit;
                c_Visita_GoleadorSuspendido.Value = objBE.C_Visita_GoleadorSuspendido;

                c_Visita_ArqueroSuspendido = new SqlParameter();
                c_Visita_ArqueroSuspendido.ParameterName = "@c_Visita_ArqueroSuspendido";
                c_Visita_ArqueroSuspendido.SqlDbType = SqlDbType.Bit;
                c_Visita_ArqueroSuspendido.Value = objBE.C_Visita_ArqueroSuspendido;
                */
                c_Visita_QExpulsados = new SqlParameter();
                c_Visita_QExpulsados.ParameterName = "@c_Visita_QExpulsados";
                c_Visita_QExpulsados.SqlDbType = SqlDbType.Int;
                c_Visita_QExpulsados.Value = objBE.C_Visita_QExpulsados;

                c_Visita_QSuspendidos = new SqlParameter();
                c_Visita_QSuspendidos.ParameterName = "@c_Visita_QSuspendidos";
                c_Visita_QSuspendidos.SqlDbType = SqlDbType.Int;
                c_Visita_QSuspendidos.Value = objBE.C_Visita_QSuspendidos;

                c_Visita_GolesAnotados = new SqlParameter();
                c_Visita_GolesAnotados.ParameterName = "@c_Visita_GolesAnotados";
                c_Visita_GolesAnotados.SqlDbType = SqlDbType.Int;
                c_Visita_GolesAnotados.Value = objBE.C_Visita_GolesAnotados;

                c_Visita_GolesEncajados = new SqlParameter();
                c_Visita_GolesEncajados.ParameterName = "@c_Visita_GolesEncajados";
                c_Visita_GolesEncajados.SqlDbType = SqlDbType.Int;
                c_Visita_GolesEncajados.Value = objBE.C_Visita_GolesEncajados;

                c_Visita_PromEdad = new SqlParameter();
                c_Visita_PromEdad.ParameterName = "@c_Visita_PromEdad";
                c_Visita_PromEdad.SqlDbType = SqlDbType.Decimal;
                c_Visita_PromEdad.Value = objBE.C_Visita_PromEdad;

                c_Visita_QPartidosMes = new SqlParameter();
                c_Visita_QPartidosMes.ParameterName = "@c_Visita_QPartidosMes";
                c_Visita_QPartidosMes.SqlDbType = SqlDbType.Int;
                c_Visita_QPartidosMes.Value = objBE.C_Visita_QPartidosMes;

                c_Resultado = new SqlParameter();
                c_Resultado.ParameterName = "@c_Resultado";
                c_Resultado.SqlDbType = SqlDbType.VarChar;
                c_Resultado.Size = 5;
                c_Resultado.Value = objBE.C_Resultado;

                cmd_PartidoPronosticadoInsertar.Parameters.Add(idPartido);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_QEquiposLiga);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Mes);
                //cmd_PartidoPronosticadoInsertar.Parameters.Add(c_QEquiposMundial);
                //cmd_PartidoPronosticadoInsertar.Parameters.Add(c_QAsistencia);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Local_PosLiga);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Local_Pts);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Local);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Local_PosRankMund);
                //cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Local_GoleadorSuspendido);
                //cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Local_ArqueroSuspendido);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Local_QExpulsados);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Local_QSuspendidos);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Local_GolesAnotados);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Local_GolesEncajados);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Local_PromEdad);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Local_QPartidosMes);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Visita_PosLiga);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Visita_Pts);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Visita);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Visita_PosRankMund);
                //cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Visita_GoleadorSuspendido);
                //cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Visita_ArqueroSuspendido);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Visita_QExpulsados);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Visita_QSuspendidos);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Visita_GolesAnotados);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Visita_GolesEncajados);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Visita_PromEdad);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Visita_QPartidosMes);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Resultado);

                cmd_PartidoPronosticadoInsertar.Connection.Open();
                cmd_PartidoPronosticadoInsertar.ExecuteNonQuery();
            }
            catch (Exception)
            {
                conexion.Dispose();
                throw;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Dispose();
                    conexion = null;
                }
            }
        }

        public List<PartidoPronosticadoBE> listar_PartidoPronosticado()
        {
            SqlConnection conexion = null;
            SqlDataReader dr;
            SqlCommand cmd;
            String sqlPartidoPronosticadoListar;

            try
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);
                sqlPartidoPronosticadoListar = "spListarPartidosPronosticados";
                cmd = new SqlCommand(sqlPartidoPronosticadoListar, conexion);
                cmd.Connection.Open();
                dr = cmd.ExecuteReader();

                List<PartidoPronosticadoBE> lista_PartidoPronosticado;
                PartidoPronosticadoBE objBE;

                lista_PartidoPronosticado = new List<PartidoPronosticadoBE>();

                while (dr.Read())
                {
                    objBE = new PartidoPronosticadoBE();

                    objBE.IdPartido = dr.GetInt32(dr.GetOrdinal("idPartido"));
                    objBE.C_QEquiposLiga = dr.GetInt32(dr.GetOrdinal("c_QEquiposLiga"));
                    objBE.C_Mes = dr.GetInt32(dr.GetOrdinal("c_Mes"));
                    //objBE.C_QEquiposMundial = dr.GetInt32(dr.GetOrdinal("c_QEquiposMundial"));
                    //objBE.C_QAsistencia = dr.GetInt32(dr.GetOrdinal("c_QAsistencia"));
                    objBE.C_Local_PosLiga = dr.GetInt32(dr.GetOrdinal("c_Local_PosLiga"));
                    objBE.C_Local_Pts = dr.GetInt32(dr.GetOrdinal("c_Local_Pts"));
                    objBE.C_Local = dr.GetBoolean(dr.GetOrdinal("c_Local"));
                    objBE.C_Local_PosRankMund = dr.GetInt32(dr.GetOrdinal("c_Local_PosRankMund"));
                    //objBE.C_Local_GoleadorSuspendido = dr.GetBoolean(dr.GetOrdinal("c_Local_GoleadorSuspendido"));
                    //objBE.C_Local_ArqueroSuspendido = dr.GetBoolean(dr.GetOrdinal("c_Local_ArqueroSuspendido"));
                    objBE.C_Local_QExpulsados = dr.GetInt32(dr.GetOrdinal("c_Local_QExpulsados"));
                    objBE.C_Local_QSuspendidos = dr.GetInt32(dr.GetOrdinal("c_Local_QSuspendidos"));
                    objBE.C_Local_GolesAnotados = dr.GetInt32(dr.GetOrdinal("c_Local_GolesAnotados"));
                    objBE.C_Local_GolesEncajados = dr.GetInt32(dr.GetOrdinal("c_Local_GolesEncajados"));
                    objBE.C_Local_PromEdad = dr.GetDecimal(dr.GetOrdinal("c_Local_PromEdad"));
                    objBE.C_Local_QPartidosMes = dr.GetInt32(dr.GetOrdinal("c_Local_QPartidosMes"));
                    objBE.C_Visita_PosLiga = dr.GetInt32(dr.GetOrdinal("c_Visita_PosLiga"));
                    objBE.C_Visita_Pts = dr.GetInt32(dr.GetOrdinal("c_Visita_Pts"));
                    objBE.C_Visita = dr.GetBoolean(dr.GetOrdinal("c_Visita"));
                    objBE.C_Visita_PosRankMund = dr.GetInt32(dr.GetOrdinal("c_Visita_PosRankMund"));
                    //objBE.C_Visita_GoleadorSuspendido = dr.GetBoolean(dr.GetOrdinal("c_Visita_GoleadorSuspendido"));
                    //objBE.C_Visita_ArqueroSuspendido = dr.GetBoolean(dr.GetOrdinal("c_Visita_ArqueroSuspendido"));
                    objBE.C_Visita_QExpulsados = dr.GetInt32(dr.GetOrdinal("c_Visita_QExpulsados"));
                    objBE.C_Visita_QSuspendidos = dr.GetInt32(dr.GetOrdinal("c_Visita_QSuspendidos"));
                    objBE.C_Visita_GolesAnotados = dr.GetInt32(dr.GetOrdinal("c_Visita_GolesAnotados"));
                    objBE.C_Visita_GolesEncajados = dr.GetInt32(dr.GetOrdinal("c_Visita_GolesEncajados"));
                    objBE.C_Visita_PromEdad = dr.GetDecimal(dr.GetOrdinal("c_Visita_PromEdad"));
                    objBE.C_Visita_QPartidosMes = dr.GetInt32(dr.GetOrdinal("c_Visita_QPartidosMes"));
                    objBE.C_Resultado = dr.GetString(dr.GetOrdinal("c_Resultado"));

                    lista_PartidoPronosticado.Add(objBE);
                }

                cmd.Connection.Close();
                conexion.Dispose();

                return lista_PartidoPronosticado;
            }

            catch (Exception ex)
            {
                conexion.Dispose();
                throw;
            }

        }

        public int existePronostico(int codPartido)
        {
            SqlConnection conexion = null;
            SqlDataReader dr_Partido;
            SqlCommand cmd_PartidoValidar;
            String sqlPartidoValidar;
            SqlParameter prm_codPartido;

            int cantidad = 0;

            try
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);
                sqlPartidoValidar = "spVerificarExistePronostico";

                cmd_PartidoValidar = new SqlCommand(sqlPartidoValidar, conexion);
                cmd_PartidoValidar.CommandType = CommandType.StoredProcedure;

                prm_codPartido = new SqlParameter();
                prm_codPartido.ParameterName = "@codPartido";
                prm_codPartido.SqlDbType = SqlDbType.Int;
                prm_codPartido.Value = codPartido;
    
                cmd_PartidoValidar.Parameters.Add(prm_codPartido);

                cmd_PartidoValidar.Connection.Open();
                dr_Partido = cmd_PartidoValidar.ExecuteReader();

                if (dr_Partido.Read())
                {
                    cantidad = dr_Partido.GetInt32(dr_Partido.GetOrdinal("CANTIDAD"));
                }

                cmd_PartidoValidar.Connection.Close();
                conexion.Dispose();

                return cantidad;
            }
            catch (Exception ex)
            {
                conexion.Dispose();
                throw;
            }
        }

        public int existePartidoPronosticado(int codPartido)
        {
            SqlConnection conexion = null;
            SqlDataReader dr_Partido;
            SqlCommand cmd_PartidoValidar;
            String sqlPartidoValidar;
            SqlParameter prm_codPartido;

            int cantidad = 0;

            try
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);
                sqlPartidoValidar = "spVerificarExistePartidoPronostico";

                cmd_PartidoValidar = new SqlCommand(sqlPartidoValidar, conexion);
                cmd_PartidoValidar.CommandType = CommandType.StoredProcedure;

                prm_codPartido = new SqlParameter();
                prm_codPartido.ParameterName = "@codPartido";
                prm_codPartido.SqlDbType = SqlDbType.Int;
                prm_codPartido.Value = codPartido;

                cmd_PartidoValidar.Parameters.Add(prm_codPartido);

                cmd_PartidoValidar.Connection.Open();
                dr_Partido = cmd_PartidoValidar.ExecuteReader();

                if (dr_Partido.Read())
                {
                    cantidad = dr_Partido.GetInt32(dr_Partido.GetOrdinal("CANTIDAD"));
                }

                cmd_PartidoValidar.Connection.Close();
                conexion.Dispose();

                return cantidad;
            }
            catch (Exception ex)
            {
                conexion.Dispose();
                throw;
            }
        }

        public void ActualizarPartidoPronosticado(PartidoPronosticadoBE objBE)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_PartidoPronosticadoInsertar;

            SqlParameter idPartido;
            SqlParameter c_QEquiposLiga;
            SqlParameter c_Mes;
            //SqlParameter c_QEquiposMundial;
            //SqlParameter c_QAsistencia;
            SqlParameter c_Local_PosLiga;
            SqlParameter c_Local_Pts;
            SqlParameter c_Local;
            SqlParameter c_Local_PosRankMund;
            //SqlParameter c_Local_GoleadorSuspendido;
            //SqlParameter c_Local_ArqueroSuspendido;
            SqlParameter c_Local_QExpulsados;
            SqlParameter c_Local_QSuspendidos;
            SqlParameter c_Local_GolesAnotados;
            SqlParameter c_Local_GolesEncajados;
            SqlParameter c_Local_PromEdad;
            SqlParameter c_Local_QPartidosMes;
            SqlParameter c_Visita_PosLiga;
            SqlParameter c_Visita_Pts;
            SqlParameter c_Visita;
            SqlParameter c_Visita_PosRankMund;
            //SqlParameter c_Visita_GoleadorSuspendido;
            //SqlParameter c_Visita_ArqueroSuspendido;
            SqlParameter c_Visita_QExpulsados;
            SqlParameter c_Visita_QSuspendidos;
            SqlParameter c_Visita_GolesAnotados;
            SqlParameter c_Visita_GolesEncajados;
            SqlParameter c_Visita_PromEdad;
            SqlParameter c_Visita_QPartidosMes;
            SqlParameter c_Resultado;

            String sqlPartidoPronosticadoInsertar;

            try
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);

                sqlPartidoPronosticadoInsertar = "spUpdatePartidoPronosticado";

                cmd_PartidoPronosticadoInsertar = new SqlCommand(sqlPartidoPronosticadoInsertar, conexion);
                cmd_PartidoPronosticadoInsertar.CommandType = CommandType.StoredProcedure;

                idPartido = new SqlParameter();
                idPartido.ParameterName = "@idPartido";
                idPartido.SqlDbType = SqlDbType.Int;
                idPartido.Value = objBE.IdPartido;

                c_QEquiposLiga = new SqlParameter();
                c_QEquiposLiga.ParameterName = "@c_QEquiposLiga";
                c_QEquiposLiga.SqlDbType = SqlDbType.Int;
                c_QEquiposLiga.Value = objBE.C_QEquiposLiga;

                c_Mes = new SqlParameter();
                c_Mes.ParameterName = "@c_mes";
                c_Mes.SqlDbType = SqlDbType.Int;
                c_Mes.Value = objBE.C_Mes;
                /*
                c_QEquiposMundial = new SqlParameter();
                c_QEquiposMundial.ParameterName = "@c_QEquiposMundial";
                c_QEquiposMundial.SqlDbType = SqlDbType.Int;
                c_QEquiposMundial.Value = objBE.C_QEquiposMundial;

                c_QAsistencia = new SqlParameter();
                c_QAsistencia.ParameterName = "@c_QAsistencia";
                c_QAsistencia.SqlDbType = SqlDbType.Int;
                c_QAsistencia.Value = objBE.C_QAsistencia;
                */
                c_Local_PosLiga = new SqlParameter();
                c_Local_PosLiga.ParameterName = "@c_Local_PosLiga";
                c_Local_PosLiga.SqlDbType = SqlDbType.Int;
                c_Local_PosLiga.Value = objBE.C_Local_PosLiga;

                c_Local_Pts = new SqlParameter();
                c_Local_Pts.ParameterName = "@c_Local_Pts";
                c_Local_Pts.SqlDbType = SqlDbType.Int;
                c_Local_Pts.Value = objBE.C_Local_Pts;

                c_Local = new SqlParameter();
                c_Local.ParameterName = "@c_Local";
                c_Local.SqlDbType = SqlDbType.Bit;
                c_Local.Value = objBE.C_Local;

                c_Local_PosRankMund = new SqlParameter();
                c_Local_PosRankMund.ParameterName = "@c_Local_PosRankMund";
                c_Local_PosRankMund.SqlDbType = SqlDbType.Int;
                c_Local_PosRankMund.Value = objBE.C_Local_PosRankMund;
                /*
                c_Local_GoleadorSuspendido = new SqlParameter();
                c_Local_GoleadorSuspendido.ParameterName = "@c_Local_GoleadorSuspendido";
                c_Local_GoleadorSuspendido.SqlDbType = SqlDbType.Bit;
                c_Local_GoleadorSuspendido.Value = objBE.C_Local_GoleadorSuspendido;

                c_Local_ArqueroSuspendido = new SqlParameter();
                c_Local_ArqueroSuspendido.ParameterName = "@c_Local_ArqueroSuspendido";
                c_Local_ArqueroSuspendido.SqlDbType = SqlDbType.Bit;
                c_Local_ArqueroSuspendido.Value = objBE.C_Local_ArqueroSuspendido;
                */
                c_Local_QExpulsados = new SqlParameter();
                c_Local_QExpulsados.ParameterName = "@c_Local_QExpulsados";
                c_Local_QExpulsados.SqlDbType = SqlDbType.Int;
                c_Local_QExpulsados.Value = objBE.C_Local_QExpulsados;

                c_Local_QSuspendidos = new SqlParameter();
                c_Local_QSuspendidos.ParameterName = "@c_Local_QSuspendidos";
                c_Local_QSuspendidos.SqlDbType = SqlDbType.Int;
                c_Local_QSuspendidos.Value = objBE.C_Local_QSuspendidos;

                c_Local_GolesAnotados = new SqlParameter();
                c_Local_GolesAnotados.ParameterName = "@c_Local_GolesAnotados";
                c_Local_GolesAnotados.SqlDbType = SqlDbType.Int;
                c_Local_GolesAnotados.Value = objBE.C_Local_GolesAnotados;

                c_Local_GolesEncajados = new SqlParameter();
                c_Local_GolesEncajados.ParameterName = "@c_Local_GolesEncajados";
                c_Local_GolesEncajados.SqlDbType = SqlDbType.Int;
                c_Local_GolesEncajados.Value = objBE.C_Local_GolesEncajados;

                c_Local_PromEdad = new SqlParameter();
                c_Local_PromEdad.ParameterName = "@c_Local_PromEdad";
                c_Local_PromEdad.SqlDbType = SqlDbType.Decimal;
                c_Local_PromEdad.Value = objBE.C_Local_PromEdad;

                c_Local_QPartidosMes = new SqlParameter();
                c_Local_QPartidosMes.ParameterName = "@c_Local_QPartidosMes";
                c_Local_QPartidosMes.SqlDbType = SqlDbType.Int;
                c_Local_QPartidosMes.Value = objBE.C_Local_QPartidosMes;

                c_Visita_PosLiga = new SqlParameter();
                c_Visita_PosLiga.ParameterName = "@c_Visita_PosLiga";
                c_Visita_PosLiga.SqlDbType = SqlDbType.Int;
                c_Visita_PosLiga.Value = objBE.C_Visita_PosLiga;

                c_Visita_Pts = new SqlParameter();
                c_Visita_Pts.ParameterName = "@c_Visita_Pts";
                c_Visita_Pts.SqlDbType = SqlDbType.Int;
                c_Visita_Pts.Value = objBE.C_Visita_Pts;

                c_Visita = new SqlParameter();
                c_Visita.ParameterName = "@c_Visita";
                c_Visita.SqlDbType = SqlDbType.Bit;
                c_Visita.Value = objBE.C_Visita;

                c_Visita_PosRankMund = new SqlParameter();
                c_Visita_PosRankMund.ParameterName = "@c_Visita_PosRankMund";
                c_Visita_PosRankMund.SqlDbType = SqlDbType.Int;
                c_Visita_PosRankMund.Value = objBE.C_Visita_PosRankMund;
                /*
                c_Visita_GoleadorSuspendido = new SqlParameter();
                c_Visita_GoleadorSuspendido.ParameterName = "@c_Visita_GoleadorSuspendido";
                c_Visita_GoleadorSuspendido.SqlDbType = SqlDbType.Bit;
                c_Visita_GoleadorSuspendido.Value = objBE.C_Visita_GoleadorSuspendido;

                c_Visita_ArqueroSuspendido = new SqlParameter();
                c_Visita_ArqueroSuspendido.ParameterName = "@c_Visita_ArqueroSuspendido";
                c_Visita_ArqueroSuspendido.SqlDbType = SqlDbType.Bit;
                c_Visita_ArqueroSuspendido.Value = objBE.C_Visita_ArqueroSuspendido;
                */
                c_Visita_QExpulsados = new SqlParameter();
                c_Visita_QExpulsados.ParameterName = "@c_Visita_QExpulsados";
                c_Visita_QExpulsados.SqlDbType = SqlDbType.Int;
                c_Visita_QExpulsados.Value = objBE.C_Visita_QExpulsados;

                c_Visita_QSuspendidos = new SqlParameter();
                c_Visita_QSuspendidos.ParameterName = "@c_Visita_QSuspendidos";
                c_Visita_QSuspendidos.SqlDbType = SqlDbType.Int;
                c_Visita_QSuspendidos.Value = objBE.C_Visita_QSuspendidos;

                c_Visita_GolesAnotados = new SqlParameter();
                c_Visita_GolesAnotados.ParameterName = "@c_Visita_GolesAnotados";
                c_Visita_GolesAnotados.SqlDbType = SqlDbType.Int;
                c_Visita_GolesAnotados.Value = objBE.C_Visita_GolesAnotados;

                c_Visita_GolesEncajados = new SqlParameter();
                c_Visita_GolesEncajados.ParameterName = "@c_Visita_GolesEncajados";
                c_Visita_GolesEncajados.SqlDbType = SqlDbType.Int;
                c_Visita_GolesEncajados.Value = objBE.C_Visita_GolesEncajados;

                c_Visita_PromEdad = new SqlParameter();
                c_Visita_PromEdad.ParameterName = "@c_Visita_PromEdad";
                c_Visita_PromEdad.SqlDbType = SqlDbType.Decimal;
                c_Visita_PromEdad.Value = objBE.C_Visita_PromEdad;

                c_Visita_QPartidosMes = new SqlParameter();
                c_Visita_QPartidosMes.ParameterName = "@c_Visita_QPartidosMes";
                c_Visita_QPartidosMes.SqlDbType = SqlDbType.Int;
                c_Visita_QPartidosMes.Value = objBE.C_Visita_QPartidosMes;
                                
                c_Resultado = new SqlParameter();
                c_Resultado.ParameterName = "@c_Resultado";
                c_Resultado.SqlDbType = SqlDbType.VarChar;
                c_Resultado.Size = 5;
                c_Resultado.Value = objBE.C_Resultado;

                cmd_PartidoPronosticadoInsertar.Parameters.Add(idPartido);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_QEquiposLiga);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Mes);
                //cmd_PartidoPronosticadoInsertar.Parameters.Add(c_QEquiposMundial);
                //cmd_PartidoPronosticadoInsertar.Parameters.Add(c_QAsistencia);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Local_PosLiga);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Local_Pts);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Local);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Local_PosRankMund);
                //cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Local_GoleadorSuspendido);
                //cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Local_ArqueroSuspendido);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Local_QExpulsados);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Local_QSuspendidos);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Local_GolesAnotados);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Local_GolesEncajados);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Local_PromEdad);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Local_QPartidosMes);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Visita_PosLiga);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Visita_Pts);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Visita);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Visita_PosRankMund);
                //cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Visita_GoleadorSuspendido);
                //cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Visita_ArqueroSuspendido);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Visita_QExpulsados);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Visita_QSuspendidos);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Visita_GolesAnotados);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Visita_GolesEncajados);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Visita_PromEdad);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Visita_QPartidosMes);
                cmd_PartidoPronosticadoInsertar.Parameters.Add(c_Resultado);

                cmd_PartidoPronosticadoInsertar.Connection.Open();
                cmd_PartidoPronosticadoInsertar.ExecuteNonQuery();
            }
            catch (Exception)
            {
                conexion.Dispose();
                throw;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Dispose();
                    conexion = null;
                }
            }
        }
    }
}
