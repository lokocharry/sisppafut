using System;
using System.Collections.Generic;
using System.Text;

namespace UPC.Proyecto.SISPPAFUT.BL.BE
{
    public class LigaEquipoBE
    {
        private int _codigoLiga;
        private int _codigoEquipo;

        public int CodigoLiga
        {
            get { return _codigoLiga; }
            set { _codigoLiga = value; }
        }
        
        public int CodigoEquipo
        {
            get { return _codigoEquipo; }
            set { _codigoEquipo = value; }
        }
    }
}
