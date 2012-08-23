using System;
using System.Collections.Generic;
using System.Text;

namespace UPC.Proyecto.SISPPAFUT.BL.BE
{
    public class HistorialJugadorBE
    {
        private String _Equipo;

        public String Equipo
        {
            get { return _Equipo; }
            set { _Equipo = value;}
        }

        private String _Liga;

        public String Liga
        {
            get { return _Liga; }
            set { _Liga = value; }
        }

        private String _Temporada;

        public String Temporada
        {
            get { return _Temporada; }
            set { _Temporada = value; }
        }
    }
}
