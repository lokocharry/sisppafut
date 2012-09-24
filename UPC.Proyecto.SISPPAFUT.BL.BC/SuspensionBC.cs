using System;
using System.Collections.Generic;
using System.Text;

using UPC.Proyecto.SISPPAFUT.DL.DALC;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class SuspensionBC
    {
        public void crear_Suspension(SuspensionBE objSuspension)
        {
            try
            {
                SuspensionDALC objSuspensionDALC = new SuspensionDALC();
                objSuspensionDALC.crear_Suspension(objSuspension);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void actualizar_Suspension(int codJugador, int codLiga, int tipo)
        {
            SuspensionDALC objSuspensionDALC;

            try
            {
                objSuspensionDALC = new SuspensionDALC();
                objSuspensionDALC.actualizar_Suspension(codJugador, codLiga, tipo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public String leer_EstadoSuspension(int codJugador, int codLiga)
        {
            try
            {
                SuspensionDALC objSuspensionDALC = new SuspensionDALC();
                return objSuspensionDALC.leer_EstadoSuspension(codJugador, codLiga);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Boolean consultar_ArqueroSuspendido(int codEquipo, int codLiga)
        {
            try
            {
                SuspensionDALC objDALC = new SuspensionDALC();
                return objDALC.consultar_ArqueroSuspendido(codEquipo, codLiga);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Boolean consultar_GoleadorSuspendido(int codEquipo, int codLiga)
        {
            try
            {
                SuspensionDALC objDALC = new SuspensionDALC();
                return objDALC.consultar_GoleadorSuspendido(codEquipo, codLiga);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int CantidadJugadoresSuspendidos(int codEquipo, int codLiga, DateTime fecha)
        {
            SuspensionDALC objSuspensionDALC;
            List<SuspensionBE> lstSuspensiones;

            try
            {
                objSuspensionDALC = new SuspensionDALC();
                lstSuspensiones = new List<SuspensionBE>();
                int qSuspendidos = 0;
                lstSuspensiones = objSuspensionDALC.CantidadJugadoresSuspendidos(codEquipo, codLiga, fecha);

                if (lstSuspensiones.Count > 0)
                {
                    foreach (SuspensionBE cDto in lstSuspensiones)
                    {
                        if (cDto.QAmarillas % 5 == 0)
                            qSuspendidos = qSuspendidos + 1;
                    }
                }

                return qSuspendidos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
