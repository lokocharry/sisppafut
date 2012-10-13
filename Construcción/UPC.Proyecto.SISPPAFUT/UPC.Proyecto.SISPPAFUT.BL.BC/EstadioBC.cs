using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class EstadioBC
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

        public int insertar_Estadio(EstadioBE objEstadioBE)
        {
            int result = 0;
            try
            {
                EstadioDALC objEstadioDALC = new EstadioDALC();
                result = objEstadioDALC.insertar_Estadio(objEstadioBE);

                if (result != 0)
                {
                    //Guardar el registro;
                    LogBC objLogBC = new LogBC();
                    LogBE objLogBE = new LogBE();

                    objLogBE.CodOperacion = result;
                    objLogBE.Fecha = DateTime.Now;
                    String nameHost = System.Net.Dns.GetHostName();
                    objLogBE.IP = System.Net.Dns.GetHostAddresses(nameHost).ToString();
                    objLogBE.Razon = "Se insertó un nuevo estadio";
                    objLogBE.Tabla = "Estadio";
                    objLogBE.Usuario = Propiedades.userLogged;//Usuario;

                    objLogBC.RegistrarLog(objLogBE);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<EstadioBE> listarEstadios()
        {
            try
            {
                EstadioDALC objEstadioDALC = new EstadioDALC();

                List<EstadioBE> lst_Estadio = new List<EstadioBE>();
                lst_Estadio = objEstadioDALC.listar_Estadios();

                LogBC objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = 0;
                objLogBE.Fecha = DateTime.Now;
                String nameHost = System.Net.Dns.GetHostName();
                objLogBE.IP = System.Net.Dns.GetHostAddresses(nameHost).ToString();
                objLogBE.Razon = "Se listaron los estadios";
                objLogBE.Tabla = "Estadio";
                objLogBE.Usuario = Propiedades.userLogged;//Usuario;

                objLogBC.RegistrarLog(objLogBE);

                return lst_Estadio;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<EstadioBE> listarEstadiosDeEquipo(int codigo_equipo)
        {
            try
            {
                EstadioDALC objEstadioDALC = new EstadioDALC();

                List<EstadioBE> lst_estadios = new List<EstadioBE>();

                lst_estadios = objEstadioDALC.obtenerEstadioDeEquipo(codigo_equipo);

                LogBC objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = 0;
                objLogBE.Fecha = DateTime.Now;
                String nameHost = System.Net.Dns.GetHostName();
                objLogBE.IP = System.Net.Dns.GetHostAddresses(nameHost).ToString();
                objLogBE.Razon = "Se listaron los estadios de un equipo";
                objLogBE.Tabla = "Estadio";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return lst_estadios;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<EstadioBE> listarEstadiosDePais(int codigo_pais)
        {
            try
            {
                EstadioDALC objEstadioDALC = new EstadioDALC();

                List<EstadioBE> lst_estadios = new List<EstadioBE>();

                lst_estadios = objEstadioDALC.obtenerEstadioDePais(codigo_pais);

                LogBC objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = 0;
                objLogBE.Fecha = DateTime.Now;
                String nameHost = System.Net.Dns.GetHostName();
                objLogBE.IP = System.Net.Dns.GetHostAddresses(nameHost).ToString();
                objLogBE.Razon = "Se listaron los estadios de un pais";
                objLogBE.Tabla = "Estadio";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return lst_estadios;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
