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
    public class UsuarioFuncionalidadBC
    {
        public static class Propiedades
        {
            public static string userLogged { get; set; }
        }

        public void Insertar_UsuarioFuncionalidad(List<UsuarioFuncionalidadBE> lst_usuarios)
        {
            try
            {
                LogBC objLogBC;
                UsuarioFuncionalidadDALC objUsuarioFuncionalidadDALC = new UsuarioFuncionalidadDALC();
                
                for(int i=0; i<lst_usuarios.Count; i++)
                {
                    objUsuarioFuncionalidadDALC.insertar_UsuarioFuncionalidad(lst_usuarios[i]);

                    //--Se registra el log
                    objLogBC = new LogBC();
                    LogBE objLogBE = new LogBE();
                    objLogBE.CodOperacion = lst_usuarios[i].idUsuario;
                    objLogBE.Fecha = DateTime.Now;
                    IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                    objLogBE.IP = entry.AddressList[0].ToString();
                    objLogBE.Razon = "Se asoció la funcionalidad con id: " + lst_usuarios[i].idFuncionalidad.ToString() + " al usuario";
                    objLogBE.Tabla = "UsuarioFuncionalidad";
                    objLogBE.Usuario = Propiedades.userLogged;

                    objLogBC.RegistrarLog(objLogBE);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Verificar_ExisteUsuarioFuncionalidad(int idUsuario, int idFuncionalidad)
        {
            try
            {
                LogBC objLogBC;
                UsuarioFuncionalidadDALC objUsuarioFuncionalidadDALC = new UsuarioFuncionalidadDALC();
                int result =  objUsuarioFuncionalidadDALC.Verificar_UsuarioXFuncionalidadExiste(idUsuario, idFuncionalidad);

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();
                objLogBE.CodOperacion = idUsuario;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se consultó la existencia de la asociación de la funcionalidad con id: " + idFuncionalidad.ToString() + " y el usuario";
                objLogBE.Tabla = "UsuarioFuncionalidad";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<FuncionalidadBE> Listar_FuncionalidadesXUsuario(int idUsuario)
        {
            try
            {
                LogBC objLogBC;
                UsuarioFuncionalidadDALC objUsuarioFuncionalidadDALC = new UsuarioFuncionalidadDALC();
                List<FuncionalidadBE> lst_funcionalidades = new List<FuncionalidadBE>();
                lst_funcionalidades = objUsuarioFuncionalidadDALC.listar_FuncionalidadesXUsuario(idUsuario);

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();
                objLogBE.CodOperacion = idUsuario;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se listaron las funcionalidades del usuario";
                objLogBE.Tabla = "UsuarioFuncionalidad";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return lst_funcionalidades;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
