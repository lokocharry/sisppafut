using System;
using System.Collections.Generic;
using System.Text;

namespace UPC.Proyecto.SISPPAFUT.BL.BE
{
    //Clase utilizada para actualizar los rankings
    public class RankingEquipoBE
    {
        private int _codigoRanking;
        private int _posicionRanking;
        private int _codigoEquipo;
        private int _anioRanking;
        private int _mesRanking;
        private int _puntosRanking;

        public int CodigoEquipo
        {
            get { return _codigoEquipo; }
            set { _codigoEquipo = value; }
        }
        public int PosicionRanking
        {
            get { return _posicionRanking; }
            set { _posicionRanking = value; }
        }     
        public int AnioRanking
        {
            get { return _anioRanking; }
            set { _anioRanking = value; }
        }
        public int MesRanking
        {
            get { return _mesRanking; }
            set { _mesRanking = value; }
        }
        public int PuntosRanking
        {
            get { return _puntosRanking; }
            set { _puntosRanking = value; }
        }
        public int CodigoRanking
        {
            get { return _codigoRanking; }
            set { _codigoRanking = value; }
        }
    }

    //Clase utilizada para leer los rankings dado un criterio
    public class RankingBE
    {
        String _nombreEquipo;
        int _posicion;
        int _puntos;
        String _pais;

        public String NombreEquipo
        {
            get { return _nombreEquipo; }
            set { _nombreEquipo = value; }
        }
        public int Posicion
        {
            get { return _posicion; }
            set { _posicion = value; }
        }
        public int Puntos
        {
            get { return _puntos; }
            set { _puntos = value; }
        }
        public String Pais
        {
            get { return _pais; }
            set { _pais = value; }
        }
    }
}
