using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.DL.DALC
{
    public class PartidoDALC
    {
        public int insertar_partido(PartidoBE objPartidoBE)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_PartidoInsertar = null;

            SqlParameter prm_CodigoPartido;
            SqlParameter prm_CodigoLiga;
            SqlParameter prm_CodigoEquipoLocal;
            SqlParameter prm_CodigoEquipoVisitante;
            SqlParameter prm_CodigoEstadio;
            //--SqlParameter prm_GolesLocal;
            //--SqlParameter prm_GolesVisita;
            SqlParameter prm_Fecha;

            int iCodigoPartido;

            String sqlPartidoInsertar;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);

                sqlPartidoInsertar = "spCreatePartido";

                cmd_PartidoInsertar = new SqlCommand(sqlPartidoInsertar, conexion);
                cmd_PartidoInsertar.CommandType = CommandType.StoredProcedure;

                prm_CodigoPartido = new SqlParameter();
                prm_CodigoPartido.Direction = ParameterDirection.ReturnValue;
                prm_CodigoPartido.SqlDbType = SqlDbType.Int;

                prm_CodigoLiga = new SqlParameter();
                prm_CodigoLiga.ParameterName = "@CodLiga";
                prm_CodigoLiga.SqlDbType = SqlDbType.Int;
                prm_CodigoLiga.Value = objPartidoBE.Codigo_liga;

                prm_CodigoEquipoLocal = new SqlParameter();
                prm_CodigoEquipoLocal.ParameterName = "@CodEquipoL";
                prm_CodigoEquipoLocal.SqlDbType = SqlDbType.Int;
                prm_CodigoEquipoLocal.Value = objPartidoBE.Codigo_equipo_local;

                prm_CodigoEquipoVisitante = new SqlParameter();
                prm_CodigoEquipoVisitante.ParameterName = "@CodEquipoV";
                prm_CodigoEquipoVisitante.SqlDbType = SqlDbType.Int;
                prm_CodigoEquipoVisitante.Value = objPartidoBE.Codigo_equipo_visitante;

                prm_CodigoEstadio = new SqlParameter();
                prm_CodigoEstadio.ParameterName = "@CodEstadio";
                prm_CodigoEstadio.SqlDbType = SqlDbType.Int;
                prm_CodigoEstadio.Value = objPartidoBE.Codigo_estadio;

                /* -- Los GOLES se actualizan de forma automática después de haberse jugado el partido
                 *      y de haber guardado la información de los datos del partido (goles_x_jugador, amonestaciones, lesiones)
                prm_GolesLocal = new SqlParameter();
                prm_GolesLocal.ParameterName = "@GolesLocal";
                prm_GolesLocal.SqlDbType = SqlDbType.Int;
                prm_GolesLocal.Value = objPartidoBE.Goles_local;

                prm_GolesVisita = new SqlParameter();
                prm_GolesVisita.ParameterName = "@GolesVisita";
                prm_GolesVisita.SqlDbType = SqlDbType.Int;
                prm_GolesVisita.Value = objPartidoBE.Goles_visita;
                */

                prm_Fecha = new SqlParameter();
                prm_Fecha.ParameterName = "@Fecha";
                prm_Fecha.SqlDbType = SqlDbType.Date;
                prm_Fecha.Value = objPartidoBE.Fecha_partido;

                cmd_PartidoInsertar.Parameters.Add(prm_CodigoPartido);
                cmd_PartidoInsertar.Parameters.Add(prm_CodigoLiga);
                cmd_PartidoInsertar.Parameters.Add(prm_CodigoEstadio);
                cmd_PartidoInsertar.Parameters.Add(prm_CodigoEquipoLocal);
                cmd_PartidoInsertar.Parameters.Add(prm_CodigoEquipoVisitante);
                cmd_PartidoInsertar.Parameters.Add(prm_Fecha);

                cmd_PartidoInsertar.Connection.Open();
                cmd_PartidoInsertar.ExecuteNonQuery();

                iCodigoPartido = Convert.ToInt32(prm_CodigoPartido.Value);

                return iCodigoPartido;
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
                cmd_PartidoInsertar.Connection.Close();
                conexion.Dispose();
            }
        }

        public List<PartidoSinJugarBE> listar_partidos_sinjugar()
        {
            SqlConnection conexion = null;
            SqlDataReader dr_partidos;
            SqlCommand cmd_partidos = null;
            String sqlPartidosListar;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlPartidosListar = "spListaPartidosSinJugar";
                cmd_partidos = conexion.CreateCommand();
                cmd_partidos.CommandText = sqlPartidosListar;
                cmd_partidos.CommandType = CommandType.StoredProcedure;

                cmd_partidos.Connection.Open();
                dr_partidos = cmd_partidos.ExecuteReader();

                List<PartidoSinJugarBE> lista_partidos;
                PartidoSinJugarBE objPartidoBE;

                lista_partidos = new List<PartidoSinJugarBE>();

                while(dr_partidos.Read())
                {
                    objPartidoBE = new PartidoSinJugarBE();

                    objPartidoBE.Codigo_partido = dr_partidos.GetInt32(0);
                    objPartidoBE.Pais = dr_partidos.GetString(1);
                    objPartidoBE.Liga = dr_partidos.GetString(2);
                    objPartidoBE.Equipo_local = dr_partidos.GetString(3);
                    objPartidoBE.Equipo_visitante = dr_partidos.GetString(4);
                    objPartidoBE.Fecha = dr_partidos.GetDateTime(5);

                    lista_partidos.Add(objPartidoBE);
                }

                return lista_partidos;
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
                cmd_partidos.Connection.Close();
                conexion.Dispose();
            }
        }
    }
}
