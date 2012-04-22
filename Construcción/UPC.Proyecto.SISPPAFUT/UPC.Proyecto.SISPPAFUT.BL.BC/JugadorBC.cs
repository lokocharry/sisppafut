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
    }
}
