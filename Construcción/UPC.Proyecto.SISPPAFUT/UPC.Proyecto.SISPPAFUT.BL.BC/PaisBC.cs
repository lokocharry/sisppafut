using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class PaisBC
    {
        public static class Propiedades
        {
            public static string userLogged { get; set; }
        }

        public int insertarPais(PaisBE objPaisBE)
        {
            PaisDALC objPaisDALC;
            LogBC objLogBC;
            try
            {
                objPaisDALC = new PaisDALC();

                if (objPaisDALC.existe_Pais(objPaisBE.NombrePais) == 1)
                {
                    return -1;
                }

                int result = objPaisDALC.insertar_Pais(objPaisBE);

                if (result != 0)
                {
                    //--Se registra el log
                    objLogBC = new LogBC();
                    LogBE objLogBE = new LogBE();

                    objLogBE.CodOperacion = result;
                    objLogBE.Fecha = DateTime.Now;
                    IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                    objLogBE.IP = entry.AddressList[0].ToString();
                    objLogBE.Razon = "Se registró un país";
                    objLogBE.Tabla = "Pais";
                    objLogBE.Usuario = Propiedades.userLogged;

                    objLogBC.RegistrarLog(objLogBE);
                }

                return objPaisDALC.insertar_Pais(objPaisBE);
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public List<PaisBE> listarPaises()
        {
            LogBC objLogBC;
            PaisDALC objPaisDALC;
            try
            {
                objPaisDALC = new PaisDALC();
                objLogBC = new LogBC();
                List<PaisBE> lst_paises = new List<PaisBE>();
                lst_paises = objPaisDALC.listar_Paises();

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = 0;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se listaron los paises";
                objLogBE.Tabla = "Pais";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return lst_paises;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
