using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UPC.Seguridad.BL.BE;
using UPC.Seguridad.DL.DALC;

namespace UPC.Seguridad.BL.BC
{
    public class UsuarioBC
    {
        public int insertar_Usuario(UsuarioBE objUsuarioBE)
        {
            UsuarioDALC objUsuarioDALC;
            int resultado = 0;

            try
            {
                objUsuarioDALC=new UsuarioDALC();
                resultado = objUsuarioDALC.insertar_Usuario(objUsuarioBE);

                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<UsuarioBE> listar_Usuarios()
        {
            UsuarioDALC objUsuarioDALC;

            try
            {
                objUsuarioDALC = new UsuarioDALC();
                return objUsuarioDALC.listar_usuarios();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int Verificar_LoginUsuario(String usuario, String contrasenia)
        {
            UsuarioDALC objUsuarioDALC;

            try
            {
                objUsuarioDALC = new UsuarioDALC();
                return objUsuarioDALC.Verificar_LoginUsuario(usuario, contrasenia);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
