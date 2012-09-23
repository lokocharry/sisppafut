using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UPC.Seguridad.BL.BE;
using UPC.Seguridad.DL.DALC;

namespace UPC.Seguridad.BL.BC
{
    public class RolBC
    {
        public int Insertar_Rol(String NombreRol, String ClaveRol, String DescripcionRol)
        {
            RolDALC objRolDALC;
            RolBE objRolBE;

            try
            {
                int Cantidad = Verificar_ExisteRol(NombreRol);

                if (Cantidad > 0)
                    return -1;

                objRolBE = new RolBE();
                objRolBE.NombreRol = NombreRol;
                objRolBE.ClaveRol = ClaveRol;
                objRolBE.DescripcionRol = DescripcionRol;

                objRolDALC = new RolDALC();
                return objRolDALC.insertar_rol(objRolBE);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Verificar_ExisteRol(String NombreRol)
        {
            RolDALC objRol;

            try
            {
                objRol = new RolDALC();

                return objRol.verificar_existeRol(NombreRol);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<RolBE> Listar_roles()
        {
            RolDALC objRolDALC;

            try
            {
                objRolDALC = new RolDALC();
                return objRolDALC.listar_roles();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
