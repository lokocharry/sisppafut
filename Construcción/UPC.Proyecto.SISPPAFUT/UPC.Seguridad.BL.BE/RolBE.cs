using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UPC.Seguridad.BL.BE
{
    public class RolBE
    {
        private int idrol;

        public int idRol
        {
            get { return idrol; }
            set { idrol = value; }
        }

        private String nombrerol;

        public String NombreRol
        {
            get { return nombrerol; }
            set { nombrerol = value; }
        }

        private String claverol;

        public String ClaveRol
        {
            get { return claverol; }
            set { claverol = value; }
        }

        private String descripcionRol;

        public String DescripcionRol
        {
            get { return descripcionRol; }
            set { descripcionRol = value; }
        }
    }
}
