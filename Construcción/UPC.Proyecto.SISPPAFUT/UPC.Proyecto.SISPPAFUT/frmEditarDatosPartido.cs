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
    public partial class frmEditarDatosPartido : Form
    {
        private int _codigo_partido;

        public int Codigo_partido
        {
            get { return _codigo_partido; }
            set { _codigo_partido = value; }
        }

        private String _equipo_local;

        public String Equipo_local
        {
            get { return _equipo_local; }
            set { _equipo_local = value; }
        }

        private String _equipo_visita;

        public String Equipo_visita
        {
            get { return _equipo_visita; }
            set { _equipo_visita = value; }
        }

        private PartidoBE objPartidoBE;
        private List<JugadorBE> lista_equipo_local;
        private List<JugadorBE> lista_equipo_visita;
        private List<AmonestacionBE> lista_amonestaciones;

        private static frmEditarDatosPartido frm = null;
        
        public static frmEditarDatosPartido Instance()
        {
            if (frm == null)
            {
                frm = new frmEditarDatosPartido();
            }
            return frm;
        }

        public frmEditarDatosPartido()
        {
            InitializeComponent();
            iniciarGrillaEquipoLocal();
            iniciarGrillaEquipoVisitante();
        }

        public void iniciarGrillaEquipoLocal()
        {
            try
            {
                dgv_equipo_local.AllowUserToAddRows = false;
                dgv_equipo_local.AllowUserToDeleteRows = false;
                dgv_equipo_local.AllowUserToResizeColumns = false;
                dgv_equipo_local.AllowUserToResizeRows = false;

                dgv_equipo_local.AllowDrop = false;

                dgv_equipo_local.MultiSelect = false; //-- Se protege la grilla para evitar seleccionar varios registros

                //dgv_equipo_local.ReadOnly = true; //-- Se protege la grilla para evitar poder modificar los datos de la grilla

                // Lo siguiente es para elegir toda la fila selecionada
                dgv_equipo_local.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                dgv_equipo_local.Columns[0].Visible = false;
                dgv_equipo_local.Columns[1].Visible = true;
                dgv_equipo_local.Columns[2].Visible = true;
                dgv_equipo_local.Columns[3].Visible = false;
                dgv_equipo_local.Columns[4].Visible = false;
                dgv_equipo_local.Columns[5].Visible = true;
                dgv_equipo_local.Columns[6].Visible = false;
                dgv_equipo_local.Columns[7].Visible = false;
                dgv_equipo_local.Columns[8].Visible = true;
                dgv_equipo_local.Columns[9].Visible = true;

                DataGridViewCellStyle csFilaPar = new DataGridViewCellStyle();
                DataGridViewCellStyle csFilaImpar = new DataGridViewCellStyle();

                csFilaPar.BackColor = dgv_equipo_local.BackgroundColor;
                csFilaImpar.BackColor = dgv_equipo_local.GridColor;

                int elemento;

                for (elemento = 0; elemento < dgv_equipo_local.Rows.Count; elemento++)
                {
                    if (elemento % 2 == 0)
                    {
                        dgv_equipo_local.Rows[elemento].DefaultCellStyle = csFilaPar;
                    }
                    else
                    {
                        dgv_equipo_local.Rows[elemento].DefaultCellStyle = csFilaImpar;
                    }
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        public void iniciarGrillaEquipoVisitante()
        {
            try
            {
                dgv_equipo_visitante.AllowUserToAddRows = false;
                dgv_equipo_visitante.AllowUserToDeleteRows = false;
                dgv_equipo_visitante.AllowUserToResizeColumns = false;
                dgv_equipo_visitante.AllowUserToResizeRows = false;

                dgv_equipo_visitante.AllowDrop = false;

                dgv_equipo_visitante.MultiSelect = false; //-- Se protege la grilla para evitar seleccionar varios registros

                //dgv_equipo_visitante.ReadOnly = true; //-- Se protege la grilla para evitar poder modificar los datos de la grilla

                // Lo siguiente es para elegir toda la fila selecionada
                dgv_equipo_visitante.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                dgv_equipo_visitante.Columns[0].Visible = false;
                dgv_equipo_visitante.Columns[1].Visible = true;
                dgv_equipo_visitante.Columns[2].Visible = true;
                dgv_equipo_visitante.Columns[3].Visible = false;
                dgv_equipo_visitante.Columns[4].Visible = false;
                dgv_equipo_visitante.Columns[5].Visible = true;
                dgv_equipo_visitante.Columns[6].Visible = false;
                dgv_equipo_visitante.Columns[7].Visible = false;
                dgv_equipo_visitante.Columns[8].Visible = true;
                dgv_equipo_visitante.Columns[9].Visible = true;

                DataGridViewCellStyle csFilaPar = new DataGridViewCellStyle();
                DataGridViewCellStyle csFilaImpar = new DataGridViewCellStyle();

                csFilaPar.BackColor = dgv_equipo_visitante.BackgroundColor;
                csFilaImpar.BackColor = dgv_equipo_visitante.GridColor;

                int elemento;

                for (elemento = 0; elemento < dgv_equipo_visitante.Rows.Count; elemento++)
                {
                    if (elemento % 2 == 0)
                    {
                        dgv_equipo_visitante.Rows[elemento].DefaultCellStyle = csFilaPar;
                    }
                    else
                    {
                        dgv_equipo_visitante.Rows[elemento].DefaultCellStyle = csFilaImpar;
                    }
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void setearCombos()
        {
            cmb_amonestaciones_equipo.SelectedIndex = 0;
            cmb_amonestaciones_jugador.SelectedIndex = 0;
            cmb_amonestaciones_minuto.SelectedIndex = 0;
            cmb_amonestaciones_amonestacion.SelectedIndex = 0;

            cmb_goles_equipos.SelectedIndex = 0;
            cmb_goles_jugadores.SelectedIndex = 0;
            cmb_goles_minuto.SelectedIndex = 0;

            cmb_lesiones_equipos.SelectedIndex = 0;
            cmb_lesiones_jugadores.SelectedIndex = 0;
            cmb_lesiones_minuto.SelectedIndex = 0;
        }

        private void llenarCombos()
        {
            cmb_amonestaciones_equipo.Items.Add(Equipo_local);
            cmb_amonestaciones_equipo.Items.Add(Equipo_visita);

            cmb_goles_equipos.Items.Add(Equipo_local);
            cmb_goles_equipos.Items.Add(Equipo_visita);

            cmb_lesiones_equipos.Items.Add(Equipo_local);
            cmb_lesiones_equipos.Items.Add(Equipo_visita);
        }

        private void EditarDatosPartido_Load(object sender, EventArgs e)
        {
            lista_equipo_local = new List<JugadorBE>();
            lista_equipo_visita = new List<JugadorBE>();
            lista_amonestaciones = new List<AmonestacionBE>();

            lbl_equipo_local.Text = Equipo_local;
            lbl_equipo_visitante.Text = Equipo_visita;

            obtenerPartido();

            dgvJugadoresDataBind();
            setearCombos();
            llenarCombos();
        }

        public void obtenerPartido()
        {
            PartidoBC objPartidoBC = new PartidoBC();
            objPartidoBE = objPartidoBC.obtener_Partido(Codigo_partido);
        }

        private void dgvJugadoresDataBind()
        {
            JugadorBC objJugadorBC = new JugadorBC();

            lista_equipo_local = objJugadorBC.listar_Jugadores_xEquipo(objPartidoBE.Codigo_equipo_local);
            lista_equipo_visita = objJugadorBC.listar_Jugadores_xEquipo(objPartidoBE.Codigo_equipo_visitante);

            dgv_equipo_local.DataSource = objJugadorBC.listar_Jugadores_xEquipo(objPartidoBE.Codigo_equipo_local);
            dgv_equipo_visitante.DataSource = objJugadorBC.listar_Jugadores_xEquipo(objPartidoBE.Codigo_equipo_visitante);
        }

        private void cmb_amonestaciones_equipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenar_comboJugadores(cmb_amonestaciones_equipo, cmb_amonestaciones_jugador);
        }

        private void cmb_goles_equipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenar_comboJugadores(cmb_goles_equipos, cmb_goles_jugadores); 
        }

        private void cmb_lesiones_equipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenar_comboJugadores(cmb_lesiones_equipos, cmb_lesiones_jugadores);
        }

        private void llenar_comboJugadores(ComboBox combo_equipos, ComboBox combo_jugadores)
        {
            combo_jugadores.Items.Clear();
            combo_jugadores.Items.Add("(Seleccione jugador)");

            if (combo_equipos.SelectedIndex == 1)
            {
                for (int i = 0; i < lista_equipo_local.Count; i++)
                    combo_jugadores.Items.Add(lista_equipo_local[i].Nombres + " " + lista_equipo_local[i].Apellidos);
            }

            if (combo_equipos.SelectedIndex == 2)
            {
                for (int i = 0; i < lista_equipo_visita.Count; i++)
                    combo_jugadores.Items.Add(lista_equipo_visita[i].Nombres + " " + lista_equipo_visita[i].Apellidos);
            }

            combo_jugadores.SelectedIndex = 0;
        }

        private void btn_amonestaciones_agregar_Click(object sender, EventArgs e)
        {
            int equipo = cmb_amonestaciones_equipo.SelectedIndex;

            AmonestacionBE objAmonestacionBE = new AmonestacionBE();

            objAmonestacionBE.Codigo_partido = Codigo_partido;
            objAmonestacionBE.Codigo_jugador = dame_codigo_jugador(equipo);
            objAmonestacionBE.Minuto = Convert.ToInt32(cmb_amonestaciones_minuto.SelectedIndex - 1);
            objAmonestacionBE.Tipo = cmb_amonestaciones_amonestacion.SelectedIndex;

            dgv_amonestaciones.Rows.Add(dame_nombre_jugador(cmb_amonestaciones_equipo.SelectedIndex), cmb_amonestaciones_equipo.SelectedItem, cmb_amonestaciones_amonestacion.SelectedItem, cmb_amonestaciones_minuto.SelectedItem);

            lista_amonestaciones.Add(objAmonestacionBE);
        }

        private int dame_codigo_jugador(int pos_equipo)
        {
            int code;

            if (pos_equipo == 1)
                code = lista_equipo_local[cmb_amonestaciones_jugador.SelectedIndex - 1].CodigoJugador;

            else if (pos_equipo == 2)
                code = lista_equipo_visita[cmb_amonestaciones_jugador.SelectedIndex - 1].CodigoJugador;

            else
                code = 0;

            return code;
        }

        private String dame_nombre_jugador(int pos_equipo)
        {
            String nombre;
            int posicion = cmb_amonestaciones_jugador.SelectedIndex - 1;

            if (pos_equipo == 1)
                nombre = lista_equipo_local[posicion].Nombres + " " + lista_equipo_local[posicion].Apellidos;
            else if (pos_equipo == 2)
                nombre = lista_equipo_visita[posicion].Nombres + " " + lista_equipo_visita[posicion].Apellidos;
            else
                nombre = "";

            return nombre;
        }

        private void btn_guardar_datos_Click(object sender, EventArgs e)
        {
            AmonestacionBC objAmonestaionesBC = new AmonestacionBC();
            objAmonestaionesBC.insertar_Amonestacion(lista_amonestaciones);
        }

        private void inSalir(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
