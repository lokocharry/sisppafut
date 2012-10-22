using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UPC.Proyecto.SISPPAFUT.BL.BE
{
    public class EntrenadorBE
    {
        private int codEntrenador;

        public int CodEntrenador
        {
            get { return codEntrenador; }
            set { codEntrenador = value; }
        }

        private int codEquipo;

        public int CodEquipo
        {
            get { return codEquipo; }
            set { codEquipo = value; }
        }

        private String nombres;

        public String Nombres
        {
            get { return nombres; }
            set { nombres = value; }
        }

        private String apellidos;

        public String Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        private String nacionalidad;

        public String Nacionalidad
        {
            get { return nacionalidad; }
            set { nacionalidad = value; }
        }

        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }


    }
}
