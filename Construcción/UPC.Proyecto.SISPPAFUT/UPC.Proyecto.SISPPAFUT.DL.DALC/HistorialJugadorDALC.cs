using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.DL.DALC
{
    public class HistorialJugadorDALC
    {
        public List<HistorialJugadorBE> listar_historialdejugador(int Jugador)
        {
            SqlConnection conexion = null;
            SqlDataReader dr_historial;
            SqlCommand cmd_historial;
            String sqlHistorialListar;
            SqlParameter _Jugador;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Cadena);
                sqlHistorialListar = "spLeerHistorialJugador";
                cmd_historial = conexion.CreateCommand();
                cmd_historial.CommandText = sqlHistorialListar;
                cmd_historial.CommandType = CommandType.StoredProcedure;

                _Jugador = cmd_historial.CreateParameter();
                _Jugador.ParameterName = "@CodJugador";
                _Jugador.SqlDbType = SqlDbType.Int;
                _Jugador.SqlValue = Jugador;

                cmd_historial.Parameters.Add(_Jugador);

                cmd_historial.Connection.Open();
                dr_historial = cmd_historial.ExecuteReader();

                List<HistorialJugadorBE> lista_historial;
                HistorialJugadorBE objHistorialJugadorBE;

                lista_historial = new List<HistorialJugadorBE>();

                while (dr_historial.Read())
                {
                    objHistorialJugadorBE = new HistorialJugadorBE();

                    objHistorialJugadorBE.Equipo = dr_historial.GetString(dr_historial.GetOrdinal("Nombre"));
                    objHistorialJugadorBE.Temporada = dr_historial.GetString(dr_historial.GetOrdinal("Temporada"));
                    lista_historial.Add(objHistorialJugadorBE);
                }

                cmd_historial.Connection.Close();
                conexion.Dispose();

                return lista_historial;
            }

            catch (Exception ex)
            {
                conexion.Dispose();
                throw;
            }

        }
    }
}
