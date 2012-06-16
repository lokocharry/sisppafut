using System;
using System.Collections.Generic;
using System.Text;

using UPC.Proyecto.SISPPAFUT.DL.DALC;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class AmonestacionBC
    {
        public void insertar_Amonestacion(List<AmonestacionBE> lista_amonestaciones)
        {
            AmonestacionDALC objAmonestacionDALC;

            try
            {
                for (int i = 0; i < lista_amonestaciones.Count; i++)
                {
                    objAmonestacionDALC = new AmonestacionDALC();
                    objAmonestacionDALC.insertar_Amonestacion(lista_amonestaciones[i]);
                }
            }

            catch(Exception)
            {
                throw;
            }
        }
    }
}
