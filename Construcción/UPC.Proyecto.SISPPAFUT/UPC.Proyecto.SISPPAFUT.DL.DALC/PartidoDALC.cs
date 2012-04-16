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
            SqlParameter prm_GolesLocal;
            SqlParameter prm_GolesVisita;
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

                prm_GolesLocal = new SqlParameter();
                prm_GolesLocal.ParameterName = "@GolesLocal";
                prm_GolesLocal.SqlDbType = SqlDbType.Int;
                prm_GolesLocal.Value = objPartidoBE.Goles_local;

                prm_GolesVisita = new SqlParameter();
                prm_GolesVisita.ParameterName = "@GolesVisita";
                prm_GolesVisita.SqlDbType = SqlDbType.Int;
                prm_GolesVisita.Value = objPartidoBE.Goles_visita;

                prm_Fecha = new SqlParameter();
                prm_Fecha.ParameterName = "@Fecha";
                prm_Fecha.SqlDbType = SqlDbType.Date;
                prm_Fecha.Value = objPartidoBE.Fecha_partido;

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
    }
}
