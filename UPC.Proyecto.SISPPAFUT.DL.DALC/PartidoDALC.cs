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
                    cmd_PartidoInsertar.Connection.Close();
                }

                throw;
            }

            finally
            {
                cmd_PartidoInsertar.Connection.Close();
                conexion.Dispose();
            }
        }

        public List<PartidoBE> listar_todos_partidos()
        {
            SqlConnection conexion = null;
            SqlDataReader dr_partidos;
            SqlCommand cmd_partidos = null;
            String sqlPartidosListar;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlPartidosListar = "spListarPartidos";
                cmd_partidos = conexion.CreateCommand();
                cmd_partidos.CommandText = sqlPartidosListar;
                cmd_partidos.CommandType = CommandType.StoredProcedure;

                cmd_partidos.Connection.Open();
                dr_partidos = cmd_partidos.ExecuteReader();

                List<PartidoBE> lista_partidos;
                PartidoBE objPartidoBE;

                lista_partidos = new List<PartidoBE>();

                while (dr_partidos.Read())
                {
                    objPartidoBE = new PartidoBE();

                    objPartidoBE.Codigo_partido = dr_partidos.GetInt32(dr_partidos.GetOrdinal("CodPartido"));
                    objPartidoBE.Codigo_liga = dr_partidos.GetInt32(dr_partidos.GetOrdinal("CodLiga"));
                    objPartidoBE.Codigo_equipo_local = dr_partidos.GetInt32(dr_partidos.GetOrdinal("CodEquipoL"));
                    objPartidoBE.Codigo_equipo_visitante = dr_partidos.GetInt32(dr_partidos.GetOrdinal("CodEquipoV"));
                    objPartidoBE.Codigo_estadio = dr_partidos.GetInt32(dr_partidos.GetOrdinal("CodEstadio"));
                    if (dr_partidos.IsDBNull(dr_partidos.GetOrdinal("GolesLocal")))
                    {
                        objPartidoBE.Goles_local = 0;
                    }
                    else
                    {
                        objPartidoBE.Goles_local = dr_partidos.GetInt32(dr_partidos.GetOrdinal("GolesLocal"));
                    }
                    if (dr_partidos.IsDBNull(dr_partidos.GetOrdinal("GolesVisita")))
                    {
                        objPartidoBE.Goles_visita = 0;
                    }
                    else
                    {
                        objPartidoBE.Goles_visita = dr_partidos.GetInt32(dr_partidos.GetOrdinal("GolesVisita"));
                    }                    
                    objPartidoBE.Fecha_partido = dr_partidos.GetDateTime(dr_partidos.GetOrdinal("Fecha"));

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

        public List<PartidoSinJugarBE> listar_partidos_pronosticados()
        {
            SqlConnection conexion = null;
            SqlDataReader dr_partidos;
            SqlCommand cmd_partidos = null;
            String sqlPartidosListar;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlPartidosListar = "spPartidosPronosticados";
                cmd_partidos = conexion.CreateCommand();
                cmd_partidos.CommandText = sqlPartidosListar;
                cmd_partidos.CommandType = CommandType.StoredProcedure;

                cmd_partidos.Connection.Open();
                dr_partidos = cmd_partidos.ExecuteReader();

                List<PartidoSinJugarBE> lista_partidos;
                PartidoSinJugarBE objPartidoBE;

                lista_partidos = new List<PartidoSinJugarBE>();

                while (dr_partidos.Read())
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

        public List<PartidoSinJugarBE> listar_partidos_sinjugar()
        {
            SqlConnection conexion = null;
            SqlDataReader dr_partidos;
            SqlCommand cmd_partidos = null;
            String sqlPartidosListar;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlPartidosListar = "spListarPartidosPorJugar";
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

        public PartidoBE obtener_Partido(int codigo_partido)
        {
            SqlConnection conexion = null;
            SqlDataReader dr_partido;
            SqlCommand cmd_partido = null;
            String sqlPartidoObtener;
            SqlParameter prm_codigo_partido;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlPartidoObtener = "spReadPartido";
                cmd_partido = conexion.CreateCommand();
                cmd_partido.CommandText = sqlPartidoObtener;
                cmd_partido.CommandType = CommandType.StoredProcedure;

                prm_codigo_partido = new SqlParameter();
                prm_codigo_partido.ParameterName = "@CodPartido";
                prm_codigo_partido.SqlDbType = SqlDbType.Int;
                prm_codigo_partido.Value = codigo_partido;

                cmd_partido.Parameters.Add(prm_codigo_partido);

                cmd_partido.Connection.Open();
                dr_partido = cmd_partido.ExecuteReader();

                PartidoBE objPartidoBE = new PartidoBE();

                if(dr_partido.Read())
                {
                    objPartidoBE.Codigo_partido = dr_partido.GetInt32(dr_partido.GetOrdinal("CodPartido"));
                    objPartidoBE.Codigo_liga = dr_partido.GetInt32(dr_partido.GetOrdinal("CodLiga"));
                    objPartidoBE.Codigo_equipo_local = dr_partido.GetInt32(dr_partido.GetOrdinal("CodEquipoL"));
                    objPartidoBE.Codigo_equipo_visitante = dr_partido.GetInt32(dr_partido.GetOrdinal("CodEquipoV"));
                    objPartidoBE.Codigo_estadio = dr_partido.GetInt32(dr_partido.GetOrdinal("CodEstadio"));
                    if(dr_partido.IsDBNull(dr_partido.GetOrdinal("GolesLocal")) == false)
                    objPartidoBE.Goles_local = dr_partido.GetInt32(dr_partido.GetOrdinal("GolesLocal"));
                    if (dr_partido.IsDBNull(dr_partido.GetOrdinal("GolesVisita")) == false)
                    objPartidoBE.Goles_visita = dr_partido.GetInt32(dr_partido.GetOrdinal("GolesVisita"));
                    objPartidoBE.Fecha_partido = dr_partido.GetDateTime(dr_partido.GetOrdinal("Fecha"));
                }

                return objPartidoBE;
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
                cmd_partido.Connection.Close();
                conexion.Dispose();
            }
        }

        public void editar_partido(int codigoPartido, DateTime nuevaFecha)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_PartidoEditar = null;

            SqlParameter prm_CodigoPartido;
            SqlParameter prm_Fecha;

            String sqlUpdatePartido;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlUpdatePartido = "spUpdatePartido";

                cmd_PartidoEditar = new SqlCommand(sqlUpdatePartido, conexion);
                cmd_PartidoEditar.CommandType = CommandType.StoredProcedure;

                prm_CodigoPartido = new SqlParameter();
                prm_CodigoPartido.ParameterName = "@CodPartido";
                prm_CodigoPartido.SqlDbType = SqlDbType.Int;
                prm_CodigoPartido.Value = codigoPartido;

                prm_Fecha = new SqlParameter();
                prm_Fecha.ParameterName = "@Fecha";
                prm_Fecha.SqlDbType = SqlDbType.Date;
                prm_Fecha.Value = nuevaFecha;

                cmd_PartidoEditar.Parameters.Add(prm_CodigoPartido);
                cmd_PartidoEditar.Parameters.Add(prm_Fecha);

                cmd_PartidoEditar.Connection.Open();
                cmd_PartidoEditar.ExecuteNonQuery();
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
                cmd_PartidoEditar.Connection.Close();
                conexion.Dispose();
            }
        }

        public int existePartido(int codEqLocal, int codEqVisitante, int codLiga)
        {
            SqlConnection conexion = null;
            SqlDataReader dr_Partido;
            SqlCommand cmd_PartidoValidar;
            String sqlPartidoValidar;
            SqlParameter prm_codEqLocal;
            SqlParameter prm_codEqVisitante;
            SqlParameter prm_codLiga;

            int cantidad = 0;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlPartidoValidar = "spPartidoVerificarRepetido";

                cmd_PartidoValidar = new SqlCommand(sqlPartidoValidar, conexion);
                cmd_PartidoValidar.CommandType = CommandType.StoredProcedure;

                prm_codEqLocal = new SqlParameter();
                prm_codEqLocal.ParameterName = "@codEqLocal";
                prm_codEqLocal.SqlDbType = SqlDbType.Int;
                prm_codEqLocal.Value = codEqLocal;

                prm_codEqVisitante = new SqlParameter();
                prm_codEqVisitante.ParameterName = "@codEqVisitante";
                prm_codEqVisitante.SqlDbType = SqlDbType.Int;
                prm_codEqVisitante.Value = codEqVisitante;

                prm_codLiga = new SqlParameter();
                prm_codLiga.ParameterName = "@codLiga";
                prm_codLiga.SqlDbType = SqlDbType.Int;
                prm_codLiga.Value = codLiga;

                cmd_PartidoValidar.Parameters.Add(prm_codEqLocal);
                cmd_PartidoValidar.Parameters.Add(prm_codEqVisitante);
                cmd_PartidoValidar.Parameters.Add(prm_codLiga);

                cmd_PartidoValidar.Connection.Open();
                dr_Partido = cmd_PartidoValidar.ExecuteReader();

                if (dr_Partido.Read())
                {
                    cantidad = dr_Partido.GetInt32(dr_Partido.GetOrdinal("Cantidad"));
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

        public String limitePartidosLiga(int codLiga)
        {
            SqlConnection conexion = null;
            SqlDataReader dr_Partido;
            SqlCommand cmd_PartidoValidar;
            String sqlPartidoValidar;
            SqlParameter prm_codLiga;    

            String resultado = "";

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlPartidoValidar = "spPartidoVerificarCantidad";

                cmd_PartidoValidar = new SqlCommand(sqlPartidoValidar, conexion);
                cmd_PartidoValidar.CommandType = CommandType.StoredProcedure;

                prm_codLiga = new SqlParameter();
                prm_codLiga.ParameterName = "@codLiga";
                prm_codLiga.SqlDbType = SqlDbType.Int;
                prm_codLiga.Value = codLiga;

                cmd_PartidoValidar.Parameters.Add(prm_codLiga);

                cmd_PartidoValidar.Connection.Open();
                dr_Partido = cmd_PartidoValidar.ExecuteReader();

                if (dr_Partido.Read())
                {
                    resultado = dr_Partido.GetString(dr_Partido.GetOrdinal("Resultado"));
                }

                cmd_PartidoValidar.Connection.Close();
                conexion.Dispose();

                return resultado;
            }
            catch (Exception ex)
            {
                conexion.Dispose();
                throw;
            }
            /*
            String resultado = "";
            return resultado;*/
        }

        public void actualizar_Resultado(int codigo_partido, int goles_local, int goles_visita)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_ResultadoActualizar = null;
            SqlParameter prm_codigo_partido;
            SqlParameter prm_goles_local;
            SqlParameter prm_goles_visita;
            String sqlActualizarResultado;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);

                sqlActualizarResultado = "spUpdateGolesPartido";

                cmd_ResultadoActualizar = new SqlCommand(sqlActualizarResultado, conexion);
                cmd_ResultadoActualizar.CommandType = CommandType.StoredProcedure;

                prm_codigo_partido = new SqlParameter();
                prm_codigo_partido.ParameterName = "@CodPartido";
                prm_codigo_partido.SqlDbType = SqlDbType.Int;
                prm_codigo_partido.Value = codigo_partido;

                prm_goles_local = new SqlParameter();
                prm_goles_local.ParameterName = "@GolesLocal";
                prm_goles_local.SqlDbType = SqlDbType.Int;
                prm_goles_local.Value = goles_local;
                
                prm_goles_visita = new SqlParameter();
                prm_goles_visita.ParameterName = "@GolesVisita";
                prm_goles_visita.SqlDbType = SqlDbType.Int;
                prm_goles_visita.Value = goles_visita;

                cmd_ResultadoActualizar.Parameters.Add(prm_codigo_partido);
                cmd_ResultadoActualizar.Parameters.Add(prm_goles_local);
                cmd_ResultadoActualizar.Parameters.Add(prm_goles_visita);

                cmd_ResultadoActualizar.Connection.Open();
                cmd_ResultadoActualizar.ExecuteNonQuery();
            }

            catch (Exception)
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Dispose();
                    cmd_ResultadoActualizar.Connection.Close();
                }

                throw;
            }

            finally
            {
                cmd_ResultadoActualizar.Connection.Close();
                conexion.Dispose();
            }
        }

        public List<PartidoJugadoBE> lista_ultimosPartidos(int codigo_equipo, int codigo_liga, DateTime fecha)
        {
            SqlConnection conexion = null;
            SqlDataReader dr_partidos;
            SqlCommand cmd_partidos = null;
            String sqlPartidosListar;

            SqlParameter prm_equipo;
            SqlParameter prm_liga;
            SqlParameter prm_fecha;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlPartidosListar = "spLista5UltimosPartidos";
                cmd_partidos = conexion.CreateCommand();
                cmd_partidos.CommandText = sqlPartidosListar;
                cmd_partidos.CommandType = CommandType.StoredProcedure;

                prm_equipo = new SqlParameter();
                prm_equipo.ParameterName = "@CodEquipo";
                prm_equipo.SqlDbType = SqlDbType.Int;
                prm_equipo.Value = codigo_equipo;

                prm_liga = new SqlParameter();
                prm_liga.ParameterName = "@CodLiga";
                prm_liga.SqlDbType = SqlDbType.Int;
                prm_liga.Value = codigo_liga;

                prm_fecha = new SqlParameter();
                prm_fecha.ParameterName = "@Fecha";
                prm_fecha.SqlDbType = SqlDbType.DateTime;
                prm_fecha.Value = fecha;

                cmd_partidos.Parameters.Add(prm_equipo);
                cmd_partidos.Parameters.Add(prm_liga);
                cmd_partidos.Parameters.Add(prm_fecha);

                cmd_partidos.Connection.Open();
                dr_partidos = cmd_partidos.ExecuteReader();

                List<PartidoJugadoBE> lista_partidos;
                PartidoJugadoBE objPartidoBE;

                lista_partidos = new List<PartidoJugadoBE>();

                while (dr_partidos.Read())
                {
                    objPartidoBE = new PartidoJugadoBE();

                    objPartidoBE.Equipo_local = dr_partidos.GetString(0);
                    objPartidoBE.Equipo_visita = dr_partidos.GetString(1);
                    objPartidoBE.Goles_local = dr_partidos.GetInt32(2);
                    objPartidoBE.Goles_visita = dr_partidos.GetInt32(3);
                    objPartidoBE.Fecha = dr_partidos.GetDateTime(4);
                    objPartidoBE.Liga = dr_partidos.GetString(5);
                    objPartidoBE.CodPartido = dr_partidos.GetInt32(6);

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

        public List<PartidoSinJugarBE> listar_partidos_jugados()
        {
            SqlConnection conexion = null;
            SqlDataReader dr_partidos;
            SqlCommand cmd_partidos = null;
            String sqlPartidosListar;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlPartidosListar = "spListarPartidosDesarrollados";
                cmd_partidos = conexion.CreateCommand();
                cmd_partidos.CommandText = sqlPartidosListar;
                cmd_partidos.CommandType = CommandType.StoredProcedure;

                cmd_partidos.Connection.Open();
                dr_partidos = cmd_partidos.ExecuteReader();

                List<PartidoSinJugarBE> lista_partidos;
                PartidoSinJugarBE objPartidoBE;

                lista_partidos = new List<PartidoSinJugarBE>();

                while (dr_partidos.Read())
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
