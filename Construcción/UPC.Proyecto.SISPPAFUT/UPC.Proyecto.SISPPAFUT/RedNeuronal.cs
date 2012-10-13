using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Windows.Forms;
using UPC.Proyecto.SISPPAFUT.BL.BE;

using ikvm.awt;
namespace UPC.Proyecto.SISPPAFUT
{
    public sealed class RedNeuronal
    {
        public static void funciona()
        { }
        private Double[,] MatrizPesos;
        private Double[] MatrizProblema;
        private Double[,] MatrizResultado;

        /* MÉTODO A EMPLEAR : Red Neuronal Artificial
         * Se emplearán variables de decisión con pesos asociados para cada variable de entrada.
         * Para la fase de prueba se emplearán los datos obtenidos de 'La Liga BBVA 2010/2011'.
         * Para la fase de predicción se emplearán los datos obtenidos de 'La Liga BBVA 2011/2012'.
         * Finalmente, se podrán poner a prueba con los partidos de la 'La Liga BBVA 2012/2013'.
         */

        //-------------------- B-A-S-E- D-E- C-O-N-O-C-I-M-I-E-N-T-O-
        private static Boolean LigaLocal_altaTabla(int qEquipos, int pos)
        {
            if (1 - Convert.ToDouble(pos / qEquipos) >= 0.75)
                return true;
            else
                return false;
        }

        private static Boolean LigaLocal_mediaTabla(int qEquipos, int pos)
        {
            if ((1 - Convert.ToDouble(pos / qEquipos) >= 0.30) && (1 - Convert.ToDouble(pos / qEquipos) < 0.75))
                return true;
            else
                return false;
        }

        private static Boolean LigaLocal_bajaTabla(int qEquipos, int pos)
        {
            if (1 - Convert.ToDouble(pos / qEquipos) < 0.30)
                return true;
            else
                return false;
        }

        private static Boolean QPtsObt_0_5(int pts)
        {
            if (pts <= 5)
                return true;
            else
                return false;
        }

        private static Boolean QPtsObt_6_9(int pts)
        {
            if (pts >= 6 && pts <= 9)
                return true;
            else
                return false;
        }

        private static Boolean QPtsObt_10_15(int pts)
        {
            if (pts >= 10 && pts <= 15)
                return true;
            else
                return false;
        }

        private static Boolean Localidad(String equipoLocal, String equipoVisita)
        {
            if (equipoLocal != null && equipoVisita == null)
            {
                return true;
            }
            else
                return false;
        }

        private static Boolean PosRankMund_1_99(int posRanking)
        {
            if (posRanking >= 1 && posRanking <= 99)
                return true;
            else
                return false;
        }

        private static Boolean PosRankMund_100_199(int posRanking)
        {
            if (posRanking >= 100 && posRanking <= 199)
                return true;
            else
                return false;
        }

        private static Boolean PosRankMund_200_299(int posRanking)
        {
            if (posRanking >= 200 && posRanking <= 299)
                return true;
            else
                return false;
        }

        private static Boolean PosRankMund_300_399(int posRanking)
        {
            if (posRanking >= 300 && posRanking <= 399)
                return true;
            else
                return false;
        }

        private static Boolean PosRankMund_400_499(int posRanking)
        {
            if (posRanking >= 400 && posRanking <= 499)
                return true;
            else
                return false;
        }

        private static Boolean Goleador_estadoSuspencion(Boolean estado)//String estado)
        {
            if(estado)//estado == "NO SUSPENDIDO")
                return true;
            else
                return false;
        }

        private static Boolean Arquero_estadoSuspencion(Boolean estado)//String estado)
        {
            if (estado)//estado == "NO SUSPENDIDO")
                return true;
            else
                return false;
        }        

        private static Boolean Expulsiones_0(int expulsiones)
        {
            if (expulsiones == 0)
                return true;
            else
                return false;
        }

        private static Boolean Expulsiones_1(int expulsiones)
        {
            if (expulsiones == 1)
                return true;
            else
                return false;
        }

        private static Boolean Expulsiones_2(int expulsiones)
        {
            if (expulsiones == 2)
                return true;
            else
                return false;
        }

        private static Boolean Expulsiones_3(int expulsiones)
        {
            if (expulsiones >= 3)
                return true;
            else
                return false;
        }

        private static Boolean Suspendidos_0(int suspendidos)
        {
            if (suspendidos == 0)
                return true;
            else
                return false;
        }

        private static Boolean Suspendidos_1(int suspendidos)
        {
            if (suspendidos == 1)
                return true;
            else
                return false;
        }

        private static Boolean Suspendidos_2(int suspendidos)
        {
            if (suspendidos == 2)
                return true;
            else
                return false;
        }

        private static Boolean Suspendidos_3(int suspendidos)
        {
            if (suspendidos >= 3)
                return true;
            else
                return false;
        }

