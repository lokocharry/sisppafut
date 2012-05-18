using System;
using System.Collections.Generic;
using System.Text;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class JugadorEquipoBC
    {
        public List<JugadorEquipoBE> listaJugadorEquipo()
        {
            JugadorEquipoDALC objJugadorDALC;

            try
            {
                objJugadorDALC = new JugadorEquipoDALC();
                return objJugadorDALC.lista_JugadoresEquipos();
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
