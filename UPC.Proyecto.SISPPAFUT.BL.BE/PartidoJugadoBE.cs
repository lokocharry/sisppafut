using System;
using System.Collections.Generic;
using System.Text;

namespace UPC.Proyecto.SISPPAFUT.BL.BE
{
    public class PartidoJugadoBE
    {
        private int _codPartido;

        public int CodPartido
        {
            get { return _codPartido; }
            set { _codPartido = value; }
        }

        private String _equipo_local;

        public String Equipo_local
        {
            get { return _equipo_local; }
            set { _equipo_local = value; }
        }

        private String _equipo_visita;

        public String Equipo_visita
        {
            get { return _equipo_visita; }
            set { _equipo_visita = value; }
        }

        private int _goles_local;

        public int Goles_local
        {
            get { return _goles_local; }
            set { _goles_local = value; }
        }

        private int _goles_visita;

        public int Goles_visita
        {
            get { return _goles_visita; }
            set { _goles_visita = value; }
        }

        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private String _liga;

        public String Liga
        {
            get { return _liga; }
            set { _liga = value; }
        }
    }
}
