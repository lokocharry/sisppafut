using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.DL.DALC
{
    public class JugadorEquipoDALC
    {
        public List<JugadorEquipoBE> lista_JugadoresEquipos()
        {
            SqlConnection conexion = null;
            SqlDataReader dr_jugadores;
            SqlCommand cmd_jugadores = null;
            String sqlListarJugadores;

            try
            {
                conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDSISPPAFUT"].ConnectionString);
                sqlListarJugadores = "spListarJugadorEquipo";
                cmd_jugadores = conexion.CreateCommand();
                cmd_jugadores.CommandText = sqlListarJugadores;
                cmd_jugadores.CommandType = CommandType.StoredProcedure;

                cmd_jugadores.Connection.Open();
                dr_jugadores = cmd_jugadores.ExecuteReader();

                List<JugadorEquipoBE> lista_jugadores;
                JugadorEquipoBE objJugadorBE;

                lista_jugadores = new List<JugadorEquipoBE>();

                while (dr_jugadores.Read())
                {
                    objJugadorBE = new JugadorEquipoBE();

                    objJugadorBE.Codigo_equipo = dr_jugadores.GetInt32(dr_jugadores.GetOrdinal("CodEquipo"));
                    objJugadorBE.Codigo_jugador = dr_jugadores.GetInt32(dr_jugadores.GetOrdinal("CodJugador"));

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
    }
}
