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
    public partial class frmAsignarJugadoresaEquipo : Form
    {
        List<PaisBE> lista_paises;
        List<EquipoBE> lista_equipos;
        List<JugadorBE> lista_jugadores;
        List<JugadorEquipoBE> lista_jugadores_equipo;
        List<JugadorEquipoBE> lista_jugadores_seleccionados;

        private static frmAsignarJugadoresaEquipo frmAsignarJugador = null;
        public static frmAsignarJugadoresaEquipo Instance()
        {
            if (frmAsignarJugador == null)
            {
                frmAsignarJugador = new frmAsignarJugadoresaEquipo();
            }
            return frmAsignarJugador;
        }

        public frmAsignarJugadoresaEquipo()
        {
            InitializeComponent();            
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }

        private void frmAsignarJugadoresaEquipo_Load(object sender, EventArgs e)
        {
            llenar_combr_paises();
            llenar_combo_jugadores();

            lista_jugadores_seleccionados = new List<JugadorEquipoBE>();
            lista_jugadores_equipo = new List<JugadorEquipoBE>();

            JugadorEquipoBC obj = new JugadorEquipoBC();
            lista_jugadores_equipo = obj.listaJugadorEquipo();

            cmb_paises.SelectedIndex = 0;
            cmb_equipos.SelectedIndex = 0;
            cmb_jugadores.SelectedIndex = 0;

            dgvPartidosConfigurar();
        }

        private void inSeleccionarPais(object sender, EventArgs e)
        {
            cmb_equipos.Items.Clear();
            cmb_equipos.Items.Add("(Elija un equipo)");

            lista_equipos = new List<EquipoBE>();

            EquipoBC objEquipoBC = new EquipoBC();
            lista_equipos = objEquipoBC.listarEquipos(cmb_paises.SelectedItem.ToString());

            for (int i = 0; i < lista_equipos.Count; i++)
            {
                cmb_equipos.Items.Add(lista_equipos[i].NombreEquipo);
            }

            cmb_equipos.SelectedIndex = 0;

            if(cmb_jugadores.Items.Count>0)
                cmb_jugadores.SelectedIndex = 0;

            dgv_jugadores.Rows.Clear();
        }

        private void llenar_combr_paises()
        {
            lista_paises = new List<PaisBE>();

            PaisBC objPaisBC = new PaisBC();
            lista_paises = objPaisBC.listarPaises();

            cmb_paises.Items.Clear();
            cmb_paises.Items.Add("(Elija un país)");
            
            for (int i = 0; i < lista_paises.Count; i++)
            {
                cmb_paises.Items.Add(lista_paises[i].NombrePais);
            }

            cmb_paises.SelectedIndex = 0;
        }

        private void llenar_combo_jugadores()
        {
            lista_jugadores = new List<JugadorBE>();

            JugadorBC objJugadorBC = new JugadorBC();
            lista_jugadores = objJugadorBC.listar_Jugadores();

            cmb_jugadores.Items.Clear();
            cmb_jugadores.Items.Add("(Elija un jugador)");

            for (int i = 0; i < lista_jugadores.Count; i++)
            {
                cmb_jugadores.Items.Add(lista_jugadores[i].Nombres + " " + lista_jugadores[i].Apellidos);
            }

            cmb_jugadores.SelectedIndex = 0;
        }

        private void btn_agregar_jugadores_Click(object sender, EventArgs e)
        {
            int pos_equipo = cmb_equipos.SelectedIndex;
            int pos_jugador = cmb_jugadores.SelectedIndex;
            bool con_equipo = false;
            bool en_lista = false;

            if(pos_jugador != 0 && pos_equipo != 0)
            {
                JugadorEquipoBE obj = new JugadorEquipoBE();
                obj.Codigo_equipo = lista_equipos[pos_equipo - 1].CodigoEquipo;
                obj.Codigo_jugador = lista_jugadores[pos_jugador - 1].CodigoJugador;

                for (int i = 0; i < lista_jugadores_equipo.Count; i++)
                    if (obj.Codigo_jugador == lista_jugadores_equipo[i].Codigo_jugador)
                    {
                        con_equipo = true;
                        break;
                    }

                for (int i = 0; i < lista_jugadores_seleccionados.Count; i++)
                    if (obj.Codigo_jugador == lista_jugadores_seleccionados[i].Codigo_jugador)
                    {
                        en_lista = true;
                        break;
                    }

                if (!con_equipo)
                {
                    if (!en_lista)
                    {
                        lista_jugadores_seleccionados.Add(obj);
                        dgvJugadoresDataBind();
                    }
                    else
                        MessageBox.Show("El jugador ya se encuentra en la lista para asignar jugadores.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("El jugador ya se encuentra registrado en un equipo.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Verifique que haya seleccionado un equipo y/o jugador.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvJugadoresDataBind()
        {
            int pos = cmb_jugadores.SelectedIndex-1;
            dgv_jugadores.Rows.Add(lista_jugadores[pos].Nombres, lista_jugadores[pos].Apellidos, lista_jugadores[pos].Nacionalidad, lista_jugadores[pos].Posicion);
        }

        private void dgvPartidosConfigurar()
        {
            dgv_jugadores.AllowUserToAddRows = false;
            dgv_jugadores.AllowUserToDeleteRows = false;

            dgv_jugadores.AllowUserToResizeColumns = false;
            dgv_jugadores.AllowUserToResizeRows = false;
            dgv_jugadores.AllowDrop = false;

            dgv_jugadores.MultiSelect = false;
            dgv_jugadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv_jugadores.ReadOnly = true;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            JugadorBC objJugadorBC;

            try
            {
                objJugadorBC = new JugadorBC();
                objJugadorBC.asignar_JugadoraEquipo(lista_jugadores_seleccionados);
            }

            catch(Exception)
            {
                throw;
            }
        }

        private void inSeleccionarEquipo(object sender, EventArgs e)
        {
            if (cmb_jugadores.Items.Count > 0)
                cmb_jugadores.SelectedIndex = 0;

            dgv_jugadores.Rows.Clear();
        }
    }
}
