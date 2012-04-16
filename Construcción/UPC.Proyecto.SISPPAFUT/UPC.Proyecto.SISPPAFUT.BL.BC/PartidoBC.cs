using System;
using System.Collections.Generic;
using System.Text;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class PartidoBC
    {
        public int insertar_Partido(PartidoBE objPartidoBE)
        {
            PartidoDALC objPartidoDALC;

            try
            {
                objPartidoDALC = new PartidoDALC();
                return objPartidoDALC.insertar_partido(objPartidoBE);
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
