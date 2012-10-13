using System;
using System.Collections.Generic;
using System.Text;

using UPC.Proyecto.SISPPAFUT.DL.DALC;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{   
    public class JugadorBC
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

        public int insertar_Jugador(JugadorBE objJugadorBE)
        {
            JugadorDALC objJugadorDALC;            
            int resultado = 0;
            try
            {
                objJugadorDALC = new JugadorDALC();                                
                resultado = objJugadorDALC.insertar_Jugador(objJugadorBE);

                if (resultado != 0)
                {
                    LogBC objLogBC = new LogBC();
                    LogBE objLogBE = new LogBE();

                    objLogBE.CodOperacion = resultado;
                    objLogBE.Fecha = DateTime.Now;
                    String nameHost = System.Net.Dns.GetHostName();
                    objLogBE.IP = System.Net.Dns.GetHostAddresses(nameHost).ToString();
                    objLogBE.Razon = "Se insertó un nuevo jugador";
                    objLogBE.Tabla = "Jugador";
                    objLogBE.Usuario = Propiedades.userLogged;

                    objLogBC.RegistrarLog(objLogBE);
                }

                return resultado;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public List<JugadorBE> listar_Jugadores()
        {
            JugadorDALC objJugadorDALC;

            try
            {
                objJugadorDALC = new JugadorDALC();

                List<JugadorBE> lst_jugadores = new List<JugadorBE>();
                lst_jugadores = objJugadorDALC.listar_Jugadores();

                LogBC objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = 0;
                objLogBE.Fecha = DateTime.Now;
                String nameHost = System.Net.Dns.GetHostName();
                objLogBE.IP = System.Net.Dns.GetHostAddresses(nameHost).ToString();
                objLogBE.Razon = "Se listó a los jugadores";
                objLogBE.Tabla = "Jugador";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return lst_jugadores;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public List<JugadorBE> listar_Jugadores_xEquipo(int codigo_equipo)
        {
            JugadorDALC objJugadorDALC;

            try
            {
                //-- Se lista solo los jugadores que estén habilitados para jugar (excluir jugadores lesionados y suspendidos)
                objJugadorDALC = new JugadorDALC();

                List<JugadorBE> lst_jugadores = new List<JugadorBE>();

                lst_jugadores = objJugadorDALC.listar_Jugadores_xEquipo(codigo_equipo);

                LogBC objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = codigo_equipo;
                objLogBE.Fecha = DateTime.Now;
                String nameHost = System.Net.Dns.GetHostName();
                objLogBE.IP = System.Net.Dns.GetHostAddresses(nameHost).ToString();
                objLogBE.Razon = "Se listó a los jugadores por equipo";
                objLogBE.Tabla = "JugadorEquipo";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return lst_jugadores;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public void asignar_JugadoraEquipo(List<JugadorEquipoBE> lista_jugadores)
        {
            JugadorDALC objJugadorDALC;

            try
            {
                LogBC objLogBC = new LogBC();
                objJugadorDALC = new JugadorDALC();

                for (int i = 0; i < lista_jugadores.Count; i++)
                {
                    objJugadorDALC.asignarJugador_aEquipo(lista_jugadores[i]);

                    
                    LogBE objLogBE = new LogBE();

                    objLogBE.CodOperacion = lista_jugadores[i].Codigo_jugador;
                    objLogBE.Fecha = DateTime.Now;
                    String nameHost = System.Net.Dns.GetHostName();
                    objLogBE.IP = System.Net.Dns.GetHostAddresses(nameHost).ToString();
                    objLogBE.Razon = "Se asignó jugador a equipo con id: "+lista_jugadores[i].Codigo_equipo.ToString();
                    objLogBE.Tabla = "JugadorEquipo";
                    objLogBE.Usuario = Propiedades.userLogged;

                    objLogBC.RegistrarLog(objLogBE);
                }
            }

            catch (Exception)
            {
                throw;
            }
        }

        public void editar_Jugador(int codigoJugador, Decimal nAltura, Decimal nPeso)
        {
            JugadorDALC objJugadorDALC;

            try
            {
                objJugadorDALC = new JugadorDALC();
                objJugadorDALC.editarJugador(codigoJugador, nAltura, nPeso);

                LogBC objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = codigoJugador;
                objLogBE.Fecha = DateTime.Now;
                String nameHost = System.Net.Dns.GetHostName();
                objLogBE.IP = System.Net.Dns.GetHostAddresses(nameHost).ToString();
                objLogBE.Razon = "Se actualizó un jugador";
                objLogBE.Tabla = "Jugador";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int cantidadGolesxJugador(int jugador, int liga)
        {
            JugadorDALC objJugadorDALC;

            try
            {
                objJugadorDALC = new JugadorDALC();

                int cantidad = objJugadorDALC.cantidadGolesxJugador(jugador, liga);

                LogBC objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = jugador;
                objLogBE.Fecha = DateTime.Now;
                String nameHost = System.Net.Dns.GetHostName();
                objLogBE.IP = System.Net.Dns.GetHostAddresses(nameHost).ToString();
                objLogBE.Razon = "Se obtuvo la cantidad de goles por jugador en una liga con id: "+liga.ToString();
                objLogBE.Tabla = "Jugador";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return cantidad;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public int cantidadPartidosxJugador(int jugador, int liga)
        {
            JugadorDALC objJugadorDALC;

            try
            {
                objJugadorDALC = new JugadorDALC();

                int Cantidad = objJugadorDALC.cantidadPartidosxJugador(jugador, liga);

                LogBC objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = jugador;
                objLogBE.Fecha = DateTime.Now;
                String nameHost = System.Net.Dns.GetHostName();
                objLogBE.IP = System.Net.Dns.GetHostAddresses(nameHost).ToString();
                objLogBE.Razon = "Se obtuvo la cantida de partidos jugados por un jugador en una liga con id: "+liga.ToString();
                objLogBE.Tabla = "Jugador";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return Cantidad;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public String estado_LesionJugador(int codigo_jugador, DateTime fecha)
        {
            JugadorDALC objJugadorDALC;

            try
            {
                objJugadorDALC = new JugadorDALC();

                String estado = objJugadorDALC.estado_LesionJugador(codigo_jugador, fecha);

                LogBC objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = codigo_jugador;
                objLogBE.Fecha = DateTime.Now;
                String nameHost = System.Net.Dns.GetHostName();
                objLogBE.IP = System.Net.Dns.GetHostAddresses(nameHost).ToString();
                objLogBE.Razon = "Se obtuvo el estado de lesión de un jugador en una fecha";
                objLogBE.Tabla = "LesionPartido";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return estado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HistorialJugadorBE> listar_HistorialDeJugador(int codigo_jugador)
        {
            HistorialJugadorDALC objHistorialJugadorDALC;

            try
            {
                objHistorialJugadorDALC = new HistorialJugadorDALC();

                List<HistorialJugadorBE> lst_historial = new List<HistorialJugadorBE>();
                lst_historial = objHistorialJugadorDALC.listar_historialdejugador(codigo_jugador);

                LogBC objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = codigo_jugador;
                objLogBE.Fecha = DateTime.Now;
                String nameHost = System.Net.Dns.GetHostName();
                objLogBE.IP = System.Net.Dns.GetHostAddresses(nameHost).ToString();
                objLogBE.Razon = "Se obtuvo el historial de un jugador";
                objLogBE.Tabla = "HistorialJugadorEquipo";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                
                return lst_historial;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void transferirJugadorNuevoEquipo(int codigo_jugador, int codigo_nuevoequipo)
        {
            JugadorDALC objJugadorDALC;

            try
            {
                objJugadorDALC = new JugadorDALC();
                objJugadorDALC.TransferirJugadorAEquipo(codigo_jugador, codigo_nuevoequipo);

                LogBC objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = codigo_jugador;
                objLogBE.Fecha = DateTime.Now;
                String nameHost = System.Net.Dns.GetHostName();
                objLogBE.IP = System.Net.Dns.GetHostAddresses(nameHost).ToString();
                objLogBE.Razon = "Se transfirió a un jugador a un equipo con id: " + codigo_nuevoequipo.ToString();
                objLogBE.Tabla = "JugadorEquipo";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<String> listar_Nacionalidades()
        {
            JugadorDALC objJugadorDALC;

            try
            {
                objJugadorDALC = new JugadorDALC();

                List<String> lst_nacionalidades = new List<String>();
                lst_nacionalidades = objJugadorDALC.ListarNacionalidades();

                LogBC objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = 0;
                objLogBE.Fecha = DateTime.Now;
                String nameHost = System.Net.Dns.GetHostName();
                objLogBE.IP = System.Net.Dns.GetHostAddresses(nameHost).ToString();
                objLogBE.Razon = "Se listaron las nacionalidades";
                objLogBE.Tabla = "Jugador";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return lst_nacionalidades;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<JugadorBE> listar_JugadoresXNacionalidad(String Nacionalidad)
        {
            JugadorDALC objJugadorDALC;

            try
            {
                objJugadorDALC = new JugadorDALC();

                List<JugadorBE> lst_jugadores = new List<JugadorBE>();
                lst_jugadores = objJugadorDALC.listar_Jugadores_xNacionalidad(Nacionalidad);

                LogBC objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = 0;
                objLogBE.Fecha = DateTime.Now;
                String nameHost = System.Net.Dns.GetHostName();
                objLogBE.IP = System.Net.Dns.GetHostAddresses(nameHost).ToString();
                objLogBE.Razon = "Se listaron los jugadores con la nacionalidad: " + Nacionalidad;
                objLogBE.Tabla = "Jugador";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return lst_jugadores;
            }
            catch (Exception)
            {
                throw;
            }
        }        
    }
}
