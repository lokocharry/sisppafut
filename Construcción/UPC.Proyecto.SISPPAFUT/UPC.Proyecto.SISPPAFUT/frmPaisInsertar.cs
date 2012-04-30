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
    public partial class frmPaisInsertar : Form
    {
        private static frmPaisInsertar frmPais = null;
        public static frmPaisInsertar Instance()
        {
            if (frmPais == null)
            {
                frmPais = new frmPaisInsertar();
            }
            return frmPais;
        }

        public frmPaisInsertar()
        {
            InitializeComponent();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if(MessageBox.Show("¿Seguro que desea salir? Hay datos que no han sido guardados.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==System.Windows.Forms.DialogResult.Yes)
                    this.Close();
            }
            else
                this.Close();
        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            try
            {
                int iCodigo = 0;

                PaisBE objPaidBE = new PaisBE();
                PaisBC objPaisBC = new PaisBC();

                if (ValidarCampos())
                {
                    objPaidBE.NombrePais = txt_pais.Text;

                    iCodigo = objPaisBC.insertarPais(objPaidBE);

                    if (iCodigo == -1)
                    {
                        MessageBox.Show("El país ya ha sido registrado anteriormente.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos();
                    }
                    else
                        if (iCodigo == 0)
                        {
                            MessageBox.Show("El país no ha sido registrada debido a un error.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("El país ha sido registrado satisfactoriamente.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                }
                else
                    MessageBox.Show("Todos los campos son obligatorios.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private bool ValidarCampos()
        {
            return !(txt_pais.Text == "");
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
            txt_pais.Clear();
        }
    }
}
