using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Net;
using UPC.Proyecto.SISPPAFUT.BL.BC;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT
{
    public sealed class Funciones
    {
        public static int UsuarioLogueado { get; set; }

        public static void RegistrarExcepcion(Exception ex)
        {
            String IPCliente;
            DateTime FechaCliente;
            int CodUsuario;
            try
            {
                ExcepcionBC objExcepcionBC = new ExcepcionBC { };

                // Obtenemos el IP del Cliente
                IPCliente = ObtenerIP();

                // Obtenemos la fecha del cliente
                FechaCliente = DateTime.Now;

                // Obtenemos el Código del Usuario loeguado
                CodUsuario = UsuarioLogueado;

                ExcepcionBE objExcepcionBE = new ExcepcionBE { CodUsuario = CodUsuario, FechaCliente = FechaCliente, IPCliente = IPCliente, Mensaje = ex.Message, StackTrace = ex.StackTrace };

                objExcepcionBC.RegistrarExcepcion(objExcepcionBE);
            }
            catch (Exception ex2)
            {

            }
            MessageBox.Show("Ocurrió un error en la aplicación. Por favor intente luego.", "Sistema de Gestión Aereo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static String ObtenerIP()
        {
            IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
            return entry.AddressList[0].ToString();
        }

        #region -convertores-
        public static byte[] Image2Bytes(Image img)
        {
            string sTemp = Path.GetTempFileName();
            using (FileStream fs = new FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                img.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                fs.Position = 0;
                int imgLength = Convert.ToInt32(fs.Length);
                byte[] bytes = new byte[imgLength];
                fs.Read(bytes, 0, imgLength);
                fs.Close();
                return bytes;
            }
        }

        public static Image Bytes2Image(byte[] bytes)
        {
            if (bytes == null) return null;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                Bitmap bm = null;
                try
                {
                    bm = new Bitmap(ms);
                }
                catch (Exception ex)
                {
                    //System.Diagnostics.Debug.WriteLine(ex.Message);
                    //OtrasFunciones.InsertarExcepcion(ex);
                }
                return bm;
            }
        }
        #endregion
    }
}