using System;
using System.Collections.Generic;
using System.Text;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class LigaBC
    {
        public int insertarLiga(LigaBE objLigaBE)
        {
            LigaDALC objLigaDALC;

            try
            {
                objLigaDALC = new LigaDALC();

                if (objLigaDALC.existe_Liga(objLigaBE.NombreLiga) == 1)
                {
                    return -1;
                }

                return objLigaDALC.insertar_Liga(objLigaBE);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<LigaBE> listarLigas()
        {
            LigaDALC objLigaDALC = new LigaDALC();
            return objLigaDALC.listar_Ligas();
        }

        public void insertarEquipoEnLiga(int codigoLiga, int codigoEquipo)
        {
            LigaDALC objLigaDALC;

            try
            {
                objLigaDALC = new LigaDALC();
                objLigaDALC.insertar_equipoEnLiga(codigoLiga, codigoEquipo);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
