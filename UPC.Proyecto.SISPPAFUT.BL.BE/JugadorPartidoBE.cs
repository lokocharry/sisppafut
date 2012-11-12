using System;
using System.Collections.Generic;
using System.Text;

namespace UPC.Proyecto.SISPPAFUT.BL.BE
{
    public class JugadorPartidoBE
    {
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

        private int _estado;

        public int Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
    }
}
