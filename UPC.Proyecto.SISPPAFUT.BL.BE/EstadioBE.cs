using System;
using System.Collections.Generic;
using System.Text;

namespace UPC.Proyecto.SISPPAFUT.BL.BE
{
    public class EstadioBE
    {
        private int codigo_estadio;
        private int codigo_pais;
        private int anho_fundacion;
        private String nombre_estadio;
        private String ciudad_estadio;
        private int aforo_estadio;

        public int Codigo_estadio
        {
            get { return codigo_estadio; }
            set { codigo_estadio = value; }
        }

        public int Codigo_pais
        {
            get { return codigo_pais; }
            set { codigo_pais = value; }
        }

        public int Anho_fundacion
        {
            get { return anho_fundacion; }
            set { anho_fundacion = value; }
        }

        public String Nombre_estadio
        {
            get { return nombre_estadio; }
            set { nombre_estadio = value; }
        }

        public String Ciudad_estadio
        {
            get { return ciudad_estadio; }
            set { ciudad_estadio = value; }
        }

        public int Aforo_estadio
        {
            get { return aforo_estadio; }
            set { aforo_estadio = value; }
        }
    }
}
