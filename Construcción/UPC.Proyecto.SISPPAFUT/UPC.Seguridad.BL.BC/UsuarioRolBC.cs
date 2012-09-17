using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UPC.Seguridad.BL.BE;
using UPC.Seguridad.DL.DALC;

namespace UPC.Seguridad.BL.BC
{
    public class UsuarioRolBC
    {
        public void asignar_RolUsuario(int codUsuario, int codRol)
        {
            UsuarioRolDALC objUsuarioRolDALC;
            try
            {
                objUsuarioRolDALC = new UsuarioRolDALC();
                objUsuarioRolDALC.asignar_Rol(codUsuario, codRol);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
