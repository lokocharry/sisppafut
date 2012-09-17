using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UPC.Seguridad.BL.BE;
using UPC.Seguridad.DL.DALC;

namespace UPC.Seguridad.BL.BC
{
    public class FuncionalidadBC
    {
        public int Insertar_Funcionalidad(String NombreFuncionalidad, String DescripcionFuncionalidad)
        {
            FuncionalidadBE objFuncionalidadBE;
            FuncionalidadDALC objFuncionalidadDALC;

            try
            {
                objFuncionalidadBE = new FuncionalidadBE();
                objFuncionalidadBE.DescripcionFuncionalidad = DescripcionFuncionalidad;
                objFuncionalidadBE.NombreFuncionalidad = NombreFuncionalidad;

                objFuncionalidadDALC = new FuncionalidadDALC();

                return objFuncionalidadDALC.insertar_funcionalidad(objFuncionalidadBE);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
