using System;
using System.Collections.Generic;
using System.Text;

using UPC.Proyecto.SISPPAFUT.DL.DALC;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class JugadorBC
    {
        public int insertar_Jugador(JugadorBE objJugadorBE)
        {
            JugadorDALC objJugadorDALC;
            int resultado = 0;
            try
            {
                objJugadorDALC = new JugadorDALC();
                resultado = objJugadorDALC.insertar_Jugador(objJugadorBE);
                return resultado;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public List<JugadorBE> listar_Jugadores()
        {
            JugadorDALC objJugadorDALC;

            try
            {
                objJugadorDALC = new JugadorDALC();
                return objJugadorDALC.listar_Jugadores();
            }

            catch (Exception)
            {
                throw;
            }
        }

        public void asignar_JugadoraEquipo(List<JugadorEquipoBE> lista_jugadores)
        {
            JugadorDALC objJugadorDALC;

            try
            {
                objJugadorDALC = new JugadorDALC();

                for (int i = 0; i < lista_jugadores.Count; i++)
                {
                    objJugadorDALC.asignarJugador_aEquipo(lista_jugadores[i]);
                }
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
