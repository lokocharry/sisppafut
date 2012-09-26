using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.BL.BC;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class frmModuloEntrenamiento : Form
    {
        //--Variables globales
        List<PartidoBE> listaPartidos;
        List<PartidoJugadoBE> listaPartidoJugadoLocal;
        List<PartidoJugadoBE> listaPartidoJugadoVisita;
        List<LigaBE> lstLigas;
        List<PronosticoBE> lstPronosticos;
        //List<EquipoBE> listaEquipos;
        List<PartidoSinJugarBE> lstPartidosPronosticados;
        List<InstanciaNormalizadaBE> lstInstancias;

        public List<InstanciaNormalizadaBE> LstInstancias
        {
            get { return lstInstancias; }
            set { lstInstancias = value; }
        }

        public List<PartidoSinJugarBE> LstPartidosPronosticados
        {
            get { return lstPartidosPronosticados; }
            set { lstPartidosPronosticados = value; }
        }        
        //-- Lista de Partidos que no se han jugado
        List<PartidoSinJugarBE> lstPartidosSinJugar;

        public List<PartidoSinJugarBE> LstPartidosSinJugar
        {
            get { return lstPartidosSinJugar; }
            set { lstPartidosSinJugar = value; }
        }
        //-- Lista de Partidos que si se han jugado
        List<PartidoSinJugarBE> lstPartidosJugados;

        public List<PartidoSinJugarBE> LstPartidosJugados
        {
            get { return lstPartidosJugados; }
            set { lstPartidosJugados = value; }
        }
        //-- Lista de Partidos con pronósticos
        List<PartidoPronosticadoBE> listaPartidosPronosticados;

        public List<PartidoPronosticadoBE> ListaPartidosPronosticados
        {
            get { return listaPartidosPronosticados; }
            set { listaPartidosPronosticados = value; }
        }
        //-- Lista de Partidos sin pronósticos
        List<PartidoSinJugarBE> lstPartidosSinPronosticos;

        public List<PartidoSinJugarBE> LstPartidosSinPronosticos
        {
            get { return lstPartidosSinPronosticos; }
            set { lstPartidosSinPronosticos = value; }
        }
        SuspensionBC objSuspensionBC;
        LigaBC objLigaBC;

        private List<PartidoSinJugarBE> lstPartidosConResultadoYPronostico;

        public List<PartidoSinJugarBE> LstPartidosConResultadoYPronostico
        {
            get { return lstPartidosConResultadoYPronostico; }
            set { lstPartidosConResultadoYPronostico = value; }
        }

        private List<PartidoSinJugarBE> lstPartidosConResultadoYSinPronostico;

        public List<PartidoSinJugarBE> LstPartidosConResultadoYSinPronostico
        {
            get { return lstPartidosConResultadoYSinPronostico; }
            set { lstPartidosConResultadoYSinPronostico = value; }
        }

        private static frmModuloEntrenamiento frmEntrenamiento = null;
        public static frmModuloEntrenamiento Instance()
        {
            if (frmEntrenamiento == null)
            {
                frmEntrenamiento = new frmModuloEntrenamiento();
            }
            return frmEntrenamiento;
        }

        public frmModuloEntrenamiento()
        {
            InitializeComponent();
        }

        private void frmEntrenarPronosticos_Load(object sender, EventArgs e)
        {
            try
            {
                lstPartidosPronosticados = new List<PartidoSinJugarBE>();
                lstPartidosSinJugar = new List<PartidoSinJugarBE>();
                lstPartidosJugados = new List<PartidoSinJugarBE>();
                listaPartidosPronosticados = new List<PartidoPronosticadoBE>();
                lstPartidosConResultadoYPronostico = new List<PartidoSinJugarBE>();
                lstPartidosConResultadoYSinPronostico = new List<PartidoSinJugarBE>();
                lstInstancias = new List<InstanciaNormalizadaBE>();
                dg_PronosticosConfigurar();
                dg_PronosticosDataBind();
                objLigaBC = new LigaBC();
                lstLigas = objLigaBC.listarLigas();
                
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void dg_PronosticosConfigurar()
        {
            dg_Pronosticos.AllowUserToAddRows = false;
            dg_Pronosticos.AllowUserToDeleteRows = false;

            dg_Pronosticos.AllowUserToResizeColumns = false;
            dg_Pronosticos.AllowUserToResizeRows = false;
            dg_Pronosticos.AllowDrop = false;

            dg_Pronosticos.MultiSelect = false;
            dg_Pronosticos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dg_Pronosticos.ReadOnly = true;
        }

        private void dg_PronosticosDataBind()
        {
            PartidoBC objPartidoBC;
            PronosticoBC objPronosticoBC;
            
            try
            {
                /*
                 * Paso 1: Recoger todos los partidos que ya se jugaron
                 * Paso 2: Recoger todos los partidos que no se han jugado
                 * Paso 3: Separar de (Paso 1) los partidos que tienen pronósticos y cuales no.
                 */

                objPartidoBC = new PartidoBC();
                //-- Paso 1: Recoger todos los partidos que ya se jugaron
                LstPartidosJugados = objPartidoBC.lista_partidos_jugados();
                //-- Paso 2: Recoger todos los partidos que no se han jugado
                LstPartidosSinJugar = objPartidoBC.lista_partidos_sinjugar();
                //-- Paso 3: Separar de (Paso 1) los partidos que tienen pronósticos y los que no.                                
                LstPartidosPronosticados = objPartidoBC.lista_partidos_pronosticados();                
                
                objPronosticoBC = new PronosticoBC();
                lstPronosticos = new List<PronosticoBE>();
                //-- Paso 4: Recoger todos los pronósticos de partidos jugados y no jugados
                lstPronosticos = objPronosticoBC.listar_Pronosticos();

                dg_Pronosticos.Rows.Clear();
                //-- Muestro la relación de partidos que cuentan con pronósticos
                if (LstPartidosPronosticados.Count > 0)
                {
                    foreach(PartidoSinJugarBE cDto in LstPartidosPronosticados)
                    {
                        for(int i = 0; i < lstPronosticos.Count; i++)
                        {
                            if(cDto.Codigo_partido == lstPronosticos[i].CodigoPartido)
                            {
                                dg_Pronosticos.Rows.Add(lstPronosticos[i].CodigoPartido, lstPronosticos[i].CodigoPronostico, 
                                                        cDto.Equipo_local, cDto.Equipo_visitante, lstPronosticos[i].PorcentajeLocal, 
                                                        lstPronosticos[i].PorcentajeEmpate, lstPronosticos[i].PorcentajeVisita, 
                                                        lstPronosticos[i].Pronostico);
                            }
                        }
                    }
                }
                
                //-- Muestro la relación de partidos jugados que no cuentan con pronósticos
                foreach (PartidoSinJugarBE cDto in LstPartidosJugados)
                {
                    foreach(PartidoSinJugarBE _cDto in LstPartidosPronosticados)
                    {
                        if (cDto.Codigo_partido == _cDto.Codigo_partido)
                        {
                            LstPartidosConResultadoYPronostico.Add(cDto);
                            break; 
                        }
                    }
                    LstPartidosConResultadoYSinPronostico.Add(cDto);
                    //dg_Pronosticos.Rows.Add(cDto.Codigo_partido, null, cDto.Equipo_local, cDto.Equipo_visitante,null, null, null, null);
                }
                //-- Muestro la relación de partidos no jugados
                if (LstPartidosSinJugar.Count > 0)
                {
                    foreach (PartidoSinJugarBE cDto in LstPartidosSinJugar)
                    {
                        int r = 0;
                        foreach (PartidoSinJugarBE _cDto in LstPartidosPronosticados)
                        {
                            if (cDto.Codigo_partido == _cDto.Codigo_partido)
                            {
                                r = 1;break;
                            }                            
                        }

                        if(r==0)
                            dg_Pronosticos.Rows.Add(cDto.Codigo_partido, null, cDto.Equipo_local, cDto.Equipo_visitante,
                                                                            null, null, null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }
                
        private void btnEntrenar_Click(object sender, EventArgs e)
        {
            //Si no existe pronostico de un partido, entonces crea uno nuevo.
            //Si existe un pronostico anterior, lo actualiza (sobreescribe) mediante el entrenamiento.

            List<PronosticoBE> listaPronosticos;

            try
            {
                PronosticoBC objPronosticoBC;
                //PronosticoBE objPronosticoBE;
                PartidoPronosticadoBC objPartidoPronosticadoBC;
                PartidoBC objPartidoBC;
                TablaPosicionesBC objTablaBC;
                RankingEquipoBC objRankingBC;
                PartidoPronosticadoBE objPartidoPronosticadoBE;
                int qPartidosJugados = 0;

                //-- Paso 1: Se recolecta los partidos que ya tienen datos resumidos de partidos cuyo resultado se conoce
                
                objPartidoPronosticadoBC = new PartidoPronosticadoBC();
                //-- Solo recopilo la información de los partidos que tienen un resultado real pero no tienen pronóstico
                ListaPartidosPronosticados = objPartidoPronosticadoBC.listar_PartidosPronosticos();
                qPartidosJugados = ListaPartidosPronosticados.Count;
                //-- Paso 2: Se recolecta los partidos cuyo resultado se desconoce
                if (LstPartidosConResultadoYSinPronostico.Count > 0)
                {
                    foreach (PartidoSinJugarBE cDto in LstPartidosConResultadoYSinPronostico)
                    {
                        objSuspensionBC = new SuspensionBC();
                        EquipoBC objEquipoBC = new EquipoBC();
                        LigaBC objLigaBC = new LigaBC();
                        objPartidoBC = new PartidoBC();
                        objTablaBC = new TablaPosicionesBC();
                        objRankingBC = new RankingEquipoBC();

                        int codEquipoL = objEquipoBC.obtenerEquipo(cDto.Equipo_local).CodigoEquipo;
                        int codEquipoV = objEquipoBC.obtenerEquipo(cDto.Equipo_visitante).CodigoEquipo;
                        int codLiga = 0;
                        foreach (LigaBE _cDto in lstLigas)
                            if (_cDto.NombreLiga == cDto.Liga)
                                codLiga = _cDto.CodigoLiga;
                        int paisL = objEquipoBC.obtenerEquipo(cDto.Equipo_local).CodigoPais;
                        int paisV = objEquipoBC.obtenerEquipo(cDto.Equipo_visitante).CodigoPais;
                        int codUltimoPartidoLocal = 0;
                        int codUltimoPartidoVisita = 0;
                        
                        objPartidoPronosticadoBE = new PartidoPronosticadoBE();
                        listaPartidoJugadoLocal = new List<PartidoJugadoBE>();
                        listaPartidoJugadoLocal = objPartidoBC.lista_ultimosPartidos(codEquipoL, codLiga, cDto.Fecha);
                        objPartidoPronosticadoBE.C_Mes = cDto.Fecha.Month;
                        objPartidoPronosticadoBE.C_Local_GolesAnotados = 0;
                        objPartidoPronosticadoBE.C_Local_GolesEncajados = 0;
                        listaPartidoJugadoVisita = new List<PartidoJugadoBE>();
                        listaPartidoJugadoVisita = objPartidoBC.lista_ultimosPartidos(codEquipoV, codLiga, cDto.Fecha);
                        objPartidoPronosticadoBE.C_Visita_GolesAnotados = 0;
                        objPartidoPronosticadoBE.C_Visita_GolesEncajados = 0;
                        objPartidoPronosticadoBE.C_Local_Pts = 0;
                        objPartidoPronosticadoBE.C_Visita_Pts = 0;

                        //-- DATOS DEL EQUIPO LOCAL
                        objPartidoPronosticadoBE.C_Local = true;
                        //objPartidoPronosticadoBE.C_Local_ArqueroSuspendido = objSuspensionBC.consultar_ArqueroSuspendido(codEquipoL, codLiga);
                        //objPartidoPronosticadoBE.C_Local_GoleadorSuspendido = objSuspensionBC.consultar_GoleadorSuspendido(codEquipoL, codLiga);
                        if (listaPartidoJugadoLocal.Count > 0)
                        {
                            codUltimoPartidoLocal = listaPartidoJugadoLocal[0].CodPartido;
                            foreach (PartidoJugadoBE pL in listaPartidoJugadoLocal)
                            {
                                int _EqL = objPartidoBC.obtener_Partido(pL.CodPartido).Codigo_equipo_local;
                                //int _EqV = objPartidoBC.obtener_Partido(pL.CodPartido).Codigo_equipo_visitante;
                                if (_EqL == codEquipoL)
                                {
                                    objPartidoPronosticadoBE.C_Local_GolesAnotados = objPartidoPronosticadoBE.C_Local_GolesAnotados + pL.Goles_local;
                                    objPartidoPronosticadoBE.C_Local_GolesEncajados = objPartidoPronosticadoBE.C_Local_GolesEncajados + pL.Goles_visita;
                                    if (pL.Goles_local > pL.Goles_visita)
                                        objPartidoPronosticadoBE.C_Local_Pts = objPartidoPronosticadoBE.C_Local_Pts + 3;
                                    else
                                        if (pL.Goles_local == pL.Goles_visita)
                                            objPartidoPronosticadoBE.C_Local_Pts = objPartidoPronosticadoBE.C_Local_Pts + 1;
                                }
                                else
                                {
                                    objPartidoPronosticadoBE.C_Local_GolesAnotados = objPartidoPronosticadoBE.C_Local_GolesAnotados + pL.Goles_visita;
                                    objPartidoPronosticadoBE.C_Local_GolesEncajados = objPartidoPronosticadoBE.C_Local_GolesEncajados + pL.Goles_local;
                                    if (pL.Goles_visita > pL.Goles_local)
                                        objPartidoPronosticadoBE.C_Local_Pts = objPartidoPronosticadoBE.C_Local_Pts + 3;
                                    else
                                        if (pL.Goles_local == pL.Goles_visita)
                                            objPartidoPronosticadoBE.C_Local_Pts = objPartidoPronosticadoBE.C_Local_Pts + 1;
                                }
                            }
                        }
                        objPartidoPronosticadoBE.C_Local_PosLiga = (int)objTablaBC.ConsultarPosicionEquipoTabla(codLiga, codEquipoL);
                        objPartidoPronosticadoBE.C_Local_PosRankMund = objRankingBC.obtener_PosRanking(cDto.Fecha.Year, cDto.Fecha.Month, paisL, cDto.Equipo_local);
                        objPartidoPronosticadoBE.C_Local_PromEdad = objEquipoBC.obtener_PromedioEquipoTitular(codEquipoL, codLiga);
                        objPartidoPronosticadoBE.C_Local_QExpulsados = objEquipoBC.obtener_CantidadExpulsadosUltimoPartido(codUltimoPartidoLocal, codEquipoL, codLiga);
                        objPartidoPronosticadoBE.C_Local_QPartidosMes = objEquipoBC.obtener_CantidadPartidosUltimoMes(codEquipoL, cDto.Fecha);
                        objPartidoPronosticadoBE.C_Local_QSuspendidos = objSuspensionBC.CantidadJugadoresSuspendidos(codEquipoL, codLiga, cDto.Fecha);

                        //-- DATOS DEL EQUIPO VISITA
                        objPartidoPronosticadoBE.C_Visita = false;
                        //objPartidoPronosticadoBE.C_Visita_ArqueroSuspendido = objSuspensionBC.consultar_ArqueroSuspendido(codEquipoV, codLiga);
                        //objPartidoPronosticadoBE.C_Visita_GoleadorSuspendido = objSuspensionBC.consultar_GoleadorSuspendido(codEquipoV, codLiga);
                        if (listaPartidoJugadoVisita.Count > 0)
                        {
                            codUltimoPartidoVisita = listaPartidoJugadoVisita[0].CodPartido;
                            foreach (PartidoJugadoBE pV in listaPartidoJugadoVisita)
                            {
                                int _EqL = objPartidoBC.obtener_Partido(pV.CodPartido).Codigo_equipo_local;
                                //int _EqV = objPartidoBC.obtener_Partido(pV.CodPartido).Codigo_equipo_visitante;
                                if (_EqL == codEquipoV)
                                {
                                    objPartidoPronosticadoBE.C_Visita_GolesAnotados = objPartidoPronosticadoBE.C_Visita_GolesAnotados + pV.Goles_local;
                                    objPartidoPronosticadoBE.C_Visita_GolesEncajados = objPartidoPronosticadoBE.C_Visita_GolesEncajados + pV.Goles_visita;
                                    if (pV.Goles_local > pV.Goles_visita)
                                        objPartidoPronosticadoBE.C_Visita_Pts = objPartidoPronosticadoBE.C_Visita_Pts + 3;
                                    else
                                        if (pV.Goles_local == pV.Goles_visita)
                                            objPartidoPronosticadoBE.C_Visita_Pts = objPartidoPronosticadoBE.C_Visita_Pts + 1;
                                }
                                else
                                {
                                    objPartidoPronosticadoBE.C_Visita_GolesAnotados = objPartidoPronosticadoBE.C_Visita_GolesAnotados + pV.Goles_visita;
                                    objPartidoPronosticadoBE.C_Visita_GolesEncajados = objPartidoPronosticadoBE.C_Visita_GolesEncajados + pV.Goles_local;
                                    if (pV.Goles_visita > pV.Goles_local)
                                        objPartidoPronosticadoBE.C_Visita_Pts = objPartidoPronosticadoBE.C_Visita_Pts + 3;
                                    else
                                        if (pV.Goles_local == pV.Goles_visita)
                                            objPartidoPronosticadoBE.C_Visita_Pts = objPartidoPronosticadoBE.C_Visita_Pts + 1;
                                }
                            }
                        }
                        objPartidoPronosticadoBE.C_Visita_PosLiga = (int)objTablaBC.ConsultarPosicionEquipoTabla(codLiga, codEquipoV);
                        objPartidoPronosticadoBE.C_Visita_PosRankMund = objRankingBC.obtener_PosRanking(cDto.Fecha.Year, cDto.Fecha.Month, paisV, cDto.Equipo_visitante);
                        objPartidoPronosticadoBE.C_Visita_PromEdad = objEquipoBC.obtener_PromedioEquipoTitular(codEquipoV, codLiga);
                        objPartidoPronosticadoBE.C_Visita_QExpulsados = objEquipoBC.obtener_CantidadExpulsadosUltimoPartido(codUltimoPartidoVisita, codEquipoV, codLiga);
                        objPartidoPronosticadoBE.C_Visita_QPartidosMes = objEquipoBC.obtener_CantidadPartidosUltimoMes(codEquipoV, cDto.Fecha);
                        objPartidoPronosticadoBE.C_Visita_QSuspendidos = objSuspensionBC.CantidadJugadoresSuspendidos(codEquipoV, codLiga, cDto.Fecha);

                        // OTRAS VARIABLES
                        //objPartidoPronosticadoBE.C_QAsistencia = <esto es lo que no decido si va o no va en la red neuronal>
                        objPartidoPronosticadoBE.C_QEquiposLiga = objLigaBC.CantidadEquiposLiga(codLiga);
                        //objPartidoPronosticadoBE.C_QEquiposMundial = 

                        objPartidoPronosticadoBE.IdPartido = cDto.Codigo_partido;

                        PartidoBE objPartidoActual = objPartidoBC.obtener_Partido(cDto.Codigo_partido);

                        if (objPartidoActual != null)
                        {
                            if(objPartidoActual.Goles_local>objPartidoActual.Goles_visita)
                                    objPartidoPronosticadoBE.C_Resultado = "L";
                                else
                                    if (objPartidoActual.Goles_local < objPartidoActual.Goles_visita)
                                        objPartidoPronosticadoBE.C_Resultado = "V";
                                    else
                                        if (objPartidoActual.Goles_local == objPartidoActual.Goles_visita)
                                            objPartidoPronosticadoBE.C_Resultado = "E";
                        }

                        ListaPartidosPronosticados.Add(objPartidoPronosticadoBE);
                    }                    
                }
                
                if (LstPartidosSinJugar.Count > 0)
                {
                    foreach (PartidoSinJugarBE cDto in LstPartidosSinJugar)
                    {
                        objSuspensionBC = new SuspensionBC();
                        EquipoBC objEquipoBC = new EquipoBC();
                        LigaBC objLigaBC = new LigaBC();
                        objPartidoBC = new PartidoBC();
                        objTablaBC = new TablaPosicionesBC();
                        objRankingBC = new RankingEquipoBC();

                        int codEquipoL = objEquipoBC.obtenerEquipo(cDto.Equipo_local).CodigoEquipo;
                        int codEquipoV = objEquipoBC.obtenerEquipo(cDto.Equipo_visitante).CodigoEquipo;
                        int codLiga = 0;
                        foreach (LigaBE _cDto in lstLigas)
                            if (_cDto.NombreLiga == cDto.Liga)
                                codLiga = _cDto.CodigoLiga;
                        int paisL = objEquipoBC.obtenerEquipo(cDto.Equipo_local).CodigoPais;
                        int paisV = objEquipoBC.obtenerEquipo(cDto.Equipo_visitante).CodigoPais;
                        int codUltimoPartidoLocal = 0;
                        int codUltimoPartidoVisita = 0;

                        objPartidoPronosticadoBE = new PartidoPronosticadoBE();
                        listaPartidoJugadoLocal = new List<PartidoJugadoBE>();
                        listaPartidoJugadoLocal = objPartidoBC.lista_ultimosPartidos(codEquipoL, codLiga, cDto.Fecha);
                        objPartidoPronosticadoBE.C_Mes = cDto.Fecha.Month;
                        objPartidoPronosticadoBE.C_Local_GolesAnotados = 0;
                        objPartidoPronosticadoBE.C_Local_GolesEncajados = 0;
                        listaPartidoJugadoVisita = new List<PartidoJugadoBE>();
                        listaPartidoJugadoVisita = objPartidoBC.lista_ultimosPartidos(codEquipoV, codLiga, cDto.Fecha);
                        objPartidoPronosticadoBE.C_Visita_GolesAnotados = 0;
                        objPartidoPronosticadoBE.C_Visita_GolesEncajados = 0;
                        objPartidoPronosticadoBE.C_Local_Pts = 0;
                        objPartidoPronosticadoBE.C_Visita_Pts = 0;

                        //-- DATOS DEL EQUIPO LOCAL
                        objPartidoPronosticadoBE.C_Local = true;
                        //objPartidoPronosticadoBE.C_Local_ArqueroSuspendido = objSuspensionBC.consultar_ArqueroSuspendido(codEquipoL, codLiga);
                        //objPartidoPronosticadoBE.C_Local_GoleadorSuspendido = objSuspensionBC.consultar_GoleadorSuspendido(codEquipoL, codLiga);
                        if (listaPartidoJugadoLocal.Count > 0)
                        {
                            codUltimoPartidoLocal = listaPartidoJugadoLocal[0].CodPartido;
                            foreach (PartidoJugadoBE pL in listaPartidoJugadoLocal)
                            {
                                int _EqL = objPartidoBC.obtener_Partido(pL.CodPartido).Codigo_equipo_local;
                                //int _EqV = objPartidoBC.obtener_Partido(pL.CodPartido).Codigo_equipo_visitante;
                                if (_EqL == codEquipoL)
                                {
                                    objPartidoPronosticadoBE.C_Local_GolesAnotados = objPartidoPronosticadoBE.C_Local_GolesAnotados + pL.Goles_local;
                                    objPartidoPronosticadoBE.C_Local_GolesEncajados = objPartidoPronosticadoBE.C_Local_GolesEncajados + pL.Goles_visita;
                                    if (pL.Goles_local > pL.Goles_visita)
                                        objPartidoPronosticadoBE.C_Local_Pts = objPartidoPronosticadoBE.C_Local_Pts + 3;
                                    else
                                        if (pL.Goles_local == pL.Goles_visita)
                                            objPartidoPronosticadoBE.C_Local_Pts = objPartidoPronosticadoBE.C_Local_Pts + 1;
                                }
                                else
                                {
                                    objPartidoPronosticadoBE.C_Local_GolesAnotados = objPartidoPronosticadoBE.C_Local_GolesAnotados + pL.Goles_visita;
                                    objPartidoPronosticadoBE.C_Local_GolesEncajados = objPartidoPronosticadoBE.C_Local_GolesEncajados + pL.Goles_local;
                                    if (pL.Goles_visita > pL.Goles_local)
                                        objPartidoPronosticadoBE.C_Local_Pts = objPartidoPronosticadoBE.C_Local_Pts + 3;
                                    else
                                        if (pL.Goles_local == pL.Goles_visita)
                                            objPartidoPronosticadoBE.C_Local_Pts = objPartidoPronosticadoBE.C_Local_Pts + 1;
                                }
                            }
                        }
                        objPartidoPronosticadoBE.C_Local_PosLiga = (int)objTablaBC.ConsultarPosicionEquipoTabla(codLiga, codEquipoL);
                        objPartidoPronosticadoBE.C_Local_PosRankMund = objRankingBC.obtener_PosRanking(cDto.Fecha.Year, cDto.Fecha.Month, paisL, cDto.Equipo_local);
                        objPartidoPronosticadoBE.C_Local_PromEdad = objEquipoBC.obtener_PromedioEquipoTitular(codEquipoL, codLiga);
                        objPartidoPronosticadoBE.C_Local_QExpulsados = objEquipoBC.obtener_CantidadExpulsadosUltimoPartido(codUltimoPartidoLocal, codEquipoL, codLiga);
                        objPartidoPronosticadoBE.C_Local_QPartidosMes = objEquipoBC.obtener_CantidadPartidosUltimoMes(codEquipoL, cDto.Fecha);
                        objPartidoPronosticadoBE.C_Local_QSuspendidos = objSuspensionBC.CantidadJugadoresSuspendidos(codEquipoL, codLiga, cDto.Fecha);

                        //-- DATOS DEL EQUIPO VISITA
                        objPartidoPronosticadoBE.C_Visita = false;
                        //objPartidoPronosticadoBE.C_Visita_ArqueroSuspendido = objSuspensionBC.consultar_ArqueroSuspendido(codEquipoV, codLiga);
                        //objPartidoPronosticadoBE.C_Visita_GoleadorSuspendido = objSuspensionBC.consultar_GoleadorSuspendido(codEquipoV, codLiga);
                        if (listaPartidoJugadoVisita.Count > 0)
                        {
                            codUltimoPartidoVisita = listaPartidoJugadoVisita[0].CodPartido;
                            foreach (PartidoJugadoBE pV in listaPartidoJugadoVisita)
                            {
                                int _EqL = objPartidoBC.obtener_Partido(pV.CodPartido).Codigo_equipo_local;
                                //int _EqV = objPartidoBC.obtener_Partido(pV.CodPartido).Codigo_equipo_visitante;
                                if (_EqL == codEquipoV)
                                {
                                    objPartidoPronosticadoBE.C_Visita_GolesAnotados = objPartidoPronosticadoBE.C_Visita_GolesAnotados + pV.Goles_local;
                                    objPartidoPronosticadoBE.C_Visita_GolesEncajados = objPartidoPronosticadoBE.C_Visita_GolesEncajados + pV.Goles_visita;
                                    if (pV.Goles_local > pV.Goles_visita)
                                        objPartidoPronosticadoBE.C_Visita_Pts = objPartidoPronosticadoBE.C_Visita_Pts + 3;
                                    else
                                        if (pV.Goles_local == pV.Goles_visita)
                                            objPartidoPronosticadoBE.C_Visita_Pts = objPartidoPronosticadoBE.C_Visita_Pts + 1;
                                }
                                else
                                {
                                    objPartidoPronosticadoBE.C_Visita_GolesAnotados = objPartidoPronosticadoBE.C_Visita_GolesAnotados + pV.Goles_visita;
                                    objPartidoPronosticadoBE.C_Visita_GolesEncajados = objPartidoPronosticadoBE.C_Visita_GolesEncajados + pV.Goles_local;
                                    if (pV.Goles_visita > pV.Goles_local)
                                        objPartidoPronosticadoBE.C_Visita_Pts = objPartidoPronosticadoBE.C_Visita_Pts + 3;
                                    else
                                        if (pV.Goles_local == pV.Goles_visita)
                                            objPartidoPronosticadoBE.C_Visita_Pts = objPartidoPronosticadoBE.C_Visita_Pts + 1;
                                }
                            }
                        }
                        objPartidoPronosticadoBE.C_Visita_PosLiga = (int)objTablaBC.ConsultarPosicionEquipoTabla(codLiga, codEquipoV);
                        objPartidoPronosticadoBE.C_Visita_PosRankMund = objRankingBC.obtener_PosRanking(cDto.Fecha.Year, cDto.Fecha.Month, paisV, cDto.Equipo_visitante);
                        objPartidoPronosticadoBE.C_Visita_PromEdad = objEquipoBC.obtener_PromedioEquipoTitular(codEquipoV, codLiga);
                        objPartidoPronosticadoBE.C_Visita_QExpulsados = objEquipoBC.obtener_CantidadExpulsadosUltimoPartido(codUltimoPartidoVisita, codEquipoV, codLiga);
                        objPartidoPronosticadoBE.C_Visita_QPartidosMes = objEquipoBC.obtener_CantidadPartidosUltimoMes(codEquipoV, cDto.Fecha);
                        objPartidoPronosticadoBE.C_Visita_QSuspendidos = objSuspensionBC.CantidadJugadoresSuspendidos(codEquipoV, codLiga, cDto.Fecha);

                        // OTRAS VARIABLES
                        //objPartidoPronosticadoBE.C_QAsistencia = <esto es lo que no decido si va o no va en la red neuronal>
                        objPartidoPronosticadoBE.C_QEquiposLiga = objLigaBC.CantidadEquiposLiga(codLiga);
                        //objPartidoPronosticadoBE.C_QEquiposMundial = 

                        objPartidoPronosticadoBE.IdPartido = cDto.Codigo_partido;

                        objPartidoPronosticadoBE.C_Resultado = "?";

                        ListaPartidosPronosticados.Add(objPartidoPronosticadoBE);
                    }

                    //qPartidosJugados = ListaPartidosPronosticados.Count - LstPartidosJugados.Count;
                    //qPartidosSinJugar = LstPartidosSinPronosticos.Count;
                }
                
                if (ListaPartidosPronosticados.Count > 0)
                {
                    //-- Se nomalizan los datos
                    LstInstancias = Normalizacion(ListaPartidosPronosticados);
                    //-- Paso 3: Se crea el fichero que contendrá toda la información para entrenar el sistema
                    CrearFicheroARFF(LstInstancias);//ListaPartidosPronosticados);

                    //-- Paso 4: Se lleva a entrenamiento los datos
                    listaPronosticos = new List<PronosticoBE>();
                    listaPronosticos = RedNeuronal.Entrenamiento();
                                        
                    //-- Paso 5: Se hace un análisis final de los pronósticos 
                    
                    if (listaPronosticos.Count > 0)
                    {
                        /*
                         * Mientras que no se entrene con el maestro/supervisor no se implementará esto
                        foreach (PronosticoBE cDto in listaPronosticos)
                        {
                            if (cDto.Pronostico == "L" && cDto.PorcentajeLocal < 85)
                            {
                                //
                            }
                            else
                            if (cDto.Pronostico == "E" && cDto.PorcentajeLocal < 85)
                            {
                                //
                            }
                            else
                            if (cDto.Pronostico == "V" && cDto.PorcentajeLocal < 85)
                            {
                                //
                            }
                        }*/
                        objPronosticoBC = new PronosticoBC();
                        for (int i = 0; i<ListaPartidosPronosticados.Count; i++)
                        {
                            if (objPartidoPronosticadoBC.VerificarExistePronostico(ListaPartidosPronosticados[i].IdPartido) > 0)
                            {
                                listaPronosticos[i].CodigoPartido = ListaPartidosPronosticados[i].IdPartido;
                                if (objPartidoPronosticadoBC.VerificarExistePartidoPronostico(ListaPartidosPronosticados[i].IdPartido) > 0)
                                {
                                    objPartidoPronosticadoBC.ActualizarPartidoPronosticado(ListaPartidosPronosticados[i]);
                                }
                                objPronosticoBC.actualizar_Pronostico(listaPronosticos[i]);
                            }
                            else
                            {
                                PartidoPronosticadoBC objPPBC = new PartidoPronosticadoBC();
                                PartidoPronosticadoBE objPPBE = new PartidoPronosticadoBE();

                                objPPBE = ListaPartidosPronosticados[i];
                                objPPBC.insertar_PartidoPronosticado(objPPBE);

                                objPronosticoBC.insertar_Pronostico(listaPronosticos[i]);
                            }
                        }                        
                    }
                    dg_PronosticosDataBind();
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private List<InstanciaNormalizadaBE> Normalizacion(List<PartidoPronosticadoBE> LstPDN)
        {
            InstanciaNormalizadaBE instancia;
            List<InstanciaNormalizadaBE> lstInstancias = new List<InstanciaNormalizadaBE>();
            List<Decimal> max = new List<Decimal>();
            List<Decimal> min = new List<Decimal>();
            max.Add(LstPDN[0].C_Local_GolesAnotados);
            max.Add(LstPDN[0].C_Local_GolesEncajados);
            max.Add(LstPDN[0].C_Local_PosLiga);
            max.Add(LstPDN[0].C_Local_PosRankMund);
            max.Add(LstPDN[0].C_Local_PromEdad);
            max.Add(LstPDN[0].C_Local_Pts);
            max.Add(LstPDN[0].C_Local_QExpulsados);
            max.Add(LstPDN[0].C_Local_QPartidosMes);
            max.Add(LstPDN[0].C_Local_QSuspendidos);
            max.Add(LstPDN[0].C_Mes);
            max.Add(LstPDN[0].C_QEquiposLiga);
            max.Add(LstPDN[0].C_Visita_GolesAnotados);
            max.Add(LstPDN[0].C_Visita_GolesEncajados);
            max.Add(LstPDN[0].C_Visita_PosLiga);
            max.Add(LstPDN[0].C_Visita_PosRankMund);
            max.Add(LstPDN[0].C_Visita_PromEdad);
            max.Add(LstPDN[0].C_Visita_Pts);
            max.Add(LstPDN[0].C_Visita_QExpulsados);
            max.Add(LstPDN[0].C_Visita_QPartidosMes);
            max.Add(LstPDN[0].C_Visita_QSuspendidos);
            min.Add(LstPDN[0].C_Local_GolesAnotados);
            min.Add(LstPDN[0].C_Local_GolesEncajados);
            min.Add(LstPDN[0].C_Local_PosLiga);
            min.Add(LstPDN[0].C_Local_PosRankMund);
            min.Add(LstPDN[0].C_Local_PromEdad);
            min.Add(LstPDN[0].C_Local_Pts);
            min.Add(LstPDN[0].C_Local_QExpulsados);
            min.Add(LstPDN[0].C_Local_QPartidosMes);
            min.Add(LstPDN[0].C_Local_QSuspendidos);
            min.Add(LstPDN[0].C_Mes);
            min.Add(10);
            min.Add(LstPDN[0].C_Visita_GolesAnotados);
            min.Add(LstPDN[0].C_Visita_GolesEncajados);
            min.Add(LstPDN[0].C_Visita_PosLiga);
            min.Add(LstPDN[0].C_Visita_PosRankMund);
            min.Add(LstPDN[0].C_Visita_PromEdad);
            min.Add(LstPDN[0].C_Visita_Pts);
            min.Add(LstPDN[0].C_Visita_QExpulsados);
            min.Add(LstPDN[0].C_Visita_QPartidosMes);
            min.Add(LstPDN[0].C_Visita_QSuspendidos);
            foreach (PartidoPronosticadoBE iDN in LstPDN)
            {
                if (max[0] < iDN.C_Local_GolesAnotados)
                    max[0] = iDN.C_Local_GolesAnotados;
                else
                    if (min[0] > iDN.C_Local_GolesAnotados)
                        min[0] = iDN.C_Local_GolesAnotados;
                if (max[1] < iDN.C_Local_GolesEncajados)
                    max[1] = iDN.C_Local_GolesEncajados;
                else
                    if (min[1] > iDN.C_Local_GolesEncajados)
                        min[1] = iDN.C_Local_GolesEncajados;
                if (max[2] < iDN.C_Local_PosLiga)
                    max[2] = iDN.C_Local_PosLiga;
                else
                    if (min[2] > iDN.C_Local_PosLiga)
                        min[2] = iDN.C_Local_PosLiga;
                if (max[3] < iDN.C_Local_PosRankMund)
                    max[3] = iDN.C_Local_PosRankMund;
                else
                    if (min[3] > iDN.C_Local_PosRankMund)
                        min[3] = iDN.C_Local_PosRankMund;
                if (max[4] < iDN.C_Local_PromEdad)
                    max[4] = iDN.C_Local_PromEdad;
                else
                    if (min[4] > iDN.C_Local_PromEdad)
                        min[4] = iDN.C_Local_PromEdad;
                if (max[5] < iDN.C_Local_Pts)
                    max[5] = iDN.C_Local_Pts;
                else
                    if (min[5] > iDN.C_Local_Pts)
                        min[5] = iDN.C_Local_Pts;
                if (max[6] < iDN.C_Local_QExpulsados)
                    max[6] = iDN.C_Local_QExpulsados;
                else
                    if (min[6] > iDN.C_Local_QExpulsados)
                        min[6] = iDN.C_Local_QExpulsados;
                if (max[7] < iDN.C_Local_QPartidosMes)
                    max[7] = iDN.C_Local_QPartidosMes;
                else
                    if (min[7] > iDN.C_Local_QPartidosMes)
                        min[7] = iDN.C_Local_QPartidosMes;
                if (max[8] < iDN.C_Local_QSuspendidos)
                    max[8] = iDN.C_Local_QSuspendidos;
                else
                    if (min[8] > iDN.C_Local_QSuspendidos)
                        min[8] = iDN.C_Local_QSuspendidos;
                if (max[9] < iDN.C_Mes)
                    max[9] = iDN.C_Mes;
                else
                    if (min[9] > iDN.C_Mes)
                        min[9] = iDN.C_Mes;
                if (max[10] < iDN.C_QEquiposLiga)
                    max[10] = iDN.C_QEquiposLiga;
                else
                    if (min[10] > iDN.C_QEquiposLiga)
                        min[10] = iDN.C_QEquiposLiga;
                if (max[11] < iDN.C_Visita_GolesAnotados)
                    max[11] = iDN.C_Visita_GolesAnotados;
                else
                    if (min[11] > iDN.C_Visita_GolesAnotados)
                        min[11] = iDN.C_Visita_GolesAnotados;
                if (max[12] < iDN.C_Visita_GolesEncajados)
                    max[12] = iDN.C_Visita_GolesEncajados;
                else
                    if (min[12] > iDN.C_Visita_GolesEncajados)
                        min[12] = iDN.C_Visita_GolesEncajados;
                if (max[13] < iDN.C_Visita_PosLiga)
                    max[13] = iDN.C_Visita_PosLiga;
                else
                    if (min[13] > iDN.C_Visita_PosLiga)
                        min[13] = iDN.C_Visita_PosLiga;
                if (max[14] < iDN.C_Visita_PosRankMund)
                    max[14] = iDN.C_Visita_PosRankMund;
                else
                    if (min[14] > iDN.C_Visita_PosRankMund)
                        min[14] = iDN.C_Visita_PosRankMund;
                if (max[15] < iDN.C_Visita_PromEdad)
                    max[15] = iDN.C_Visita_PromEdad;
                else
                    if (min[15] > iDN.C_Visita_PromEdad)
                        min[15] = iDN.C_Visita_PromEdad;
                if (max[16] < iDN.C_Visita_Pts)
                    max[16] = iDN.C_Visita_Pts;
                else
                    if (min[16] > iDN.C_Visita_Pts)
                        min[16] = iDN.C_Visita_Pts;
                if (max[17] < iDN.C_Visita_QExpulsados)
                    max[17] = iDN.C_Visita_QExpulsados;
                else
                    if (min[17] > iDN.C_Visita_QExpulsados)
                        min[17] = iDN.C_Visita_QExpulsados;
                if (max[18] < iDN.C_Visita_QPartidosMes)
                    max[18] = iDN.C_Visita_QPartidosMes;
                else
                    if (min[18] > iDN.C_Visita_QPartidosMes)
                        min[18] = iDN.C_Visita_QPartidosMes;
                if (max[19] < iDN.C_Visita_QSuspendidos)
                    max[19] = iDN.C_Visita_QSuspendidos;
                else
                    if (min[19] > iDN.C_Visita_QSuspendidos)
                        min[19] = iDN.C_Visita_QSuspendidos;
            }

            foreach (PartidoPronosticadoBE iDN in LstPDN)
            {
                instancia = new InstanciaNormalizadaBE();
                instancia.C_Local_GolesAnotados = Math.Round(valorNormalizado(iDN.C_Local_GolesAnotados, max[0], min[0], 0),4);
                instancia.C_Local_GolesEncajados = Math.Round(valorNormalizado(iDN.C_Local_GolesEncajados, max[1], min[1], 0),4);
                instancia.C_Local_PosLiga = Math.Round(valorNormalizado(iDN.C_Local_PosLiga, max[2], min[2], 1),4);
                instancia.C_Local_PosRankMund = Math.Round(valorNormalizado(iDN.C_Local_PosRankMund, max[3], min[3], 1),4);
                instancia.C_Local_PromEdad = Math.Round(valorNormalizado(iDN.C_Local_PromEdad, max[4], min[4], 0),4);
                instancia.C_Local_Pts = Math.Round(valorNormalizado(iDN.C_Local_Pts, max[5], min[5], 0),4);
                instancia.C_Local_QExpulsados = Math.Round(valorNormalizado(iDN.C_Local_QExpulsados, max[6], min[6], 1),4);
                instancia.C_Local_QPartidosMes = Math.Round(valorNormalizado(iDN.C_Local_QPartidosMes, max[7], min[7], 0),4);
                instancia.C_Local_QSuspendidos = Math.Round(valorNormalizado(iDN.C_Local_QSuspendidos, max[8], min[8], 1),4);
                instancia.C_Mes = Math.Round(valorNormalizado(iDN.C_Mes, max[9], min[9], 0),4);
                instancia.C_QEquiposLiga = Math.Round(valorNormalizado(iDN.C_QEquiposLiga, max[10], min[10], 0),4);
                instancia.C_Visita_GolesAnotados = Math.Round(valorNormalizado(iDN.C_Visita_GolesAnotados, max[11], min[11], 0),4);
                instancia.C_Visita_GolesEncajados = Math.Round(valorNormalizado(iDN.C_Visita_GolesEncajados, max[12], min[12], 0),4);
                instancia.C_Visita_PosLiga = Math.Round(valorNormalizado(iDN.C_Visita_PosLiga, max[13], min[13], 1),4);
                instancia.C_Visita_PosRankMund = Math.Round(valorNormalizado(iDN.C_Visita_PosRankMund, max[14], min[14], 1),4);
                instancia.C_Visita_PromEdad = Math.Round(valorNormalizado(iDN.C_Visita_PromEdad, max[15], min[15], 0),4);
                instancia.C_Visita_Pts = Math.Round(valorNormalizado(iDN.C_Visita_Pts, max[16], min[16], 0),4);
                instancia.C_Visita_QExpulsados = Math.Round(valorNormalizado(iDN.C_Visita_QExpulsados, max[17], min[17], 1),4);
                instancia.C_Visita_QPartidosMes = Math.Round(valorNormalizado(iDN.C_Visita_QPartidosMes, max[18], min[18], 0),4);
                instancia.C_Visita_QSuspendidos = Math.Round(valorNormalizado(iDN.C_Visita_QSuspendidos, max[19], min[19], 1), 4);
                instancia.C_Local = iDN.C_Local;
                instancia.C_Visita = iDN.C_Visita;
                instancia.C_Resultado = iDN.C_Resultado;
                lstInstancias.Add(instancia);
            }

            return lstInstancias;
        }

        private Decimal valorNormalizado(Decimal V, Decimal Xmax, Decimal Xmin, int tipo)
        {
            if (tipo == 0)
            {
                return ((V - Xmin) / (Xmax - Xmin));
            }
            else
            {
                return ((Xmax-V) / (Xmax - Xmin));
            }
        }

        private void CrearFicheroARFF(List<InstanciaNormalizadaBE> Data)//List<PartidoPronosticadoBE> Data)
        {
            String fic = Application.StartupPath + "\\SISPPAFUT.arff";
            //const string fic = @"C:\Users\Michael\Documents\UPC\2012\TP1\Documentos\SISPPAFUT.arff";

            //-- fuente de la función: http://www.elguille.info/NET/dotnet/leer_escribir_ficheros_texto.htm
            System.IO.StreamWriter archivo = new StreamWriter(fic, false);

            //-- Contenido del fichero

            archivo.WriteLine("@relation SISPPAFUT");
            archivo.WriteLine("@attribute qEquiposLiga real");
            archivo.WriteLine("@attribute mes real");
            //archivo.WriteLine("@attribute qEquiposMundial numeric");
            //archivo.WriteLine("@attribute qAsistencia numeric");
            archivo.WriteLine("@attribute Local_PosLiga real");
            archivo.WriteLine("@attribute Local_Pts real");
            archivo.WriteLine("@attribute Local {True, False}");
            archivo.WriteLine("@attribute Local_PosRankMund real");
            //archivo.WriteLine("@attribute Local_GoleadorSuspendido {True, False}");
            //archivo.WriteLine("@attribute Local_ArqueroSuspendido {True, False}");
            archivo.WriteLine("@attribute Local_qExpulsados real");
            archivo.WriteLine("@attribute Local_qSuspendidos real");
            archivo.WriteLine("@attribute Local_GolesAnotados real");
            archivo.WriteLine("@attribute Local_GolesEncajados real");
            archivo.WriteLine("@attribute Local_PromEdad real");
            archivo.WriteLine("@attribute Local_qPartidosMes real");
            archivo.WriteLine("@attribute Visita_PosLiga real");
            archivo.WriteLine("@attribute Visita_Pts real");
            archivo.WriteLine("@attribute Visita {True, False}");
            archivo.WriteLine("@attribute Visita_PosRankMund real");
            //archivo.WriteLine("@attribute Visita_GoleadorSuspendido {True, False}");
            //archivo.WriteLine("@attribute Visita_ArqueroSuspendido {True, False}");
            archivo.WriteLine("@attribute Visita_qExpulsados real");
            archivo.WriteLine("@attribute Visita_qSuspendidos real");
            archivo.WriteLine("@attribute Visita_GolesAnotados real");
            archivo.WriteLine("@attribute Visita_GolesEncajados real");
            archivo.WriteLine("@attribute Visita_PromEdad real");
            archivo.WriteLine("@attribute Visita_qPartidosMes real");
            archivo.WriteLine("@attribute resultado {L, E, V}");
            archivo.WriteLine("@data");
            
            foreach (InstanciaNormalizadaBE cDto in Data)//PartidoPronosticadoBE cDto in Data)
            {
                string _data = String.Empty;
                _data = cDto.C_QEquiposLiga + "," +
                        cDto.C_Mes + "," + 
                        //cDto.C_QEquiposMundial+ "," + 
                        //cDto.C_QAsistencia    + "," +
                        cDto.C_Local_PosLiga    + "," + 
                        cDto.C_Local_Pts + "," + cDto.C_Local + "," + cDto.C_Local_PosRankMund + "," + 
                        //cDto.C_Local_GoleadorSuspendido + "," + cDto.C_Local_ArqueroSuspendido + "," + 
                        cDto.C_Local_QExpulsados + "," + cDto.C_Local_QSuspendidos + "," + cDto.C_Local_GolesAnotados + "," + 
                        cDto.C_Local_GolesEncajados + "," + cDto.C_Local_PromEdad + "," + cDto.C_Local_QPartidosMes + "," + 
                        cDto.C_Visita_PosLiga + "," + cDto.C_Visita_Pts + "," + cDto.C_Visita + "," + 
                        cDto.C_Visita_PosRankMund + "," + 
                        //cDto.C_Visita_GoleadorSuspendido + "," + cDto.C_Visita_ArqueroSuspendido + "," + 
                        cDto.C_Visita_QExpulsados + "," + cDto.C_Visita_QSuspendidos + "," +
                        cDto.C_Visita_GolesAnotados + "," + cDto.C_Visita_GolesEncajados + "," + cDto.C_Visita_PromEdad + "," +
                        cDto.C_Visita_QPartidosMes + "," + cDto.C_Resultado;
                archivo.WriteLine(_data);
            }
            
            archivo.Close();
        }

        private void inCerrar(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                e.Cancel = true;
        }
    }
}
