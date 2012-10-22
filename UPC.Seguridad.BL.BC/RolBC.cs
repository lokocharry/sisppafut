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
    public class RolBC
    {
        public static class Propiedades
        {
            public static string userLogged { get; set; }
        }

        public int Insertar_Rol(String NombreRol, String ClaveRol, String DescripcionRol)
        {
            RolDALC objRolDALC;
            RolBE objRolBE;
            LogBC objLogBC;

            try
            {
                int Cantidad = Verificar_ExisteRol(NombreRol);

                if (Cantidad > 0)
                    return -1;

                objRolBE = new RolBE();
                objRolBE.NombreRol = NombreRol;
                objRolBE.ClaveRol = ClaveRol;
                objRolBE.DescripcionRol = DescripcionRol;

                objRolDALC = new RolDALC();
                int result =  objRolDALC.insertar_rol(objRolBE);

                if (result != 0)
                {
                    //--Se registra el log
                    objLogBC = new LogBC();
                    LogBE objLogBE = new LogBE();
                    objLogBE.CodOperacion = result;
                    objLogBE.Fecha = DateTime.Now;
                    IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                    objLogBE.IP = entry.AddressList[0].ToString();
                    objLogBE.Razon = "Se registró un rol";
                    objLogBE.Tabla = "Rol";
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

        public int Verificar_ExisteRol(String NombreRol)
        {
            RolDALC objRol;
            LogBC objLogBC;

            try
            {
                objRol = new RolDALC();

                int verificar =  objRol.verificar_existeRol(NombreRol);

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();
                objLogBE.CodOperacion = 0;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se verificó si existe el rol " + NombreRol;
                objLogBE.Tabla = "Rol";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return verificar;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<RolBE> Listar_roles()
        {
            RolDALC objRolDALC;
            LogBC objLogBC;

            try
            {
                objRolDALC = new RolDALC();
                List<RolBE> lst_roles = new List<RolBE>();
                lst_roles = objRolDALC.listar_roles();

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();
                objLogBE.CodOperacion = 0;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se listaron los roles";
                objLogBE.Tabla = "Rol";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return lst_roles;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
