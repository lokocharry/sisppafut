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
    public class UsuarioBC
    {
        public static class Propiedades
        {
            public static string userLogged { get; set; }
        }

        public int insertar_Usuario(UsuarioBE objUsuarioBE)
        {
            UsuarioDALC objUsuarioDALC;
            LogBC objLogBC;
            int resultado = 0;

            try
            {
                objUsuarioDALC=new UsuarioDALC();
                resultado = objUsuarioDALC.insertar_Usuario(objUsuarioBE);

                if (resultado != 0)
                {
                    //--Se registra el log
                    objLogBC = new LogBC();
                    LogBE objLogBE = new LogBE();
                    objLogBE.CodOperacion = resultado;
                    objLogBE.Fecha = DateTime.Now;
                    IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                    objLogBE.IP = entry.AddressList[0].ToString();
                    objLogBE.Razon = "Se registró un usuario";
                    objLogBE.Tabla = "Usuario";
                    objLogBE.Usuario = Propiedades.userLogged;

                    objLogBC.RegistrarLog(objLogBE);
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<UsuarioBE> listar_Usuarios()
        {
            UsuarioDALC objUsuarioDALC;
            LogBC objLogBC;

            try
            {
                objUsuarioDALC = new UsuarioDALC();
                List<UsuarioBE> lst_usuarios = new List<UsuarioBE>();
                lst_usuarios = objUsuarioDALC.listar_usuarios();

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();
                objLogBE.CodOperacion = 0;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se listaron los usuarios";
                objLogBE.Tabla = "Usuario";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return lst_usuarios;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int Verificar_LoginUsuario(String usuario, String contrasenia)
        {
            UsuarioDALC objUsuarioDALC;
            LogBC objLogBC;

            try
            {
                objUsuarioDALC = new UsuarioDALC();
                int result =  objUsuarioDALC.Verificar_LoginUsuario(usuario, contrasenia);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Verificar_LoginExiste(String usuario)
        {
            try
            {
                UsuarioDALC objUsuarioDALC = new UsuarioDALC();
                return objUsuarioDALC.Verificar_LoginExiste(usuario);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
