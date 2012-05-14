using System;
using System.Collections.Generic;
using System.Text;

namespace UPC.Proyecto.SISPPAFUT.BL.BE
{
    public class PartidoSinJugarBE
    {
        private int _codigo_partido;

        public int Codigo_partido
        {
            get { return _codigo_partido; }
            set { _codigo_partido = value; }
        }

        private String _pais;

        public String Pais
        {
            get { return _pais; }
            set { _pais = value; }
        }

        private String _liga;

        public String Liga
        {
            get { return _liga; }
            set { _liga = value; }
        }

        private String _equipo_local;

        public String Equipo_local
        {
            get { return _equipo_local; }
            set { _equipo_local = value; }
        }

        private String _equipo_visitante;

        public String Equipo_visitante
        {
            get { return _equipo_visitante; }
            set { _equipo_visitante = value; }
        }

        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
    }
}
