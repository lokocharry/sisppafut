using System;
using System.Collections.Generic;
using System.Text;

using UPC.Proyecto.SISPPAFUT.DL.DALC;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class LesionPartidoBC
    {
        public static class Propiedades
        {
            public static string userLogged { get; set; }
        }

        public void insertar_Lesiones(List<LesionPartidoBE> lista_lesiones)
        {
            LesionPartidoDALC objLesionDALC;

            try
            {
                for (int i = 0; i < lista_lesiones.Count; i++)
                {
                    objLesionDALC = new LesionPartidoDALC();
                    objLesionDALC.insertar_LesionPartido(lista_lesiones[i]);
                }
            }

            catch (Exception)
            {
                throw;
            }
        }        
    }
}
