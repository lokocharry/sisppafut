using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

using UPC.Proyecto.SISPPAFUT.DL.DALC;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class GolBC
    {
        public static class Propiedades
        {
            public static string userLogged { get; set; }
        }

        public void insertar_Goles(List<GolBE> lista_goles)
        {
            GolDALC objGolDALC;
            LogBC objLogBC = new LogBC();
            LogBE objLogBE;

            try
            {
                for (int i = 0; i < lista_goles.Count; i++)
                {
                    objGolDALC = new GolDALC();
                    int result = objGolDALC.insertar_Gol(lista_goles[i]);
                    
                    //--Se registra el log                    
                    objLogBE = new LogBE();

                    objLogBE.CodOperacion = result;
                    objLogBE.Fecha = DateTime.Now;
                    IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                    objLogBE.IP = entry.AddressList[0].ToString();
                    objLogBE.Razon = "Se registró un nuevo gol";
                    objLogBE.Tabla = "Gol";
                    objLogBE.Usuario = Propiedades.userLogged;

                    objLogBC.RegistrarLog(objLogBE);
                }
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
