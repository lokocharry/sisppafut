using System;
using System.Collections.Generic;
using System.Text;

namespace UPC.Proyecto.SISPPAFUT.BL.BE
{
    public class LigaBE
    {
        private int _codigoLiga;
        private int _codigoCompeticion;
        private String _temporadaLiga;
        private string _nombreLiga;
        private int _cantidadEquipos;

        public int CodigoLiga
        {
            get { return _codigoLiga; }
            set { _codigoLiga = value; }
        }
        public int CodigoCompeticion
        {
            get { return _codigoCompeticion; }
            set { _codigoCompeticion = value; }
        }
        public String TemporadaLiga
        {
            get { return _temporadaLiga; }
            set { _temporadaLiga = value; }
        }
        public string NombreLiga
        {
            get { return _nombreLiga; }
            set { _nombreLiga = value; }
        }
        public int CantidadEquipos
        {
            get { return _cantidadEquipos; }
            set { _cantidadEquipos = value; }
        }
    }
}
