using System;
using System.Collections.Generic;
using System.Text;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class RankingEquipoBC
    {
        public static class Propiedades
        {
            public static string userLogged { get; set; }
        }

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


        public int obtener_PosRanking(int anio, int mes, int codPais, String eq)
        {
            try
            {
                RankingEquipoDALC objRankingEquipoDALC = new RankingEquipoDALC();

                List<RankingBE> rank = new List<RankingBE>();

                int _anio;
                int _mes;

                if(mes == 1)
                {   
                    _mes = 12;
                    _anio = anio - 1;
                }
                else
                {
                    _mes = mes;
                    _anio = anio;
                }

                rank = obtener_ranking(_anio, _mes, codPais);

                if (rank.Count > 0)
                {
                    foreach (RankingBE cDto in rank)
                    {
                        if (cDto.NombreEquipo == eq)
                            return cDto.Posicion;
                    }
                    return 0;
                }
                else
                    return 0;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
