using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class LigaEquipoBC
    {
        public static class Propiedades
        {
            public static string userLogged { get; set; }
        }

        public void insertarEquipoEnLiga(LigaEquipoBE objLigaEquipoBE)
        {
            LigaEquipoDALC objLigaEquipoDALC;
            LogBC objLogBC;

            try
            {
                objLigaEquipoDALC = new LigaEquipoDALC();
                objLigaEquipoDALC.insertar_LigaEquipo(objLigaEquipoBE);

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = objLigaEquipoBE.CodigoEquipo;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se registró equipo en liga con id: " + objLigaEquipoBE.CodigoLiga.ToString();
                objLogBE.Tabla = "LigaEquipo";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
