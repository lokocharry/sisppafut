using System;
using System.Collections.Generic;
using System.Text;

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

            try
            {
                objPartidoDALC = new PartidoDALC();
                return objPartidoDALC.listar_todos_partidos();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<PartidoSinJugarBE> lista_partidos_pronosticados()
        {
            PartidoDALC objPartidoDALC;

            try
            {
                objPartidoDALC = new PartidoDALC();
                return objPartidoDALC.listar_partidos_pronosticados();
            }

            catch (Exception)
            {
                throw;
            }
        }

        public List<PartidoSinJugarBE> lista_partidos_sinjugar()
        {
            PartidoDALC objPartidoDALC;

            try
            {
                objPartidoDALC = new PartidoDALC();
                return objPartidoDALC.listar_partidos_sinjugar();
            }

            catch (Exception)
            {
                throw;
            }
        }

        public PartidoBE obtener_Partido(int codigo_partido)
        {
            PartidoDALC objPartidoDALC;

            try
            {
                objPartidoDALC = new PartidoDALC();
                return objPartidoDALC.obtener_Partido(codigo_partido);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public void editar_Partido(int codigoPartido, DateTime nuevaFecha)
        {
            PartidoDALC objPartidoDALC;
            
            try
            {
                objPartidoDALC = new PartidoDALC();
                objPartidoDALC.editar_partido(codigoPartido, nuevaFecha);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void actualizar_Resultado(int codigo_partido, int goles_local, int goles_visita)
        {
            PartidoDALC objPartidoDALC;

            try
            {
                objPartidoDALC = new PartidoDALC();
                objPartidoDALC.actualizar_Resultado(codigo_partido, goles_local, goles_visita);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public List<PartidoJugadoBE> lista_ultimosPartidos(int codigo_equipo, int codigo_liga, DateTime fecha)
        {
            PartidoDALC objPartidoDALC;

            try
            {
                objPartidoDALC = new PartidoDALC();
                return objPartidoDALC.lista_ultimosPartidos(codigo_equipo, codigo_liga, fecha);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public List<PartidoSinJugarBE> lista_partidos_jugados()
        {
            PartidoDALC objPartidoDALC;

            try
            {
                objPartidoDALC = new PartidoDALC();
                return objPartidoDALC.listar_partidos_jugados();
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
