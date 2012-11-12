using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UPC.Proyecto.SISPPAFUT.BL.BE
{
    public class InstanciaNormalizadaBE
    {
        private int idPartido;
        private Decimal c_QEquiposLiga;
        private Decimal c_Mes;
        private Decimal c_QEquiposMundial;
        private Decimal c_QAsistencia;
        private Decimal c_Local_PosLiga;
        private Decimal c_Local_Pts;
        private Boolean c_Local;
        private Decimal c_Local_PosRankMund;
        private Boolean c_Local_GoleadorSuspendido;
        private Boolean c_Local_ArqueroSuspendido;
        private Decimal c_Local_QExpulsados;
        private Decimal c_Local_QSuspendidos;
        private Decimal c_Local_GolesAnotados;
        private Decimal c_Local_GolesEncajados;
        private Decimal c_Local_PromEdad;
        private Decimal c_Local_QPartidosMes;
        private Decimal c_Visita_PosLiga;
        private Decimal c_Visita_Pts;
        private Boolean c_Visita;
        private Decimal c_Visita_PosRankMund;
        private Boolean c_Visita_GoleadorSuspendido;
        private Boolean c_Visita_ArqueroSuspendido;
        private Decimal c_Visita_QExpulsados;
        private Decimal c_Visita_QSuspendidos;
        private Decimal c_Visita_GolesAnotados;
        private Decimal c_Visita_GolesEncajados;
        private Decimal c_Visita_PromEdad;
        private Decimal c_Visita_QPartidosMes;
        private String c_Resultado;

        public int IdPartido
        {
            get { return idPartido; }
            set { idPartido = value; }
        }
        
        public Decimal C_QEquiposLiga
        {
            get { return c_QEquiposLiga; }
            set { c_QEquiposLiga = value; }
        }
        
        public Decimal C_Mes
        {
            get { return c_Mes; }
            set { c_Mes = value; }
        }
        
        public Decimal C_QEquiposMundial
        {
            get { return c_QEquiposMundial; }
            set { c_QEquiposMundial = value; }
        }
        
        public Decimal C_QAsistencia
        {
            get { return c_QAsistencia; }
            set { c_QAsistencia = value; }
        }
        
        public Decimal C_Local_PosLiga
        {
            get { return c_Local_PosLiga; }
            set { c_Local_PosLiga = value; }
        }
        
        public Decimal C_Local_Pts
        {
            get { return c_Local_Pts; }
            set { c_Local_Pts = value; }
        }
        
        public Boolean C_Local
        {
            get { return c_Local; }
            set { c_Local = value; }
        }
        
        public Decimal C_Local_PosRankMund
        {
            get { return c_Local_PosRankMund; }
            set { c_Local_PosRankMund = value; }
        }
        
        public Boolean C_Local_GoleadorSuspendido
        {
            get { return c_Local_GoleadorSuspendido; }
            set { c_Local_GoleadorSuspendido = value; }
        }
        
        public Boolean C_Local_ArqueroSuspendido
        {
            get { return c_Local_ArqueroSuspendido; }
            set { c_Local_ArqueroSuspendido = value; }
        }
        
        public Decimal C_Local_QExpulsados
        {
            get { return c_Local_QExpulsados; }
            set { c_Local_QExpulsados = value; }
        }
        
        public Decimal C_Local_QSuspendidos
        {
            get { return c_Local_QSuspendidos; }
            set { c_Local_QSuspendidos = value; }
        }
        
        public Decimal C_Local_GolesAnotados
        {
            get { return c_Local_GolesAnotados; }
            set { c_Local_GolesAnotados = value; }
        }
        
        public Decimal C_Local_GolesEncajados
        {
            get { return c_Local_GolesEncajados; }
            set { c_Local_GolesEncajados = value; }
        }
        
        public Decimal C_Local_PromEdad
        {
            get { return c_Local_PromEdad; }
            set { c_Local_PromEdad = value; }
        }
        
        public Decimal C_Local_QPartidosMes
        {
            get { return c_Local_QPartidosMes; }
            set { c_Local_QPartidosMes = value; }
        }
        
        public Decimal C_Visita_PosLiga
        {
            get { return c_Visita_PosLiga; }
            set { c_Visita_PosLiga = value; }
        }
        
        public Decimal C_Visita_Pts
        {
            get { return c_Visita_Pts; }
            set { c_Visita_Pts = value; }
        }
        
        public Boolean C_Visita
        {
            get { return c_Visita; }
            set { c_Visita = value; }
        }
        
        public Decimal C_Visita_PosRankMund
        {
            get { return c_Visita_PosRankMund; }
            set { c_Visita_PosRankMund = value; }
        }
        
        public Boolean C_Visita_GoleadorSuspendido
        {
            get { return c_Visita_GoleadorSuspendido; }
            set { c_Visita_GoleadorSuspendido = value; }
        }
        
        public Boolean C_Visita_ArqueroSuspendido
        {
            get { return c_Visita_ArqueroSuspendido; }
            set { c_Visita_ArqueroSuspendido = value; }
        }
        
        public Decimal C_Visita_QExpulsados
        {
            get { return c_Visita_QExpulsados; }
            set { c_Visita_QExpulsados = value; }
        }
        
        public Decimal C_Visita_QSuspendidos
        {
            get { return c_Visita_QSuspendidos; }
            set { c_Visita_QSuspendidos = value; }
        }
        
        public Decimal C_Visita_GolesAnotados
        {
            get { return c_Visita_GolesAnotados; }
            set { c_Visita_GolesAnotados = value; }
        }
        
        public Decimal C_Visita_GolesEncajados
        {
            get { return c_Visita_GolesEncajados; }
            set { c_Visita_GolesEncajados = value; }
        }
        
        public Decimal C_Visita_PromEdad
        {
            get { return c_Visita_PromEdad; }
            set { c_Visita_PromEdad = value; }
        }
        
        public Decimal C_Visita_QPartidosMes
        {
            get { return c_Visita_QPartidosMes; }
            set { c_Visita_QPartidosMes = value; }
        }
        
        public String C_Resultado
        {
            get { return c_Resultado; }
            set { c_Resultado = value; }
        }
    }
}
