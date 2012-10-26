using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.BL.BC;
using UPC.Seguridad.BL.BE;
using UPC.Seguridad.DL.DALC;

namespace UPC.Seguridad.BL.BC
{
    public class FuncionalidadBC
    {
        public static class Propiedades
        {
            public static string userLogged { get; set; }
        }

        public int Insertar_Funcionalidad(String NombreFuncionalidad, String DescripcionFuncionalidad)
        {
            FuncionalidadBE objFuncionalidadBE;
            FuncionalidadDALC objFuncionalidadDALC;

            try
            {
                int Cantidad = Verificar_ExisteFuncionalidad(NombreFuncionalidad);

                if (Cantidad > 0)
                    return -1;

                objFuncionalidadBE = new FuncionalidadBE();
                objFuncionalidadBE.DescripcionFuncionalidad = DescripcionFuncionalidad;
                objFuncionalidadBE.NombreFuncionalidad = NombreFuncionalidad;

                objFuncionalidadDALC = new FuncionalidadDALC();

                int result =  objFuncionalidadDALC.insertar_funcionalidad(objFuncionalidadBE);

                if (result != 0)
                {
                    //--Se registra el log
                    LogBC objLogBC = new LogBC();
                    LogBE objLogBE = new LogBE();
                    objLogBE.CodOperacion = result;
                    objLogBE.Fecha = DateTime.Now;
                    IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                    objLogBE.IP = entry.AddressList[0].ToString();
                    objLogBE.Razon = "Se registró una funcionalidad";
                    objLogBE.Tabla = "Funcionalidad";
                    objLogBE.Usuario = Propiedades.userLogged;

                    objLogBC.RegistrarLog(objLogBE);
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Verificar_ExisteFuncionalidad(String NombreFuncionalidad)
        {
            FuncionalidadDALC objFuncionalidadDALC;
            LogBC objLogBC;

            try
            {
                objFuncionalidadDALC = new FuncionalidadDALC();

                int resultado =  objFuncionalidadDALC.verificar_existeFuncionalidad(NombreFuncionalidad);

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();
                objLogBE.CodOperacion = 0;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se verificó si existe la funcionalidad " + NombreFuncionalidad;
                objLogBE.Tabla = "Funcionalidad";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<FuncionalidadBE> Listar_Funcionalidades()
        {
            FuncionalidadDALC objFuncionalidadDALC;
            LogBC objLogBC;

            try
            {
                objFuncionalidadDALC = new FuncionalidadDALC();
                List<FuncionalidadBE> lst_funcionalidad = new List<FuncionalidadBE>();

                lst_funcionalidad = objFuncionalidadDALC.listar_Funcionalid();

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();
                objLogBE.CodOperacion = 0;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se listaron las funcionalidades";
                objLogBE.Tabla = "Funcionalidad";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return lst_funcionalidad;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
