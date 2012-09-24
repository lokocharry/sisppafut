using System;
using System.Collections.Generic;
using System.Text;

namespace UPC.Proyecto.SISPPAFUT.BL.BE
{
    public class HistorialJugadorBE
    {
        private int codJugador;

        public int CodJugador
        {
            get { return codJugador; }
            set { codJugador = value; }
        }
        private String nombresJugador;

        public String NombresJugador
        {
            get { return nombresJugador; }
            set { nombresJugador = value; }
        }
        private String apellidosJugador;

        public String ApellidosJugador
        {
            get { return apellidosJugador; }
            set { apellidosJugador = value; }
        }
        private String nombreEquipo;

        public String NombreEquipo
        {
            get { return nombreEquipo; }
            set { nombreEquipo = value; }
        }
    }
}
