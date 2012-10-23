using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class EntrenadorBC
    {
        public static class Propiedades
        {
            public static string userLogged { get; set; }
        }

        public int RegistrarEntrenador(EntrenadorBE objEntrenadorBE)
        {
            EntrenadorDALC objEntrenadorDALC;

            try
            {
                objEntrenadorDALC = new EntrenadorDALC();
                int idoperacion = objEntrenadorDALC.RegistrarEntrenador(objEntrenadorBE);

                //--Se registra el log
                LogBC objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = idoperacion;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se registró un nuevo entrenador";
                objLogBE.Tabla = "Entrenador";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return idoperacion;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ActualizarEntrenador(EntrenadorBE objEntrenadorBE)
        {
            EntrenadorDALC objEntrenadorDALC;

            try
            {
                objEntrenadorDALC = new EntrenadorDALC();
                objEntrenadorDALC.ActualizarEntrenador(objEntrenadorBE);

                //--Se registra el log
                LogBC objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = objEntrenadorBE.CodEntrenador;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se actualizó el entrenador";
                objLogBE.Tabla = "Entrenador";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<EntrenadorBE> ListarEntrenadores()
        {
            EntrenadorDALC objEntrenadorDALC;

            try
            {
                objEntrenadorDALC = new EntrenadorDALC();
                List<EntrenadorBE> lst = new List<EntrenadorBE>();
                lst = objEntrenadorDALC.ListarEntrenadores();

                //--Se registra el log
                LogBC objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = 0;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se listaron los entrenadores";
                objLogBE.Tabla = "Entrenador";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return lst;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
