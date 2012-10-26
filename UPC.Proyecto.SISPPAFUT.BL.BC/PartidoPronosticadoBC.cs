using System;
using System.Collections.Generic;
using System.Text;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class PartidoPronosticadoBC
    {
        public void insertar_PartidoPronosticado(PartidoPronosticadoBE objPartidoPronosticado)
        {
            try
            {
                PartidoPronosticadoDALC objPartidoDALC = new PartidoPronosticadoDALC();
                objPartidoDALC.insertar_PartidoPronosticado(objPartidoPronosticado);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<PartidoPronosticadoBE> listar_PartidosPronosticos()
        {
            try
            {
                PartidoPronosticadoDALC objPartidoPronosticoDALC;
                objPartidoPronosticoDALC = new PartidoPronosticadoDALC();

                return objPartidoPronosticoDALC.listar_PartidoPronosticado();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int VerificarExistePronostico(int codPartido)
        {
            try
            {
                PartidoPronosticadoDALC objPartidoPronosticoDALC;
                objPartidoPronosticoDALC = new PartidoPronosticadoDALC();

                return objPartidoPronosticoDALC.existePronostico(codPartido);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int VerificarExistePartidoPronostico(int codPartido)
        {
            try
            {
                PartidoPronosticadoDALC objPartidoPronosticoDALC;
                objPartidoPronosticoDALC = new PartidoPronosticadoDALC();

                return objPartidoPronosticoDALC.existePartidoPronosticado(codPartido);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ActualizarPartidoPronosticado(PartidoPronosticadoBE PP)
        {
            try
            {
                PartidoPronosticadoDALC objPartidoPronosticoDALC;
                objPartidoPronosticoDALC = new PartidoPronosticadoDALC();

                objPartidoPronosticoDALC.ActualizarPartidoPronosticado(PP);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
