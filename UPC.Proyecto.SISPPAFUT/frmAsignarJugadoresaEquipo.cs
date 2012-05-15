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
            this.Close();
        }

        private void frmAsignarJugadoresaEquipo_Load(object sender, EventArgs e)
        {
            llenar_combr_paises();
            llenar_combo_jugadores();

            lista_jugadores_seleccionados = new List<JugadorEquipoBE>();

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
        }

        private void llenar_combr_paises()
        {
            lista_paises = new List<PaisBE>();

            PaisBC objPaisBC = new PaisBC();
            lista_paises = objPaisBC.listarPaises();

            for (int i = 0; i < lista_paises.Count; i++)
            {
                cmb_paises.Items.Add(lista_paises[i].NombrePais);
            }
        }

        private void llenar_combo_jugadores()
        {
            lista_jugadores = new List<JugadorBE>();

            JugadorBC objJugadorBC = new JugadorBC();
            lista_jugadores = objJugadorBC.listar_Jugadores();

            for (int i = 0; i < lista_jugadores.Count; i++)
            {
                cmb_jugadores.Items.Add(lista_jugadores[i].Nombres + " " + lista_jugadores[i].Apellidos);
            }
        }

        private void btn_agregar_jugadores_Click(object sender, EventArgs e)
        {
            if(cmb_jugadores.SelectedIndex != 0)
            {
                JugadorEquipoBE obj = new JugadorEquipoBE();
                obj.Codigo_equipo = lista_equipos[cmb_equipos.SelectedIndex - 1].CodigoEquipo;
                obj.Codigo_jugador = lista_jugadores[cmb_jugadores.SelectedIndex - 1].CodigoJugador;

                lista_jugadores_seleccionados.Add(obj);
                dgvJugadoresDataBind();
            }   
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
    }
}
