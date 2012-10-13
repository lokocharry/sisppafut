using System;
using System.Collections.Generic;
using System.Text;

using UPC.Proyecto.SISPPAFUT.DL.DALC;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class GolBC
    {
        public static class Propiedades
        {
            public static string userLogged { get; set; }
        }

        public void insertar_Goles(List<GolBE> lista_goles)
        {
            GolDALC objGolDALC;

            try
            {
                for (int i = 0; i < lista_goles.Count; i++)
                {
                    objGolDALC = new GolDALC();
                    objGolDALC.insertar_Gol(lista_goles[i]);
                }
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