        private static Boolean GolesAnotados_0_3(int GA)
        {
            if (GA >= 0 && GA <= 3)
                return true;
            else
                return false;
        }

        private static Boolean GolesAnotados_4_8(int GA)
        {
            if (GA >= 4 && GA <= 8)
                return true;
            else
                return false;
        }

        private static Boolean GolesAnotados_9_12(int GA)
        {
            if (GA >= 9 && GA <= 12)
                return true;
            else
                return false;
        }

        private static Boolean GolesAnotados_13_16(int GA)
        {
            if (GA >= 13 && GA <= 16)
                return true;
            else
                return false;
        }

        private static Boolean GolesAnotados_17_23(int GA)
        {
            if (GA >= 17 && GA <= 23)
                return true;
            else
                return false;
        }

        private static Boolean GolesAnotados_24_28(int GA)
        {
            if (GA >= 24 && GA <= 28)
                return true;
            else
                return false;
        }

        private static Boolean GolesEncajados_0_2(int GC)
        {
            if (GC >= 0 && GC <= 2)
                return true;
            else
                return false;
        }

        private static Boolean GolesEncajados_3_6(int GC)
        {
            if (GC >= 3 && GC <= 6)
                return true;
            else
                return false;
        }

        private static Boolean GolesEncajados_7_10(int GC)
        {
            if (GC >= 7 && GC <= 10)
                return true;
            else
                return false;
        }

        private static Boolean GolesEncajados_11_16(int GC)
        {
            if (GC >= 11 && GC <= 16)
                return true;
            else
                return false;
        }

        private static Boolean GolesEncajados_17_25(int GC)
        {
            if (GC >= 17 && GC <= 25)
                return true;
            else
                return false;
        }

        private static Boolean PromedioEdad_0(Decimal promEdad)
        {
            if (Convert.ToDouble(promEdad) < 23.5)
                return true;
            else
                return false;
        }

        private static Boolean PromedioEdad_1(Decimal promEdad)
        {
            if (Convert.ToDouble(promEdad) >= 23.5 && Convert.ToDouble(promEdad) < 24.5)
                return true;
            else
                return false;
        }

        private static Boolean PromedioEdad_2(Decimal promEdad)
        {
            if (Convert.ToDouble(promEdad) >= 24.5 && Convert.ToDouble(promEdad) < 25.5)
                return true;
            else
                return false;
        }

        private static Boolean PromedioEdad_3(Decimal promEdad)
        {
            if (Convert.ToDouble(promEdad) >= 25.5 && Convert.ToDouble(promEdad) < 26.5)
                return true;
            else
                return false;
        }

        private static Boolean PromedioEdad_4(Decimal promEdad)
        {
            if (Convert.ToDouble(promEdad) >= 26.5 && Convert.ToDouble(promEdad) < 27.5)
                return true;
            else
                return false;
        }

        private static Boolean PromedioEdad_5(Decimal promEdad)
        {
            if (Convert.ToDouble(promEdad) > 27.5)
                return true;
            else
                return false;
        }

        private static Boolean QPartidosMes_0_4(int PJ)
        {
            if (PJ >= 0 && PJ <= 4)
                return true;
            else
                return false;
        }

        private static Boolean QPartidosMes_5_7(int PJ)
        {
            if (PJ >= 5 && PJ <= 7)
                return true;
            else
                return false;
        }

        private static Boolean QPartidosMes_8_10(int PJ)
        {
            if (PJ >= 8 && PJ <= 10)
                return true;
            else
                return false;
        }
                
        //-------------------- R-E-S-O-L-V-E-R  P-R-O-B-L-E-M-A-        
        public Double[,] ResolverCaso(DatosPartidoConsolidado objCaso, int qEqRank)
        {
            //-- Se crea una matriz
            MatrizPesos = new Double[85, 3];
            //-- Se instancia la matriz con los pesos correspondientes
            LlenarMatriz(MatrizPesos);
            //-- Se crea una matriz para el caso a resolver
            MatrizProblema = new Double[85];
            //-- Se instancia la matriz con los valores del caso a resolver
            LlenarMatrizProblema(MatrizProblema, qEqRank, objCaso);
            MatrizResultado = new Double[85, 3];
            LlenarMatrizResultado(MatrizResultado, MatrizPesos, MatrizProblema);
            /*
             * dRLocal.Text = (MatrizResultado[0, 0] / MatrizPesos[0, 0] * 100).ToString();
             * dREmpate.Text = (MatrizResultado[0, 1] / MatrizPesos[0, 1] * 100).ToString();
             * dRVisita.Text = (MatrizResultado[0, 2] / MatrizPesos[0, 2] * 100).ToString();
             */
            return MatrizResultado;
            
            //GuardarHistorial(objEquipoLocal.Nombre, objEquipoVisita.Nombre, Convert.ToDouble(dRLocal.Text), Convert.ToDouble(dREmpate.Text), Convert.ToDouble(dRVisita.Text));
        }
                 
