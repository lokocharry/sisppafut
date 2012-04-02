using System;
using System.Collections.Generic;
using System.Text;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class EquipoBC
    {
        public int insertarEquipo(EquipoBE objEquipoBE)
        {
            EquipoDALC objEquipoDALC;

            try
            {
                objEquipoDALC = new EquipoDALC();

                if (objEquipoDALC.existe_Equipo(objEquipoBE.NombreEquipo) == 1)
                {
                    return -1;
                }

                return objEquipoDALC.insertar_Equipo(objEquipoBE);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<EquipoBE> listarEquipos()
        {
            EquipoDALC objEquipoDALC = new EquipoDALC();
            return objEquipoDALC.listar_Equipos();
        }
    }
}
