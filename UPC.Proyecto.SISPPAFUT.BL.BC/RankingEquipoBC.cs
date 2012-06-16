using System;
using System.Collections.Generic;
using System.Text;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class RankingEquipoBC
    {
        public int insertar_ranking(RankingEquipoBE objRankingEquipoBE)
        {
            RankingEquipoDALC objRankingEquipoDALC;
            try
            {
                objRankingEquipoDALC = new RankingEquipoDALC();

                return objRankingEquipoDALC.insertar_ranking(objRankingEquipoBE);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<RankingBE> obtener_ranking(int anio, int mes, int codigoPais)
        {
            try
            {
                RankingEquipoDALC objRankingEquipoDALC = new RankingEquipoDALC();
                return objRankingEquipoDALC.obtener_ranking(anio, mes, codigoPais);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
