using System;
using System.Collections.Generic;
using System.Text;

namespace UPC.Proyecto.SISPPAFUT.BL.BE
{
    public class CompeticionBE
    {
        private int _codigo_competicion;
        private int _codigo_pais;
        private String _nombre_competicion;

        public int Codigo_competicion
        {
            get { return _codigo_competicion; }
            set { _codigo_competicion = value; }
        }

        public int Codigo_pais
        {
            get { return _codigo_pais; }
            set { _codigo_pais = value; }
        }

        public String Nombre_competicion
        {
            get { return _nombre_competicion; }
            set { _nombre_competicion = value; }
        }

    }
}
