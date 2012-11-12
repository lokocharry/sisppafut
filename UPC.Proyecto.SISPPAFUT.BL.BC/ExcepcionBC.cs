using System;
using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class ExcepcionBC
    {
        public int RegistrarExcepcion(ExcepcionBE objExcepcionBE)
        {
            int result = 0;
            try
            {
                ExcepcionDALC objExcepcionDALC = new ExcepcionDALC();
                result = objExcepcionDALC.ExcepcionInsertar(objExcepcionBE);
            }
            catch (Exception ex)
            {
            }
            return result;
        }
    }
}