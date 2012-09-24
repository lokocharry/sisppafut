using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UPC.Proyecto.SISPPAFUT.BL.BE
{
    public class PronosticoCliente
    {
        private int _codigoPartido;

        public int CodigoPartido
        {
            get { return _codigoPartido; }
            set { _codigoPartido = value; }
        }

        private int _codigoUsuario;

        public int CodigoUsuario
        {
            get { return _codigoUsuario; }
            set { _codigoUsuario = value; }
        }

        private String _pronostico;

        public String Pronostico
        {
            get { return _pronostico; }
            set { _pronostico = value; }
        }
        
    }
}
