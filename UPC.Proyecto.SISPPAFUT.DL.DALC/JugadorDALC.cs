using System;
using System.Collections.Generic;
using System.Text;

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
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);

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
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
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

        public List<JugadorBE> listar_Jugadores_xEquipo(int codigo_equipo)
        {
            SqlConnection conexion = null;
            SqlDataReader dr_jugadores;
            SqlCommand cmd_jugadores = null;
            String sqlListarJugadores;
            SqlParameter prm_codigo_equipo;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
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
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);

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
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
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

        public String verificar_Suspendido(int codigo_jugador)
        {
            SqlConnection conexion = null;
            SqlCommand cmd_JugadorInsertar = null;
            SqlDataReader dr_jugadores;

            SqlParameter prm_CodigoJugador;

            String result;

            String sqlJugadorInsertar;

            try
            { 
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlJugadorInsertar = "spReadEstadoSuspension";
                cmd_JugadorInsertar = conexion.CreateCommand();
                cmd_JugadorInsertar.CommandText = sqlJugadorInsertar;
                cmd_JugadorInsertar.CommandType = CommandType.StoredProcedure;

                prm_CodigoJugador = new SqlParameter();
                prm_CodigoJugador.ParameterName = "@CodJugador";
                prm_CodigoJugador.SqlDbType = SqlDbType.Int;
                prm_CodigoJugador.Value = codigo_jugador;

                cmd_JugadorInsertar.Parameters.Add(prm_CodigoJugador);

                cmd_JugadorInsertar.Connection.Open();
                dr_jugadores = cmd_JugadorInsertar.ExecuteReader();

                result = dr_jugadores.GetString(0);

                return result;
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
    }
}
