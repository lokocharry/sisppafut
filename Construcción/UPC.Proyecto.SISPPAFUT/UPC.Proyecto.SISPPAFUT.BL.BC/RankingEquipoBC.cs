using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

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
            LogBC objLogBC;

            try
            {
                objRankingEquipoDALC = new RankingEquipoDALC();
                int result = objRankingEquipoDALC.insertar_ranking(objRankingEquipoBE);

                if (result != 0)
                {
                    //--Se registra el log
                    objLogBC = new LogBC();
                    LogBE objLogBE = new LogBE();

                    objLogBE.CodOperacion = result;
                    objLogBE.Fecha = DateTime.Now;
                    IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                    objLogBE.IP = entry.AddressList[0].ToString();
                    objLogBE.Razon = "Se registró un ranking para el equipo con id: "+objRankingEquipoBE.CodigoEquipo.ToString();
                    objLogBE.Tabla = "RankingEquipo";
                    objLogBE.Usuario = Propiedades.userLogged;

                    objLogBC.RegistrarLog(objLogBE);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<RankingBE> obtener_ranking(int anio, int mes, int codigoPais)
        {
            RankingEquipoDALC objRankingEquipoDALC;
            LogBC objLogBC;
            try
            {
                objRankingEquipoDALC = new RankingEquipoDALC();
                List<RankingBE> lst_ranking = new List<RankingBE>();
                lst_ranking =  objRankingEquipoDALC.obtener_ranking(anio, mes, codigoPais);

                //--Se registra el log
                objLogBC = new LogBC();
                LogBE objLogBE = new LogBE();

                objLogBE.CodOperacion = codigoPais;
                objLogBE.Fecha = DateTime.Now;
                IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                objLogBE.IP = entry.AddressList[0].ToString();
                objLogBE.Razon = "Se consultó el ranking de un país en el año : "+anio.ToString() +" y mes: "+mes.ToString();
                objLogBE.Tabla = "RankingEquipo";
                objLogBE.Usuario = Propiedades.userLogged;

                objLogBC.RegistrarLog(objLogBE);

                return lst_ranking;
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
                LogBC objLogBC;
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
                        {
                            int posicion = cDto.Posicion;

                            //--Se registra el log
                            objLogBC = new LogBC();
                            LogBE objLogBE = new LogBE();

                            objLogBE.CodOperacion = 0;
                            objLogBE.Fecha = DateTime.Now;
                            IPHostEntry entry = Dns.GetHostByName(Dns.GetHostName());
                            objLogBE.IP = entry.AddressList[0].ToString();
                            objLogBE.Razon = "Se consultó la posición en el ranking de: " + cDto.NombreEquipo + " para el año: " + anio.ToString() + " y mes : " + _mes.ToString();
                            objLogBE.Tabla = "RankingEquipo";
                            objLogBE.Usuario = Propiedades.userLogged;

                            objLogBC.RegistrarLog(objLogBE);

                            return posicion;
                        }
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
