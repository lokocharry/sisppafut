using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UPC.Proyecto.SISPPAFUT.DL.DALC;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class UsuarioReferenciaBC
    {
        public void insertar_UsuarioReferencia(UsuarioReferenciaBE objUsuarioReferenciaBE)
        {
            UsuarioReferenciaDALC objUsuarioReferenciaDALC;

            try
            {
                objUsuarioReferenciaDALC = new UsuarioReferenciaDALC();
                objUsuarioReferenciaDALC.insertar_UsuarioReferencia(objUsuarioReferenciaBE);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
