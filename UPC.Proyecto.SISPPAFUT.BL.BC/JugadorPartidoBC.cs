using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

using UPC.Proyecto.SISPPAFUT.DL.DALC;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class JugadorPartidoBC
    {
        public static class Propiedades
        {
            public static string userLogged { get; set; }
        }

        public void insertar_jugadores(List<JugadorPartidoBE> lista_jugadores)
        {
            JugadorPartidoDALC objJugadorPartidoDALC;
            LogBC objLogBC;
            try
            {
                for (int i = 0; i < lista_jugadores.Count; i++)
                {
                    objJugadorPartidoDALC = new JugadorPartidoDALC();
                    objJugadorPartidoDALC.insertarJugadorPartido(lista_jugadores[i]);

                    //--Se registra el log
                    objLogBC = new LogBC();
                    LogBE objLogBE = new LogBE();

                    objLogBE.CodOperacion = lista_jugadores[i].Codigo_jugador;
                    objLogBE.Fecha = DateTime.Now;
                    IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                    objLogBE.IP = entry.AddressList[0].ToString();
                    objLogBE.Razon = "Se registró un jugador a un partido con id: " + lista_jugadores[i].Codigo_partido;
                    objLogBE.Tabla = "JugadorPartido";
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
