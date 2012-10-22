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
    public class RolXFuncionalidadBC
    {
        public static class Propiedades
        {
            public static string userLogged { get; set; }
        }

        public void Insertar_RolXFuncionalidad(List<RolXFuncionalidadBE> lst_RolFunc)
        {
            RolXFuncionalidadDALC objRolFuncionalidad;
            LogBC objLogBC;

            try
            {
                objRolFuncionalidad = new RolXFuncionalidadDALC();

                for (int i = 0; i < lst_RolFunc.Count; i++)
                {
                    objRolFuncionalidad.insertar_RolXFuncionalidad(lst_RolFunc[i]);

                    //--Se registra el log
                    objLogBC = new LogBC();
                    LogBE objLogBE = new LogBE();
                    objLogBE.CodOperacion = lst_RolFunc[i].idRol;
                    objLogBE.Fecha = DateTime.Now;
                    IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                    objLogBE.IP = entry.AddressList[0].ToString();
                    objLogBE.Razon = "Se asoció la funcionalidad con id: " + lst_RolFunc[i].idFuncionalidad.ToString() + " al rol";
                    objLogBE.Tabla = "RolFuncionalidad";
                    objLogBE.Usuario = Propiedades.userLogged;

                    objLogBC.RegistrarLog(objLogBE);

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<FuncionalidadBE> Listar_FuncionalidadesXRol(int idRol)
        {
            RolXFuncionalidadDALC objRolFuncionalidadDALC;
            LogBC objLogBC;

            try
            {
                objRolFuncionalidadDALC = new RolXFuncionalidadDALC();
                List<FuncionalidadBE> lst_funcionalidad = new List<FuncionalidadBE>();
                lst_funcionalidad = objRolFuncionalidadDALC.listar_FuncionalidadesXRol(idRol);

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();
                objLogBE.CodOperacion = idRol;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se listaron las funcionalidades del rol";
                objLogBE.Tabla = "RolFuncionalidad";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return lst_funcionalidad;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int VerificarSiExiste_RolXFuncionalidad(int idRol, int idFuncionalidad)
        {
            RolXFuncionalidadDALC objRolXFuncionalidadDALC;
            LogBC objLogBC; 

            try
            {
                objRolXFuncionalidadDALC = new RolXFuncionalidadDALC();

                int resultado =  objRolXFuncionalidadDALC.Verificar_RolXFuncionalidadExiste(idRol, idFuncionalidad);

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();
                objLogBE.CodOperacion = idRol;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se verificó si existe la asociación del rol con la funcionalidad con id: " + idFuncionalidad.ToString();
                objLogBE.Tabla = "RolFuncionalidad";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
