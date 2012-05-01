using System;
using System.Collections.Generic;
using System.Text;

namespace UPC.Proyecto.SISPPAFUT.BL.BE
{
    public class JugadorBE
    {
        private int _codigoJugador;

        public int CodigoJugador
        {
            get { return _codigoJugador; }
            set { _codigoJugador = value; }
        }

        private String _nombres;

        public String Nombres
        {
            get { return _nombres; }
            set { _nombres = value; }
        }

        private String _apellidos;

        public String Apellidos
        {
            get { return _apellidos; }
            set { _apellidos = value; }
        }

        private String _nacionalidad;

        public String Nacionalidad
        {
            get { return _nacionalidad; }
            set { _nacionalidad = value; }
        }

        private DateTime _fechaNacimiento;

        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }

        private String _posicion;

        public String Posicion
        {
            get { return _posicion; }
            set { _posicion = value; }
        }

        private Decimal _altura;

        public Decimal Altura
        {
            get { return _altura; }
            set { _altura = value; }
        }

        private Decimal _peso;

        public Decimal Peso
        {
            get { return _peso; }
            set { _peso = value; }
        }

    }
}
