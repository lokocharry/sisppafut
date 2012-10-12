using System;
using System.Collections.Generic;
using System.Text;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class EquipoBC
    {
        String Usuario;

        public void RecibirCodigoUsuario(String Usuario)
        {
            this.Usuario = Usuario;
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

                LogBC objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                int idoperacion = objEquipoDALC.insertar_Equipo(objEquipoBE);

                objLogBE.CodOperacion = idoperacion;
                objLogBE.Fecha = DateTime.Now;
                String nameHost = System.Net.Dns.GetHostName();
                objLogBE.IP = System.Net.Dns.GetHostAddresses(nameHost).ToString();
                objLogBE.Razon = "Se insertó un nuevo equipo";
                objLogBE.Tabla = "Equipo";
                objLogBE.Usuario = Usuario;

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

                LogBC objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = 0;
                objLogBE.Fecha = DateTime.Now;
                String nameHost = System.Net.Dns.GetHostName();
                objLogBE.IP = System.Net.Dns.GetHostAddresses(nameHost).ToString();
                objLogBE.Razon = "Se listaron los equipos de "+Pais;
                objLogBE.Tabla = "Equipo";
                objLogBE.Usuario = Usuario;

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

                LogBC objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = 0;
                objLogBE.Fecha = DateTime.Now;
                String nameHost = System.Net.Dns.GetHostName();
                objLogBE.IP = System.Net.Dns.GetHostAddresses(nameHost).ToString();
                objLogBE.Razon = "Se listaron los equipos de la liga con id: "+Liga.ToString();
                objLogBE.Tabla = "Equipo";
                objLogBE.Usuario = Usuario;

                objLogBC.RegistrarLog(objLogBE);

                return objEquipoDALC.listar_EquiposDeLiga(Liga);
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

                LogBC objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = objEquipoBE.CodigoEquipo;
                objLogBE.Fecha = DateTime.Now;
                String nameHost = System.Net.Dns.GetHostName();
                objLogBE.IP = System.Net.Dns.GetHostAddresses(nameHost).ToString();
                objLogBE.Razon = "Se obtuvo un el equipo "+_equipo;
                objLogBE.Tabla = "Equipo";
                objLogBE.Usuario = Usuario;

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

                LogBC objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = codigo_equipo;
                objLogBE.Fecha = DateTime.Now;
                String nameHost = System.Net.Dns.GetHostName();
                objLogBE.IP = System.Net.Dns.GetHostAddresses(nameHost).ToString();
                objLogBE.Razon = "Se actualizó un equipo";
                objLogBE.Tabla = "Equipo";
                objLogBE.Usuario = Usuario;

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
                return qPartidosMes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
