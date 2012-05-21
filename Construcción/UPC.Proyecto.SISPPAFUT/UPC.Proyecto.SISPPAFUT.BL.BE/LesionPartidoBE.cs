using System;
using System.Collections.Generic;
using System.Text;

namespace UPC.Proyecto.SISPPAFUT.BL.BE
{
    public class LesionPartidoBE
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

        private String _tipo_lesion;

        public String Tipo_lesion
        {
            get { return _tipo_lesion; }
            set { _tipo_lesion = value; }
        }

        private int _dias_descanso;

        public int Dias_descanso
        {
            get { return _dias_descanso; }
            set { _dias_descanso = value; }
        }
    }
}
