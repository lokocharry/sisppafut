using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class PronosticoClienteBC
    {
        public static class Propiedades
        {
            public static string userLogged { get; set; }
        }

        public void inssertarPronosticoCliente(PronosticoClienteBE objPronosticoClienteBE)
        {
            PronosticoClienteDALC objPronosticoClienteDALC;
            LogBC objLogBC;

            try
            {                
                objPronosticoClienteDALC = new PronosticoClienteDALC();

                objPronosticoClienteDALC.insertarPronosticoCliente(objPronosticoClienteBE);

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = objPronosticoClienteBE.CodigoUsuario;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se registró un pronóstico para el cliente";
                objLogBE.Tabla = "PronosticoCliente";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);
                listarPronosticosCliente(objPronosticoClienteBE.CodigoUsuario);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<PronosticoClienteBE> listarPronosticosCliente(int icodCliente)
        {
            PronosticoClienteDALC objPronosticoClienteDALC;
            LogBC objLogBC;

            try
            {                
                objPronosticoClienteDALC = new PronosticoClienteDALC();

                List<PronosticoClienteBE> lst_pronostico = new List<PronosticoClienteBE>();
                lst_pronostico = objPronosticoClienteDALC.listarPronosticosCliente(icodCliente);

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = icodCliente;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se listaron los pronósticos del cliente";
                objLogBE.Tabla = "PronosticoCliente";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return lst_pronostico;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
