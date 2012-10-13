using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class PartidoBC
    {
        public static class Propiedades
        {
            public static string userLogged { get; set; }
        }

        public int insertar_Partido(PartidoBE objPartidoBE)
        {
            PartidoDALC objPartidoDALC = new PartidoDALC();
            LogBC objLogBC = new LogBC();
            int resultado = 0;
            try
            {
                if (objPartidoDALC.existePartido(objPartidoBE.Codigo_equipo_local, objPartidoBE.Codigo_equipo_visitante, objPartidoBE.Codigo_liga) == 1)
                {
                    return -1;
                }
                else
                {
                    if (objPartidoDALC.limitePartidosLiga(objPartidoBE.Codigo_liga) == "No registrar")
                    {
                        return -1;
                    }
                    else
                    {
                        resultado = objPartidoDALC.insertar_partido(objPartidoBE);

                        //--Se registra el log
                        LogBE objLogBE = new LogBE();

                        objLogBE.CodOperacion = resultado;
                        objLogBE.Fecha = DateTime.Now;
                        IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                        objLogBE.IP = entry.AddressList[0].ToString();
                        objLogBE.Razon = "Se registró un partido";
                        objLogBE.Tabla = "Partido";
                        objLogBE.Usuario = Propiedades.userLogged;

                        objLogBC.RegistrarLog(objLogBE);

                    }
                }
                return resultado;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public List<PartidoBE> lista_todos_partidos()
        {
            PartidoDALC objPartidoDALC;
            LogBC objLogBC;

            try
            {
                objPartidoDALC = new PartidoDALC();
                List<PartidoBE> lst_partidos = new List<PartidoBE>();
                lst_partidos = objPartidoDALC.listar_todos_partidos();

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = 0;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se listaron todos los partidos";
                objLogBE.Tabla = "Partido";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return lst_partidos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<PartidoSinJugarBE> lista_partidos_pronosticados()
        {
            PartidoDALC objPartidoDALC;
            LogBC objLogBC;

            try
            {
                objPartidoDALC = new PartidoDALC();
                List<PartidoSinJugarBE> lst_partidos = new List<PartidoSinJugarBE>();
                lst_partidos = objPartidoDALC.listar_partidos_pronosticados();

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = 0;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se listaron los partidos pronosticados";
                objLogBE.Tabla = "Partido";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return lst_partidos;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public List<PartidoSinJugarBE> lista_partidos_sinjugar()
        {
            PartidoDALC objPartidoDALC;
            LogBC objLogBC;

            try
            {
                objPartidoDALC = new PartidoDALC();
                List<PartidoSinJugarBE> lst_partidos = new List<PartidoSinJugarBE>();
                lst_partidos = objPartidoDALC.listar_partidos_sinjugar();

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = 0;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se listaron los partidos sin jugar";
                objLogBE.Tabla = "Partido";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return lst_partidos;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public PartidoBE obtener_Partido(int codigo_partido)
        {
            PartidoDALC objPartidoDALC;
            LogBC objLogBC = new LogBC();

            try
            {
                objPartidoDALC = new PartidoDALC();
                PartidoBE objPartidoBE = new PartidoBE();

                objPartidoBE = objPartidoDALC.obtener_Partido(codigo_partido);

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = codigo_partido;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se obtuvo un partido";
                objLogBE.Tabla = "Partido";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return objPartidoBE;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public void editar_Partido(int codigoPartido, DateTime nuevaFecha)
        {
            PartidoDALC objPartidoDALC;
            LogBC objLogBC;
            
            try
            {
                objPartidoDALC = new PartidoDALC();
                objPartidoDALC.editar_partido(codigoPartido, nuevaFecha);

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = codigoPartido;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se actualizó un partido a una nueva fecha: " + nuevaFecha;
                objLogBE.Tabla = "Partido";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void actualizar_Resultado(int codigo_partido, int goles_local, int goles_visita)
        {
            PartidoDALC objPartidoDALC;
            LogBC objLogBC;

            try
            {
                objPartidoDALC = new PartidoDALC();
                objPartidoDALC.actualizar_Resultado(codigo_partido, goles_local, goles_visita);

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = codigo_partido;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se actualizó el resultado de un partido";
                objLogBE.Tabla = "Partido";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public List<PartidoJugadoBE> lista_ultimosPartidos(int codigo_equipo, int codigo_liga, DateTime fecha)
        {
            PartidoDALC objPartidoDALC;
            LogBC objLogBC;

            try
            {
                objPartidoDALC = new PartidoDALC();
                List<PartidoJugadoBE> lst_partidos = new List<PartidoJugadoBE>();
                
                lst_partidos =  objPartidoDALC.lista_ultimosPartidos(codigo_equipo, codigo_liga, fecha);

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = 0;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se listaron los ultimos partidos jugados";
                objLogBE.Tabla = "Partido";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return lst_partidos;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public List<PartidoSinJugarBE> lista_partidos_jugados()
        {
            PartidoDALC objPartidoDALC;
            LogBC objLogBC;

            try
            {
                objPartidoDALC = new PartidoDALC();
                List<PartidoSinJugarBE> lst_partidos = new List<PartidoSinJugarBE>();
                lst_partidos =  objPartidoDALC.listar_partidos_jugados();

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = 0;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se listaron los partidos jugados";
                objLogBE.Tabla = "Partido";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return lst_partidos;
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
