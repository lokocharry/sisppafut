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
    public partial class frmActualizarRanking : Form
    {
        //--Variables globales
        List<PaisBE> lista_paises;
        List<EquipoBE> lista_equipos;

        public frmActualizarRanking()
        {
            InitializeComponent();
        }

        private static frmActualizarRanking frmRanking = null;
        public static frmActualizarRanking Instance()
        {
            if (frmRanking == null)
            {
                frmRanking = new frmActualizarRanking();
            }
            return frmRanking;
        }

        private void frmActualizarRanking_Load(object sender, EventArgs e)
        {
            try
            {
                iniciarPais();
                iniciarAnio();
                iniciarMes();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void iniciarPais()
        {
            try
            {
                cmbPais.Items.Clear();
                cmbPais.Items.Add("Seleccione un pais..");
                cmbPais.SelectedIndex = 0;

                lista_paises = new List<PaisBE>();
                PaisBC objPaisBC = new PaisBC();

                lista_paises = objPaisBC.listarPaises();

                for (int i = 0; i < lista_paises.Count; i++)
                {
                    PaisBE objPaisBE = lista_paises[i];
                    cmbPais.Items.Add(objPaisBE.NombrePais);
                }
            }
            catch(Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void iniciarAnio()
        {
            cmbAnio.Items.Clear();
            cmbAnio.Items.Add("Seleccione un año...");
            cmbAnio.Items.Add("2007");
            cmbAnio.Items.Add("2008");
            cmbAnio.Items.Add("2009");
            cmbAnio.Items.Add("2010");
            cmbAnio.Items.Add("2011");
            cmbAnio.Items.Add("2012");
            cmbAnio.SelectedIndex = 0;
        }

        private void iniciarMes()
        {
            cmbMes.Items.Clear();
            cmbMes.Items.Add("Seleccione un mes...");
            cmbMes.Items.Add("Enero");
            cmbMes.Items.Add("Febrero");
            cmbMes.Items.Add("Marzo");
            cmbMes.Items.Add("Abril");
            cmbMes.Items.Add("Mayo");
            cmbMes.Items.Add("Junio");
            cmbMes.Items.Add("Julio");
            cmbMes.Items.Add("Agosto");
            cmbMes.Items.Add("Setiembre");
            cmbMes.Items.Add("Octubre");
            cmbMes.Items.Add("Noviembre");
            cmbMes.Items.Add("Diciembre");
            cmbMes.SelectedIndex = 0;
        }

        private void cmbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPais.SelectedIndex > 0)
            {
                iniciarEquipos(cmbPais.SelectedItem.ToString());
            }
        }

        private void iniciarEquipos(String pais)
        {
            try
            {                
                cmbEquipo.Items.Clear();
                cmbEquipo.Items.Add("Seleccione un equipo...");
                cmbEquipo.SelectedIndex = 0;

                lista_equipos = new List<EquipoBE>();
                EquipoBC objEquipoBC = new EquipoBC();

                lista_equipos = objEquipoBC.listarEquipos(pais);

                for (int i = 0; i < lista_equipos.Count; i++)
                {
                    EquipoBE objEquipoBE = lista_equipos[i];
                    cmbEquipo.Items.Add(objEquipoBE.NombreEquipo);
                }

            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int iCodigo = 0;
                RankingEquipoBC objEquipoBC;
                RankingEquipoBE objEquipoBE;

                if (VerificarDatos())
                {
                    if (VerificarSeleccion())
                    {
                        objEquipoBE = new RankingEquipoBE();
                        objEquipoBC = new RankingEquipoBC();

                        objEquipoBE.CodigoEquipo = lista_equipos[cmbEquipo.SelectedIndex - 1].CodigoEquipo;
                        objEquipoBE.PosicionRanking = Convert.ToInt32(txtPosicion.Text);
                        objEquipoBE.AnioRanking = Convert.ToInt32(cmbAnio.Text);
                        objEquipoBE.MesRanking = cmbMes.SelectedIndex;
                        objEquipoBE.PuntosRanking = Convert.ToInt32(txtPuntos.Text);

                        iCodigo = objEquipoBC.insertar_ranking(objEquipoBE);
                        if (iCodigo == 0)
                        {
                            MessageBox.Show("Los datos no han sido registrados debido a un error.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (iCodigo == -2)
                                MessageBox.Show("Los datos han sido actualizados satisfactoriamente.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Los datos han sido registrados satisfactoriamente.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCampos();
                        }
                    }
                    else
                        MessageBox.Show("Debe elegir una fecha válida para registrar los datos.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Debe llenar todos los campos.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void LimpiarCampos()
        {
            cmbPais.SelectedIndex = 0;
            cmbEquipo.Items.Clear();
            cmbAnio.SelectedIndex = 0;
            cmbMes.SelectedIndex = 0;
            txtPosicion.Clear();
            txtPuntos.Clear();
        }

        private void inSalir(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }

        private Boolean VerificarDatos()
        {
            return (cmbPais.SelectedIndex > 0 && cmbEquipo.SelectedIndex > 0 &&
                    cmbAnio.SelectedIndex > 0 && cmbMes.SelectedIndex > 0 &&
                    txtPosicion.Text != "" && txtPuntos.Text != "");
        }

        private Boolean VerificarSeleccion()
        {
            if(Convert.ToInt32(cmbAnio.SelectedItem) < DateTime.Today.Year)
                return true;
            else
                if (Convert.ToInt32(cmbAnio.SelectedItem) == DateTime.Today.Year)
                {
                    String mes = cmbMes.SelectedItem.ToString();
                    switch (mes)
                    {
                        case "Enero": return DateTime.Today.Month > 1;
                        case "Febrero": return DateTime.Today.Month > 2;
                        case "Marzo": return DateTime.Today.Month > 3;
                        case "Abril": return DateTime.Today.Month > 4;
                        case "Mayo": return DateTime.Today.Month > 5;
                        case "Junio": return DateTime.Today.Month > 6;
                        case "Julio": return DateTime.Today.Month > 7;
                        case "Agosto": return DateTime.Today.Month > 8;
                        case "Setiembre": return DateTime.Today.Month > 9;
                        case "Octubre": return DateTime.Today.Month > 10;
                        case "Noviembre": return DateTime.Today.Month > 11;
                        case "Diciembre": return DateTime.Today.Month > 12;
                    }
                }
            return false;
                
        }

        private void ValidarEntrada(object sender, KeyPressEventArgs e)
        {
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

        private void ValidarPuntos(object sender, KeyPressEventArgs e)
        {
            //-- fuente: http://social.msdn.microsoft.com/Forums/es/vcses/thread/0bfbee6c-219e-4895-a458-ae3d59c81079 --
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtPuntos.Text.Length; i++)
            {
                if (txtPuntos.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }
    }
}
