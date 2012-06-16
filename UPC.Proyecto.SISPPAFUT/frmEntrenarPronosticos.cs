using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.BL.BC;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class frmEntrenarPronosticos : Form
    {
        //--Variables globales
        List<PartidoBE> listaPartidos;
        List<PronosticoBE> listaPronosticos;
        List<EquipoBE> listaEquipos;

        private static frmEntrenarPronosticos frmEntrenamiento = null;
        public static frmEntrenarPronosticos Instance()
        {
            if (frmEntrenamiento == null)
            {
                frmEntrenamiento = new frmEntrenarPronosticos();
            }
            return frmEntrenamiento;
        }

        public frmEntrenarPronosticos()
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

        private void listarEquipos()
        {
            //Aqui se inicia la lista de equipos para usar en la grilla
            //Este metodo es muy complejo, considerar implementar mas SP's para simplificarlo
            EquipoBC objEquipoBC = new EquipoBC();
            PaisBC objPaisBC = new PaisBC();
            listaEquipos=new List<EquipoBE>();

            List<PaisBE> listaPaises = objPaisBC.listarPaises();
            for (int i = 0; i < listaPaises.Count; i++)
            {
                listaEquipos.AddRange(objEquipoBC.listarEquipos(listaPaises[i].NombrePais));
            }
        }

        private void dg_PronosticosDataBind()
        {
            try
            {
                //Este metodo llena la grilla con la data apropiada
                //Es muy complejo, considerar implementar mas SP's para simplificarlo
                PartidoBC objPartidoBC = new PartidoBC();
                PronosticoBC objPronosticoBC = new PronosticoBC();

                listarEquipos();

                listaPartidos = new List<PartidoBE>();
                listaPronosticos = new List<PronosticoBE>();

                listaPartidos = objPartidoBC.lista_todos_partidos();
                listaPronosticos = objPronosticoBC.listar_Pronosticos();

                for (int i = 0; i < listaPartidos.Count; i++)
                {
                    PartidoBE objPartidoBE = objPartidoBC.obtener_Partido(listaPartidos[i].Codigo_partido);
                    String sEquipoLocal = "";
                    String sEquipoVisitante = "";

                    for (int j = 0; j < listaEquipos.Count; j++)
                    {
                        if (listaEquipos[j].CodigoEquipo == objPartidoBE.Codigo_equipo_local)
                        {
                            sEquipoLocal = listaEquipos[j].NombreEquipo;
                        }
                        if (listaEquipos[j].CodigoEquipo == objPartidoBE.Codigo_equipo_visitante)
                        {
                            sEquipoVisitante = listaEquipos[j].NombreEquipo;
                        }
                    }

                    for (int k = 0; k < listaPronosticos.Count; k++)
                    {
                        if (listaPronosticos[k].CodigoPartido == objPartidoBE.Codigo_partido)
                        {
                            dg_Pronosticos.Rows.Add(listaPartidos[i].Codigo_partido, listaPronosticos[k].CodigoPronostico, sEquipoLocal, sEquipoVisitante,
                                listaPronosticos[k].PorcentajeLocal, listaPronosticos[k].PorcentajeEmpate, listaPronosticos[k].PorcentajeVisita,
                                listaPronosticos[k].Pronostico);
                        }
                    }
                    dg_Pronosticos.Rows.Add(listaPartidos[i].Codigo_partido, null, sEquipoLocal, sEquipoVisitante, null, null, null, null);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void btnEntrenar_Click(object sender, EventArgs e)
        {
            //Este metodo es temporal, solo ingresa data aleatoria a la tabla de pronosticos.
            //Si no existe pronostico de un partido, entonces crea uno nuevos,
            //si existe un pronostico anterior, lo actualiza(sobreescribe).
            try
            {
                PronosticoBC objPronosticoBC;
                PronosticoBE objPronosticoBE;
                Decimal dLocal;
                Decimal dEmpate;
                Decimal dVisita;
                Random objRandom;
                String sPronostico;

                for (int i = 0; i < dg_Pronosticos.Rows.Count; i++)
                {
                    objPronosticoBC = new PronosticoBC();
                    objRandom=new Random();
                    dLocal = Convert.ToDecimal(objRandom.Next(100));
                    objRandom = new Random();
                    dEmpate = Convert.ToDecimal(objRandom.Next(100));
                    objRandom = new Random();
                    dVisita = Convert.ToDecimal(objRandom.Next(100));
                    sPronostico = hallarPronostico(dLocal,dEmpate,dVisita);

                    if (dg_Pronosticos["porcentajeLocal", i] == null && dg_Pronosticos["porcentajeEmpate", i] == null
                        && dg_Pronosticos["porcentajeVisita", i] == null)
                    {
                        objPronosticoBE = new PronosticoBE();
                        objPronosticoBE.CodigoPartido = Convert.ToInt32(dg_Pronosticos["Codigo", i]);
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
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
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
