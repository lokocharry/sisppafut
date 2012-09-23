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
        public void asignar_RolUsuario(List<UsuarioRolBE> lst_asoc)
        {
            UsuarioRolDALC objUsuarioRolDALC;
            try
            {
                objUsuarioRolDALC = new UsuarioRolDALC();

                for(int i=0; i<lst_asoc.Count; i++)
                    objUsuarioRolDALC.asignar_Rol(lst_asoc[i].IdUsuario, lst_asoc[i].IdRol);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int VerificarExiste_Asociacion(int idRol, int idUsuario)
        {
            UsuarioRolDALC objUsuarioRolDALC;

            try
            {
                objUsuarioRolDALC = new UsuarioRolDALC();

                return objUsuarioRolDALC.Verificar_ExisteRolUsuario(idUsuario, idRol);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<RolBE> Listar_RolesXUsuario(int idUsuario)
        {
            try
            {
                UsuarioRolDALC objUsuarioRolDALC = new UsuarioRolDALC();

                return objUsuarioRolDALC.Listar_RolesXUsuario(idUsuario);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
