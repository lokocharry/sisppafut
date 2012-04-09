using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.BL.BC;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class frmLigaInsertar : Form
    {
        //-- Varibles globales
        List<PaisBE> lista_paises;
        List<EquipoBE> lista_equipos;

        private static frmLigaInsertar frmLiga = null;
        public static frmLigaInsertar Instance()
        {
            if (frmLiga == null)
            {
                frmLiga = new frmLigaInsertar();
            }
            return frmLiga;
        }

        public frmLigaInsertar()
        {
            InitializeComponent();
            iniciarPais();
            iniciarGrilla();
        }

        private void iniciarPais()
        {
            try
            {
                PaisBC objPaisBC = new PaisBC();
                lista_paises = new List<PaisBE>();
                lista_paises = objPaisBC.listarPaises();

                for (int i = 0; i < lista_paises.Count; i++)
                {
                    cmb_pais.Items.Add(lista_paises[i].NombrePais);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }
        
        private void iniciarGrilla()
        {
            try
            {
                dg_equipos.AllowUserToAddRows = false;
                dg_equipos.AllowUserToDeleteRows = false;
                dg_equipos.AllowUserToResizeColumns = false;
                dg_equipos.AllowUserToResizeRows = false;

                dg_equipos.AllowDrop = false;

                dg_equipos.MultiSelect = false; //-- Se protege la grilla para evitar seleccionar varios registros

                dg_equipos.ReadOnly = true; //-- Se protege la grilla para evitar poder modificar los datos de la grilla

                // Lo siguiente es para elegir toda la fila selecionada
                dg_equipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                dg_equipos.Columns[0].Visible = false;
                dg_equipos.Columns[1].Visible = true;
                dg_equipos.Columns[2].Visible = true;

                DataGridViewCellStyle csFilaPar = new DataGridViewCellStyle();
                DataGridViewCellStyle csFilaImpar = new DataGridViewCellStyle();

                csFilaPar.BackColor = dg_equipos.BackgroundColor;
                csFilaImpar.BackColor = dg_equipos.GridColor;

                int elemento;

                for (elemento = 0; elemento < dg_equipos.Rows.Count; elemento++)
                {
                    if (elemento % 2 == 0)
                    {
                        dg_equipos.Rows[elemento].DefaultCellStyle = csFilaPar;
                    }
                    else
                    {
                        dg_equipos.Rows[elemento].DefaultCellStyle = csFilaImpar;
                    }
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void inPaisSeleccionado(object sender, EventArgs e)
        {
            try
            {
                //-- Se lista las competiciones del país seleccionado
                CompeticionBC objCompeticionBC = new CompeticionBC();
                List<CompeticionBE> lstCompeticion = objCompeticionBC.ListarCompeticion(cmb_pais.Text);

                for (int i = 0; i < lstCompeticion.Count; i++)
                {
                    cmb_competicion.Items.Add(lstCompeticion[i].Nombre_competicion);
                }

                //-- Se listan los equipos del país seleccionado
                EquipoBC objEquipoBC = new EquipoBC();
                List<EquipoBE> lstEquipo = objEquipoBC.listarEquipos(cmb_pais.Text);

                for (int i = 0; i < lstEquipo.Count; i++)
                {
                    cmb_equipo.Items.Add(lstEquipo[i].NombreEquipo);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void inTemporada(object sender, EventArgs e)
        {
            txt_nombre.Text = String.Format("{0} {1}", cmb_competicion.Text, txt_temporada.Text);
        }

        private void inEditarNombreLiga(object sender, EventArgs e)
        {
            if (chb_editar.Checked)
            {
                txt_nombre.Enabled = true;
            }
            else
                txt_nombre.Enabled = false;
        }

        private void btnCancelar(object sender, EventArgs e)
        {
            this.Close();
        }

        private void inAgregarEquipoaLista(object sender, EventArgs e)
        {
            try
            {
                EquipoBC objEquipoBC = new EquipoBC();
                EquipoBE objEquipoBE;
                objEquipoBE = objEquipoBC.obtenerEquipo(cmb_equipo.Text);
                dg_equipos.Rows.Add(objEquipoBE.CodigoEquipo,objEquipoBE.NombreEquipo,objEquipoBE.CiudadEquipo);                
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void btnGuardarLiga(object sender, EventArgs e)
        {
            try
            {
                LigaBE objLigaBE = new LigaBE();
                LigaEquipoBE objLigaEquipoBE;
                List<LigaEquipoBE> lstEquipos = new List<LigaEquipoBE>();
                int iCodigo = 0;

                String _pais = cmb_pais.Text;
                String _competicion = cmb_competicion.Text;
                objLigaBE.TemporadaLiga = txt_temporada.Text;
                objLigaBE.NombreLiga = txt_nombre.Text;
                objLigaBE.CantidadEquipos = Convert.ToInt32(txt_cantidad.Text);

                for (int i = 0; i < dg_equipos.Rows.Count; i++)
                {
                    objLigaEquipoBE = new LigaEquipoBE();
                    objLigaEquipoBE.CodigoEquipo = Convert.ToInt32(dg_equipos.Rows[i].Cells[0].Value.ToString());
                    lstEquipos.Add(objLigaEquipoBE);
                }

                LigaBC objLigaBC = new LigaBC();
                iCodigo = objLigaBC.insertarLiga(_pais, _competicion, objLigaBE, lstEquipos);

                if (iCodigo == -1)
                {
                    MessageBox.Show("La liga ya ha sido registrada anteriormente.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    if (iCodigo == 0)
                    {
                        MessageBox.Show("La liga no ha sido registrada debido a un error.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("La liga ha sido registrada satisfactoriamente.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }
    }
}
