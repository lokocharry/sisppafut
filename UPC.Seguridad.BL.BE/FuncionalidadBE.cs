using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UPC.Seguridad.BL.BE
{
    public class FuncionalidadBE
    {
        private int idfuncionalidad;

        public int idFuncionalidad
        {
            get { return idfuncionalidad; }
            set { idfuncionalidad = value; }
        }

        private String nombrefuncionalidad;

        public String NombreFuncionalidad
        {
            get { return nombrefuncionalidad; }
            set { nombrefuncionalidad = value; }
        }

        private String descripcionfuncionalidad;

        public String DescripcionFuncionalidad
        {
            get { return descripcionfuncionalidad; }
            set { descripcionfuncionalidad = value; }
        }
    }
}
