using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class EstadioBC
    {
        public int insertar_Estadio(EstadioBE objEstadioBE)
        {
            int result = 0;
            try
            {
                EstadioDALC objEstadioDALC = new EstadioDALC();
                result = objEstadioDALC.insertar_Estadio(objEstadioBE);

                if (result != 0)
                {
                    //Guardar el registro;
                    LogBC objLogBC = new LogBC();
                    LogBE objLogBE = new LogBE();
                    IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                    objLogBE.CodOperacion = result;
                    objLogBE.Fecha = DateTime.Now;
                    objLogBE.IP = entry.AddressList[0].ToString();
                    objLogBE.Razon = "Inserción de un nuevo registro en el sistema";
                    objLogBE.Tabla = "Estadio";
                    objLogBE.Usuario = "Adminn"; //Debo obtener el usuario
                    int r = (objLogBC.RegistrarLog(objLogBE));
                }

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<EstadioBE> listarEstadios()
        {
            try
            {
                EstadioDALC objEstadioDALC = new EstadioDALC();
                return objEstadioDALC.listar_Estadios();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<EstadioBE> listarEstadiosDeEquipo(int codigo_equipo)
        {
            try
            {
                EstadioDALC objEstadioDALC = new EstadioDALC();
                return objEstadioDALC.obtenerEstadioDeEquipo(codigo_equipo);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<EstadioBE> listarEstadiosDePais(int codigo_pais)
        {
            try
            {
                EstadioDALC objEstadioDALC = new EstadioDALC();
                return objEstadioDALC.obtenerEstadioDePais(codigo_pais);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
