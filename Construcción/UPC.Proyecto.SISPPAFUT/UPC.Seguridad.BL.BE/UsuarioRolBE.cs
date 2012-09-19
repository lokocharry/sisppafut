using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UPC.Seguridad.BL.BE
{
    public class UsuarioRolBE
    {
        private int _idUsuario;

        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        private int _idRol;

        public int IdRol
        {
            get { return _idRol; }
            set { _idRol = value; }
        }

        private String nombreUsuario;

        public String NombreUsuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }

        private String nombreRol;

        public String NombreRol
        {
            get { return nombreRol; }
            set { nombreRol = value; }
        }
    }
}
