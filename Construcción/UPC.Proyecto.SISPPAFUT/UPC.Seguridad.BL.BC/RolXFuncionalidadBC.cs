using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UPC.Seguridad.BL.BE;
using UPC.Seguridad.DL.DALC;

namespace UPC.Seguridad.BL.BC
{
    public class RolXFuncionalidadBC
    {
        public void Insertar_RolXFuncionalidad(int idRol, int idFuncionalidad)
        {
            RolXFuncionalidadDALC objRolFuncionalidad;

            try
            {
                objRolFuncionalidad = new RolXFuncionalidadDALC();

                RolXFuncionalidadBE objRolFuncionalidadBE = new RolXFuncionalidadBE();

                objRolFuncionalidadBE.idRol = idRol;
                objRolFuncionalidadBE.idFuncionalidad = idFuncionalidad;

                objRolFuncionalidad.insertar_RolXFuncionalidad(objRolFuncionalidadBE);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<FuncionalidadBE> Listar_FuncionalidadesXRol(int idRol)
        {
            RolXFuncionalidadDALC objRolFuncionalidadDALC;
            
            try
            {
                objRolFuncionalidadDALC = new RolXFuncionalidadDALC();

                return objRolFuncionalidadDALC.listar_FuncionalidadesXRol(idRol);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
