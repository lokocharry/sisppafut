using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

using UPC.Proyecto.SISPPAFUT.DL.DALC;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class LesionPartidoBC
    {
        public static class Propiedades
        {
            public static string userLogged { get; set; }
        }

        public void insertar_Lesiones(List<LesionPartidoBE> lista_lesiones)
        {
            LesionPartidoDALC objLesionDALC;
            LogBC objLogBC;

            try
            {
                objLogBC = new LogBC();

                for (int i = 0; i < lista_lesiones.Count; i++)
                {
                    objLesionDALC = new LesionPartidoDALC();
                    objLesionDALC.insertar_LesionPartido(lista_lesiones[i]);

                    //--Se registra el log
                    LogBE objLogBE = new LogBE();

                    objLogBE.CodOperacion = lista_lesiones[i].Codigo_jugador;
                    objLogBE.Fecha = DateTime.Now;
                    IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                    objLogBE.IP = entry.AddressList[0].ToString();
                    objLogBE.Razon = "Se registró una lesión a un jugador de un partido con id: " + lista_lesiones[i].Codigo_partido;
                    objLogBE.Tabla = "LesionPartido";
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
