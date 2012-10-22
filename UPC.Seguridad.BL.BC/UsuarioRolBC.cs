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
    public class UsuarioRolBC
    {
        public static class Propiedades
        {
            public static string userLogged { get; set; }
        }

        public void asignar_RolUsuario(List<UsuarioRolBE> lst_asoc)
        {
            UsuarioRolDALC objUsuarioRolDALC;
            LogBC objLogBC;
            try
            {
                objUsuarioRolDALC = new UsuarioRolDALC();

                for (int i = 0; i < lst_asoc.Count; i++)
                {
                    objUsuarioRolDALC.asignar_Rol(lst_asoc[i].IdUsuario, lst_asoc[i].IdRol);

                    //--Se registra el log
                    objLogBC = new LogBC();
                    LogBE objLogBE = new LogBE();
                    objLogBE.CodOperacion = lst_asoc[i].IdUsuario;
                    objLogBE.Fecha = DateTime.Now;
                    IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                    objLogBE.IP = entry.AddressList[0].ToString();
                    objLogBE.Razon = "Se registró el rol con id: " + lst_asoc[i].IdRol + " al usuario";
                    objLogBE.Tabla = "UsuarioRol";
                    objLogBE.Usuario = Propiedades.userLogged;

                    objLogBC.RegistrarLog(objLogBE);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int VerificarExiste_Asociacion(int idRol, int idUsuario)
        {
            UsuarioRolDALC objUsuarioRolDALC;
            LogBC objLogBC;

            try
            {
                objUsuarioRolDALC = new UsuarioRolDALC();

                int verificar = objUsuarioRolDALC.Verificar_ExisteRolUsuario(idUsuario, idRol);

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();
                objLogBE.CodOperacion = idUsuario;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se consultó la existencia de una asociación entre el usuario y el rol con id: " + idRol.ToString();
                objLogBE.Tabla = "UsuarioRol";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return verificar;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<RolBE> Listar_RolesXUsuario(int idUsuario)
        {
            try
            {
                UsuarioRolDALC objUsuarioRolDALC = new UsuarioRolDALC();
                LogBC objLogBC;

                List<RolBE> lst_roles = new List<RolBE>();

                lst_roles = objUsuarioRolDALC.Listar_RolesXUsuario(idUsuario);

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();
                objLogBE.CodOperacion = idUsuario;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se listaron los roles del usuario";
                objLogBE.Tabla = "UsuarioRol";
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
