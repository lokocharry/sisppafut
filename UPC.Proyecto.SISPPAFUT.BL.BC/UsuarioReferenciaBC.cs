using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

using UPC.Proyecto.SISPPAFUT.DL.DALC;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class UsuarioReferenciaBC
    {
        public static class Propiedades
        {
            public static string userLogged { get; set; }
        }

        public void insertar_UsuarioReferencia(UsuarioReferenciaBE objUsuarioReferenciaBE)
        {
            UsuarioReferenciaDALC objUsuarioReferenciaDALC;
            LogBC objLogBC;
            try
            {
                objUsuarioReferenciaDALC = new UsuarioReferenciaDALC();
                objUsuarioReferenciaDALC.insertar_UsuarioReferencia(objUsuarioReferenciaBE);

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = 0;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se registró un usuario referencia";
                objLogBE.Tabla = "UsuarioReferencia";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
