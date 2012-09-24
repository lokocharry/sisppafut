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
                int Cantidad = Verificar_ExisteFuncionalidad(NombreFuncionalidad);

                if (Cantidad > 0)
                    return -1;

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

        public int Verificar_ExisteFuncionalidad(String NombreFuncionalidad)
        {
            FuncionalidadDALC objFuncionalidadDALC;

            try
            {
                objFuncionalidadDALC = new FuncionalidadDALC();

                return objFuncionalidadDALC.verificar_existeFuncionalidad(NombreFuncionalidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<FuncionalidadBE> Listar_Funcionalidades()
        {
            FuncionalidadDALC objFuncionalidadDALC;

            try
            {
                objFuncionalidadDALC = new FuncionalidadDALC();

                return objFuncionalidadDALC.listar_Funcionalid();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
