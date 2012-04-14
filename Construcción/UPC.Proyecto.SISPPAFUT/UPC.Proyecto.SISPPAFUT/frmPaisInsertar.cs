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
            this.Close();
        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            try
            {
                int iCodigo = 0;

                PaisBE objPaidBE = new PaisBE();
                PaisBC objPaisBC = new PaisBC();

                if (ValidarCampos(txt_pais))
                {
                    objPaidBE.NombrePais = txt_pais.Text;

                    iCodigo = objPaisBC.insertarPais(objPaidBE);

                    if (iCodigo == -1)
                    {
                        MessageBox.Show("El país ya ha sido registrado anteriormente.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private bool ValidarCampos(TextBox campo)
        {
            return !(campo.Text == "");
        }
    }
}
