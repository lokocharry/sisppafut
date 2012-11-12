using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.DL.DALC
{
    public class JugadorDALC
    {
        public int insertar_Jugador(JugadorBE objJugadorBE)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_JugadorInsertar = null;

            SqlParameter prm_CodigoJugador;
            SqlParameter prm_Nombres;
            SqlParameter prm_Apellidos;
            SqlParameter prm_Nacionalidad;
            SqlParameter prm_Fecha;
            SqlParameter prm_Posicion;
            SqlParameter prm_Altura;
            SqlParameter prm_Peso;

            int iCodigoJugador;

            String sqlJugadorInsertar;

            try
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);

                sqlJugadorInsertar = "spCreateJugador";

                cmd_JugadorInsertar = new SqlCommand(sqlJugadorInsertar, conexion);
                cmd_JugadorInsertar.CommandType = CommandType.StoredProcedure;

                prm_CodigoJugador = new SqlParameter();
                prm_CodigoJugador.Direction = ParameterDirection.ReturnValue;
                prm_CodigoJugador.SqlDbType = SqlDbType.Int;

                prm_Nombres = new SqlParameter();
                prm_Nombres.ParameterName = "@Nombres";
                prm_Nombres.SqlDbType = SqlDbType.VarChar;
                prm_Nombres.Size = 20;
                prm_Nombres.Value = objJugadorBE.Nombres;

                prm_Apellidos = new SqlParameter();
                prm_Apellidos.ParameterName = "@Apellidos";
                prm_Apellidos.SqlDbType = SqlDbType.VarChar;
                prm_Apellidos.Size = 20;
                prm_Apellidos.Value = objJugadorBE.Apellidos;

                prm_Nacionalidad = new SqlParameter();
                prm_Nacionalidad.ParameterName = "@Nacionalidad";
                prm_Nacionalidad.SqlDbType = SqlDbType.VarChar;
                prm_Nacionalidad.Size = 20;
                prm_Nacionalidad.Value = objJugadorBE.Nacionalidad;

                prm_Fecha = new SqlParameter();
                prm_Fecha.ParameterName = "@FechaNacimiento";
                prm_Fecha.SqlDbType = SqlDbType.Date;
                prm_Fecha.Value = objJugadorBE.FechaNacimiento;

                prm_Posicion = new SqlParameter();
                prm_Posicion.ParameterName = "@Posicion";
                prm_Posicion.SqlDbType = SqlDbType.VarChar;
                prm_Posicion.Size = 15;
                prm_Posicion.Value = objJugadorBE.Posicion;

                prm_Altura = new SqlParameter();
                prm_Altura.ParameterName = "@Altura";
                prm_Altura.SqlDbType = SqlDbType.Decimal;
                prm_Altura.Value = objJugadorBE.Altura;

                prm_Peso = new SqlParameter();
                prm_Peso.ParameterName = "@Peso";
                prm_Peso.SqlDbType = SqlDbType.Decimal;
                prm_Peso.Value = objJugadorBE.Peso;

                cmd_JugadorInsertar.Parameters.Add(prm_CodigoJugador);
                cmd_JugadorInsertar.Parameters.Add(prm_Nombres);
                cmd_JugadorInsertar.Parameters.Add(prm_Apellidos);
                cmd_JugadorInsertar.Parameters.Add(prm_Nacionalidad);
                cmd_JugadorInsertar.Parameters.Add(prm_Posicion);
                cmd_JugadorInsertar.Parameters.Add(prm_Peso);
                cmd_JugadorInsertar.Parameters.Add(prm_Altura);
                cmd_JugadorInsertar.Parameters.Add(prm_Fecha);

                cmd_JugadorInsertar.Connection.Open();
                cmd_JugadorInsertar.ExecuteNonQuery();

                iCodigoJugador = Convert.ToInt32(prm_CodigoJugador.Value);

                return iCodigoJugador;
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
                cmd_JugadorInsertar.Connection.Close();
                conexion.Dispose();
            }
        }

        public List<JugadorBE> listar_Jugadores()
        {
            SqlConnection conexion = null;
            SqlDataReader dr_jugadores;
            SqlCommand cmd_jugadores = null;
            String sqlListarJugadores;

            try
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);
                sqlListarJugadores = "spListarJugadores";
                cmd_jugadores = conexion.CreateCommand();
                cmd_jugadores.CommandText = sqlListarJugadores;
                cmd_jugadores.CommandType = CommandType.StoredProcedure;

                cmd_jugadores.Connection.Open();
                dr_jugadores = cmd_jugadores.ExecuteReader();

                List<JugadorBE> lista_jugadores;
                JugadorBE objJugadorBE;

                lista_jugadores = new List<JugadorBE>();

                while (dr_jugadores.Read())
                {
                    objJugadorBE = new JugadorBE();

                    objJugadorBE.CodigoJugador = dr_jugadores.GetInt32(dr_jugadores.GetOrdinal("CodJugador"));
                    objJugadorBE.Nombres = dr_jugadores.GetString(dr_jugadores.GetOrdinal("Nombres"));
                    objJugadorBE.Apellidos = dr_jugadores.GetString(dr_jugadores.GetOrdinal("Apellidos"));
                    objJugadorBE.Posicion = dr_jugadores.GetString(dr_jugadores.GetOrdinal("Posicion"));
                    objJugadorBE.Nacionalidad = dr_jugadores.GetString(dr_jugadores.GetOrdinal("Nacionalidad"));
                    objJugadorBE.FechaNacimiento = dr_jugadores.GetDateTime(dr_jugadores.GetOrdinal("FechaNacimiento"));
                    objJugadorBE.Peso = dr_jugadores.GetDecimal(dr_jugadores.GetOrdinal("Peso"));
                    objJugadorBE.Altura = dr_jugadores.GetDecimal(dr_jugadores.GetOrdinal("Altura"));

                    lista_jugadores.Add(objJugadorBE);
                }

                return lista_jugadores;
            }

            catch (Exception)
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    cmd_jugadores.Connection.Close();
                    conexion.Dispose();
                }

                throw;
            }

            finally
            {
                cmd_jugadores.Connection.Close();
                conexion.Dispose();
            }
        }

        public List<JugadorBE> listar_Jugadores_xNacionalidad(String Nacionalidad)
        {
            SqlConnection conexion = null;
            SqlDataReader dr_jugadores;
            SqlCommand cmd_jugadores = null;
            String sqlListarJugadores;
            SqlParameter prm_nacionalidad;

            try
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);
                sqlListarJugadores = "spListaJugadoresPorNacionalidad";
                cmd_jugadores = conexion.CreateCommand();
                cmd_jugadores.CommandText = sqlListarJugadores;
                cmd_jugadores.CommandType = CommandType.StoredProcedure;

                prm_nacionalidad = new SqlParameter();
                prm_nacionalidad.ParameterName = "@Nacionalidad";
                prm_nacionalidad.SqlDbType = SqlDbType.VarChar;
                prm_nacionalidad.Size = 20;
                prm_nacionalidad.Value = Nacionalidad;

                cmd_jugadores.Parameters.Add(prm_nacionalidad);

                cmd_jugadores.Connection.Open();
                dr_jugadores = cmd_jugadores.ExecuteReader();

                List<JugadorBE> lista_jugadores;
                JugadorBE objJugadorBE;

                lista_jugadores = new List<JugadorBE>();

                while (dr_jugadores.Read())
                {
                    objJugadorBE = new JugadorBE();

                    objJugadorBE.CodigoJugador = dr_jugadores.GetInt32(dr_jugadores.GetOrdinal("CodJugador"));
                    objJugadorBE.Nombres = dr_jugadores.GetString(dr_jugadores.GetOrdinal("Nombres"));
                    objJugadorBE.Apellidos = dr_jugadores.GetString(dr_jugadores.GetOrdinal("Apellidos"));
                    objJugadorBE.Posicion = dr_jugadores.GetString(dr_jugadores.GetOrdinal("Posicion"));
                    objJugadorBE.Nacionalidad = dr_jugadores.GetString(dr_jugadores.GetOrdinal("Nacionalidad"));
                    objJugadorBE.FechaNacimiento = dr_jugadores.GetDateTime(dr_jugadores.GetOrdinal("FechaNacimiento"));
                    objJugadorBE.Peso = dr_jugadores.GetDecimal(dr_jugadores.GetOrdinal("Peso"));
                    objJugadorBE.Altura = dr_jugadores.GetDecimal(dr_jugadores.GetOrdinal("Altura"));

                    lista_jugadores.Add(objJugadorBE);
                }

                return lista_jugadores;
            }

            catch (Exception)
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    cmd_jugadores.Connection.Close();
                    conexion.Dispose();
                }

                throw;
            }

            finally
            {
                cmd_jugadores.Connection.Close();
                conexion.Dispose();
            }
        }

        public List<JugadorBE> listar_Jugadores_xEquipo(int codigo_equipo)
        {
            SqlConnection conexion = null;
            SqlDataReader dr_jugadores;
            SqlCommand cmd_jugadores = null;
            String sqlListarJugadores;
            SqlParameter prm_codigo_equipo;

            try
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);
                sqlListarJugadores = "spListarJugadoresXEquipo";
                cmd_jugadores = conexion.CreateCommand();
                cmd_jugadores.CommandText = sqlListarJugadores;
                cmd_jugadores.CommandType = CommandType.StoredProcedure;

                prm_codigo_equipo = new SqlParameter();
                prm_codigo_equipo.ParameterName = "@CodEquipo";
                prm_codigo_equipo.SqlDbType = SqlDbType.Int;
                prm_codigo_equipo.Value = codigo_equipo;

                cmd_jugadores.Parameters.Add(prm_codigo_equipo);

                cmd_jugadores.Connection.Open();
                dr_jugadores = cmd_jugadores.ExecuteReader();

                List<JugadorBE> lista_jugadores;
                JugadorBE objJugadorBE;

                lista_jugadores = new List<JugadorBE>();

                while (dr_jugadores.Read())
                {
                    objJugadorBE = new JugadorBE();

                    objJugadorBE.CodigoJugador = dr_jugadores.GetInt32(dr_jugadores.GetOrdinal("CodJugador"));
                    objJugadorBE.Nombres = dr_jugadores.GetString(dr_jugadores.GetOrdinal("Nombres"));
                    objJugadorBE.Apellidos = dr_jugadores.GetString(dr_jugadores.GetOrdinal("Apellidos"));
                    objJugadorBE.Posicion = dr_jugadores.GetString(dr_jugadores.GetOrdinal("Posicion"));
                    objJugadorBE.Nacionalidad = dr_jugadores.GetString(dr_jugadores.GetOrdinal("Nacionalidad"));
                    objJugadorBE.FechaNacimiento = dr_jugadores.GetDateTime(dr_jugadores.GetOrdinal("FechaNacimiento"));
                    objJugadorBE.Peso = dr_jugadores.GetDecimal(dr_jugadores.GetOrdinal("Peso"));
                    objJugadorBE.Altura = dr_jugadores.GetDecimal(dr_jugadores.GetOrdinal("Altura"));

                    lista_jugadores.Add(objJugadorBE);
                }

                return lista_jugadores;
            }

            catch (Exception)
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    cmd_jugadores.Connection.Close();
                    conexion.Dispose();
                }

                throw;
            }

            finally
            {
                cmd_jugadores.Connection.Close();
                conexion.Dispose();
            }
        }

        public void asignarJugador_aEquipo(JugadorEquipoBE objJugadorEquipoBE)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_JugadorAsignar = null;

            SqlParameter prm_CodigoEquipo;
            SqlParameter prm_CodigoJugador;

            String sqlJugadorAsignar;

            try
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);

                sqlJugadorAsignar = "spCreateJugadorEquipo";

                cmd_JugadorAsignar = new SqlCommand(sqlJugadorAsignar, conexion);
                cmd_JugadorAsignar.CommandType = CommandType.StoredProcedure;

                prm_CodigoEquipo = new SqlParameter();
                prm_CodigoEquipo.ParameterName = "@CodEquipo";
                prm_CodigoEquipo.SqlDbType = SqlDbType.Int;
                prm_CodigoEquipo.Value = objJugadorEquipoBE.Codigo_equipo;

                prm_CodigoJugador = new SqlParameter();
                prm_CodigoJugador.ParameterName = "@CodJugador";
                prm_CodigoJugador.SqlDbType = SqlDbType.Int;
                prm_CodigoJugador.Value = objJugadorEquipoBE.Codigo_jugador;

                cmd_JugadorAsignar.Parameters.Add(prm_CodigoEquipo);
                cmd_JugadorAsignar.Parameters.Add(prm_CodigoJugador);

                cmd_JugadorAsignar.Connection.Open();
                cmd_JugadorAsignar.ExecuteNonQuery();
            }

            catch (Exception)
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    cmd_JugadorAsignar.Connection.Close();
                    conexion.Dispose();
                }

                throw;
            }

            finally
            {
                cmd_JugadorAsignar.Connection.Close();
                conexion.Dispose();
            }
        }

        public void editarJugador(int codigoJugador, Decimal nAltura, Decimal nPeso)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_JugadorEditar = null;

            SqlParameter prm_CodigoJugador;
            SqlParameter prm_Altura;
            SqlParameter prm_Peso;

            String sqlJugadorEditar;

            try
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);
                sqlJugadorEditar = "spUpdateJugador";

                cmd_JugadorEditar = new SqlCommand(sqlJugadorEditar, conexion);
                cmd_JugadorEditar.CommandType = CommandType.StoredProcedure;

                prm_CodigoJugador = new SqlParameter();
                prm_CodigoJugador.ParameterName = "@CodJugador";
                prm_CodigoJugador.SqlDbType = SqlDbType.Int;
                prm_CodigoJugador.Value = codigoJugador;

                prm_Altura = new SqlParameter();
                prm_Altura.ParameterName = "@Altura";
                prm_Altura.SqlDbType = SqlDbType.Decimal;
                prm_Altura.Value = nAltura;

                prm_Peso = new SqlParameter();
                prm_Peso.ParameterName = "@Peso";
                prm_Peso.SqlDbType = SqlDbType.Decimal;
                prm_Peso.Value = nPeso;

                cmd_JugadorEditar.Parameters.Add(prm_CodigoJugador);
                cmd_JugadorEditar.Parameters.Add(prm_Altura);
                cmd_JugadorEditar.Parameters.Add(prm_Peso);

                cmd_JugadorEditar.Connection.Open();
                cmd_JugadorEditar.ExecuteNonQuery();
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
                cmd_JugadorEditar.Connection.Close();
                conexion.Dispose();
            }
        }

        public int cantidadGolesxJugador(int jugador, int liga)
        {
            SqlConnection conexion = null;
            SqlDataReader dr_jugadores;
            SqlCommand cmd_jugadores = null;
            String sqlListarJugadores;
            SqlParameter prm_codigo_jugador;
            SqlParameter prm_codigo_liga;

            try
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);
                sqlListarJugadores = "spCantidadGolesJugador";
                cmd_jugadores = conexion.CreateCommand();
                cmd_jugadores.CommandText = sqlListarJugadores;
                cmd_jugadores.CommandType = CommandType.StoredProcedure;

                prm_codigo_jugador = new SqlParameter();
                prm_codigo_jugador.ParameterName = "@CodJugador";
                prm_codigo_jugador.SqlDbType = SqlDbType.Int;
                prm_codigo_jugador.Value = jugador;

                prm_codigo_liga = new SqlParameter();
                prm_codigo_liga.ParameterName = "@CodLiga";
                prm_codigo_liga.SqlDbType = SqlDbType.Int;
                prm_codigo_liga.Value = liga;

                cmd_jugadores.Parameters.Add(prm_codigo_jugador);
                cmd_jugadores.Parameters.Add(prm_codigo_liga);

                cmd_jugadores.Connection.Open();
                dr_jugadores = cmd_jugadores.ExecuteReader();

                int cantidad_partidos = 0;

                while (dr_jugadores.Read())
                {
                    cantidad_partidos = dr_jugadores.GetInt32(dr_jugadores.GetOrdinal("Cantidad"));
                }

                return cantidad_partidos;
            }

            catch (Exception)
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    cmd_jugadores.Connection.Close();
                    conexion.Dispose();
                }

                throw;
            }

            finally
            {
                cmd_jugadores.Connection.Close();
                conexion.Dispose();
            }
        }

        public int cantidadPartidosxJugador(int jugador, int liga)
        {
            SqlConnection conexion = null;
            SqlDataReader dr_jugadores;
            SqlCommand cmd_jugadores = null;
            String sqlListarJugadores;
            SqlParameter prm_codigo_jugador;
            SqlParameter prm_codigo_liga;

            try
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);
                sqlListarJugadores = "spCantidadPartidosJugados";
                cmd_jugadores = conexion.CreateCommand();
                cmd_jugadores.CommandText = sqlListarJugadores;
                cmd_jugadores.CommandType = CommandType.StoredProcedure;

                prm_codigo_jugador = new SqlParameter();
                prm_codigo_jugador.ParameterName = "@CodJugador";
                prm_codigo_jugador.SqlDbType = SqlDbType.Int;
                prm_codigo_jugador.Value = jugador;

                prm_codigo_liga = new SqlParameter();
                prm_codigo_liga.ParameterName = "@CodLiga";
                prm_codigo_liga.SqlDbType = SqlDbType.Int;
                prm_codigo_liga.Value = liga;

                cmd_jugadores.Parameters.Add(prm_codigo_jugador);
                cmd_jugadores.Parameters.Add(prm_codigo_liga);

                cmd_jugadores.Connection.Open();
                dr_jugadores = cmd_jugadores.ExecuteReader();

                int cantidad_partidos = 0;

                while (dr_jugadores.Read())
                {
                    cantidad_partidos = dr_jugadores.GetInt32(dr_jugadores.GetOrdinal("NUMERO"));
                }

                return cantidad_partidos;
            }

            catch (Exception)
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    cmd_jugadores.Connection.Close();
                    conexion.Dispose();
                }

                throw;
            }

            finally
            {
                cmd_jugadores.Connection.Close();
                conexion.Dispose();
            }
        }

        public String estado_LesionJugador(int codigo_jugador, DateTime fecha)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_LeerEstadoLesion = null;
            SqlParameter prm_Codigo;
            SqlParameter prm_Fecha;
            String sqlReadLesion;
            String sEstado = null;
            SqlDataReader dr_lesion;

            try
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);
                sqlReadLesion = "spReadEstadoLesion";

                cmd_LeerEstadoLesion = new SqlCommand(sqlReadLesion, conexion);
                cmd_LeerEstadoLesion.CommandType = CommandType.StoredProcedure;

                prm_Codigo = new SqlParameter();
                prm_Codigo.ParameterName = "@CodJugador";
                prm_Codigo.SqlDbType = SqlDbType.Int;
                prm_Codigo.Value = codigo_jugador;

                prm_Fecha = new SqlParameter();
                prm_Fecha.ParameterName = "@Fecha";
                prm_Fecha.SqlDbType = SqlDbType.Date;
                prm_Fecha.Value = fecha;

                cmd_LeerEstadoLesion.Parameters.Add(prm_Codigo);
                cmd_LeerEstadoLesion.Parameters.Add(prm_Fecha);

                cmd_LeerEstadoLesion.Connection.Open();
                dr_lesion = cmd_LeerEstadoLesion.ExecuteReader();

                if (dr_lesion.Read())
                {
                    sEstado = dr_lesion.GetString(dr_lesion.GetOrdinal("Estado"));
                }
                return sEstado;
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

        public void TransferirJugadorAEquipo(int codigo_jugador, int codigo_nuevoequipo)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_transferirjugador = null;

            SqlParameter prm_CodigoJugador;
            SqlParameter prm_CodigoNuevoEquipo;

            String sqlTransferirJugador;

            try
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);
                sqlTransferirJugador = "spCreateTransferenciaJugadorNuevoEquipo";

                cmd_transferirjugador = new SqlCommand(sqlTransferirJugador, conexion);
                cmd_transferirjugador.CommandType = CommandType.StoredProcedure;

                prm_CodigoJugador = new SqlParameter();
                prm_CodigoJugador.ParameterName = "@CodJugador";
                prm_CodigoJugador.SqlDbType = SqlDbType.Int;
                prm_CodigoJugador.Value = codigo_jugador;

                prm_CodigoNuevoEquipo = new SqlParameter();
                prm_CodigoNuevoEquipo.ParameterName = "@CodEquipoNuevo";
                prm_CodigoNuevoEquipo.SqlDbType = SqlDbType.Int;
                prm_CodigoNuevoEquipo.Value = codigo_nuevoequipo;

                cmd_transferirjugador.Parameters.Add(prm_CodigoJugador);
                cmd_transferirjugador.Parameters.Add(prm_CodigoNuevoEquipo);

                cmd_transferirjugador.Connection.Open();
                cmd_transferirjugador.ExecuteNonQuery();
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
                cmd_transferirjugador.Connection.Close();
                conexion.Dispose();
            }
        }

        public List<String> ListarNacionalidades()
        {
            SqlConnection conexion = null;
            SqlCommand cmd_listaNacionalidades = null;
            SqlDataReader dr_nacionalidades;
            String sqlListaNacionalidades;

            try
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);
                sqlListaNacionalidades = "spListaNacionalidades";

                cmd_listaNacionalidades = new SqlCommand(sqlListaNacionalidades, conexion);
                cmd_listaNacionalidades.CommandType = CommandType.StoredProcedure;

                cmd_listaNacionalidades.Connection.Open();
                dr_nacionalidades = cmd_listaNacionalidades.ExecuteReader();

                List<String> lista_nacionalidades;

                lista_nacionalidades = new List<String>();

                while (dr_nacionalidades.Read())
                {
                    String nacionalidad = dr_nacionalidades.GetString(dr_nacionalidades.GetOrdinal("Nacionalidad"));
                    lista_nacionalidades.Add(nacionalidad);
                }

                return lista_nacionalidades;
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
                cmd_listaNacionalidades.Connection.Close();
                conexion.Dispose();
            }
        }        
    }
}
