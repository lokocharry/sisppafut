using System;

namespace UPC.Proyecto.SISPPAFUT.BL.BE
{
    public class LogBE
    {
        private int codRegistro;

        public int CodRegistro
        {
            get { return codRegistro; }
            set { codRegistro = value; }
        }
        private int codOperacion;

        public int CodOperacion
        {
            get { return codOperacion; }
            set { codOperacion = value; }
        }
        private String tabla;

        public String Tabla
        {
            get { return tabla; }
            set { tabla = value; }
        }
        private String usuario;

        public String Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private String iP;

        public String IP
        {
            get { return iP; }
            set { iP = value; }
        }
        private String razon;

        public String Razon
        {
            get { return razon; }
            set { razon = value; }
        }
    }
}
