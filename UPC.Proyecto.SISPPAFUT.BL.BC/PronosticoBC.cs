using System;
using System.Collections.Generic;
using System.Text;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class PronosticoBC
    {
        public int insertar_Pronostico(PronosticoBE objPronosticoBE)
        {
            try
            {
                PronosticoDALC objPronosticoDALC;
                objPronosticoDALC = new PronosticoDALC();

                return objPronosticoDALC.insertar_Pronostico(objPronosticoBE);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void actualizar_Pronostico(PronosticoBE objPronosticoBE)
        {
            try
            {
                PronosticoDALC objPronosticoDALC;
                objPronosticoDALC = new PronosticoDALC();

                objPronosticoDALC.actualizar_Pronostico(objPronosticoBE);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<PronosticoBE> listar_Pronosticos()
        {
            try
            {
                PronosticoDALC objPronosticoDALC;
                objPronosticoDALC = new PronosticoDALC();

                return objPronosticoDALC.listar_Pronosticos();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<PronosticoBE> listar_PronosticosParaApostador()
        {
            try
            {
                PronosticoDALC objPronosticoDALC;
                objPronosticoDALC = new PronosticoDALC();

                return objPronosticoDALC.listar_PronosticosParaApostador();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
