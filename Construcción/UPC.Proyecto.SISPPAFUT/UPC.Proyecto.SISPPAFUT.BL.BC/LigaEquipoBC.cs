using System;
using System.Collections.Generic;
using System.Text;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class LigaEquipoBC
    {
        public static class Propiedades
        {
            public static string userLogged { get; set; }
        }

        public void insertarEquipoEnLiga(LigaEquipoBE objLigaEquipoBE)
        {
            LigaEquipoDALC objLigaEquipoDALC;

            try
            {
                objLigaEquipoDALC = new LigaEquipoDALC();
                objLigaEquipoDALC.insertar_LigaEquipo(objLigaEquipoBE);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
