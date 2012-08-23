using System;
using System.Collections.Generic;
using System.Text;

namespace UPC.Proyecto.SISPPAFUT.BL.BE
{
    public class TransferenciaJugadorBE
    {
        private int _CodEquipoNuevo;

        public int CodEquipoNuevo
        {
            get { return _CodEquipoNuevo; }
            set { _CodEquipoNuevo = value; }
        }

        private int _CodEquipoJugador;

        public int CodEquipoJugador
        {
            get { return _CodEquipoJugador; }
            set { _CodEquipoJugador = value; }
        }
    }
}
