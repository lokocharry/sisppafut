using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UPC.Proyecto.SISPPAFUT.BL.BE
{
    public class UsuarioReferenciaBE
    {
        private int _idUsuario;

        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        private String _nombreUsuario;

        public String NombreUsuario
        {
            get { return _nombreUsuario; }
            set { _nombreUsuario = value; }
        }
    }
}
