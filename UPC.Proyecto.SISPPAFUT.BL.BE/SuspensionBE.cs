using System;
using System.Collections.Generic;
using System.Text;

namespace UPC.Proyecto.SISPPAFUT.BL.BE
{
    public class SuspensionBE
    {
        private int _codigoJugador;
        private int _qRojas;
        private int _qAmarillas;
        private int _codLiga;

        public int CodLiga
        {
            get { return _codLiga; }
            set { _codLiga = value; }
        }

        public int CodigoJugador
        {
            get { return _codigoJugador; }
            set { _codigoJugador = value; }
        }

        public int QAmarillas
        {
            get { return _qAmarillas; }
            set { _qAmarillas = value; }
        }

        public int QRojas
        {
            get { return _qRojas; }
            set { _qRojas = value; }
        }
    }
}
