using System;
using System.Collections.Generic;
using System.Text;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class PaisBC
    {
        public static class Propiedades
        {
            public static string userLogged { get; set; }
        }

        public int insertarPais(PaisBE objPaisBE)
        {
            PaisDALC objPaisDALC;

            try
            {
                objPaisDALC = new PaisDALC();

                if (objPaisDALC.existe_Pais(objPaisBE.NombrePais) == 1)
                {
                    return -1;
                }

                return objPaisDALC.insertar_Pais(objPaisBE);
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public List<PaisBE> listarPaises()
        {
            PaisDALC objPaisDALC = new PaisDALC();
            return objPaisDALC.listar_Paises();
        }
    }
}
