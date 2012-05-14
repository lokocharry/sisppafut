using System;
using System.Collections.Generic;
using System.Text;

namespace UPC.Proyecto.SISPPAFUT.BL.BE
{
    public class JugadorEquipoBE
    {
        private int _codigo_equipo;

        public int Codigo_equipo
        {
            get { return _codigo_equipo; }
            set { _codigo_equipo = value; }
        }

        private int _codigo_jugador;

        public int Codigo_jugador
        {
            get { return _codigo_jugador; }
            set { _codigo_jugador = value; }
        }
    }
}
