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
    public partial class frmInsertarEquipo : Form
    {
        private List<PaisBE> listaPaises;
        private List<EstadioBE> listaEstadios;
        private String _NombreEquipo;
        private int _Modo; //Indica el modo en que se inicia el formulario 1-Registrar 2-Editar
        public int Modo
        {
            get { return _Modo; }
            set { _Modo = value; }
        }
        public String NombreEquipo
        {
            get { return _NombreEquipo; }
            set { _NombreEquipo = value; }
        }

        private static frmInsertarEquipo frmEquipo = null;
        public static frmInsertarEquipo Instance()
        {
            if (frmEquipo == null)
            {
                frmEquipo = new frmInsertarEquipo();
            }
            return frmEquipo;
        }

        public frmInsertarEquipo()
        {
            InitializeComponent();
        }

        private void frmEquipoInsert()
        {
            iniciarPais();
            iniciarAnio();
        }

        private void frmEquipoEditar()
        {
            iniciarPais();
            llenarDatosEquipo();
        }

        private void llenarDatosEquipo()
        {
            EquipoBC objEquipoBC = new EquipoBC();
            PaisBC objPaisBC=new PaisBC();
            EquipoBE objEquipoBE = objEquipoBC.obtenerEquipo(_NombreEquipo);

            txt_nombre.Text = objEquipoBE.NombreEquipo;
            for (int i = 0; i < listaPaises.Count; i++)
            {
                if (listaPaises[i].CodigoPais == objEquipoBE.CodigoPais)
                {
                    cmb_pais.SelectedIndex = i+1;
                }
            }
            cmb_anio.Items.Clear();
            cmb_anio.Items.Add(objEquipoBE.AnioFundacion.ToString());
            cmb_anio.SelectedIndex = 0;
            txt_ciudad.Text = objEquipoBE.CiudadEquipo;

            iniciarEstadios();

            for (int i = 0; i < listaEstadios.Count; i++)
            {
                if (listaEstadios[i].Codigo_estadio == objEquipoBE.CodigoEstadioPrincipal)
                {
                    cmb_estadioPrincipal.SelectedIndex = i + 1;
                }
            }
            for (int i = 0; i < listaEstadios.Count; i++)
            {
                if (listaEstadios[i].Codigo_estadio == objEquipoBE.CodigoEstadioAlterno)
                {
                    cmb_estadioAlterno.SelectedIndex = i + 1;
                }
            }
        }

        private void iniciarControles()
        {
            if (_Modo == 1)
            {
                lbl_titulo.Text = "Registro de Equipos";
                txt_nombre.Enabled = true;
                cmb_pais.Enabled = true;
                cmb_anio.Enabled = true;
                txt_ciudad.Enabled = true;
                cmb_estadioPrincipal.Enabled = true;
                cmb_estadioAlterno.Enabled = true;
            }
            if (_Modo == 2)
            {
                lbl_titulo.Text = "Actualizacion de Equipo";
                txt_nombre.Enabled = false;
                cmb_pais.Enabled = false;
                cmb_anio.Enabled = false;
                txt_ciudad.Enabled = false;
                cmb_estadioPrincipal.Enabled = true;
                cmb_estadioAlterno.Enabled = true;
            }
        }

        private void iniciarModo()
        {
            switch (_Modo)
            {
                case 1: //Insertar
                    frmEquipoInsert();
                    break;
                case 2: //Editar
                    frmEquipoEditar();
                    break;
            }
        }


        private void iniciarPais()
        {
            try
            {
                cmb_pais.Items.Clear();
                cmb_pais.Items.Add("(Seleccione un país...)");
                cmb_pais.SelectedIndex = 0;
                listaPaises = new List<PaisBE>();
                PaisBC objPaisBC = new PaisBC();

                listaPaises = objPaisBC.listarPaises();                

                for (int i = 0; i < listaPaises.Count; i++)
                {
                    PaisBE objPais = listaPaises[i];
                    cmb_pais.Items.Add(objPais.NombrePais);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void iniciarAnio()
        {
            cmb_anio.Items.Clear();
            cmb_anio.Items.Add("(Seleccione un país)");
            cmb_anio.SelectedIndex = 0;
            for (int i = 1857; i < 2013; i++)
            {
                cmb_anio.Items.Add(i.ToString());
            }
        }

        private void iniciarEstadios()
        {
            try
            {
                cmb_estadioPrincipal.Items.Clear();
                cmb_estadioAlterno.Items.Clear();
                cmb_estadioPrincipal.Items.Add("(Seleccione un estadio...)");
                cmb_estadioAlterno.Items.Add("(Seleccione un estadio...)");
                cmb_estadioPrincipal.SelectedIndex = 0;
                cmb_estadioAlterno.SelectedIndex = 0;

                listaEstadios = new List<EstadioBE>();
                EstadioBC objEstadioBC = new EstadioBC();

                listaEstadios = objEstadioBC.listarEstadiosDePais(listaPaises[cmb_pais.SelectedIndex - 1].CodigoPais);

                for (int i = 0; i < listaEstadios.Count; i++)
                {
                    EstadioBE objEstadio = listaEstadios[i];
                    cmb_estadioPrincipal.Items.Add(objEstadio.Nombre_estadio);
                    cmb_estadioAlterno.Items.Add(objEstadio.Nombre_estadio);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void brn_Cancelar(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }

        private void btn_GuardarEquipo(object sender, EventArgs e)
        {
            if (_Modo == 1)
            {
                guardarEquipo();
            }
            if (_Modo == 2)
            {
                editarEquipo();
                frmEditarEquipo frm = frmEditarEquipo.Instance();
                frm.iniciarEquipos();
                this.Close();
            }
        }

        private void editarEquipo()
        {
            try
            {
                int iCodigo = 0;
                EquipoBE objEquipoBE;
                EquipoBC objEquipoBC;

                if (ValidarCampos())
                {
                    objEquipoBC = new EquipoBC();
                    objEquipoBE = objEquipoBC.obtenerEquipo(txt_nombre.Text);

                    iCodigo = objEquipoBE.CodigoEquipo;
                    if (cmb_estadioPrincipal.SelectedIndex > 0)
                    {
                        objEquipoBE.CodigoEstadioPrincipal = listaEstadios[cmb_estadioPrincipal.SelectedIndex - 1].Codigo_estadio;
                    }
                    if (cmb_estadioAlterno.SelectedIndex > 0)
                    {
                        objEquipoBE.CodigoEstadioAlterno = listaEstadios[cmb_estadioAlterno.SelectedIndex - 1].Codigo_estadio;
                    }

                    if (cmb_estadioPrincipal.SelectedIndex == 0)
                    {
                        MessageBox.Show("El equipo debe tener un estadio designado.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        objEquipoBC.actualizarEquipo(iCodigo, objEquipoBE.CodigoEstadioPrincipal, objEquipoBE.CodigoEstadioAlterno);
                        MessageBox.Show("El equipo ha sido actualizado satisfactoriamente.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void guardarEquipo()
        {
            try
            {
                int iCodigo = 0;

                EquipoBE objEquipoBE;
                EquipoBC objEquipoBC;

                if (ValidarCampos())
                {
                    objEquipoBE = new EquipoBE();
                    objEquipoBC = new EquipoBC();

                    objEquipoBE.CodigoPais = listaPaises[cmb_pais.SelectedIndex - 1].CodigoPais;
                    objEquipoBE.NombreEquipo = txt_nombre.Text;
                    objEquipoBE.AnioFundacion = Convert.ToInt32(cmb_anio.SelectedItem.ToString());
                    objEquipoBE.CiudadEquipo = txt_ciudad.Text;
                    objEquipoBE.CodigoEstadioPrincipal = listaEstadios[cmb_estadioPrincipal.SelectedIndex - 1].Codigo_estadio;
                    if (cmb_estadioAlterno.SelectedIndex > 0)
                        objEquipoBE.CodigoEstadioAlterno = listaEstadios[cmb_estadioAlterno.SelectedIndex - 1].Codigo_estadio;
                    else
                        objEquipoBE.CodigoEstadioAlterno = 0;

                    iCodigo = objEquipoBC.insertarEquipo(objEquipoBE);

                    if (iCodigo == -1)
                    {
                        MessageBox.Show("El equipo ya ha sido registrado anteriormente.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        if (iCodigo == 0 || objEquipoBE.CodigoEstadioPrincipal == objEquipoBE.CodigoEstadioAlterno)
                        {
                            MessageBox.Show("El equipo no ha sido registrada debido a un error.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("El equipo ha sido registrado satisfactoriamente.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCampos();
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
            return (!(txt_nombre.Text == "") && !(txt_ciudad.Text == "") 
                    && (cmb_pais.SelectedIndex >= 0) && (cmb_anio.SelectedIndex >= 0) 
                    && (cmb_estadioPrincipal.SelectedIndex >= 0) && (cmb_estadioAlterno.SelectedIndex >= 0));
        }

        private void cmb_pais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_pais.SelectedIndex > 0 && _Modo == 1)
            {
                iniciarEstadios();
            }
        }

        private void frmEquipoInsertar_Load(object sender, EventArgs e)
        {
            try
            {
                iniciarControles();
                iniciarModo();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void LimpiarCampos()
        {
            txt_ciudad.Clear();
            txt_nombre.Clear();
            iniciarAnio();
            iniciarPais();
            cmb_estadioPrincipal.Items.Clear();
            cmb_estadioAlterno.Items.Clear();
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
    }
}
