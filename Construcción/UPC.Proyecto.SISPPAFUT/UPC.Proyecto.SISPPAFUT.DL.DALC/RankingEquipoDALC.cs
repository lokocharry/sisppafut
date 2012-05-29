using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.DL.DALC
{
    public class RankingEquipoDALC
    {
        public int insertar_ranking(RankingEquipoBE objRankingBE)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_RankingInsertar;

            SqlParameter prm_Codigo;
            SqlParameter prm_CodigoEquipo;
            SqlParameter prm_Posicion;
            SqlParameter prm_Anio;
            SqlParameter prm_Mes;
            SqlParameter prm_Puntos;

            int iCodigoRanking;
            String sqlRankingInsertar;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);

                sqlRankingInsertar = "spCreateRankingEquipo";
                cmd_RankingInsertar = new SqlCommand(sqlRankingInsertar, conexion);
                cmd_RankingInsertar.CommandType = CommandType.StoredProcedure;

                prm_Codigo = new SqlParameter();
                prm_Codigo.Direction = ParameterDirection.ReturnValue;
                prm_Codigo.SqlDbType = SqlDbType.Int;

                prm_CodigoEquipo = new SqlParameter();
                prm_CodigoEquipo.ParameterName = "@codEquipo";
                prm_CodigoEquipo.SqlDbType = SqlDbType.Int;
                prm_CodigoEquipo.Value = objRankingBE.CodigoEquipo;

                prm_Posicion = new SqlParameter();
                prm_Posicion.ParameterName = "@posicion";
                prm_Posicion.SqlDbType = SqlDbType.Int;
                prm_Posicion.Value = objRankingBE.PosicionRanking;

                prm_Anio = new SqlParameter();
                prm_Anio.ParameterName = "@anio";
                prm_Anio.SqlDbType = SqlDbType.Int;
                prm_Anio.Value = objRankingBE.AnioRanking;

                prm_Mes = new SqlParameter();
                prm_Mes.ParameterName = "@mes";
                prm_Mes.SqlDbType = SqlDbType.Int;
                prm_Mes.Value = objRankingBE.MesRanking;

                prm_Puntos = new SqlParameter();
                prm_Puntos.ParameterName = "@puntos";
                prm_Puntos.SqlDbType = SqlDbType.Int;
                prm_Puntos.Value = objRankingBE.PuntosRanking;

                cmd_RankingInsertar.Parameters.Add(prm_Codigo);
                cmd_RankingInsertar.Parameters.Add(prm_CodigoEquipo);
                cmd_RankingInsertar.Parameters.Add(prm_Posicion);
                cmd_RankingInsertar.Parameters.Add(prm_Anio);
                cmd_RankingInsertar.Parameters.Add(prm_Mes);
                cmd_RankingInsertar.Parameters.Add(prm_Puntos);

                cmd_RankingInsertar.Connection.Open();
                cmd_RankingInsertar.ExecuteNonQuery();

                iCodigoRanking = Convert.ToInt32(prm_Codigo.Value);
                
                return iCodigoRanking;
            }
            catch (Exception ex)
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

        public List<RankingBE> obtener_ranking(int anio, int mes, int codigoPais)
        {
            SqlConnection conexion = null;
            SqlDataReader dr_ranking;
            SqlCommand cmd_ranking;
            String sqlRankingObtener;
            SqlParameter prm_anio;
            SqlParameter prm_mes;
            SqlParameter prm_codigoPais;

            try
            {

                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlRankingObtener = "spReadRankingEquipo";
                cmd_ranking = conexion.CreateCommand();
                cmd_ranking.CommandText = sqlRankingObtener;
                cmd_ranking.CommandType = CommandType.StoredProcedure;

                prm_anio = cmd_ranking.CreateParameter();
                prm_anio.ParameterName = "@anio";
                prm_anio.SqlDbType = SqlDbType.Int;
                prm_anio.Value = anio;

                prm_mes = cmd_ranking.CreateParameter();
                prm_mes.ParameterName = "@mes";
                prm_mes.SqlDbType = SqlDbType.Int;
                prm_mes.Value = mes;

                prm_codigoPais = cmd_ranking.CreateParameter();
                prm_codigoPais.ParameterName = "@codPais";
                prm_codigoPais.SqlDbType = SqlDbType.Int;
                prm_codigoPais.Value = codigoPais;

                cmd_ranking.Parameters.Add(prm_anio);
                cmd_ranking.Parameters.Add(prm_mes);
                cmd_ranking.Parameters.Add(prm_codigoPais);

                cmd_ranking.Connection.Open();
                dr_ranking = cmd_ranking.ExecuteReader();

                List<RankingBE> lista_ranking;
                RankingBE objRankingBE;

                lista_ranking = new List<RankingBE>();

                while (dr_ranking.Read())
                {
                    objRankingBE = new RankingBE();

                    objRankingBE.NombreEquipo = dr_ranking.GetString(dr_ranking.GetOrdinal("Nombre"));
                    objRankingBE.Posicion = dr_ranking.GetInt32(dr_ranking.GetOrdinal("Posicion"));
                    objRankingBE.Puntos = dr_ranking.GetInt32(dr_ranking.GetOrdinal("Puntos"));
                    objRankingBE.Pais = dr_ranking.GetString(dr_ranking.GetOrdinal("Pais"));

                    lista_ranking.Add(objRankingBE);
                }

                cmd_ranking.Connection.Close();
                conexion.Dispose();

                return lista_ranking;
            }
            catch (Exception ex)
            {
                conexion.Dispose();
                throw;
            }
        }



    }
}
