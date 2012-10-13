using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using UPC.Proyecto.SISPPAFUT.DL.DALC;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class AmonestacionBC
    {
        public static class Propiedades
        {
            public static string userLogged { get; set; }
        }

        String Usuario;

        public void RecibirCodigoUsuario(String Usuario)
        {
            this.Usuario = Usuario;
        }

        public void insertar_Amonestacion(List<AmonestacionBE> lista_amonestaciones)
        {
            AmonestacionDALC objAmonestacionDALC;
            LogBC objLogBC;
            LogBE objLogBE;

            try
            {
                objLogBC = new LogBC();

                for (int i = 0; i < lista_amonestaciones.Count; i++)
                {
                    objLogBE = new LogBE();
                    objAmonestacionDALC = new AmonestacionDALC();
                    objAmonestacionDALC.insertar_Amonestacion(lista_amonestaciones[i]);

                    objLogBE.CodOperacion = lista_amonestaciones[i].Codigo_amonestacion;
                    objLogBE.Fecha = DateTime.Now;
                    String nameHost = System.Net.Dns.GetHostName();
                    objLogBE.IP = System.Net.Dns.GetHostAddresses(nameHost).ToString();
                    objLogBE.Razon = "Se insertó una amonestación";
                    objLogBE.Tabla = "AmonestacionPartido";
                    objLogBE.Usuario = Propiedades.userLogged;

                    objLogBC.RegistrarLog(objLogBE);

                }
            }

            catch(Exception)
            {
                throw;
            }
        }        
    }
}
