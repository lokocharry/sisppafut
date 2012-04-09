using System;
using System.Collections.Generic;
using System.Text;

namespace UPC.Proyecto.SISPPAFUT.BL.BE
{
    public class EquipoBE
    {
        private int _codigoEquipo;
        private int _codigoPais;
        private String _nombreEquipo;
        private int _anioFundacion;
        private String _ciudadEquipo;
        private int _codigoEstadioPrincipal;
        private int _codigoEstadioAlterno;

        public int CodigoEquipo
        {
            get { return _codigoEquipo; }
            set { _codigoEquipo = value; }
        }
        public int CodigoPais
        {
            get { return _codigoPais; }
            set { _codigoPais = value; }
        }
        public String NombreEquipo
        {
            get { return _nombreEquipo; }
            set { _nombreEquipo = value; }
        }
        public int AnioFundacion
        {
            get { return _anioFundacion; }
            set { _anioFundacion = value; }
        }
        public String CiudadEquipo
        {
            get { return _ciudadEquipo; }
            set { _ciudadEquipo = value; }
        }
        public int CodigoEstadioPrincipal
        {
            get { return _codigoEstadioPrincipal; }
            set { _codigoEstadioPrincipal = value; }
        }
        public int CodigoEstadioAlterno
        {
            get { return _codigoEstadioAlterno; }
            set { _codigoEstadioAlterno = value; }
        }
    }
}
