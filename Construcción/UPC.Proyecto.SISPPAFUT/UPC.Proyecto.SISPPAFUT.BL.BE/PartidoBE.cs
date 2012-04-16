using System;
using System.Collections.Generic;
using System.Text;

namespace UPC.Proyecto.SISPPAFUT.BL.BE
{
    public class PartidoBE
    {
        private int codigo_partido;

        public int Codigo_partido
        {
            get { return codigo_partido; }
            set { codigo_partido = value; }
        }

        private int codigo_liga;

        public int Codigo_liga
        {
            get { return codigo_liga; }
            set { codigo_liga = value; }
        }

        private int codigo_equipo_local;

        public int Codigo_equipo_local
        {
            get { return codigo_equipo_local; }
            set { codigo_equipo_local = value; }
        }

        private int codigo_equipo_visitante;

        public int Codigo_equipo_visitante
        {
            get { return codigo_equipo_visitante; }
            set { codigo_equipo_visitante = value; }
        }

        private int codigo_estadio;

        public int Codigo_estadio
        {
            get { return codigo_estadio; }
            set { codigo_estadio = value; }
        }

        private int goles_local;

        public int Goles_local
        {
            get { return goles_local; }
            set { goles_local = value; }
        }

        private int goles_visita;

        public int Goles_visita
        {
            get { return goles_visita; }
            set { goles_visita = value; }
        }

        private DateTime fecha_partido;

        public DateTime Fecha_partido
        {
            get { return fecha_partido; }
            set { fecha_partido = value; }
        }
    }
}
