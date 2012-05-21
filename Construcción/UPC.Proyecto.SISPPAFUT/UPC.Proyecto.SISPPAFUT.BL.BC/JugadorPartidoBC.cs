using System;
using System.Collections.Generic;
using System.Text;

using UPC.Proyecto.SISPPAFUT.DL.DALC;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class JugadorPartidoBC
    {
        public void insertar_jugadores(List<JugadorPartidoBE> lista_jugadores)
        {
            JugadorPartidoDALC objJugadorPartidoDALC;

            try
            {
                for (int i = 0; i < lista_jugadores.Count; i++)
                {
                    objJugadorPartidoDALC = new JugadorPartidoDALC();
                    objJugadorPartidoDALC.insertarJugadorPartido(lista_jugadores[i]);
                }
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
