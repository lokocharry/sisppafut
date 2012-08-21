using System;
using System.Collections.Generic;
using System.Text;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class PartidoPronosticadoBC
    {
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
    }
}
