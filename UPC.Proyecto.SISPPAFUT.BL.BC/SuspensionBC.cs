using System;
using System.Collections.Generic;
using System.Text;

using UPC.Proyecto.SISPPAFUT.DL.DALC;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class SuspensionBC
    {
        public void crear_Suspension(int codJugador)
        {
            try
            {
                SuspensionDALC objSuspensionDALC = new SuspensionDALC();
                objSuspensionDALC.crear_Suspension(codJugador);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void actualizar_Suspension(int codJugador, int tipo)
        {
            try
            {
                SuspensionDALC objSuspensionDALC = new SuspensionDALC();
                objSuspensionDALC.actualizar_Suspension(codJugador, tipo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public String leer_EstadoSuspension(int codJugador)
        {
            try
            {
                SuspensionDALC objSuspensionDALC = new SuspensionDALC();
                return objSuspensionDALC.leer_EstadoSuspension(codJugador);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
