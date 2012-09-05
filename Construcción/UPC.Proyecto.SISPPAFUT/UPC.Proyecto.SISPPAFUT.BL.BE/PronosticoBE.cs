using System;
using System.Collections.Generic;
using System.Text;

namespace UPC.Proyecto.SISPPAFUT.BL.BE
{
    public class PronosticoBE
    {
        private int _codigoPronostico;
        private int _codigoPartido;
        private String _pronostico;
        private Decimal _porcentajeLocal;
        private Decimal _porcentajeEmpate;
        private Decimal _porcentajeVisita;

        public int CodigoPronostico
        {
            get { return _codigoPronostico; }
            set { _codigoPronostico = value; }
        }

        public int CodigoPartido
        {
            get { return _codigoPartido; }
            set { _codigoPartido = value; }
        }

        public String Pronostico
        {
            get { return _pronostico; }
            set { _pronostico = value; }
        }

        public Decimal PorcentajeLocal
        {
            get { return _porcentajeLocal; }
            set { _porcentajeLocal = value; }
        }

        public Decimal PorcentajeEmpate
        {
            get { return _porcentajeEmpate; }
            set { _porcentajeEmpate = value; }
        }

        public Decimal PorcentajeVisita
        {
            get { return _porcentajeVisita; }
            set { _porcentajeVisita = value; }
        }

        private String equipoLocal;

        public String EquipoLocal
        {
            get { return equipoLocal; }
            set { equipoLocal = value; }
        }
        private String equipoVisita;

        public String EquipoVisita
        {
            get { return equipoVisita; }
            set { equipoVisita = value; }
        }
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private int codLiga;

        public int CodLiga
        {
            get { return codLiga; }
            set { codLiga = value; }
        }
    }
}