        //-- La siguiente función me debería permitir reajustar los pesos mediante el entrenamiento
        private static void LlenarMatriz(Double[,] matrizPesos)
        {
            //-- UMBRAL
            matrizPesos[0, 0] = 172; matrizPesos[0, 1] = 79; matrizPesos[0, 2] = 105;
            //-- PESOS DE LAS CARACTERÍSTICAS POR CADA PATRÓN
            matrizPesos[1, 0] = 10; matrizPesos[1, 1] = 3; matrizPesos[1, 2] = 2;
            matrizPesos[2, 0] = 2; matrizPesos[2, 1] = 3; matrizPesos[2, 2] = 10;
            matrizPesos[3, 0] = 6; matrizPesos[3, 1] = 3; matrizPesos[3, 2] = 3;
            matrizPesos[4, 0] = 3; matrizPesos[4, 1] = 3; matrizPesos[4, 2] = 6;
            matrizPesos[5, 0] = 2; matrizPesos[5, 1] = 2; matrizPesos[5, 2] = 4;
            matrizPesos[6, 0] = 4; matrizPesos[6, 1] = 2; matrizPesos[6, 2] = 2;
            matrizPesos[7, 0] = 7; matrizPesos[7, 1] = 3; matrizPesos[7, 2] = 5;
            matrizPesos[8, 0] = 5; matrizPesos[8, 1] = 3; matrizPesos[8, 2] = 0;
            matrizPesos[9, 0] = 8; matrizPesos[9, 1] = 4; matrizPesos[9, 2] = 2;
            matrizPesos[10, 0] = 3; matrizPesos[10, 1] = 2; matrizPesos[10, 2] = 4;
            matrizPesos[11, 0] = 0; matrizPesos[11, 1] = 3; matrizPesos[11, 2] = 5;
            matrizPesos[12, 0] = 2; matrizPesos[12, 1] = 4; matrizPesos[12, 2] = 8;
            matrizPesos[13, 0] = 10; matrizPesos[13, 1] = 2; matrizPesos[13, 2] = 0;
            matrizPesos[14, 0] = 0; matrizPesos[14, 1] = 2; matrizPesos[14, 2] = 3;
            matrizPesos[15, 0] = 10; matrizPesos[15, 1] = 2; matrizPesos[15, 2] = 0;
            matrizPesos[16, 0] = 8; matrizPesos[16, 1] = 4; matrizPesos[16, 2] = 1;
            matrizPesos[17, 0] = 5; matrizPesos[17, 1] = 3; matrizPesos[17, 2] = 0;
            matrizPesos[18, 0] = 0; matrizPesos[18, 1] = 2; matrizPesos[18, 2] = 5;
            matrizPesos[19, 0] = 2; matrizPesos[19, 1] = 3; matrizPesos[19, 2] = 4;
            matrizPesos[20, 0] = 2; matrizPesos[20, 1] = 3; matrizPesos[20, 2] = 4;
            matrizPesos[21, 0] = 1; matrizPesos[21, 1] = 1; matrizPesos[21, 2] = 0;
            matrizPesos[22, 0] = 9; matrizPesos[22, 1] = 9; matrizPesos[22, 2] = 7;
            matrizPesos[23, 0] = 5; matrizPesos[23, 1] = 3; matrizPesos[23, 2] = 3;
            matrizPesos[24, 0] = 7; matrizPesos[24, 1] = 2; matrizPesos[24, 2] = 4;
            matrizPesos[25, 0] = 7; matrizPesos[25, 1] = 1; matrizPesos[25, 2] = 3;
            matrizPesos[26, 0] = 4; matrizPesos[26, 1] = 1; matrizPesos[26, 2] = 2;
            matrizPesos[27, 0] = 10; matrizPesos[27, 1] = 1; matrizPesos[27, 2] = 1;
            matrizPesos[28, 0] = 0; matrizPesos[28, 1] = 1; matrizPesos[28, 2] = 1;
            matrizPesos[29, 0] = 7; matrizPesos[29, 1] = 4; matrizPesos[29, 2] = 2;
            matrizPesos[30, 0] = 9; matrizPesos[30, 1] = 3; matrizPesos[30, 2] = 2;
            matrizPesos[31, 0] = 6; matrizPesos[31, 1] = 3; matrizPesos[31, 2] = 3;
            matrizPesos[32, 0] = 4; matrizPesos[32, 1] = 1; matrizPesos[32, 2] = 2;
            matrizPesos[33, 0] = 5; matrizPesos[33, 1] = 1; matrizPesos[33, 2] = 5;
            matrizPesos[34, 0] = 1; matrizPesos[34, 1] = 2; matrizPesos[34, 2] = 5;
            matrizPesos[35, 0] = 10; matrizPesos[35, 1] = 2; matrizPesos[35, 2] = 3;
            matrizPesos[36, 0] = 1; matrizPesos[36, 1] = 0; matrizPesos[36, 2] = 2;
            matrizPesos[37, 0] = 1; matrizPesos[37, 1] = 1; matrizPesos[37, 2] = 2;
            matrizPesos[38, 0] = 8; matrizPesos[38, 1] = 6; matrizPesos[38, 2] = 6;
            matrizPesos[39, 0] = 3; matrizPesos[39, 1] = 2; matrizPesos[39, 2] = 0;
            matrizPesos[40, 0] = 6; matrizPesos[40, 1] = 8; matrizPesos[40, 2] = 7;
            matrizPesos[41, 0] = 3; matrizPesos[41, 1] = 1; matrizPesos[41, 2] = 1;
            matrizPesos[42, 0] = 6; matrizPesos[42, 1] = 2; matrizPesos[42, 2] = 2;
            matrizPesos[43, 0] = 0; matrizPesos[43, 1] = 2; matrizPesos[43, 2] = 3;
            matrizPesos[44, 0] = 0; matrizPesos[44, 1] = 2; matrizPesos[44, 2] = 3;
            matrizPesos[45, 0] = 10; matrizPesos[45, 1] = 4; matrizPesos[45, 2] = 5;
            matrizPesos[46, 0] = 9; matrizPesos[46, 1] = 2; matrizPesos[46, 2] = 3;
            matrizPesos[47, 0] = 1; matrizPesos[47, 1] = 1; matrizPesos[47, 2] = 1;
            matrizPesos[48, 0] = 10; matrizPesos[48, 1] = 4; matrizPesos[48, 2] = 5;
            matrizPesos[49, 0] = 5; matrizPesos[49, 1] = 2; matrizPesos[49, 2] = 2;
            matrizPesos[50, 0] = 1; matrizPesos[50, 1] = 1; matrizPesos[50, 2] = 1;
            matrizPesos[51, 0] = 4; matrizPesos[51, 1] = 5; matrizPesos[51, 2] = 2;
            matrizPesos[52, 0] = 8; matrizPesos[52, 1] = 3; matrizPesos[52, 2] = 4;
            matrizPesos[53, 0] = 6; matrizPesos[53, 1] = 2; matrizPesos[53, 2] = 4;
            matrizPesos[54, 0] = 8; matrizPesos[54, 1] = 1; matrizPesos[54, 2] = 2;
            matrizPesos[55, 0] = 4; matrizPesos[55, 1] = 1; matrizPesos[55, 2] = 2;
            matrizPesos[56, 0] = 4; matrizPesos[56, 1] = 1; matrizPesos[56, 2] = 2;
            matrizPesos[57, 0] = 3; matrizPesos[57, 1] = 1; matrizPesos[57, 2] = 1;
            matrizPesos[58, 0] = 10; matrizPesos[58, 1] = 4; matrizPesos[58, 2] = 3;
            matrizPesos[59, 0] = 6; matrizPesos[59, 1] = 2; matrizPesos[59, 2] = 6;
            matrizPesos[60, 0] = 2; matrizPesos[60, 1] = 1; matrizPesos[60, 2] = 3;
            matrizPesos[61, 0] = 2; matrizPesos[61, 1] = 4; matrizPesos[61, 2] = 10;
            matrizPesos[62, 0] = 2; matrizPesos[62, 1] = 4; matrizPesos[62, 2] = 10;
            matrizPesos[63, 0] = 12; matrizPesos[63, 1] = 1; matrizPesos[63, 2] = 2;
            matrizPesos[64, 0] = 4; matrizPesos[64, 1] = 1; matrizPesos[64, 2] = 1;
            matrizPesos[65, 0] = 10; matrizPesos[65, 1] = 4; matrizPesos[65, 2] = 5;
            matrizPesos[66, 0] = 6; matrizPesos[66, 1] = 4; matrizPesos[66, 2] = 4;
            matrizPesos[67, 0] = 1; matrizPesos[67, 1] = 1; matrizPesos[67, 2] = 0;
            matrizPesos[68, 0] = 9; matrizPesos[68, 1] = 5; matrizPesos[68, 2] = 9;
            matrizPesos[69, 0] = 11; matrizPesos[69, 1] = 4; matrizPesos[69, 2] = 6;
            matrizPesos[70, 0] = 9; matrizPesos[70, 1] = 5; matrizPesos[70, 2] = 4;
            matrizPesos[71, 0] = 6; matrizPesos[71, 1] = 2; matrizPesos[71, 2] = 1;
            matrizPesos[72, 0] = 0; matrizPesos[72, 1] = 1; matrizPesos[72, 2] = 1;
            matrizPesos[73, 0] = 6; matrizPesos[73, 1] = 3; matrizPesos[73, 2] = 3;
            matrizPesos[74, 0] = 7; matrizPesos[74, 1] = 2; matrizPesos[74, 2] = 3;
            matrizPesos[75, 0] = 6; matrizPesos[75, 1] = 2; matrizPesos[75, 2] = 2;
            matrizPesos[76, 0] = 7; matrizPesos[76, 1] = 3; matrizPesos[76, 2] = 2;
            matrizPesos[77, 0] = 6; matrizPesos[77, 1] = 2; matrizPesos[77, 2] = 3;
            matrizPesos[78, 0] = 5; matrizPesos[78, 1] = 3; matrizPesos[78, 2] = 7;
            matrizPesos[79, 0] = 4; matrizPesos[79, 1] = 1; matrizPesos[79, 2] = 2;
            matrizPesos[80, 0] = 10; matrizPesos[80, 1] = 3; matrizPesos[80, 2] = 4;
            matrizPesos[81, 0] = 6; matrizPesos[81, 1] = 2; matrizPesos[81, 2] = 3;
            matrizPesos[82, 0] = 5; matrizPesos[82, 1] = 3; matrizPesos[82, 2] = 7;
            matrizPesos[83, 0] = 4; matrizPesos[83, 1] = 1; matrizPesos[83, 2] = 2;
            matrizPesos[84, 0] = 10; matrizPesos[84, 1] = 3; matrizPesos[84, 2] = 4;
        }
        
