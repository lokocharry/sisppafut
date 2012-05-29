using System;

namespace UPC.Proyecto.SISPPAFUT.BL.BE
{
    public class ExcepcionBE
    {
        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private String mensaje;

        public String Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }
        private String stackTrace;

        public String StackTrace
        {
            get { return stackTrace; }
            set { stackTrace = value; }
        }
        private DateTime fechaCliente;

        public DateTime FechaCliente
        {
            get { return fechaCliente; }
            set { fechaCliente = value; }
        }
        private DateTime fechaServidor;

        public DateTime FechaServidor
        {
            get { return fechaServidor; }
            set { fechaServidor = value; }
        }
        private int codUsuario;

        public int CodUsuario
        {
            get { return codUsuario; }
            set { codUsuario = value; }
        }
        private String iPCliente;

        public String IPCliente
        {
            get { return iPCliente; }
            set { iPCliente = value; }
        }                
    }
}
