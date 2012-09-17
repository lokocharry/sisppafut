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
    }
}
