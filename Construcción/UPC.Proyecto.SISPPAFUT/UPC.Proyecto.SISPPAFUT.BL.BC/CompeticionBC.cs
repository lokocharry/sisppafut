using System;
using System.Collections.Generic;
using System.Text;

using UPC.Proyecto.SISPPAFUT.DL.DALC;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class CompeticionBC
    {
        public int insertar_Competicion(CompeticionBE objCompeticionBE)
        {
            CompeticionDALC objCompeticionDALC = new CompeticionDALC();
            return objCompeticionDALC.insertar_Competicion(objCompeticionBE);
        }

        public List<CompeticionBE> ListarCompeticion(String Pais)
        {
            try
            {
                CompeticionDALC objCompeticionDALC = new CompeticionDALC();
                List<CompeticionBE> lst = objCompeticionDALC.listar_Competicion(Pais);
                return lst;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
