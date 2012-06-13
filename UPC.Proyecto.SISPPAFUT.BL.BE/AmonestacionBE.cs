using System;
using System.Collections.Generic;
using System.Text;

namespace UPC.Proyecto.SISPPAFUT.BL.BE
{
    public class AmonestacionBE
    {
        private int _codigo_amonestacion;

        public int Codigo_amonestacion
        {
            get { return _codigo_amonestacion; }
            set { _codigo_amonestacion = value; }
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

        private int _tipo;

        public int Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        private int _minuto;

        public int Minuto
        {
            get { return _minuto; }
            set { _minuto = value; }
        }
    }
}
