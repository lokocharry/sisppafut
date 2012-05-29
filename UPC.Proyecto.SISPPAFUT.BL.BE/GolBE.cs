using System;
using System.Collections.Generic;
using System.Text;

namespace UPC.Proyecto.SISPPAFUT.BL.BE
{
    public class GolBE
    {
        private int _codigo_gol;

        public int Codigo_gol
        {
            get { return _codigo_gol; }
            set { _codigo_gol = value; }
        }

        private int _codigo_partido;

        public int Codigo_partido
        {
            get { return _codigo_partido; }
            set { _codigo_partido = value; }
        }

        private int _codigo_jugador;

        public int Codigo_jugador
        {
            get { return _codigo_jugador; }
            set { _codigo_jugador = value; }
        }

        private int _minuto_gol;

        public int Minuto_gol
        {
            get { return _minuto_gol; }
            set { _minuto_gol = value; }
        }
    }
}
