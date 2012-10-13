using System;
using System.Collections.Generic;
using System.Text;

using System.Net;
using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class EquipoBC
    {
        public static class Propiedades
        {
            public static string userLogged { get; set; }
        }
        
        public int insertarEquipo(EquipoBE objEquipoBE)
        {
            EquipoDALC objEquipoDALC;

            try
            {
                objEquipoDALC = new EquipoDALC();

                if (objEquipoDALC.existe_Equipo(objEquipoBE.NombreEquipo) == 1)
                {
                    return -1;
                }

                int idoperacion = objEquipoDALC.insertar_Equipo(objEquipoBE);

                //--Se registra el log
                LogBC objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();           

                objLogBE.CodOperacion = idoperacion;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se registró un nuevo equipo";
                objLogBE.Tabla = "Equipo";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return idoperacion;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<EquipoBE> listarEquipos(String Pais)
        {
            try
            {
                EquipoDALC objEquipoDALC = new EquipoDALC();

                //--Se registra el log
                LogBC objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = 0;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se listaron los equipos de "+Pais;
                objLogBE.Tabla = "Equipo";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);
                
                return objEquipoDALC.listar_Equipos(Pais);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public List<EquipoBE> listarEquiposDeLiga(int Liga)
        {
            try
            {
                EquipoDALC objEquipoDALC = new EquipoDALC();
                List<EquipoBE> lst_equipos = new List<EquipoBE>();
                lst_equipos = objEquipoDALC.listar_EquiposDeLiga(Liga);

                //--Se registra el log
                LogBC objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = 0;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se listaron los equipos de la liga con id: "+Liga.ToString();
                objLogBE.Tabla = "Equipo";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return lst_equipos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public EquipoBE obtenerEquipo(String _equipo)
        {
            try
            {
                EquipoBE objEquipoBE;
                EquipoDALC objEquipoDALC = new EquipoDALC();
                objEquipoBE = objEquipoDALC.obtener_Equipo(_equipo);

                //--Se registra el log
                LogBC objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = objEquipoBE.CodigoEquipo;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se consultó el equipo: "+_equipo;
                objLogBE.Tabla = "Equipo";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);
                
                return objEquipoBE;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void actualizarEquipo(int codigo_equipo, int estadio_principal, int estadio_alterno)
        {
            try
            {
                EquipoDALC objEquipoDALC = new EquipoDALC();
                objEquipoDALC.actualizar_equipo(codigo_equipo, estadio_principal, estadio_alterno);

                //--Se registra el log
                LogBC objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = codigo_equipo;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se actualizó un equipo";
                objLogBE.Tabla = "Equipo";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Decimal obtener_PromedioEquipoTitular(int codEquipo, int codLiga)
        {
            try
            {
                Decimal promEdad;
                EquipoDALC objEquipoDALC = new EquipoDALC();
                promEdad = objEquipoDALC.obtener_PromedioEquipoTitular(codEquipo, codLiga);

                //--Se registra el log
                LogBC objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = codEquipo;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se consultó la edad promedio del equipo titular en la liga con id: " + codLiga.ToString();
                objLogBE.Tabla = "JugadorEquipo";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return promEdad;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int obtener_CantidadExpulsadosUltimoPartido(int codPartido, int codEquipo, int codLiga)
        {
            try
            {
                int qExpulsados;
                EquipoDALC objEquipoDALC = new EquipoDALC();
                qExpulsados = objEquipoDALC.obtener_CantidadExpulsadosUltimoPartido(codPartido, codEquipo, codLiga);

                //--Se registra el log
                LogBC objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = codPartido;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se consultó la cantidad de expulsados en el último partido para el equipo: "+codEquipo.ToString()+ " en la liga " + codLiga.ToString();
                objLogBE.Tabla = "AmonestacionPartido";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return qExpulsados;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int obtener_CantidadPartidosUltimoMes(int codEquipo, DateTime fecha)
        {
            try
            {
                int qPartidosMes;
                EquipoDALC objEquipoDALC = new EquipoDALC();
                qPartidosMes = objEquipoDALC.obtener_CantidadPartidosUltimoMes(codEquipo, fecha);

                //--Se registra el log
                LogBC objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = codEquipo;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se consultó la cantidad de partidos del equipo en el último mes";
                objLogBE.Tabla = "Partido";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return qPartidosMes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
