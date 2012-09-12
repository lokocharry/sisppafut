using System;
using System.Collections.Generic;
using System.Text;
using System.Numeric;
using System.Globalization;

namespace UPC.Proyecto.SISPPAFUT.BL.BE
{
    public class TablaPosicionesBE
    {
        private int CodTabla;

        public int codTabla
        {
            get { return CodTabla; }
            set { CodTabla = value; }
        }

        private int CodLiga;

        public int codLiga
        {
            get { return CodLiga; }
            set { CodLiga = value; }
        }
        private int CodEquipo;

        public int codEquipo
        {
            get { return CodEquipo; }
            set { CodEquipo = value; }
        }

        private String nombreEquipo;

        public String NombreEquipo
        {
            get { return nombreEquipo; }
            set { nombreEquipo = value; }
        }

        private int puntosGeneral;

        public int PuntosGeneral
        {
            get { return puntosGeneral; }
            set { puntosGeneral = value; }
        }

        private int partidosJugadosTotal;

        public int PartidosJugadosTotal
        {
            get { return partidosJugadosTotal; }
            set { partidosJugadosTotal = value; }
        }

        private int victoriasTotal;

        public int VictoriasTotal
        {
            get { return victoriasTotal; }
            set { victoriasTotal = value; }
        }

        private int empatesTotal;

        public int EmpatesTotal
        {
            get { return empatesTotal; }
            set { empatesTotal = value; }
        }

        private int derrotasTotal;

        public int DerrotasTotal
        {
            get { return derrotasTotal; }
            set { derrotasTotal = value; }
        }

        private int golesAnotadosTotal;

        public int GolesAnotadosTotal
        {
            get { return golesAnotadosTotal; }
            set { golesAnotadosTotal = value; }
        }

        private int golesEncajadosTotal;

        public int GolesEncajadosTotal
        {
            get { return golesEncajadosTotal; }
            set { golesEncajadosTotal = value; }
        }

        private int PuntosLocal;

        public int puntosLocal
        {
            get { return PuntosLocal; }
            set { PuntosLocal = value; }
        }
        private int PartidosJugadosLocal;

        public int partidosJugadosLocal
        {
            get { return PartidosJugadosLocal; }
            set { PartidosJugadosLocal = value; }
        }
        private int VictoriasLocal;

        public int victoriasLocal
        {
            get { return VictoriasLocal; }
            set { VictoriasLocal = value; }
        }
        private int EmpatesLocal;

        public int empatesLocal
        {
            get { return EmpatesLocal; }
            set { EmpatesLocal = value; }
        }
        private int DerrotasLocal;

        public int derrotasLocal
        {
            get { return DerrotasLocal; }
            set { DerrotasLocal = value; }
        }
        private int GolesAnotadosLocal;

        public int golesAnotadosLocal
        {
            get { return GolesAnotadosLocal; }
            set { GolesAnotadosLocal = value; }
        }
        private int GolesEncajadosLocal;

        public int golesEncajadosLocal
        {
            get { return GolesEncajadosLocal; }
            set { GolesEncajadosLocal = value; }
        }
        private int PuntosVisita;

        public int puntosVisita
        {
            get { return PuntosVisita; }
            set { PuntosVisita = value; }
        }
        private int PartidosJugadosVisita;

        public int partidosJugadosVisita
        {
            get { return PartidosJugadosVisita; }
            set { PartidosJugadosVisita = value; }
        }
        private int VictoriasVisita;

        public int victoriasVisita
        {
            get { return VictoriasVisita; }
            set { VictoriasVisita = value; }
        }
        private int EmpatesVisita;

        public int empatesVisita
        {
            get { return EmpatesVisita; }
            set { EmpatesVisita = value; }
        }
        private int DerrotasVisita;

        public int derrotasVisita
        {
            get { return DerrotasVisita; }
            set { DerrotasVisita = value; }
        }
        private int GolesAnotadosVisita;

        public int golesAnotadosVisita
        {
            get { return GolesAnotadosVisita; }
            set { GolesAnotadosVisita = value; }
        }
        private int GolesEncajadosVisita;

        public int golesEncajadosVisita
        {
            get { return GolesEncajadosVisita; }
            set { GolesEncajadosVisita = value; }
        }

        private Int64 Posicion;

        public Int64 posicion
        {
            get { return Posicion; }
            set { Posicion = value; }
        }
    }
}
