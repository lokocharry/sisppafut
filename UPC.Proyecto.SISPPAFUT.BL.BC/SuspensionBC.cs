using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

using UPC.Proyecto.SISPPAFUT.DL.DALC;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class SuspensionBC
    {
        public static class Propiedades
        {
            public static string userLogged { get; set; }
        }

        public void crear_Suspension(SuspensionBE objSuspension)
        {
            LogBC objLogBC;

            try
            {
                SuspensionDALC objSuspensionDALC = new SuspensionDALC();
                objSuspensionDALC.crear_Suspension(objSuspension);

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = objSuspension.CodigoJugador;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se registró una suspensión al jugador. Tarjetas amarillas: " + objSuspension.QAmarillas.ToString() + " y tarjetas rojas: " + objSuspension.QRojas.ToString();
                objLogBE.Tabla = "Suspension";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void actualizar_Suspension(int codJugador, int codLiga, int tipo)
        {
            SuspensionDALC objSuspensionDALC;
            LogBC objLogBC; 

            try
            {
                objSuspensionDALC = new SuspensionDALC();
                objSuspensionDALC.actualizar_Suspension(codJugador, codLiga, tipo);

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = codJugador;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se actualizó una suspensión del jugador en la liga con id: " + codLiga.ToString() + " y de tipo: " + tipo.ToString();
                objLogBE.Tabla = "Suspension";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public String leer_EstadoSuspension(int codJugador, int codLiga)
        {
            LogBC objLogBC;

            try
            {
                SuspensionDALC objSuspensionDALC = new SuspensionDALC();
                String estado = objSuspensionDALC.leer_EstadoSuspension(codJugador, codLiga);

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = codJugador;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se obtuvo el estado de la suspensión del jugador en la liga con id: " + codLiga.ToString();
                objLogBE.Tabla = "Suspension";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return estado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Boolean consultar_ArqueroSuspendido(int codEquipo, int codLiga)
        {
            LogBC objLogBC;

            try
            {
                SuspensionDALC objDALC = new SuspensionDALC();
                Boolean suspendido =  objDALC.consultar_ArqueroSuspendido(codEquipo, codLiga);

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = codEquipo;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se consultó la suspensión del arquero del equipo en la liga con id: "+codLiga.ToString();
                objLogBE.Tabla = "Suspension";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return suspendido;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Boolean consultar_GoleadorSuspendido(int codEquipo, int codLiga)
        {
            LogBC objLogBC;

            try
            {
                SuspensionDALC objDALC = new SuspensionDALC();
                Boolean suspendido =  objDALC.consultar_GoleadorSuspendido(codEquipo, codLiga);

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = codEquipo;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se consultó si el goleador del equipo está suspendido para la liga con id: " + codLiga.ToString();
                objLogBE.Tabla = "Suspension";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return suspendido;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //-- En el siguiente no va log porque es parte del entrenamiento
        public int CantidadJugadoresSuspendidos(int codEquipo, int codLiga, DateTime fecha)
        {
            SuspensionDALC objSuspensionDALC;
            List<SuspensionBE> lstSuspensiones;

            try
            {
                objSuspensionDALC = new SuspensionDALC();
                lstSuspensiones = new List<SuspensionBE>();
                int qSuspendidos = 0;
                lstSuspensiones = objSuspensionDALC.CantidadJugadoresSuspendidos(codEquipo, codLiga, fecha);

                if (lstSuspensiones.Count > 0)
                {
                    foreach (SuspensionBE cDto in lstSuspensiones)
                    {
                        if (cDto.QAmarillas % 5 == 0)
                            qSuspendidos = qSuspendidos + 1;
                    }
                }

                return qSuspendidos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
