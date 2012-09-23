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

        private String nusuario;

        public String Usuario
        {
            get { return nusuario; }
            set { nusuario = value; }
        }

        private String nrol;

        public String Rol
        {
            get { return nrol; }
            set { nrol = value; }
        }
    }
}
