using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UPC.Seguridad.BL.BE
{
    public class UsuarioFuncionalidadBE
    {
        private int idusuario;

        public int idUsuario
        {
            get { return idusuario; }
            set { idusuario = value; }
        }

        private int idfuncionalidad;

        public int idFuncionalidad
        {
            get { return idfuncionalidad; }
            set { idfuncionalidad = value; }
        }

        private String rol;

        public String Rol
        {
            get { return rol; }
            set { rol = value; }
        }

        private String nusuario;

        public String Usuario
        {
            get { return nusuario; }
            set { nusuario = value; }
        }

        private String nfuncionalidad;

        public String Funcionalidad
        {
            get { return nfuncionalidad; }
            set { nfuncionalidad = value; }
        }
    }
}
