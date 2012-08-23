using System;
using System.Collections.Generic;
using System.Text;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.DL.DALC;

namespace UPC.Proyecto.SISPPAFUT.BL.BC
{
    public class TablaPosicionesBC
    {
        List<TablaPosicionesBE> lstTabla;

        public List<TablaPosicionesBE> tablaPosicion
        {
            get { return lstTabla; }
            set { lstTabla = value; }
        }

        public void InsertarEquiposTablaPosiciones(int codLiga, List<LigaEquipoBE> lstLigaEquipos)
        {
            TablaPosicionesDALC objDALC = new TablaPosicionesDALC();
            TablaPosicionesBE objBE;

            foreach (LigaEquipoBE cDto in lstLigaEquipos)
            {
                objBE = new TablaPosicionesBE();
                objBE.codEquipo = cDto.CodigoEquipo;
                objBE.codLiga = codLiga;
                objBE.derrotasLocal = 0;
                objBE.derrotasVisita = 0;
                objBE.empatesLocal = 0;
                objBE.empatesVisita = 0;
                objBE.golesAnotadosLocal = 0;
                objBE.golesAnotadosVisita = 0;
                objBE.golesEncajadosLocal = 0;
                objBE.golesEncajadosVisita = 0;
                objBE.partidosJugadosLocal = 0;
                objBE.partidosJugadosVisita = 0;
                objBE.puntosLocal = 0;
                objBE.puntosVisita = 0;
                objBE.victoriasLocal = 0;
                objBE.victoriasVisita = 0;

                int iCod = objDALC.insertar_Tabla(objBE);
            }
        }

        public void ObtenerTablaPosicionLiga(int codLiga)
        {
            try
            {
                TablaPosicionesDALC objDALC = new TablaPosicionesDALC();
                lstTabla = objDALC.ObtenerTablaLiga(codLiga);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int ConsultarPosicionEquipoTabla(int codEquipo)
        {
            int pos = 0;

            try
            {

                if (tablaPosicion.Count > 0)
                {
                    foreach (TablaPosicionesBE cDto in tablaPosicion)
                    {
                        if (codEquipo == cDto.codEquipo)
                        {
                            pos =  cDto.posicion;
                            break;
                        }
                    }
                }

                return pos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
