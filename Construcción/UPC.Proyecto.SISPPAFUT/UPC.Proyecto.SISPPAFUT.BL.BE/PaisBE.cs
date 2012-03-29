using System;
using System.Collections.Generic;
using System.Text;

namespace UPC.Proyecto.SISPPAFUT.BL.BE
{
    public class PaisBE
    {
        private int _codigoPais;
        private String _nombrePais;

        public int CodigoPais
        {
            get { return _codigoPais; }
            set { _codigoPais = value; }
        }

        public String NombrePais
        {
            get { return _nombrePais; }
            set { _nombrePais = value; }
        }
    }
}