        private static void LlenarMatrizProblema(Double[] matrizProblema, int qEqRank, DatosPartidoConsolidado objCaso)
        {
            if (LigaLocal_altaTabla(objCaso.C_QEquipos, objCaso.C_local_posliga))
                matrizProblema[1] = 1;
            else
                matrizProblema[1] = 0;
            if (LigaLocal_mediaTabla(objCaso.C_QEquipos, objCaso.C_local_posliga))
                matrizProblema[2] = 1;
            else
                matrizProblema[2] = 0;
            if (LigaLocal_bajaTabla(objCaso.C_QEquipos, objCaso.C_local_posliga))
                matrizProblema[3] = 1;
            else
                matrizProblema[3] = 0;
            if (LigaLocal_altaTabla(objCaso.C_QEquipos, objCaso.C_Visita_PosLiga))
                matrizProblema[4] = 1;
            else
                matrizProblema[4] = 0;
            if (LigaLocal_mediaTabla(objCaso.C_QEquipos, objCaso.C_Visita_PosLiga))
                matrizProblema[5] = 1;
            else
                matrizProblema[5] = 0;
            if (LigaLocal_bajaTabla(objCaso.C_QEquipos, objCaso.C_Visita_PosLiga))
                matrizProblema[6] = 1;
            else
                matrizProblema[6] = 0;
            if (QPtsObt_0_5(objCaso.C_Local_QPtsObt))
                matrizProblema[7] = 1;
            else
                matrizProblema[7] = 0;
            if (QPtsObt_6_9(objCaso.C_Local_QPtsObt))
                matrizProblema[8] = 1;
            else
                matrizProblema[8] = 0;
            if (QPtsObt_10_15(objCaso.C_Local_QPtsObt))
                matrizProblema[9] = 1;
            else
                matrizProblema[9] = 0;
            if (QPtsObt_0_5(objCaso.C_Visita_QPtsObt))
                matrizProblema[10] = 1;
            else
                matrizProblema[10] = 0;
            if (QPtsObt_6_9(objCaso.C_Visita_QPtsObt))
                matrizProblema[11] = 1;
            else
                matrizProblema[11] = 0;
            if (QPtsObt_10_15(objCaso.C_Visita_QPtsObt))
                matrizProblema[12] = 1;
            else
                matrizProblema[12] = 0;
            if (Localidad("Local", null))
                matrizProblema[13] = 1;
            else
                matrizProblema[13] = 0;
            if (!Localidad(null, "Visita"))
                matrizProblema[14] = 1;
            else
                matrizProblema[14] = 0;
            if (PosRankMund_1_99(objCaso.C_Local_PosRankMund))
                matrizProblema[15] = 1;
            else
                matrizProblema[15] = 0;
            if (PosRankMund_100_199(objCaso.C_Local_PosRankMund))
                matrizProblema[16] = 1;
            else
                matrizProblema[16] = 0;
            if (PosRankMund_200_299(objCaso.C_Local_PosRankMund))
                matrizProblema[17] = 1;
            else
                matrizProblema[17] = 0;
            if (PosRankMund_300_399(objCaso.C_Local_PosRankMund))
                matrizProblema[18] = 1;
            else
                matrizProblema[18] = 0;
            if (PosRankMund_400_499(objCaso.C_Local_PosRankMund))
                matrizProblema[19] = 1;
            else
                matrizProblema[19] = 0;
            if (PosRankMund_1_99(objCaso.C_Visita_PosRankMund))
                matrizProblema[20] = 1;
            else
                matrizProblema[20] = 0;
            if (PosRankMund_100_199(objCaso.C_Visita_PosRankMund))
                matrizProblema[21] = 1;
            else
                matrizProblema[21] = 0;
            if (PosRankMund_200_299(objCaso.C_Visita_PosRankMund))
                matrizProblema[22] = 1;
            else
                matrizProblema[22] = 0;
            if (PosRankMund_300_399(objCaso.C_Visita_PosRankMund))
                matrizProblema[23] = 1;
            else
                matrizProblema[23] = 0;
            if (PosRankMund_400_499(objCaso.C_Visita_PosRankMund))
                matrizProblema[24] = 1;
            else
                matrizProblema[24] = 0;
            if (Goleador_estadoSuspencion(objCaso.C_Local_GoleadorEsta))
                matrizProblema[25] = 1;
            else
                matrizProblema[25] = 0;
            if (Goleador_estadoSuspencion(objCaso.C_Visita_GoleadorEsta))
                matrizProblema[26] = 1;
            else
                matrizProblema[26] = 0;
            if (Arquero_estadoSuspencion(objCaso.C_Local_ArqueroEsta))
                matrizProblema[27] = 1;
            else
                matrizProblema[27] = 0;
            if (Arquero_estadoSuspencion(objCaso.C_Visita_ArqueroEsta))
                matrizProblema[28] = 1;
            else
                matrizProblema[28] = 0;
            if (Expulsiones_0(objCaso.C_Local_QExpulsados))
                matrizProblema[29] = 1;
            else
                matrizProblema[29] = 0;
            if (Expulsiones_1(objCaso.C_Local_QExpulsados))
                matrizProblema[30] = 1;
            else
                matrizProblema[30] = 0;
            if (Expulsiones_2(objCaso.C_Local_QExpulsados))
                matrizProblema[31] = 1;
            else
                matrizProblema[31] = 0;
            if (Expulsiones_3(objCaso.C_Local_QExpulsados))
                matrizProblema[32] = 1;
            else
                matrizProblema[32] = 0;
            if (Expulsiones_0(objCaso.C_Visita_QExpulsados))
                matrizProblema[33] = 1;
            else
                matrizProblema[33] = 0;
            if (Expulsiones_1(objCaso.C_Visita_QExpulsados))
                matrizProblema[34] = 1;
            else
                matrizProblema[34] = 0;
            if (Expulsiones_2(objCaso.C_Visita_QExpulsados))
                matrizProblema[35] = 1;
            else
                matrizProblema[35] = 0;
            if (Expulsiones_3(objCaso.C_Visita_QExpulsados))
                matrizProblema[36] = 1;
            else
                matrizProblema[36] = 0;
            if (Suspendidos_0(objCaso.C_Local_QSuspendidos))
                matrizProblema[37] = 1;
            else
                matrizProblema[37] = 0;
            if (Suspendidos_1(objCaso.C_Local_QSuspendidos))
                matrizProblema[38] = 1;
            else
                matrizProblema[38] = 0;
            if (Suspendidos_2(objCaso.C_Local_QSuspendidos))
                matrizProblema[39] = 1;
            else
                matrizProblema[39] = 0;
            if (Suspendidos_3(objCaso.C_Local_QSuspendidos))
                matrizProblema[40] = 1;
            else
                matrizProblema[40] = 0;
            if (Suspendidos_0(objCaso.C_Visita_QSuspendidos))
                matrizProblema[41] = 1;
            else
                matrizProblema[41] = 0;
            if (Suspendidos_1(objCaso.C_Visita_QSuspendidos))
                matrizProblema[42] = 1;
            else
                matrizProblema[42] = 0;
            if (Suspendidos_2(objCaso.C_Visita_QSuspendidos))
                matrizProblema[43] = 1;
            else
                matrizProblema[43] = 0;
            if (Suspendidos_3(objCaso.C_Visita_QSuspendidos))
                matrizProblema[44] = 1;
            else
                matrizProblema[44] = 0;
            if (GolesAnotados_0_3(objCaso.C_Local_GolesAnotados))
                matrizProblema[45] = 1;
            else
                matrizProblema[45] = 0;
            if (GolesAnotados_4_8(objCaso.C_Local_GolesAnotados))
                matrizProblema[46] = 1;
            else
                matrizProblema[46] = 0;
            if (GolesAnotados_9_12(objCaso.C_Local_GolesAnotados))
                matrizProblema[47] = 1;
            else
                matrizProblema[47] = 0;
            if (GolesAnotados_13_16(objCaso.C_Local_GolesAnotados))
                matrizProblema[48] = 1;
            else
                matrizProblema[48] = 0;
            if (GolesAnotados_17_23(objCaso.C_Local_GolesAnotados))
                matrizProblema[49] = 1;
            else
                matrizProblema[49] = 0;
            if (GolesAnotados_24_28(objCaso.C_Local_GolesAnotados))
                matrizProblema[50] = 1;
            else
                matrizProblema[50] = 0;
            if (GolesAnotados_0_3(objCaso.C_Visita_GolesAnotados))
                matrizProblema[51] = 1;
            else
                matrizProblema[51] = 0;
            if (GolesAnotados_4_8(objCaso.C_Visita_GolesAnotados))
                matrizProblema[52] = 1;
            else
                matrizProblema[52] = 0;
            if (GolesAnotados_9_12(objCaso.C_Visita_GolesAnotados))
                matrizProblema[53] = 1;
            else
                matrizProblema[53] = 0;
            if (GolesAnotados_13_16(objCaso.C_Visita_GolesAnotados))
                matrizProblema[54] = 1;
            else
                matrizProblema[54] = 0;
            if (GolesAnotados_17_23(objCaso.C_Visita_GolesAnotados))
                matrizProblema[55] = 1;
            else
                matrizProblema[55] = 0;
            if (GolesAnotados_24_28(objCaso.C_Visita_GolesAnotados))
                matrizProblema[56] = 1;
            else
                matrizProblema[56] = 0;
            if (GolesEncajados_0_2(objCaso.C_Local_GolesEncajados))
                matrizProblema[57] = 1;
            else
                matrizProblema[57] = 0;
            if (GolesEncajados_3_6(objCaso.C_Local_GolesEncajados))
                matrizProblema[58] = 1;
            else
                matrizProblema[58] = 0;
            if (GolesEncajados_7_10(objCaso.C_Local_GolesEncajados))
                matrizProblema[59] = 1;
            else
                matrizProblema[59] = 0;
            if (GolesEncajados_11_16(objCaso.C_Local_GolesEncajados))
                matrizProblema[60] = 1;
            else
                matrizProblema[60] = 0;
            if (GolesEncajados_17_25(objCaso.C_Local_GolesEncajados))
                matrizProblema[61] = 1;
            else
                matrizProblema[61] = 0;
            if (GolesEncajados_0_2(objCaso.C_Visita_GolesEncajados))
                matrizProblema[62] = 1;
            else
                matrizProblema[62] = 0;
            if (GolesEncajados_3_6(objCaso.C_Visita_GolesEncajados))
                matrizProblema[63] = 1;
            else
                matrizProblema[63] = 0;
            if (GolesEncajados_7_10(objCaso.C_Visita_GolesEncajados))
                matrizProblema[64] = 1;
            else
                matrizProblema[64] = 0;
            if (GolesEncajados_11_16(objCaso.C_Visita_GolesEncajados))
                matrizProblema[65] = 1;
            else
                matrizProblema[65] = 0;
            if (GolesEncajados_17_25(objCaso.C_Visita_GolesEncajados))
                matrizProblema[66] = 1;
            else
                matrizProblema[66] = 0;
            if (QPartidosMes_0_4(objCaso.C_Local_QPartidosMes))
                matrizProblema[67] = 1;
            else
                matrizProblema[67] = 0;
            if (QPartidosMes_5_7(objCaso.C_Local_QPartidosMes))
                matrizProblema[68] = 1;
            else
                matrizProblema[68] = 0;
            if (QPartidosMes_8_10(objCaso.C_Local_QPartidosMes))
                matrizProblema[69] = 1;
            else
                matrizProblema[69] = 0;
            if (QPartidosMes_0_4(objCaso.C_Visita_QPartidosMes))
                matrizProblema[70] = 1;
            else
                matrizProblema[70] = 0;
            if (QPartidosMes_5_7(objCaso.C_Visita_QPartidosMes))
                matrizProblema[71] = 1;
            else
                matrizProblema[71] = 0;
            if (QPartidosMes_8_10(objCaso.C_Visita_QPartidosMes))
                matrizProblema[72] = 1;
            else
                matrizProblema[72] = 0;
            if (PromedioEdad_0(objCaso.C_Local_PromEdadEqTitu))
                matrizProblema[73] = 1;
            else
                matrizProblema[73] = 0;
            if (PromedioEdad_1(objCaso.C_Local_PromEdadEqTitu))
                matrizProblema[74] = 1;
            else
                matrizProblema[74] = 0;
            if (PromedioEdad_2(objCaso.C_Local_PromEdadEqTitu))
                matrizProblema[75] = 1;
            else
                matrizProblema[75] = 0;
            if (PromedioEdad_3(objCaso.C_Local_PromEdadEqTitu))
                matrizProblema[76] = 1;
            else
                matrizProblema[76] = 0;
            if (PromedioEdad_4(objCaso.C_Local_PromEdadEqTitu))
                matrizProblema[77] = 1;
            else
                matrizProblema[77] = 0;
            if (PromedioEdad_5(objCaso.C_Local_PromEdadEqTitu))
                matrizProblema[78] = 1;
            else
                matrizProblema[78] = 0;
            if (PromedioEdad_0(objCaso.C_Visita_PromEdadEqTitu))
                matrizProblema[79] = 1;
            else
                matrizProblema[79] = 0;
            if (PromedioEdad_1(objCaso.C_Visita_PromEdadEqTitu))
                matrizProblema[80] = 1;
            else
                matrizProblema[80] = 0;
            if (PromedioEdad_2(objCaso.C_Visita_PromEdadEqTitu))
                matrizProblema[81] = 1;
            else
                matrizProblema[81] = 0;
            if (PromedioEdad_3(objCaso.C_Visita_PromEdadEqTitu))
                matrizProblema[82] = 1;
            else
                matrizProblema[82] = 0;
            if (PromedioEdad_4(objCaso.C_Visita_PromEdadEqTitu))
                matrizProblema[83] = 1;
            else
                matrizProblema[83] = 0;
            if (PromedioEdad_5(objCaso.C_Visita_PromEdadEqTitu))
                matrizProblema[84] = 1;
            else
                matrizProblema[84] = 0;
        }
        
