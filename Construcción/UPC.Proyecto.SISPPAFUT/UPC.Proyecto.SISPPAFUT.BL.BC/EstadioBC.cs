using System;
using System.Collections.Generic;
using System.Text;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class EstadioBC
    {
        public int insertar_Estadio(EstadioBE objEstadioBE)
        {
            EstadioDALC objEstadioDALC = new EstadioDALC();
            return objEstadioDALC.insertar_Estadio(objEstadioBE);
        }
    }
}
