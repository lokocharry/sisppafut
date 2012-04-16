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

            try
            {
                objJugadorDALC = new JugadorDALC();
                return objJugadorDALC.insertar_Jugador(objJugadorBE);
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
