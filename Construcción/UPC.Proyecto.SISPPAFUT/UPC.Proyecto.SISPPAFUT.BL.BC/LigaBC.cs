using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class LigaBC
    {
        public static class Propiedades
        {
            public static string userLogged { get; set; }
        }

        public int insertarLiga(String pais, String competicion, LigaBE objLigaBE, List<LigaEquipoBE> lstEquipos)
        {
            LigaDALC objLigaDALC;
            LogBC objLogBC;

            try
            {
                objLigaDALC = new LigaDALC();
                int codLiga = 0;
                
                if (objLigaDALC.existe_Liga(objLigaBE.NombreLiga) == 1)
                {
                    return -1;
                }
                else
                {
                    objLogBC = new LogBC();

                    //-- Recupero el codigo de la competición
                    CompeticionBC objCompBC = new CompeticionBC();
                    CompeticionBE objCompeticionBE = objCompBC.obtenerCompeticion(competicion, pais);
                    
                    if (objCompeticionBE != null)
                    {                        
                        //-- Agrego el codigo de la competición
                        objLigaBE.CodigoCompeticion = objCompeticionBE.Codigo_competicion;

                        codLiga = objLigaDALC.insertar_Liga(objLigaBE);

                        //--Log Insersión de Liga                        
                        LogBE objLogBE = new LogBE();

                        objLogBE.CodOperacion = codLiga;
                        objLogBE.Fecha = DateTime.Now;
                        IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                        objLogBE.IP = entry.AddressList[0].ToString();
                        objLogBE.Razon = "Se registró una liga";
                        objLogBE.Tabla = "Liga";
                        objLogBE.Usuario = Propiedades.userLogged;

                        objLogBC.RegistrarLog(objLogBE);

                        //--Fin de Log Insersión de Liga

                        if (codLiga != 0)
                        {
                            LigaEquipoBC objLigaEquipoBC = new LigaEquipoBC();
                            LigaEquipoBE objLigaEquipoBE = new LigaEquipoBE();
                            SuspensionBC objSuspensionBC;
                            foreach (LigaEquipoBE cDto in lstEquipos)
                            {
                                objLigaEquipoBE.CodigoLiga = codLiga;
                                objLigaEquipoBE.CodigoEquipo = cDto.CodigoEquipo;

                                objLigaEquipoBC.insertarEquipoEnLiga(objLigaEquipoBE);

                                //--listo los jugadores del equipo e inserto un registro de suspensión
                                JugadorBC objJugadorBC = new JugadorBC();
                                List<JugadorBE> lstJugadoresDelEquipo = new List<JugadorBE>();
                                lstJugadoresDelEquipo = objJugadorBC.listar_Jugadores_xEquipo(cDto.CodigoEquipo);
                                if (lstJugadoresDelEquipo.Count > 0)
                                {
                                    foreach (JugadorBE _cDto in lstJugadoresDelEquipo)
                                    {
                                        objSuspensionBC = new SuspensionBC();
                                        SuspensionBE objSuspensionBE = new SuspensionBE();
                                        objSuspensionBE.CodigoJugador = _cDto.CodigoJugador;
                                        objSuspensionBE.CodLiga = codLiga;
                                        objSuspensionBC.crear_Suspension(objSuspensionBE);
                                    }
                                }
                            }
                            //-- Agrego datos para la tabla de la liga
                            TablaPosicionesBC objTablaBC = new TablaPosicionesBC();
                            objTablaBC.InsertarEquiposTablaPosiciones(codLiga, lstEquipos);

                            //--Log Tabla LigaEquipo

                            LogBE objLogBE2 = new LogBE();

                            objLogBE2.CodOperacion = 0;
                            objLogBE2.Fecha = DateTime.Now;
                            IPHostEntry entry2 = Dns.GetHostByName(Dns.GetHostName());
                            objLogBE2.IP = entry2.AddressList[0].ToString();
                            objLogBE2.Razon = "Se registraron los equipos de una liga con id: "+codLiga.ToString();
                            objLogBE2.Tabla = "LigaEquipo";
                            objLogBE2.Usuario = Propiedades.userLogged;

                            objLogBC.RegistrarLog(objLogBE2);
                        }
                    }
                }
                return codLiga;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<LigaBE> listarLigas()
        {
            LigaDALC objLigaDALC;
            LogBC objLogBC;

            try
            {
                objLigaDALC = new LigaDALC();

                List<LigaBE> lst_ligas = new List<LigaBE>();
                lst_ligas = objLigaDALC.listar_Ligas();

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE2 = new LogBE();

                objLogBE2.CodOperacion = 0;
                objLogBE2.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE2.IP = entry.AddressList[0].ToString();
                objLogBE2.Razon = "Se listaron las ligas";
                objLogBE2.Tabla = "Liga";
                objLogBE2.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE2);

                return lst_ligas;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<LigaBE> listaLigasPorCompeticion(int codigoCompeticion)
        {
            LigaDALC objLigaDALC;
            LogBC objLogBC;
            try
            {
                objLigaDALC = new LigaDALC();

                List<LigaBE> lst_ligas = new List<LigaBE>();
                lst_ligas = objLigaDALC.listarLigasDeCompeticion(codigoCompeticion);

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = 0;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se listaron las ligas para la competición con id: " + codigoCompeticion.ToString();
                objLogBE.Tabla = "Liga";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return lst_ligas;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int CantidadEquiposLiga(int codLiga)
        {
            LigaDALC objLigaDALC;
            LogBC objLogBC;

            try
            {
                objLigaDALC = new LigaDALC();
                LigaBE objLigaBE = new LigaBE();
                objLigaBE = objLigaDALC.ObtenerLiga(codLiga);

                int qEquipos = 0;
                
                if(objLigaBE!=null)
                {
                   qEquipos = objLigaBE.CantidadEquipos;
                }

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = codLiga;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se consultó la cantidad de equipos por liga";
                objLogBE.Tabla = "LigaEquipo";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return qEquipos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
   
    }
}
