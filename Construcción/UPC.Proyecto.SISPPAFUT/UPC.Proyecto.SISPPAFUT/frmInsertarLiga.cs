using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.BL.BC;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class frmInsertarLiga : Form
    {
        //-- Varibles globales
        List<PaisBE> lista_paises;
        List<EquipoBE> lista_equipos;

        private static frmInsertarLiga frmLiga = null;
        public static frmInsertarLiga Instance()
        {
            if (frmLiga == null)
            {
                frmLiga = new frmInsertarLiga();
            }
            return frmLiga;
        }

        public frmInsertarLiga()
        {
            InitializeComponent();
            iniciarPais();
            iniciarGrilla();
            iniciarControles();
        }

        private void iniciarPais()
        {
            try
            {
                PaisBC objPaisBC = new PaisBC();
                lista_paises = new List<PaisBE>();
                lista_paises = objPaisBC.listarPaises();

                cmb_pais.Items.Clear();
                cmb_pais.Items.Add("Seleccione un pais...");
                cmb_pais.SelectedIndex = 0;

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

        private void iniciarControles()
        {
            cmb_competicion.Enabled = false;
            txt_temporada.Enabled = false;
            txt_cantidad.Enabled = false;
            txt_cantidad.Enabled = false;
            cmb_equipo.Enabled = false;
            btn_agregarEquipo.Enabled = false;
            chb_editar.Enabled = false;
            btn_agregarEquipo.Enabled = false;
        }

        private void inPaisSeleccionado(object sender, EventArgs e)
        {
            try
            {
                //-- Se lista las competiciones del país seleccionado
                CompeticionBC objCompeticionBC = new CompeticionBC();
                if (cmb_pais.SelectedIndex > 0)
                {                    
                    List<CompeticionBE> lstCompeticion = objCompeticionBC.ListarCompeticion(cmb_pais.Text);

                    if (lstCompeticion.Count != 0)
                    {
                        cmb_competicion.Items.Clear();

                        for (int i = 0; i < lstCompeticion.Count; i++)
                        {
                            cmb_competicion.Items.Add(lstCompeticion[i].Nombre_competicion);
                        }

                        //-- Se listan los equipos del país seleccionado
                        EquipoBC objEquipoBC = new EquipoBC();
                        List<EquipoBE> lstEquipo = objEquipoBC.listarEquipos(cmb_pais.Text);

                        cmb_equipo.Items.Clear();

                        for (int i = 0; i < lstEquipo.Count; i++)
                        {
                            cmb_equipo.Items.Add(lstEquipo[i].NombreEquipo);
                        }

                        //Se habilita el siguiente comboBox
                        cmb_competicion.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("El país seleccionado no dispone de ligas para mostrar.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmb_pais.SelectedIndex = 0;
                    }
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

            //Se habilita el checkbox de edicion del Nombre
            chb_editar.Enabled = true;
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

        private void inAgregarEquipoaLista(object sender, EventArgs e)
        {
            try
            {
                EquipoBC objEquipoBC;
                EquipoBE objEquipoBE;

                if (cmb_equipo.SelectedIndex >= 0)
                {
                    if (!EquipoExisteEnLista(cmb_equipo.Text))
                    {
                        objEquipoBC = new EquipoBC();
                        objEquipoBE = objEquipoBC.obtenerEquipo(cmb_equipo.Text);
                        dg_equipos.Rows.Add(objEquipoBE.CodigoEquipo, objEquipoBE.NombreEquipo, objEquipoBE.CiudadEquipo);
                    }
                    else
                        MessageBox.Show("Equipo seleccionado ya está en la lista.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Debe elegir un equipo de fútbol.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private bool EquipoExisteEnLista(String nombre)
        {
            for (int i = 0; i < dg_equipos.Rows.Count; i++)
            {
                if (dg_equipos.Rows[i].Cells[1].Value.ToString() == nombre)
                    return true;
            }
            return false;
        }

        private void btnGuardarLiga(object sender, EventArgs e)
        {
            try
            {
                int iCodigo = 0;
                LigaBE objLigaBE;
                LigaEquipoBE objLigaEquipoBE;
                List<LigaEquipoBE> lstEquipos;

                if (ValidarCampos())
                {
                    objLigaBE = new LigaBE();
                    lstEquipos = new List<LigaEquipoBE>();

                    String _pais = cmb_pais.Text;
                    String _competicion = cmb_competicion.Text;
                    objLigaBE.TemporadaLiga = txt_temporada.Text;
                    objLigaBE.NombreLiga = txt_nombre.Text;
                    objLigaBE.CantidadEquipos = Convert.ToInt32(txt_cantidad.Text);

                    if (dg_equipos.Rows.Count == objLigaBE.CantidadEquipos)
                    {
                        if (objLigaBE.CantidadEquipos >= 2)
                        {
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
                                    LimpiarCampos();
                                }
                        }
                        else
                        {
                            MessageBox.Show("La cantidad de equipos de una la liga debe contener al menos 2 equipos.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La cantidad de equipos seleccionados debe ser igual a la cantidad de equipos que componen la liga.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private bool ValidarCampos()
        {
            return ((cmb_pais.SelectedIndex >= 1) && (cmb_competicion.SelectedIndex >= 0) 
                    && !(txt_temporada.Text == "") && !(txt_nombre.Text == "") && !(txt_cantidad.Text == ""));
        }
        
        private void ValidarEntradaNumerica(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            int nroDec = 0;

            for (int i = 0; i < txt_cantidad.Text.Length; i++)
            {
                if (nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void LimpiarCampos()
        {
            txt_cantidad.Clear();
            txt_nombre.Clear();
            txt_temporada.Clear();
            chb_editar.CheckState = CheckState.Unchecked;
            iniciarPais();
            cmb_competicion.Items.Clear();
            cmb_equipo.Items.Clear();
            dg_equipos.Rows.Clear();
        }

        private void ValidarTemporada(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txt_temporada.Text.Length; i++)
            {
                if (txt_temporada.Text[i] == '/')
                    IsDec = true;

                if (IsDec && nroDec++ >= 4)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 47)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void inCambiarSeleccionPais(object sender, EventArgs e)
        {
            int pais_select = cmb_pais.SelectedIndex;
            LimpiarCampos();
            cmb_pais.SelectedIndex = pais_select;            
        }

        private void inCambiarSeleccionCompeticion(object sender, EventArgs e)
        {
            int pais_select = cmb_pais.SelectedIndex;
            int competicion_select = cmb_competicion.SelectedIndex;
            LimpiarCampos();
            cmb_pais.SelectedIndex = pais_select;
            cmb_competicion.SelectedIndex = competicion_select;

            //Se habilita la edicion del nombre de la temporada y la cantidad de equipos
            txt_temporada.Enabled = true;
            txt_cantidad.Enabled = true;
        }

        private void txt_cantidad_TextChanged(object sender, EventArgs e)
        {
            if (txt_cantidad.Text == "")
            {
                btn_agregarEquipo.Enabled = false;
                cmb_equipo.Enabled = false;
            }
            else
            {
                //Se habilita el poder agregar equipos
                btn_agregarEquipo.Enabled = true;
                cmb_equipo.Enabled = true;
            }
        }

        private void dg_equipos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    dg_equipos.Rows.RemoveAt(dg_equipos.SelectedRows[0].Index);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void inCerrar(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                e.Cancel = true;
        }
    }
}