using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class PronosticoClienteBC
    {
        public static class Propiedades
        {
            public static string userLogged { get; set; }
        }

        public void inssertarPronosticoCliente(PronosticoClienteBE objPronosticoClienteBE)
        {
            try
            {
                PronosticoClienteDALC objPronosticoClienteDALC;
                objPronosticoClienteDALC = new PronosticoClienteDALC();

                objPronosticoClienteDALC.insertarPronosticoCliente(objPronosticoClienteBE);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<PronosticoClienteBE> listarPronosticosCliente(int icodCliente)
        {
            try
            {
                PronosticoClienteDALC objPronosticoClienteDALC;
                objPronosticoClienteDALC = new PronosticoClienteDALC();

                return objPronosticoClienteDALC.listarPronosticosCliente(icodCliente);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