        private static void LlenarMatrizResultado(Double[,] matrizResultado, Double[,] matrizPesos, Double[] matrizProblema)
        {
            for (int i = 0; i <= 2; i++)
                for (int e = 1; e <= 84; e++)
                {
                    matrizResultado[e, i] = matrizPesos[e, i] * matrizProblema[e];
                    matrizResultado[0, i] += matrizResultado[e, i];
                }
        }
        
        public static List<PronosticoBE> Entrenamiento()
        {
            //-- Variable para almacenar los pronósticos
            List<PronosticoBE> lstPronosticos = new List<PronosticoBE>();
            PronosticoBE objPronosticoBE;

            try
            {
                //-- Se abre el fichero que contiene la capa de entrada y saldia y los datos de prueba
                String fic = Application.StartupPath + "\\SISPPAFUT.arff";
                weka.core.Instances data = new weka.core.Instances(new java.io.FileReader(fic));
                //-- Se selecciona las características de la capa de entrada
                data.setClassIndex(data.numAttributes() - 1);
                //-- Se instancia una red neuronal perceptrón multilayer (MLP)
                var red_Perceptron = new weka.classifiers.functions.MultilayerPerceptron();
                //-- Se configura la red neuronal con la configuración deseada
                red_Perceptron.setGUI(false);
                red_Perceptron.setDebug(false);
                red_Perceptron.setAutoBuild(true);
                red_Perceptron.setDecay(false);
                red_Perceptron.setHiddenLayers("12");
                red_Perceptron.setLearningRate(0.05);
                red_Perceptron.setMomentum(0.2);
                red_Perceptron.setNominalToBinaryFilter(true);
                red_Perceptron.setNormalizeAttributes(true);
                red_Perceptron.setNormalizeNumericClass(true);
                red_Perceptron.setReset(true);
                red_Perceptron.setSeed(0);
                red_Perceptron.setTrainingTime(1700);
                red_Perceptron.setValidationSetSize(0);
                red_Perceptron.setValidationThreshold(20);
                //-- Se inicia el proceso de entrenamiento
                int trainSize = 250;//--data.numInstances();
                weka.core.Instances train = new weka.core.Instances(data, 0, trainSize);
                red_Perceptron.buildClassifier(train);
                //-- Se leen los resultados del entrenamiento y se almacenan en la lista de pronósticos
                for (int i = 0; i < trainSize; i++)
                {
                    //-- Se instancia un pronóstico
                    objPronosticoBE = new PronosticoBE();
                    weka.core.Instance currentInst = data.instance(i);
                    double predictedClass = red_Perceptron.classifyInstance(currentInst);
                    double[] resultPredict = red_Perceptron.distributionForInstance(train.instance(i));

                    objPronosticoBE.Pronostico = train.classAttribute().value((int)predictedClass);
                    objPronosticoBE.PorcentajeLocal = Convert.ToDecimal(resultPredict[0]);
                    objPronosticoBE.PorcentajeEmpate = Convert.ToDecimal(resultPredict[1]);
                    objPronosticoBE.PorcentajeVisita = Convert.ToDecimal(resultPredict[2]);
                    //-- Se agrega objeto a la lista
                    lstPronosticos.Add(objPronosticoBE);
                }
                
                return lstPronosticos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
