using System;
using System.Collections.Generic;
using System.Text;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class PartidoBC
    {
        public int insertar_Partido(PartidoBE objPartidoBE)
        {
            PartidoDALC objPartidoDALC;
            int resultado = 0;
            try
            {
                objPartidoDALC = new PartidoDALC();
                resultado = objPartidoDALC.insertar_partido(objPartidoBE);
                return resultado;
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
    }
}
