using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using UPC.Proyecto.SISPPAFUT.BL.BC;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class frmCompeticionInsertar : Form
    {
        private static frmCompeticionInsertar frmCompeticion = null;
        public static frmCompeticionInsertar Instance()
        {
            if (frmCompeticion == null)
            {
                frmCompeticion = new frmCompeticionInsertar();
            }
            return frmCompeticion;
        }

        public frmCompeticionInsertar()
        {
            InitializeComponent();
        }

        private void FrmCompeticionInsertar_Load(object sender, EventArgs e)
        {
            IniciarPais();
        }

        private void IniciarPais()
        {
            try
            {
                PaisBC objPaisBC = new PaisBC();
                List<PaisBE> lista_paises = objPaisBC.listarPaises();

                cmb_paises.Items.Clear();

                for (int i = 0; i < lista_paises.Count; i++)
                {
                    cmb_paises.Items.Add(lista_paises[i].NombrePais);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void btn_GuardarCompeticion(object sender, EventArgs e)
        {
            try
            {
                int codigo = 0;

                CompeticionBE objCompeticionBE;
                CompeticionBC objCompeticionBC;

                if (ValidarCampos())
                {
                    objCompeticionBE = new CompeticionBE();

                    objCompeticionBE.Codigo_pais = Convert.ToInt32(cmb_paises.SelectedIndex + 1);
                    objCompeticionBE.Nombre_competicion = txt_nombre.Text;

                    objCompeticionBC = new CompeticionBC();
                    codigo = objCompeticionBC.insertar_Competicion(objCompeticionBE);

                    if (codigo != 0)
                    {
                        MessageBox.Show("La Competición ha sido registrada satisfactoriamente.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("La Competición no ha sido registrada por un error interno.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btn_Salir(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }

        private bool ValidarCampos()
        {
            return (!(txt_nombre.Text == "") && cmb_paises.SelectedIndex>=0);
        }

        private void ValidarEntradaTexto(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void LimpiarCampos()
        {
            txt_nombre.Clear();
            IniciarPais();
        }
    }
}
