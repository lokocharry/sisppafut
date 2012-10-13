using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{   
    public class JugadorEquipoBC
    {
        public static class Propiedades
        {
            public static string userLogged { get; set; }
        }

        public List<JugadorEquipoBE> listaJugadorEquipo()
        {
            JugadorEquipoDALC objJugadorDALC;
            LogBC objLogBC;

            try
            {
                objJugadorDALC = new JugadorEquipoDALC();

                List<JugadorEquipoBE> lst_jugadoresEquipo = new List<JugadorEquipoBE>();
                lst_jugadoresEquipo = objJugadorDALC.lista_JugadoresEquipos();

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = 0;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se listaron los jugadores por equipo";
                objLogBE.Tabla = "Jugador";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return lst_jugadoresEquipo;
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
