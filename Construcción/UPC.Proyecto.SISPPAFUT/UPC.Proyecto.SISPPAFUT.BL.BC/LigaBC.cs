using System;
using System.Collections.Generic;
using System.Text;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class LigaBC
    {
        public int insertarLiga(String pais, String competicion, LigaBE objLigaBE, List<LigaEquipoBE> lstEquipos)
        {
            LigaDALC objLigaDALC;

            try
            {
                objLigaDALC = new LigaDALC();
                int codLiga = 0;
                
                if (objLigaDALC.existe_Liga(objLigaBE.NombreLiga) == 1)
                {
                    return -1;
                }
                else
                {
                    //-- Recupero el codigo de la competición
                    CompeticionBC objCompBC = new CompeticionBC();
                    CompeticionBE objCompeticionBE = objCompBC.obtenerCompeticion(competicion, pais);
                    
                    if (objCompeticionBE != null)
                    {
                        //-- Agrego el codigo de la competición
                        objLigaBE.CodigoCompeticion = objCompeticionBE.Codigo_competicion;

                        codLiga = objLigaDALC.insertar_Liga(objLigaBE);
                        if (codLiga != 0)
                        {
                            LigaEquipoBC objLigaEquipoBC = new LigaEquipoBC();
                            LigaEquipoBE objLigaEquipoBE = new LigaEquipoBE();
                            foreach (LigaEquipoBE cDto in lstEquipos)
                            {
                                objLigaEquipoBE.CodigoLiga = codLiga;
                                objLigaEquipoBE.CodigoEquipo = cDto.CodigoEquipo;

                                objLigaEquipoBC.insertarEquipoEnLiga(objLigaEquipoBE);
                            }
                        }
                    }
                }
                return codLiga;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<LigaBE> listarLigas()
        {
            try
            {
                LigaDALC objLigaDALC = new LigaDALC();
                return objLigaDALC.listar_Ligas();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        
    }
}
