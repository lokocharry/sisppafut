using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UPC.Seguridad.BL.BE
{
    public class RolXFuncionalidadBE
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

        private int idfuncionalidad;

        public int idFuncionalidad
        {
            get { return idfuncionalidad; }
            set { idfuncionalidad = value; }
        }

        private String nombreFuncionalidad;

        public String NombreFuncionalidad
        {
            get { return nombreFuncionalidad; }
            set { nombreFuncionalidad = value; }
        }
    }
}
