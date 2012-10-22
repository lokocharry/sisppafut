using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class EntrenadorBC
    {
        public int RegistrarEntrenador(EntrenadorBE objEntrenadorBE)
        {
            EntrenadorDALC objEntrenadorDALC;

            try
            {
                objEntrenadorDALC = new EntrenadorDALC();
                return objEntrenadorDALC.RegistrarEntrenador(objEntrenadorBE);
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
                return objEntrenadorDALC.ListarEntrenadores();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
