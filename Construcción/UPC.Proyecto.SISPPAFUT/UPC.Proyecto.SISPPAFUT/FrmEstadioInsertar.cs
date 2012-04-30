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
    public partial class frmEstadioInsertar : Form
    {
        //--Área de variables globales
        List<PaisBE> lista_paises;

        private static frmEstadioInsertar frmEstadio = null;
        public static frmEstadioInsertar Instance()
        {
            if (frmEstadio == null)
            {
                frmEstadio = new frmEstadioInsertar();
            }
            return frmEstadio;
        }

        public frmEstadioInsertar()
        {
            InitializeComponent();
            iniciarPais();
            iniciarAnio();
        }
        
        private void iniciarPais()
        {
            try
            {
                cmb_pais.Items.Clear();
                cmb_pais.Items.Add("(Seleccione un país...)");
                cmb_pais.SelectedIndex = 0;
                lista_paises = new List<PaisBE>();
                PaisBC objPaisBC = new PaisBC();
                
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

        private void iniciarAnio()
        {
            cmb_anho.Items.Clear();
            cmb_anho.Items.Add("(Seleccione un año...)");
            cmb_anho.SelectedIndex = 0;
            for (int i = 1857; i < 2013; i++)
            {
                cmb_anho.Items.Add(i.ToString());
            }
        }
        
        private void btn_GuardarEstadio(object sender, EventArgs e)
        {
            try
            {
                int codigo = 0;

                EstadioBE objEstadioBE;

                if (ValidarCampos())
                {
                    if (Convert.ToInt32(txt_aforo.Text) >= 1000)
                    {
                        objEstadioBE = new EstadioBE();

                        objEstadioBE.Codigo_pais = lista_paises[cmb_pais.SelectedIndex - 1].CodigoPais;
                        objEstadioBE.Anho_fundacion = Convert.ToInt32(cmb_anho.Items[cmb_anho.SelectedIndex]);
                        objEstadioBE.Nombre_estadio = txt_nombre.Text;
                        objEstadioBE.Ciudad_estadio = txt_ciudad.Text;
                        objEstadioBE.Aforo_estadio = Convert.ToInt32(txt_aforo.Text);

                        EstadioBC objEstadioBC = new EstadioBC();
                        codigo = objEstadioBC.insertar_Estadio(objEstadioBE);

                        if (codigo != 0)
                        {
                            MessageBox.Show("El estadio ha sido registrada satisfactoriamente.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("El estadio no ha sido registrada debido a un error.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("El aforo mínimo de un estadio de fútbol es 1000 personas.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void btn_Cancelar(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }

        private bool ValidarCampos()
        {
            return (!(txt_nombre.Text == "") && !(txt_ciudad.Text == "") 
                    && !(txt_aforo.Text == "") && (cmb_anho.SelectedIndex>=0) && (cmb_pais.SelectedIndex>=0));
        }

        private void ValidarCampoNombre(object sender, KeyPressEventArgs e)
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
            else if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else
            {
                e.Handled = true;
            }
        }

        private void ValidarCampoCiudad(object sender, KeyPressEventArgs e)
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

        private void ValidarCampoAforo(object sender, KeyPressEventArgs e)
        {
            //-- fuente: http://social.msdn.microsoft.com/Forums/es/vcses/thread/0bfbee6c-219e-4895-a458-ae3d59c81079 --
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void LimpiarCampos()
        {
            txt_aforo.Clear();
            txt_ciudad.Clear();
            txt_nombre.Clear();
            iniciarPais();
            iniciarAnio();
        }
    }
}
