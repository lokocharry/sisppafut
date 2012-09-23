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
        public void Insertar_RolXFuncionalidad(List<RolXFuncionalidadBE> lst_RolFunc)
        {
            RolXFuncionalidadDALC objRolFuncionalidad;

            try
            {
                objRolFuncionalidad = new RolXFuncionalidadDALC();

                for (int i = 0; i < lst_RolFunc.Count; i++)
                {
                    objRolFuncionalidad.insertar_RolXFuncionalidad(lst_RolFunc[i]);
                }
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

        public int VerificarSiExiste_RolXFuncionalidad(int idRol, int idFuncionalidad)
        {
            RolXFuncionalidadDALC objRolXFuncionalidadDALC;

            try
            {
                objRolXFuncionalidadDALC = new RolXFuncionalidadDALC();

                return objRolXFuncionalidadDALC.Verificar_RolXFuncionalidadExiste(idRol, idFuncionalidad);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
