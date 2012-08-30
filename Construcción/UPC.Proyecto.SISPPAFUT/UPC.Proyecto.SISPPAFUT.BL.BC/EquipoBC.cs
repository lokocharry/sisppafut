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

        public List<EquipoBE> listarEquipos(String Pais)
        {
            try
            {
                EquipoDALC objEquipoDALC = new EquipoDALC();
                return objEquipoDALC.listar_Equipos(Pais);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public List<EquipoBE> listarEquiposDeLiga(int Liga)
        {
            try
            {
                EquipoDALC objEquipoDALC = new EquipoDALC();
                return objEquipoDALC.listar_EquiposDeLiga(Liga);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public EquipoBE obtenerEquipo(String _equipo)
        {
            try
            {
                EquipoBE objEquipoBE;
                EquipoDALC objEquipoDALC = new EquipoDALC();
                objEquipoBE = objEquipoDALC.obtener_Equipo(_equipo);
                return objEquipoBE;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void actualizarEquipo(int codigo_equipo, int estadio_principal, int estadio_alterno)
        {
            try
            {
                EquipoDALC objEquipoDALC = new EquipoDALC();
                objEquipoDALC.actualizar_equipo(codigo_equipo, estadio_principal, estadio_alterno);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Decimal obtener_PromedioEquipoTitular(int codEquipo, int codLiga)
        {
            try
            {
                Decimal promEdad;
                EquipoDALC objEquipoDALC = new EquipoDALC();
                promEdad = objEquipoDALC.obtener_PromedioEquipoTitular(codEquipo, codLiga);
                return promEdad;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int obtener_CantidadExpulsadosUltimoPartido(int codPartido, int codEquipo, int codLiga)
        {
            try
            {
                int qExpulsados;
                EquipoDALC objEquipoDALC = new EquipoDALC();
                qExpulsados = objEquipoDALC.obtener_CantidadExpulsadosUltimoPartido(codPartido, codEquipo, codLiga);
                return qExpulsados;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
