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
        List<PronosticoBE> lstPronosticos;
        List<EquipoBE> listaEquipos;
        List<PartidoSinJugarBE> lstPartidosPronosticados;
        List<PartidoSinJugarBE> lstPartidosSinJugar;
        List<PartidoPronosticadoBE> listaPartidosPronosticados;

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
                dg_PronosticosConfigurar();
                dg_PronosticosDataBind();
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
                /* Este método va a mostrar todos los partidos que van a entrar para pronosticar 
                 * o para actualizar los pronósticos ya existentes con los nuevos pesos de las variables*/

                //-- 1°: Se muestran los partidos que ya cuentan con un pronóstico
                //-- 2°: Se muestran los partidos que no cuentan con un pronóstico

                /* Para mostrar los partidos que ya cuentan con un pronóstico 
                 * se empleará el SP: 'spListarPartidosPronosticados', el cual recoge todos los datos necesarios de
                 * los partidos que están en la tabla 'ResumenPartidoPronosticado'.
                 * Para mostrar los partidos que no cuentan con un pronóstico
                 * se empleará el SP: 'spListaPartidosSinJugar' el cual recoge todos los partidos que aún no tienen datos
                 * de como se desarrolló el encuentro.
                 */
                objPartidoBC = new PartidoBC();

                lstPartidosPronosticados = new List<PartidoSinJugarBE>();
                lstPartidosPronosticados = objPartidoBC.lista_partidos_pronosticados();

                lstPartidosSinJugar = new List<PartidoSinJugarBE>();
                lstPartidosSinJugar = objPartidoBC.lista_partidos_sinjugar();

                objPronosticoBC = new PronosticoBC();
                lstPronosticos = new List<PronosticoBE>();
                lstPronosticos = objPronosticoBC.listar_Pronosticos();

                dg_Pronosticos.Rows.Clear();

                if (lstPartidosPronosticados.Count > 0)
                {
                    foreach(PartidoSinJugarBE cDto in lstPartidosPronosticados)
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

                if (lstPartidosSinJugar.Count > 0)
                {
                    foreach (PartidoSinJugarBE cDto in lstPartidosSinJugar)
                    {
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
            //Este metodo es temporal, solo ingresa data aleatoria a la tabla de pronosticos. Después se unirá a la red neuronal.
            //Si no existe pronostico de un partido, entonces crea uno nuevo.
            //Si existe un pronostico anterior, lo actualiza (sobreescribe) mediante el entrenamiento.
            try
            {
                PronosticoBC objPronosticoBC;
                PronosticoBE objPronosticoBE;
                
                PartidoPronosticadoBC objPartidoPronosticadoBC;
                PartidoPronosticadoBE objPartidoPronosticadoBE;
                
                Decimal dLocal;
                Decimal dEmpate;
                Decimal dVisita;
                Random objRandom;
                String sPronostico;

                //-- Paso 1: Se recolecta los partidos que ya tienen datos resumidos de partidos cuyo resultado se conoce
                listaPartidosPronosticados = new List<PartidoPronosticadoBE>();
                objPartidoPronosticadoBC = new PartidoPronosticadoBC();
                listaPartidosPronosticados = objPartidoPronosticadoBC.listar_PartidosPronosticos();
                /*
                //-- Paso 2: Se recolecta los partidos cuyo resultado se desconoce
                foreach (PartidoSinJugarBE cDto in lstPartidosSinJugar)
                {
                    objPartidoPronosticadoBE = new PartidoPronosticadoBE();
                    /* Aquí se debe averiguar por cada característica de la red neuronal, el valor correspondiente 
                     * Por ejemplo: objPartidoPronosticadoBE.C_LocalPts = objPartidoBC.lista_ultimosPartidos(lista_equipos[cmb_equipo.SelectedIndex - 1].CodigoEquipo, lista_ligas[cmb_liga.SelectedIndex - 1].CodigoLiga);
                     *              objPartidoPronosticadoBE.C_PromEdad = PromEdadEq(objJugadorBC.listar_Jugadores_xEquipo(lista_equipos[cmb_equipo.SelectedIndex - 1].CodigoEquipo));
                     *              ...
                     *
                    listaPartidosPronosticados.Add(objPartidoPronosticadoBE);
                }
                */
                //-- Paso 3: Se crea el fichero que contendrá toda la información para entrenar el sistema
                CrearFicheroARFF(listaPartidosPronosticados);
                /*
                for (int i = 0; i < dg_Pronosticos.Rows.Count; i++)
                {
                    objPronosticoBC = new PronosticoBC();
                    objRandom = new Random();
                    dLocal = Convert.ToDecimal(objRandom.Next(100));
                    objRandom = new Random();
                    dEmpate = Convert.ToDecimal(objRandom.Next(100));
                    objRandom = new Random();
                    dVisita = Convert.ToDecimal(objRandom.Next(100));
                    
                    //-- Esta asignación es temporal
                    sPronostico = hallarPronostico(dLocal,dEmpate,dVisita);

                    RedNeuronal RNA = new RedNeuronal();
                    DatosPartidoConsolidado objCaso = null;
                    int qEqRank = 0;
                    Double[,] _sPronostico = RNA.ResolverCaso(objCaso, qEqRank);

                    object var = dg_Pronosticos["porcentajeLocal", i].Value;

                    if (dg_Pronosticos["porcentajeLocal", i].Value == null || dg_Pronosticos["porcentajeEmpate", i].Value == null ||
                        dg_Pronosticos["porcentajeVisita", i].Value == null)
                    {
                        objPronosticoBE = new PronosticoBE();
                        objPronosticoBE.CodigoPartido = Convert.ToInt32(dg_Pronosticos["codPartido", i].Value);
                        objPronosticoBE.PorcentajeLocal = dLocal;
                        objPronosticoBE.PorcentajeEmpate = dEmpate;
                        objPronosticoBE.PorcentajeVisita = dVisita;
                        objPronosticoBE.Pronostico = sPronostico;

                        objPronosticoBC.insertar_Pronostico(objPronosticoBE);
                    }
                    else
                    {
                        objPronosticoBC.actualizar_Pronostico(Convert.ToInt32(dg_Pronosticos["codPronostico", i].Value),
                             sPronostico, dLocal, dEmpate, dVisita);
                    }
                }*/
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void CrearFicheroARFF(List<PartidoPronosticadoBE> Data)
        {
            String fic = Application.StartupPath + "\\SISPPAFUT.arff";
            //const string fic = @"C:\Users\Michael\Documents\UPC\2012\TP1\Documentos\SISPPAFUT.arff";

            //-- fuente de la función: http://www.elguille.info/NET/dotnet/leer_escribir_ficheros_texto.htm
            System.IO.StreamWriter archivo = new StreamWriter(fic, false);

            //-- Contenido del fichero

            archivo.WriteLine("@relation SISPPAFUT");
            archivo.WriteLine("@attribute qEquiposLiga numeric");
            archivo.WriteLine("@attribute qEquiposMundial numeric");
            archivo.WriteLine("@attribute qAsistencia numeric");
            archivo.WriteLine("@attribute Local_PosLiga numeric");
            archivo.WriteLine("@attribute Local_Pts numeric");
            archivo.WriteLine("@attribute Local {TRUE, FALSE}");
            archivo.WriteLine("@attribute Local_PosRankMund numeric");
            archivo.WriteLine("@attribute Local_GoleadorSuspendido {TRUE, FALSE}");
            archivo.WriteLine("@attribute Local_ArqueroSuspendido {TRUE, FALSE}");
            archivo.WriteLine("@attribute Local_qExpulsados numeric");
            archivo.WriteLine("@attribute Local_qSuspendidos numeric");
            archivo.WriteLine("@attribute Local_GolesAnotados numeric");
            archivo.WriteLine("@attribute Local_GolesEncajados numeric");
            archivo.WriteLine("@attribute Local_PromEdad real");
            archivo.WriteLine("@attribute Local_qPartidosMes numeric");
            archivo.WriteLine("@attribute Visita_PosLiga numeric");
            archivo.WriteLine("@attribute Visita_Pts numeric");
            archivo.WriteLine("@attribute Visita {TRUE, FALSE}");
            archivo.WriteLine("@attribute Visita_PosRankMund numeric");
            archivo.WriteLine("@attribute Visita_GoleadorSuspendido {TRUE, FALSE}");
            archivo.WriteLine("@attribute Visita_ArqueroSuspendido {TRUE, FALSE}");
            archivo.WriteLine("@attribute Visita_qExpulsados numeric");
            archivo.WriteLine("@attribute Visita_qSuspendidos numeric");
            archivo.WriteLine("@attribute Visita_GolesAnotados numeric");
            archivo.WriteLine("@attribute Visita_GolesEncajados numeric");
            archivo.WriteLine("@attribute Visita_PromEdad real");
            archivo.WriteLine("@attribute Visita_qPartidosMes numeric");
            archivo.WriteLine("@attribute resultado {L, E, V}");
            archivo.WriteLine("@data");
            /*
            foreach (PartidoPronosticadoBE cDto in Data)
            {
                string _data = String.Empty;
                _data = cDto.C_QEquiposLiga + "," + cDto.C_QEquiposMundial  + "," + cDto.C_Local_PosLiga        + "," + 
                        cDto.C_Local_Pts + "," + cDto.C_Local + "," + cDto.C_Local_PosRankMund + "," + 
                        cDto.C_Local_GoleadorSuspendido + "," + cDto.C_Local_ArqueroSuspendido + "," + 
                        cDto.C_Local_QExpulsados + "," + cDto.C_Local_QSuspendidos + "," + cDto.C_Local_GolesAnotados + "," + 
                        cDto.C_Local_GolesEncajados + "," + cDto.C_Local_PromEdad + "," + cDto.C_Local_QPartidosMes + "," + 
                        cDto.C_Visita_PosLiga + "," + cDto.C_Visita_Pts + "," + cDto.C_Visita + "," + 
                        cDto.C_Visita_PosRankMund + "," + cDto.C_Visita_GoleadorSuspendido + "," + 
                        cDto.C_Visita_ArqueroSuspendido + "," + cDto.C_Visita_QExpulsados + "," + cDto.C_Visita_QSuspendidos + "," +
                        cDto.C_Visita_GolesAnotados + "," + cDto.C_Visita_GolesEncajados + "," + cDto.C_Visita_PromEdad + "," + 
                        cDto.C_Visita_QPartidosMes+cDto.C_Resultado;
                archivo.WriteLine(_data);
            }
            */

            
            //texto = sr.ReadToEnd();
            //sr.Close();

            archivo.Close();
        }

        private void inCerrar(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                e.Cancel = true;
        }

        //Metodo temporal que nos devuelve un pronostico basado en las probabilidades
        private String hallarPronostico(Decimal dLocal, Decimal dEmpate, Decimal dVisita)
        {
            String ganaLocal = "L";
            String empateEquipos = "E";
            String ganaVisita = "V";

            if (dLocal >= dEmpate && dLocal >= dVisita)
            {
                return ganaLocal;
            }
            if (dEmpate >= dLocal && dEmpate >= dVisita)
            {
                return empateEquipos;
            }
            if (dVisita >= dLocal && dVisita >= dEmpate)
            {
                return ganaVisita;
            }
            return null;
        }
    }
}
