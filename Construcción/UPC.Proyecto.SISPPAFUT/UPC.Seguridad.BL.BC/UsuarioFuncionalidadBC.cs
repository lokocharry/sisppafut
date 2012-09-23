using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UPC.Seguridad.BL.BE;
using UPC.Seguridad.DL.DALC;

namespace UPC.Seguridad.BL.BC
{
    public class UsuarioFuncionalidadBC
    {
        public void Insertar_UsuarioFuncionalidad(List<UsuarioFuncionalidadBE> lst_usuarios)
        {
            try
            {
                UsuarioFuncionalidadDALC objUsuarioFuncionalidadDALC = new UsuarioFuncionalidadDALC();
                
                for(int i=0; i<lst_usuarios.Count; i++)
                objUsuarioFuncionalidadDALC.insertar_UsuarioFuncionalidad(lst_usuarios[i]);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
