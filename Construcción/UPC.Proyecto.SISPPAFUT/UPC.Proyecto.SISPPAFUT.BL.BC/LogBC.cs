using System;
using System.Collections.Generic;
using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class LogBC
    {
        public int RegistrarLog(LogBE objLogBE)
        {
            int result = 0;
            try
            {
                LogDALC objLogDALC = new LogDALC();
                result = objLogDALC.InsertarLogBE(objLogBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public List<LogBE> ListarLogs()
        {
            List<LogBE> lsLogs = null;
            try
            {
                LogDALC objLogDALC = new LogDALC();
                lsLogs = objLogDALC.ListarLogBE();
            }
            catch (Exception ex)
            {
            }
            return lsLogs;
        }

        public List<LogBE> ListarLogsTabla(String Tabla)
        {
            List<LogBE> lsLogs = null;
            try
            {
                LogDALC objLogDALC = new LogDALC();
                lsLogs = objLogDALC.ListarLogBETabla(Tabla);
            }
            catch (Exception ex)
            {
            }
            return lsLogs;
        }

        public List<LogBE> ListarLogsUsuario(String Usuario)
        {
            List<LogBE> lsLogs = null;
            try
            {
                LogDALC objLogDALC = new LogDALC();
                lsLogs = objLogDALC.ListarLogBEUsuario(Usuario);
            }
            catch (Exception ex)
            {
            }
            return lsLogs;
        }

        public List<LogBE> ListarLogsIP(String IP)
        {
            List<LogBE> lsLogs = null;
            try
            {
                LogDALC objLogDALC = new LogDALC();
                lsLogs = objLogDALC.ListarLogBEIP(IP);
            }
            catch (Exception ex)
            {
            }
            return lsLogs;
        }

        public List<LogBE> ListarLogsFecha(DateTime Fecha)
        {
            List<LogBE> lsLogs = null;
            try
            {
                LogDALC objLogDALC = new LogDALC();
                lsLogs = objLogDALC.ListarLogBEFecha(Fecha);
            }
            catch (Exception ex)
            {
            }
            return lsLogs;
        }
    }
}